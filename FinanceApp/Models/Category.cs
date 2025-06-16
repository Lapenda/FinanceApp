using FinanceApp.Encryption;
using System;
using System.Xml.Serialization;

namespace FinanceApp.Models
{
    public class Category
    {
        private string encryptedDescription;

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        [XmlElement("Description")]
        public string EncryptedDescription
        {
            get => encryptedDescription ?? Convert.ToBase64String(AesEncryptionHelper.EncryptString(string.Empty));
            set => encryptedDescription = value;
        }

        [XmlIgnore]
        public string Description
        {
            get => string.IsNullOrEmpty(EncryptedDescription) ? string.Empty : AesEncryptionHelper.DecryptString(Convert.FromBase64String(EncryptedDescription));
            set => EncryptedDescription = Convert.ToBase64String(AesEncryptionHelper.EncryptString(value ?? string.Empty));
        }

        public Category() { }

        public Category(int userId, string name, string description)
        {
            UserId = userId;
            Name = name;
            Description = description;
        }
    }
}
