using Microsoft.Extensions.DependencyInjection;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProgrammersBlogContext>();
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                //Kullanıcı şifre ayaları
                options.Password.RequireDigit = false; //şifrelerde rakam zorunlu mu
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0; //şifrelerde özel karakterlerin bulunma sayısı
                options.Password.RequireNonAlphanumeric = false; //özel karakterlerin zorunlu olup olmaması
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                //Kullanıcı adı ve mail ayarları
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; //kullanıcı adının içereceği karakterler.
                options.User.RequireUniqueEmail = true; //sistemde ilgili mail sadece 1 tane bulunur.
                
            }).AddEntityFrameworkStores<ProgrammersBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
        }
    }
}
