using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Content).IsRequired(true);
            builder.Property(x => x.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.SeoAuthor).IsRequired();
            builder.Property(x => x.SeoAuthor).HasMaxLength(50);
            builder.Property(x => x.SeoDescription).HasMaxLength(150);
            builder.Property(x => x.SeoDescription).IsRequired();
            builder.Property(x => x.SeoTags).IsRequired();
            builder.Property(x => x.SeoTags).HasMaxLength(70);
            builder.Property(x => x.ViewsCount).IsRequired();
            builder.Property(x => x.CommentCount).IsRequired();
            builder.Property(x => x.Thumbnail).IsRequired();
            builder.Property(x => x.Thumbnail).HasMaxLength(250);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.HasOne<Category>(x => x.Category).WithMany(y => y.Articles).HasForeignKey(z => z.CategoryId);
            builder.HasOne<User>(x => x.User).WithMany(y => y.Articles).HasForeignKey(z => z.UserId);
            builder.ToTable("Articles");
            //builder.HasData(
            //    new Article
            //    {
            //        Id = 1,
            //        CategoryId = 1,
            //        Title = "C# 9.0 ve .Net 5 Yenilikleri",
            //        Content = "Lorem Ipsum , baskı ve dizgi endüstrisinin basit bir sahte metnidir. Lorem Ipsum, bilinmeyen bir matbaacının bir tip numune kitabı yapmak için bir yazı galerisini alıp karıştırdığı 1500'lerden beri endüstrinin standart sahte metni olmuştur. Sadece beş yüzyıl boyunca hayatta kalmayıp, aynı zamanda esasen değişmeden elektronik dizgiye sıçradı. 1960'larda Lorem Ipsum pasajları içeren Letraset sayfalarının yayınlanmasıyla ve daha yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümlerini içeren masaüstü yayıncılık yazılımlarıyla popüler hale geldi.",
            //        Thumbnail = "Default.jpg",
            //        SeoDescription = "C# 9.0 ve .Net 5 Yenilikleri",
            //        SeoTags = "C#, C# 9, .Net5, .Net Framework, .Net Core",
            //        SeoAuthor = "Ali Yildiz",
            //        Date = DateTime.Now,
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "C# 9.0 ve .Net 5 Yenilikleri",
            //        UserId = 1,
            //        ViewsCount=100,
            //        CommentCount=1
            //    },
            //    new Article
            //    {
            //        Id = 2,
            //        CategoryId = 2,
            //        Title = "C++ 11.0 ve 19 Yenilikleri",
            //        Content = "Okuyucunun, sayfa düzenine bakarken sayfanın okunabilir içeriğinin dikkatini dağıtacağı uzun zamandır bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, 'İçerik burada, içerik burada' kullanılmasının aksine, harflerin az çok normal dağılımına sahip olması ve okunabilir İngilizce gibi görünmesini sağlamasıdır. Birçok masaüstü yayıncılık paketi ve web sayfası düzenleyicisi artık varsayılan model metni olarak Lorem Ipsum'u kullanıyor ve 'lorem ipsum' araması, henüz emekleme aşamasında olan birçok web sitesini ortaya çıkaracaktır. Yıllar içinde, bazen tesadüfen, bazen de bilerek (enjekte edilmiş mizah ve benzeri) çeşitli versiyonlar gelişti.",
            //        Thumbnail = "Default.jpg",
            //        SeoDescription = "C++ 11.0 ve 19 Yenilikleri",
            //        SeoTags = "C++ 11.0 ve 19 Yenilikleri",
            //        SeoAuthor = "Ali Yildiz",
            //        Date = DateTime.Now,
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "C++ 11.0 ve 19 Yenilikleri",
            //        UserId = 1,
            //        ViewsCount = 295,
            //        CommentCount = 1
            //    },
            //    new Article
            //    {
            //        Id = 3,
            //        CategoryId = 3,
            //        Title = "JavaScript ES2019 ve ES2020 Yenilikleri",
            //        Content = "Popüler inanışın aksine, Lorem Ipsum rastgele bir metin değildir. 45'ten kalma bir klasik Latin edebiyatı parçasında kökleri vardır ve 2000 yıldan daha eskidir. Virginia'daki Hampden-Sydney College'da Latince profesörü olan Richard McClintock, bir Lorem Ipsum pasajındaki daha anlaşılması güç Latince sözcüklerden biri olan consectetur'u aradı ve kelimenin klasik edebiyattaki örneklerini inceleyerek, şüphesiz kaynağı keşfetti. Lorem Ipsum, Cicero'nun MÖ 45 yılında yazdığı \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Noktaları) kitabının 1.10.32 ve 1.10.33 bölümlerinden gelmektedir. Bu kitap, Rönesans döneminde çok popüler olan etik teorisi üzerine bir incelemedir. Lorem Ipsum'un ilk satırı \"Lorem ipsum dolor sit amet..\", bölüm 1.10.32'deki bir satırdan gelmektedir.",
            //        Thumbnail = "Default.jpg",
            //        SeoDescription = "JavaScript ES2019 ve ES2020 Yenilikleri",
            //        SeoTags = "JavaScript ES2019 ve ES2020 Yenilikleri",
            //        SeoAuthor = "Ali Yildiz",
            //        Date = DateTime.Now,
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "JavaScript ES2019 ve ES2020 Yenilikleri",
            //        UserId = 1,
            //        ViewsCount = 12,
            //        CommentCount = 1
            //    }
            //);
        }
    }
}
