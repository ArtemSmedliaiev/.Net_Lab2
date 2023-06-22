using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MainModel
{
    public class Organization : IModelElement
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        public Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new();

            properties.Add("OrganizationID", OrganizationID.ToString());
            properties.Add("Name", Name);
            properties.Add("Adress", Adress);
            properties.Add("City", City);

            return properties;
        }

        public override string ToString()
        {
            return $"Назва: {Name} адреса: {Adress} місто: {City}";
        }
    }
}
