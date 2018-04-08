using System;
using System.Data.Entity;
using TestInfoTecs.Properties;

namespace TestInfoTecs.Models
{
    public class DbInitializerConstant : CreateDatabaseIfNotExists<RegistrationContext>
    {
        protected override void Seed(RegistrationContext db)
        {
            var citiesName = Resources.Cities.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in citiesName)
                db.Cities.Add(new City { Name = name });
            base.Seed(db);
        }
    }
    public class DbInitializerTesting : DropCreateDatabaseAlways<RegistrationContext>
    {
        protected override void Seed(RegistrationContext db)
        {
            var citiesName = Resources.Cities.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in citiesName)
                db.Cities.Add(new City { Name = name });

            db.Users.Add(new User { Name = "Александр", SecondName = "Петро", CitiesId = 1 });
            db.Users.Add(new User { Name = "Петр", SecondName = "Кукушкин", CitiesId = 2 });
            db.Users.Add(new User { Name = "Алена", SecondName = "Водолазова", CitiesId = 3 });
            db.Users.Add(new User { Name = "Фатима", SecondName = "Бах", CitiesId = 4 });
            db.Users.Add(new User { Name = "Анастасия", SecondName = "Зуркина", CitiesId = 5 });
            db.Users.Add(new User { Name = "Александр", SecondName = "Зуркина", CitiesId = 5 });
            db.Users.Add(new User { Name = "Петр", SecondName = "Бах", CitiesId = 4 });
            db.Users.Add(new User { Name = "Алена", SecondName = "Водолазова", CitiesId = 3 });
            db.Users.Add(new User { Name = "Фатима", SecondName = "Кукушкин", CitiesId = 2 });
            db.Users.Add(new User { Name = "Анастасия", SecondName = "Петро", CitiesId = 1 });

            base.Seed(db);
        }
    }
}