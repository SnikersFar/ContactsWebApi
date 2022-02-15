using ContactsWebAPI.EfStuff.DbModel;
using ContactsWebAPI.EfStuff.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace ContactsWebAPI.EfStuff
{
    public static class SeedExtention
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var authorRepository = scope.ServiceProvider.GetService<AuthorRepository>();
                var photoRepository = scope.ServiceProvider.GetService<PhotoRepository>();
                var textRepository = scope.ServiceProvider.GetService<TextRepository>();
                var authors = authorRepository.GetAll();
                if (!authors.Any())
                {
                    var user = new Author
                    {
                        Name = "Vova",
                        NickName = "Snikers",
                        Age = 21,
                        DateCreateAccount = System.DateTime.Now,
                        
                    };
                    user.Texts = new List<Text>();
                    user.Photos = new List<Photo>();

                    var text = new Text
                    {
                        Name = "MyText",
                        Content = "Every thing good",
                        Cost = 100,
                        Author = user,
                        CountOfBuying = 0,
                        DateCreate = System.DateTime.Now,
                        Size = 16,
                        Rating = 5
                    };

                    var photo = new Photo
                    {
                        Name = "myPhoto",
                        Author = user,
                        UrlContent = "https://www.ixbt.com/img/n1/news/2020/8/0/windowsxp_large.jpg",
                        Cost = 100,
                        CountOfBuying= 2000,
                        SizeOfPhoto = "800x401",
                        Rating = 5,
                    };
                    user.Texts.Add(text);
                    user.Photos.Add(photo);

                    authorRepository.Save(user);

                }

            }

            return host;
        }
    }
}
