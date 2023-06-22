using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MainModel
{
    public class Autor : IModelElement
    {
        public int AutorID { get; set; }
        public string AutorName { get; set; }
        public string AutorSurname { get; set; }
        public string AutorMiddleName { get; set; }
        public int OrganizationID { get; set; }

        public Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new();

            properties.Add("AutorID", AutorID.ToString());
            properties.Add("AutorName", AutorName);
            properties.Add("AutorSurname", AutorSurname);
            properties.Add("AutorMiddleName", AutorMiddleName);
            properties.Add("OrganizationID", OrganizationID.ToString());

            return properties;
        }

        public override string ToString()
        {
            return $"Aвтор: {AutorName} {AutorSurname}";
        }
    }
}
