using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MainModel
{
    public class Article : IModelElement
    {
        public string Name { get; set; } = string.Empty;
        public int ArticleId { get; set; }
        public int AutorID { get; set; }
        public int MagazineID { get; set; }
        public DateTime AddingDate { get; set; }

        public Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new();

            properties.Add("Name", Name);
            properties.Add("ArticleID", ArticleId.ToString());
            properties.Add("AutorID", AutorID.ToString());
            properties.Add("MagazineID", MagazineID.ToString());
            properties.Add("AddingDate", AddingDate.ToString());

            return properties;
        }

        public override string ToString()
        {
            return $"Назва статті: {Name} дата публікації: {AddingDate}";
        }
    }
}
