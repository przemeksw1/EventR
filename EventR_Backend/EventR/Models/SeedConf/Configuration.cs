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
            int level = 1;
            for (int i = 1; i < users; i++)
            {
                var user = new User
                {
                    UserId = i,
                    Nickname = "nick" + i,
                    FirstName = "Imie" + i,
                    LastName = "Nazwisko" + i,
                    Email = "Email" + i + "@gmail.com",
                    Password = "qwerty123",
                    AccessLevel = level,

                    //Avatar = "https://vignette.wikia.nocookie.net/james-camerons-avatar/images/d/d4/Neytiri_Profil.jpg/revision/latest/scale-to-width-down/1000?cb=20100226001342&path-prefix=pl"
                };
                
                level = 0;
                builder.Entity<User>().HasData(user);
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

                var nevent = new Event
                {
                    EventId = i,
                    AuthorId = random.Next(1, users),
                    Name = "Wydarzenie" + i,
                    Description = "To jest jakis tam opis" + i,
                    Date = DateTime.Now,
                    Category = category,
                    State = status,
                    Subject = thema
                };
                builder.Entity<Event>().HasData(nevent);
            }

            //
            //Dodawanie komentarzy
            //

            int coments = events + 2;
            for(int i=1; i<coments;i++)
            {
                var comment = new Comment
                {
                    CommentId = i,
                    AuthorId=random.Next(1,users),
                    EventId= random.Next(1, events),
                    Title = "tytyl"+i,
                    Content = "To jest komentarz="+i
                };
                builder.Entity<Comment>().HasData(comment);
            }


            //
            // Dodawanie pReferencjio
            //
            int prefs = 5;
            for(int i=1;i<prefs;i++)
            {
                var pref = new Preference
                {
                    PreferenceId = i,
                    UserId = i,
                    Type = "thema",
                    PreferenceContent = "Metal"
                };
                builder.Entity<Preference>().HasData(pref);
            }

            //
            // Dodanie grafiki
            //

            int images = 3;
            for(int i=1;i<images;i++)
            {
                var image = new Image
                {
                    ImageId = i,
                    AuthorId = i,
                    EventId = i,
                    ImageLink = "https://www.google.pl/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&ved=2ahUKEwjFmKWCvIThAhUrMuwKHd0mDmsQjRx6BAgBEAU&url=https%3A%2F%2Fwww.ahe.lodz.pl%2Fgrafika&psig=AOvVaw0FHDYm1d4noTaLO_6-U1k0&ust=1552750362497167"
                };
                builder.Entity<Image>().HasData(image);
            }


    
        }
    }
}
        
    

