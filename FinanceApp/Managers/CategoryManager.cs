using FinanceApp.Encryption;
using FinanceApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FinanceApp.Managers
{
    public class CategoryManager
    {
        private readonly string filePath;
        private static readonly object fileLock = new object();
        private readonly TransactionManager transactionManager;

        public CategoryManager(string fileName, TransactionManager transactionManager)
        {
            filePath = Path.Combine("C:\\Users\\Borna\\Desktop\\Borna\\Faks\\Napredne tehnike programiranja\\projekt\\FinanceApp\\Data\\" + fileName);

            if (!File.Exists(filePath))
            {
                SaveCategories(new List<Category>());
            }

            this.transactionManager = transactionManager ?? throw new ArgumentNullException(nameof(transactionManager));
        }

        private List<Category> ReadAllCategories()
        {
            lock (fileLock)
            {
                try
                {
                    if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
                    {
                        Console.WriteLine($"No file or file is empty in {filePath}");
                        return new List<Category>();
                    }

                    XmlSerializer serializer = new XmlSerializer(typeof(List<Category>), new XmlRootAttribute("Categories"));
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        return (List<Category>)serializer.Deserialize(sr);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from xml: {ex.Message}");
                    return new List<Category>();
                }
            }
        }

        public List<Category> ReadAllUserCategories(int? userId = null)
        {
            int id = userId ?? SessionManager.currentUserId;
            return ReadAllCategories().Where(c => c.UserId == id).ToList();
        }

        private void SaveCategories(List<Category> categories)
        {
            lock (fileLock)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Category>), new XmlRootAttribute("Categories"));
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        serializer.Serialize(sw, categories);
                    }
                    Console.WriteLine($"Categories saved to: {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing categories to xml: {ex.Message}");
                }
            }
        }

        public void CreateCategory(Category category)
        {
            var categories = ReadAllCategories();
            category.Id = categories.Any() ? categories.Max(c => c.Id) + 1 : 1;
            categories.Add(category);
            SaveCategories(categories);
            MessageBox.Show(Properties.Resources.Success);
        }

        public void UpdateCategory(Category updatedCategory, string newName, string newDesc)
        {
            var categories = ReadAllCategories();
            var existingCategory = categories.FirstOrDefault(c => c.Id == updatedCategory.Id);
            if(existingCategory != null) 
            {
                existingCategory.Name = newName;
                existingCategory.Description = newDesc;
                SaveCategories(categories);
                MessageBox.Show(Properties.Resources.Success);
            }
            else
            {
                throw new Exception($"Category with ID {updatedCategory.Id} not found");
            }
        }

        public void DeleteCategory(Category category)
        {
            var categories = ReadAllCategories();
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if(existingCategory != null)
            {
                categories.Remove(existingCategory);
                SaveCategories(categories);
                //MessageBox.Show(Properties.Resources.Success);

                transactionManager.DeleteTransactionsByCategory(existingCategory.Id);
            }
            else
            {
                throw new Exception($"Category with ID {category.Id} not found");
            }
        }

        public void DeleteAllUserCategories(int userId)
        {
            var categories = ReadAllCategories();
            if (categories.Count == 0)
            {
                return;
            }

            foreach (var category in categories)
            {
                if(category.UserId == userId)
                {
                    DeleteCategory(category);
                }
            }
        }
    }
}
