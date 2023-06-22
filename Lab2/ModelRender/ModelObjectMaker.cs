using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Lab2.MainModel;

namespace Lab2.ModelRender
{
    internal class ModelObjectMaker
    {
        public Article MakeArticle(XElement element)
        {
            return new Article()
            {
                Name = element.Element("Name").Value,
                ArticleId = Convert.ToInt32(element.Element("ArticleID").Value),
                AutorID = Convert.ToInt32(element.Element("AutorID").Value),
                MagazineID = Convert.ToInt32(element.Element("MagazineID").Value),
                AddingDate = Convert.ToDateTime(element.Element("AddingDate").Value)
            };
        }
        public Autor MakeAutor(XElement element)
        {
            return new Autor()
            {
                AutorID = Convert.ToInt32(element.Element("AutorID").Value),
                AutorName = Convert.ToString(element.Element("AutorName").Value),
                AutorSurname = Convert.ToString(element.Element("AutorSurname").Value),
                AutorMiddleName = Convert.ToString(element.Element("AutorMiddleName").Value),
                OrganizationID = Convert.ToInt32(element.Element("OrganizationID").Value)
            };
        }
        public Magazine MakeMagazine(XElement element)
        {
            return new Magazine()
            {
                MagazineID = Convert.ToInt32(element.Element("MagazineID").Value),
                Name = Convert.ToString(element.Element("Name").Value),
                Period = Convert.ToInt32(element.Element("Period").Value),
                Edition = Convert.ToInt32(element.Element("Edition").Value),
                ReleaseDate = Convert.ToDateTime(element.Element("ReleaseDate").Value)
            };
        }
        public Organization MakeOrganization(XElement element)
        {
            return new Organization()
            {
                OrganizationID = Convert.ToInt32(element.Element("OrganizationID").Value),
                Name = Convert.ToString(element.Element("Name").Value),
                Adress = Convert.ToString(element.Element("Adress").Value),
                City = Convert.ToString(element.Element("City").Value)
            };
        }
        public Article MakeArticle(XmlNode node)
        {
            return new Article()
            {
                Name = Convert.ToString((node["Name"].Value)),
                ArticleId = Convert.ToInt32((node["ArticleID"].Value)),
                AutorID = Convert.ToInt32((node["AutorID"].Value)),
                MagazineID = Convert.ToInt32((node["MagazineID"].Value)),
                AddingDate = Convert.ToDateTime((node["AddingDate"].Value))
            };
        }
        public Autor MakeAutor(XmlNode node)
        {
            return new Autor()
            {
                AutorID = Convert.ToInt32((node["AutorID"].Value)),
                AutorName = Convert.ToString((node["AutorName"].Value)),
                AutorSurname = Convert.ToString((node["AutorSurname"].Value)),
                AutorMiddleName = Convert.ToString((node["AutorMiddleName"].Value)),
                OrganizationID = Convert.ToInt32((node["OrganizationID"].Value))
            };
        }
        public Magazine MakeMagazine(XmlNode node)
        {
            return new Magazine()
            {
                MagazineID = Convert.ToInt32((node["MagazineID"].Value)),
                Name = Convert.ToString((node["Name"].Value)),
                Period = Convert.ToInt32((node["Period"].Value)),
                Edition = Convert.ToInt32((node["Edition"].Value)),
                ReleaseDate = Convert.ToDateTime((node["ReleaseDate"].Value))
            };
        }
        public Organization MakeOrganization(XmlNode node)
        {
            return new Organization()
            {
                OrganizationID = Convert.ToInt32((node["OrganizationID"].Value)),
                Name = Convert.ToString((node["Name"].Value)),
                Adress = Convert.ToString((node["Adress"].Value)),
                City = Convert.ToString((node["City"].Value))
            };
        }
        public Article MakeArticle(ProperValueEnter vEnter)
        {
            return new Article
            {
                Name = vEnter.StringValueEnter("Введіть Name: "),
                ArticleId = vEnter.IntValueEnter("Введіть Article ID: "),
                AutorID = vEnter.IntValueEnter("Введіть Autor ID: "),
                MagazineID = vEnter.IntValueEnter("Введіть Magazine ID: "),
                AddingDate = vEnter.TimeValueEnter("Введіть Adding Date: ")
            };
        }
        public Autor MakeAutor(ProperValueEnter vEnter)
        {
            return new Autor
            {
                AutorID = vEnter.IntValueEnter("Введіть AutorID: "),
                AutorName = vEnter.StringValueEnter("Введіть Autor Name: "),
                AutorSurname = vEnter.StringValueEnter("Введіть Autor Surname: "),
                AutorMiddleName = vEnter.StringValueEnter("Введіть Autor Middle Name: "),
                OrganizationID = vEnter.IntValueEnter("Введіть Organization ID: ")
            };
        }
        public Magazine MakeMagazine(ProperValueEnter vEnter)
        {
            return new Magazine
            {
                MagazineID = vEnter.IntValueEnter("Введіть Magazine ID: "),
                Name = vEnter.StringValueEnter("Введіть Name: "),
                Period = vEnter.IntValueEnter("Введіть Period: "),
                Edition = vEnter.IntValueEnter("Введіть Edition: "),
                ReleaseDate = vEnter.TimeValueEnter("Введіть Release Date: ")
            };
        }
        public Organization MakeOrganization(ProperValueEnter vEnter)
        {
            return new Organization
            {
                OrganizationID = vEnter.IntValueEnter("Введіть Organization ID: "),
                Name = vEnter.StringValueEnter("Введіть Name: "),
                Adress = vEnter.StringValueEnter("Введіть Adress: "),
                City = vEnter.StringValueEnter("Введіть City: "),
            };
        }
    }
}
