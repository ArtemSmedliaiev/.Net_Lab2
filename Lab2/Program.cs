using Lab2.ModelRender;
using Lab2.PresentationLayer;
using Lab2.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.MainModel;

namespace Lab2
{
    internal class Program
    {
        static void Pause()
        {
            Console.WriteLine("\nДля продовження натисніть будь-яку клавішу");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            ModelObjectMaker maker = new();
            ProperValueEnter valueEnter = new();
            string ArticleFilePath = "C:\\Users\\user\\source\\repos\\Lab2\\Lab2\\XmlDocuments\\Articles.xml";
            string AutorFilePath = "C:\\Users\\user\\source\\repos\\Lab2\\Lab2\\XmlDocuments\\Autors.xml";
            string MagazineFilePath = "C:\\Users\\user\\source\\repos\\Lab2\\Lab2\\XmlDocuments\\Magazines.xml";
            string OrganizationFilePath = "C:\\Users\\user\\source\\repos\\Lab2\\Lab2\\XmlDocuments\\Organizations.xml";

            // First part
            List<Article> articles = new();
            List<Autor> autors = new();
            List<Magazine> magazines = new();
            List<Organization> organizations = new();

            Menu firstMenu = new();
            MenuItemSelector fistMenuSelector = new(1, 6);
            firstMenu.Items = new()
            {
                new MenuItem("1. Додати нову статтю",
                    () => articles.Add(maker.MakeArticle(valueEnter))),

                new MenuItem("2. Додати нового автора",
                    () => autors.Add(maker.MakeAutor(valueEnter))),

                new MenuItem("3. Додати новий журнал",
                    () => magazines.Add(maker.MakeMagazine(valueEnter))),

                new MenuItem("4. Додати нову організацію",
                    () => organizations.Add(maker.MakeOrganization(valueEnter))),

                new MenuItem("5. Додати заготовлені списки", () =>
                    {
                        DataList data = new();
                        articles = data.Articles;
                        autors = data.Autors;
                        magazines = data.Magazines;
                        organizations = data.Organizations;
                    }),

                new MenuItem("6. Зберігти",
                    () => firstMenu.IsExitWanted = true)
            };

            while (!firstMenu.IsExitWanted)
            {
                firstMenu.PrintMenu("Меню заповнення документів");
                firstMenu.ExecuteSelectedItem(fistMenuSelector.SelectItem());
                Pause();
            }

            // Second Part
            Writer writer = new();
            writer.AddGroupOfElements(ArticleFilePath, "Articles", articles);
            writer.AddGroupOfElements(AutorFilePath, "Autors", autors);
            writer.AddGroupOfElements(MagazineFilePath, "Magazines", magazines);
            writer.AddGroupOfElements(OrganizationFilePath,"Organizations", organizations);

            ConsoleQueriesPrinter printer = new();
            Reader reader = new();

            // Third part 
            Menu secondMenu = new();
            MenuItemSelector secondMenuSelector = new(1, 15);
            secondMenu.Items = new()
            {
                new MenuItem("1. Вивести всі статті",
                () => printer.Print("всі статті", reader.GetAllArticles(ArticleFilePath))),

                new MenuItem("2. Вивести статті назви яких мають принаймні два слова",
                () => printer.Print("статті з двома та більше словами в імені", reader.GetArticlesWithMoreThanOneWordName(ArticleFilePath))),

                new MenuItem("3. Вивести журнали наступний випуск яких буде цього року",
                () => printer.Print("журнали наступний випуск яких буде цього року", reader.GetMagazinesNextPublishingThisYear(MagazineFilePath))),

                new MenuItem("4. Вивести організації згруповані по містам",  
                () => printer.Print("організації згруповані по містам", reader.GetOrganizationsGroupedByCity(OrganizationFilePath))),

                new MenuItem("5. Вивести статті по порядку зростання назви",
                () => printer.Print("статті по порядку зростання назви", reader.GetArticlesOrderedByNameLength(ArticleFilePath))),

                new MenuItem("6. Вивести статті опубліковані після 2020 року",
                () => printer.Print("статті опубліковані після 2020 року", reader.GetArticlesOrderedByDateAfter2020(ArticleFilePath))),

                new MenuItem("7. Вивести статті її автора та журнал", 
                () => printer.Print("статті її автора та журнал", reader.GetArticleMagazineAndAutor(ArticleFilePath, MagazineFilePath, AutorFilePath))),

                new MenuItem("8. Вивести статті та їхніх авторів", 
                () => printer.Print("статті та їхніх авторів", reader.GetAllArticlesAndTheirAutors(ArticleFilePath, AutorFilePath))),

                new MenuItem("9. Вивести статті згруповані за журналами в яких вони опубліковані",
                () => printer.Print("статті згруповані за журналами в яких вони опубліковані", reader.GetArticlesGroupedByMagazines(MagazineFilePath, ArticleFilePath))),

                new MenuItem("10. Вивести статті з найбільшим накладом",
                () => printer.Print("статті з найбільшим накладом", reader.GetArticlesWithBiggestEdition(ArticleFilePath, MagazineFilePath))),

                new MenuItem("11. Вивести організації за зростанням кількості учасників",
                () => printer.Print("організації за зростанням кількості учасників", reader.GetOrganizationOrderedByParticipantCount(OrganizationFilePath, AutorFilePath))),

                new MenuItem("12. Вивести статті згруповані по організаціям",
                () => printer.Print("статті згруповані по організаціям", reader.GetArticlesGroupedByOrganization(OrganizationFilePath, ArticleFilePath, AutorFilePath))),

                new MenuItem("13. Вивести авторів та кількість журналів надрукованих з їхніми статтями", 
                () => printer.Print("авторів та кількість журналів надрукованих з їхніми статтями", reader.GetCountOfReleasedArticlesOfAutors(AutorFilePath, ArticleFilePath, MagazineFilePath))),

                new MenuItem("14. Вивести організації у визначоеному місті",
                () => printer.Print("організації у визначоеному місті", reader.GetOrganizationsByTheCity(OrganizationFilePath, secondMenuSelector.GetCity()))),

                new MenuItem("15. Вивести журнали з накладом у визначеному діапазоні",
                () => printer.Print("журнали з накладом у визначеному діапазоні", reader.GetMagazinesWithEditionInRange(MagazineFilePath, secondMenuSelector.GetMin(), secondMenuSelector.GetMax()))),

                new MenuItem("16. Вихід", () => secondMenu.IsExitWanted = true)
            };

            while (!secondMenu.IsExitWanted)
            {
                secondMenu.PrintMenu("Головне меню програми");
                secondMenu.ExecuteSelectedItem(secondMenuSelector.SelectItem());
                Pause();
            }
        }
    }
}
