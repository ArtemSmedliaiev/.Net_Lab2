using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Lab2.ModelRender;
using Lab2.MainModel;

namespace Lab2.XML
{
    public class Reader
    {
        private ModelObjectMaker _maker = new();

        private XmlElement? GetFileRootAsXmlElement(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(fileName);
            XmlElement root = xDoc.DocumentElement;

            return root;
        }

        private XElement? GetFileRootAsXElement(string fileName)
        {
            if (!File.Exists(fileName))
                return null;
            var result = XDocument.Load(fileName).Root;
            return result;
        }
        //1
        public IEnumerable<Article> GetAllArticles(string fileName)
        {
            return GetFileRootAsXElement(fileName)
                .Elements("Article")
                .Select(article => _maker.MakeArticle(article));
        }
        //2
        public IEnumerable<Article> GetArticlesWithMoreThanOneWordName(string fileName)
        {
            return GetFileRootAsXElement(fileName)
                .Elements("Article")
                .Where(article => article.Element("Name").Value.Contains(' '))
                .Select(article => _maker.MakeArticle(article));
        }
        //3
        public IEnumerable<Magazine> GetMagazinesNextPublishingThisYear(string fileName)
        {
            return GetFileRootAsXElement(fileName)
                .Elements("Magazine")
                .Where(magazine => magazine.Element("ReleaseDate").Value.Contains("2023"))
                .Select(magazine => _maker.MakeMagazine(magazine));
        }
        //4
        public Dictionary<string, List<Organization>> GetOrganizationsGroupedByCity(string fileName)
        {
            return (from organization in
                    GetFileRootAsXElement(fileName)
                    .Elements("Organization")
                    group organization by organization.Element("City").Value into organizationGroup
                    select new
                    {
                        key = organizationGroup.Key,
                        Value = from groupElement in organizationGroup
                                select _maker.MakeOrganization(groupElement)
                    })
                .ToDictionary(organization => organization.key, organization => organization.Value.ToList());
        }
        //5
        public IEnumerable<Article> GetArticlesOrderedByNameLength(string fileName)
        {
            return from article in GetFileRootAsXElement(fileName)
                   .Elements("Article")
                   orderby article.Element("Name").Value.Length
                   select _maker.MakeArticle(article);
        }
        //6
        public IEnumerable<Article> GetArticlesOrderedByDateAfter2020(string fileName)
        {
            return GetFileRootAsXElement(fileName)
                .Elements("Articles")
                .Select(articles => _maker.MakeArticle(articles))
                .Where(articles => articles.AddingDate.Year > 2020)
                .OrderBy(articles => articles.AddingDate);
        }
        //7
        public IEnumerable<string> GetArticleMagazineAndAutor(string ArticleFileName, 
                                                              string MagazineFileName, 
                                                              string AutorFileName)
        {
            var query = from article in GetFileRootAsXElement(ArticleFileName).Elements("Article").Select(article => _maker.MakeArticle(article))
                        join magazine in GetFileRootAsXElement(MagazineFileName).Elements("Magazine").Select(magazine => _maker.MakeMagazine(magazine))
                        on article.MagazineID equals magazine.MagazineID
                        join autor in GetFileRootAsXElement(AutorFileName).Elements("Autor").Select(autor => _maker.MakeAutor(autor))
                        on article.AutorID equals autor.AutorID
                        select new
                        {
                            ArticleName = article.Name,
                            MagazineName = magazine.Name,
                            AutorName = autor.AutorName,
                            AutorSurname = autor.AutorSurname
                        };

            var result = new List<string>();
            foreach (var obj in query)
            {
                result.Add($"Назва статті: {obj.ArticleName}\tжурнал у якому ця стаття: {obj.MagazineName}\t\tїї автор: {obj.AutorName} {obj.AutorSurname}");
            }
            return result;
        }
        //8
        public IEnumerable<string> GetAllArticlesAndTheirAutors(string ArticleFileName,
                                                                string AutorFileName)
        {
            var result = new List<string>();

            var query = from article in GetFileRootAsXElement(ArticleFileName).Elements("Article").Select(article => _maker.MakeArticle(article))
                        join autor in GetFileRootAsXElement(AutorFileName).Elements("Autor").Select(autor => _maker.MakeAutor(autor))
                        on article.AutorID equals autor.AutorID
                        orderby article.ArticleId descending
                        select new
                        {
                            ArticleName = article.Name,
                            AutorName = autor.AutorName,
                            AutorSurname = autor.AutorSurname,
                            AutorMiddleName = autor.AutorMiddleName
                        };

            foreach (var obj in query)
            {
                result.Add($"Стаття: {obj.ArticleName}\tАвтор: {obj.AutorName} {obj.AutorSurname} {obj.AutorMiddleName}");
            }

            return result;
        }
        //9
        public Dictionary<string, List<string>> GetArticlesGroupedByMagazines(string MagazineFileName, 
                                                                              string ArticleFileName)
        {
            return GetFileRootAsXElement(MagazineFileName)
                .Elements("Magazine")
                .Select(magazine => _maker.MakeMagazine(magazine))
                .GroupJoin(GetFileRootAsXElement(ArticleFileName)
                            .Elements("Article")
                            .Select(article => _maker.MakeArticle(article)),
                                            magazines => magazines.MagazineID,
                                            articles => articles.MagazineID,
                                            (magazines, articles) => new
                                            {
                                                MagazineName = magazines.Name,
                                                ArticleName = articles.Select(articles => articles.Name)
                                            })
                            .ToDictionary(magazines => magazines.MagazineName, articles => articles.ArticleName.ToList());
        }
        //10
        public IEnumerable<Article> GetArticlesWithBiggestEdition(string ArticleFileName, string MagazineFileName)
        {
            var magazines = GetFileRootAsXElement(MagazineFileName)
                            .Elements("Magazine");
            var MaxEdition = magazines.Max(magazines => Convert.ToInt32(magazines.Element("Edition").Value));
            var MaxEditionMagazines = magazines.Where(magazine => Convert.ToInt32(magazine.Element("Edition").Value) 
                                                      == magazines.Max(magazines => Convert.ToInt32(magazines.Element("Edition").Value)));
            var MaxEditionMagazinesID = MaxEditionMagazines.Elements("MagazineID")
                                                           .Select(magazineID => Convert.ToInt32(magazineID.Value));
            return MaxEditionMagazinesID.Join(GetFileRootAsXElement(ArticleFileName)
                                              .Elements("Article")
                                              .Select(article => _maker.MakeArticle(article)),
                                              MEMag => MEMag,
                                              art => art.MagazineID,
                                              (MEMag, art) => art);
        }
        //11
        public IEnumerable<Organization> GetOrganizationOrderedByParticipantCount(string OrganizationFileName,
                                                                                  string AutorFileName)
        {
            var OrganizationsID = GetFileRootAsXElement(AutorFileName)
                                  .Elements("Autor")
                                  .Join(GetFileRootAsXElement(OrganizationFileName)
                                        .Elements("Organization"),
                                              autors => Convert.ToInt32(autors.Element("OrganizationID").Value),
                                              org => Convert.ToInt32(org.Element("OrganizationID").Value),
                                              (autors, org) => Convert.ToInt32(org.Element("OrganizationID").Value));
            var groupedID = OrganizationsID.GroupBy(orgID => orgID)
                                           .OrderBy(group => group.Count())
                                           .Select(group => group.Key);
            return groupedID.Join(GetFileRootAsXElement(OrganizationFileName)
                                  .Elements("Organization")
                                  .ToList(),
                                  groupedID => groupedID,
                                  organizations => Convert.ToInt32(organizations.Element("OrganizationID").Value),
                                  (groupedID, organizations) => organizations)
                                  .Select(organization => _maker.MakeOrganization(organization));
        }
        //12
        public Dictionary<string, List<string>> GetArticlesGroupedByOrganization(string OrganizationFileName,
                                                                                 string ArticleFileName,
                                                                                 string AutorFileName)
        {
            var articleAutors = GetFileRootAsXElement(ArticleFileName)
                                  .Elements("Article")
                                  .Join(GetFileRootAsXElement(AutorFileName)
                                        .Elements("Autor"),
                                              article => Convert.ToInt32(article.Element("AutorID").Value),
                                              autor => Convert.ToInt32(autor.Element("AutorID").Value),
                                              (article, autor) => new
                                              {
                                                  ArticleName = article.Element("Name").Value,
                                                  AutorID = Convert.ToInt32(autor.Element("AutorID").Value),
                                                  OrganizationID = Convert.ToInt32(autor.Element("OrganizationID").Value)
                                              });
            var articleOrganizations = GetFileRootAsXElement(OrganizationFileName)
                                  .Elements("Organization").Select(org => _maker.MakeOrganization(org))
                                  .Join(articleAutors,
                                        org => org.OrganizationID,
                                        artAut => artAut.OrganizationID,
                                        (org, artAut) => new
                                        {
                                            ArticleName = artAut.ArticleName,
                                            OrganizationName = org.Name
                                        });
            var groupedArtOrg = from articleOrganization in articleOrganizations
                                group articleOrganization by articleOrganization.OrganizationName into groupedArt
                                select new
                                {
                                    Key = groupedArt.Key,
                                    Values = groupedArt.Select(groupedArt => groupedArt.ArticleName)
                                };
            return groupedArtOrg.ToDictionary(groupedArtOrg => groupedArtOrg.Key, groupedArtOrg => groupedArtOrg.Values.ToList());
        }
        //13
        public IEnumerable<string> GetCountOfReleasedArticlesOfAutors(string AutorFileName,
                                                                      string ArticleFileName,
                                                                      string MagazineFileName)
        {
            var autorEditions = GetFileRootAsXElement(ArticleFileName)
                                  .Elements("Article")
                                  .Join(GetFileRootAsXElement(MagazineFileName)
                                        .Elements("Magazine"),
                                              article => Convert.ToInt32(article.Element("MagazineID").Value),
                                              mag => Convert.ToInt32(mag.Element("MagazineID").Value),
                                              (article, mag) => new
                                              {
                                                  AutorID = Convert.ToInt32(article.Element("AutorID").Value),
                                                  Edition = Convert.ToInt32(mag.Element("Edition").Value)
                                              });
            var groupAutors = from autorEdition in autorEditions
                              group autorEdition by autorEdition.AutorID into editionAutor
                              select new
                              {
                                  Key = editionAutor.Key,
                                  Value = editionAutor.Sum(editionAutor => editionAutor.Edition)
                              };
            var query = groupAutors
                        .Join(GetFileRootAsXElement(AutorFileName)
                              .Elements("Autor"),
                                    groupAutors => groupAutors.Key,
                                    autors => Convert.ToInt32(autors.Element("AutorID").Value),
                                    (group, autors) => new
                                    {
                                        Value = group.Value,
                                        Name = autors.Element("AutorName").Value,
                                        Surname = autors.Element("AutorSurname").Value
                                    });
            var result = new List<string>();
            foreach (var autor in query)
            {
                result.Add($"Автор: {autor.Name} {autor.Surname} кількість журналів з статтями автора: {autor.Value}");
            }
            return result;
        }
        //14
        public IEnumerable<Organization> GetOrganizationsByTheCity(string OrganizationFileName,
                                                                   string City)
        {
            return GetFileRootAsXElement(OrganizationFileName)
                   .Elements("Organization")
                   .Where(org => org.Element("City").Value == City)
                   .Select(org => _maker.MakeOrganization(org));
        }
        //15
        public IEnumerable<Magazine> GetMagazinesWithEditionInRange(string MagazineFileName,
                                                                    int Min,
                                                                    int Max)
        {
            return GetFileRootAsXElement(MagazineFileName) 
                   .Elements("Magazine")
                   .Where(mag => (Convert.ToInt32(mag.Element("Edition").Value)) >= Min)
                   .Where(mag => (Convert.ToInt32(mag.Element("Edition").Value)) <= Max)
                   .Select(mag => _maker.MakeMagazine(mag));
        }

    }
}
