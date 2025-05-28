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
    internal class CategoryManager
    {
        private readonly string filePath;
        private static readonly object fileLock = new object();

        public CategoryManager(string fileName)
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data/" + fileName);

            if (!File.Exists(filePath))
            {
                SaveCategories(new List<Category>());
            }
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

        public List<Category> ReadAllUserCategories()
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
                        var allCategories = (List<Category>)serializer.Deserialize(sr);
                        return allCategories.Where(c => c.UserId == SessionManager.currentUserId).ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from xml: {ex.Message}");
                    return new List<Category>();
                }
            }
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
            MessageBox.Show("Succes");
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
                MessageBox.Show("Succes");
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
                MessageBox.Show("Succes");
            }
            else
            {
                throw new Exception($"Category with ID {category.Id} not found");
            }
        }
    }
}
