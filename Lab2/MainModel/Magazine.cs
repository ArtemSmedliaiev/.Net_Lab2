using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MainModel
{
    public class Magazine : IModelElement
    {
        public int MagazineID { get; set; }
        public string Name { get; set; }
        public int Period { get; set; }
        public int Edition { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new();

            properties.Add("MagazineID", MagazineID.ToString());
            properties.Add("Name", Name);
            properties.Add("Period", Period.ToString());
            properties.Add("Edition", Edition.ToString());
            properties.Add("ReleaseDate", ReleaseDate.ToString());

            return properties;
        }


        public override string ToString()
        {
            return $"Журнал: {Name} наступна публікація: {ReleaseDate}";
        }
    }
}
