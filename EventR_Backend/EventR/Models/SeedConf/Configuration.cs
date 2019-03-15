using System;
using EventRApi.Models;
using Microsoft.EntityFrameworkCore;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace EventRApi.Models.SeedConf
{

    public static class Configuration
    {
        //  <param name = "builder" ></ param >
        public static void Seed(this ModelBuilder builder)
        {
            Random random = new Random();
            //
            // Dodawanie uzytkownikow do bazy
            //
            int users = 6;
            for (int i = 1; i < users; i++)
            {
                var user = new Uzytkownicy
                {
                    Id_Uytkownika = i,
                    Nick = "nick" + i,
                    Imie = "Imie" + i,
                    Nazwisko = "Nazwisko" + i,
                    Email = "Email" + i + "@gmail.com",
                    NumerTel = 514111231,
                    Status = 'a',
                    Poziom_Konta = i,
                    Avatar = "https://vignette.wikia.nocookie.net/james-camerons-avatar/images/d/d4/Neytiri_Profil.jpg/revision/latest/scale-to-width-down/1000?cb=20100226001342&path-prefix=pl"
                };
                builder.Entity<Uzytkownicy>().HasData(user);
            }

            //
            //Dodawanie wydarzej do bazy
            //
            int events = 11;
            string category, thema;
            char status;
            for (int i = 1; i < events; i++)
            {
                if (i % 2 == 1)
                    category = "Koncert";
                else
                    category = "Przedstawienie";

                if (random.Next(0, 1) == 0)
                    status = 'T';
                else
                    status = 'F';
                if (random.Next(0, 3) == 0)
                    thema = "Lata 20";
                else if (random.Next(0, 3) == 1)
                    thema = "Metal";
                else
                    thema = "Poezja";

                var nevent = new Wydarzenia
                {
                    Id_Wydarzenia = i,
                    Id_Autora = random.Next(1, users),
                    Nazwa = "Wydarzenie" + i,
                    Opis = "To jest jakis tam opis" + i,
                    Data = DateTime.Now,
                    Kategoria = category,
                    Status = status,
                    Tematyka = thema
                };
                builder.Entity<Wydarzenia>().HasData(nevent);
            }

            //
            //Dodawanie komentarzy
            //

            int coments = events + 2;
            for(int i=1; i<coments;i++)
            {
                var comment = new Komentarze
                {
                    Id_Komentarza = i,
                    Id_Autora=random.Next(1,users),
                    Id_Wydarzenia= random.Next(1, events),
                    Tytul = "tytyl"+i,
                    Tresc = "To jest komentarz="+i
                };
                builder.Entity<Komentarze>().HasData(comment);
            }


            //
            // Dodawanie pReferencjio
            //
            int prefs = 5;
            for(int i=1;i<prefs;i++)
            {
                var pref = new Preferencje
                {
                    Id_Preferencji = i,
                    Id_Uzytkownika = i,
                    Typ = "thema",
                    Preferencja = "Metal"
                };
                builder.Entity<Preferencje>().HasData(pref);
            }

            //
            // Dodanie grafiki
            //

            int images = 3;
            for(int i=1;i<images;i++)
            {
                var image = new Grafiki
                {
                    Id_Grafiki = i,
                    Id_Autora = i,
                    Id_Wydarzenia = i,
                    Grafika = "https://www.google.pl/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&ved=2ahUKEwjFmKWCvIThAhUrMuwKHd0mDmsQjRx6BAgBEAU&url=https%3A%2F%2Fwww.ahe.lodz.pl%2Fgrafika&psig=AOvVaw0FHDYm1d4noTaLO_6-U1k0&ust=1552750362497167"
                };
                builder.Entity<Grafiki>().HasData(image);
            }


    
        }
    }
}
        
    

