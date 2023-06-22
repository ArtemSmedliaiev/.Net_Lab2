using Lab2.MainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ModelRender
{
    public class DataList
    {
        public List<Article> Articles { get;  } = new ()
        {
            new()
            {
                Name = "Old beauty",
                ArticleId = 1,
                AutorID = 2,
                MagazineID = 1,
                AddingDate = new DateTime(2019, 2, 12),
                
            },
            new()
            {
                Name = "Sense of money",
                ArticleId = 2,
                AutorID = 3,
                MagazineID = 2,
                AddingDate = new DateTime(2023, 11, 1),
            },
            new()
            {
                Name = "Son of the king",
                ArticleId = 3,
                AutorID = 1,
                MagazineID = 3,
                AddingDate = new DateTime(2022, 5, 25),
            },
            new()
            {
                Name = "Next in fashion",
                ArticleId = 4,
                AutorID = 4,
                MagazineID = 7,
                AddingDate = new DateTime(2014, 7, 18),
            },
            new()
            {
                Name = "Suit essentials",
                ArticleId = 5,
                AutorID = 5,
                MagazineID = 5,
                AddingDate = new DateTime(2018, 3, 9),
            },
            new()
            {
                Name = "Richiest people",
                ArticleId = 6,
                AutorID = 6,
                MagazineID = 4,
                AddingDate = new DateTime(2021, 4, 14),
            },
            new()
            {
                Name = "Jeans importance",
                ArticleId = 7,
                AutorID = 5,
                MagazineID = 6,
                AddingDate = new DateTime(2023, 8, 12),
            }

        };
        public List<Magazine> Magazines { get; set; } = new List<Magazine>()
        {
            new()
            {
                MagazineID = 1,
                Name = "Vogue",
                Period = 7,
                Edition = 500,
                ReleaseDate = new DateTime(2023, 9, 23),
            },
            new()
            {
                MagazineID = 2,
                Name = "International",
                Period = 30,
                Edition = 10000,
                ReleaseDate = new DateTime(2021, 9, 16),
            },
            new()
            {
                MagazineID = 3,
                Name = "Times",
                Period = 7,
                Edition = 1000,
                ReleaseDate = new DateTime(2022, 11, 2),
            },
            new()
            {
                MagazineID = 4,
                Name = "Forbes",
                Period = 14,
                Edition = 1000,
                ReleaseDate = new DateTime(2022, 1, 26),
            },
            new()
            {
                MagazineID = 5,
                Name = "Cosmopolitan",
                Period = 7,
                Edition = 1000,
                ReleaseDate = new DateTime(2023, 10, 19),
            },
            new()
            {
                MagazineID = 6,
                Name = "Elle",
                Period = 30,
                Edition = 10000,
                ReleaseDate = new DateTime(2019, 4, 29),
            },
            new()
            {
                MagazineID = 7,
                Name = "Bazaar",
                Period = 7,
                Edition = 100,
                ReleaseDate = new DateTime(2024, 3, 8),
            }

        };
        public List<Autor> Autors { get; set; } = new List<Autor>()
        {
            new()
            {
                AutorID = 1,
                AutorName = "Василь",
                AutorSurname = "Василенко",
                AutorMiddleName = "Василійович",
                OrganizationID = 1,
            },
            new()
            {
                AutorID = 2,
                AutorName = "Тарас",
                AutorSurname = "Тарасенко",
                AutorMiddleName = "Тарасович",
                OrganizationID = 2,
            },
            new()
            {
                AutorID = 3,
                AutorName = "Ганна",
                AutorSurname = "Іваненко",
                AutorMiddleName = "Данилівна",
                OrganizationID = 3,
            },
            new()
            {
                AutorID = 4,
                AutorName = "Петро",
                AutorSurname = "Петренко",
                AutorMiddleName = "Петрович",
                OrganizationID = 1,
            },
            new()
            {
                AutorID = 5,
                AutorName = "Оксана",
                AutorSurname = "Шевченко",
                AutorMiddleName = "Володимирівна",
                OrganizationID = 4,
            },
            new()
            {
                AutorID = 6,
                AutorName = "Вікторія",
                AutorSurname = "Стельмах",
                AutorMiddleName = "Вікторівна",
                OrganizationID = 5,
            },
            new()
            {
                AutorID = 7,
                AutorName = "Юлія",
                AutorSurname = "Шевченко",
                AutorMiddleName = "Ярославівна",
                OrganizationID = 5,
            }

        };
        public List<Organization> Organizations { get; set; } = new List<Organization>()
        {
            new()
            {   
                OrganizationID = 1,
                Name = "Global Autors Organization",
                Adress = "20 Great Queen St",
                City = "London",  
            },
            new()
            {
                OrganizationID = 2,
                Name = "Autor Group",
                Adress = "95 New Cavendish St",
                City = "London",
            },
            new()
            {
                OrganizationID = 3,
                Name = "New York Autors Organization",
                Adress = "1201 Broadway",
                City = "New York",
            },
            new()
            {
                OrganizationID = 4,
                Name = "World Autors",
                Adress = "580 5th Ave Suite 1721",
                City = "New York",
            },
            new()
            {
                OrganizationID = 5,
                Name = "Товариство київських журналістів",
                Adress = "вул. Хрещатик 18",
                City = "Київ",
            }
        };
    }
}
