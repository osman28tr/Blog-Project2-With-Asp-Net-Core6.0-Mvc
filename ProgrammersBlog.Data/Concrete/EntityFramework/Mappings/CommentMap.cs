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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(1000);
            builder.HasOne<Article>(x => x.Article).WithMany(y => y.Comments).HasForeignKey(z => z.ArticleId);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.ToTable("Comments");
            //builder.HasData(
            //    new Comment
            //    {
            //        Id = 1,
            //        ArticleId = 1,
            //        Text = "Lorem Ipsum'un birçok pasaj varyasyonu mevcuttur, ancak çoğunluğu, enjekte edilen mizah veya biraz inandırıcı görünmeyen rastgele kelimelerle bir şekilde değişikliğe uğramıştır. Lorem Ipsum'dan bir pasaj kullanacaksanız, metnin ortasında utanç verici bir şey olmadığından emin olmalısınız. İnternetteki tüm Lorem Ipsum oluşturucular, önceden tanımlanmış parçaları gerektiği gibi tekrarlama eğilimindedir ve bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum'u oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince sözcükten oluşan bir sözlük kullanır. Üretilen Lorem Ipsum bu nedenle her zaman tekrardan, enjekte edilen mizahtan veya karakteristik olmayan kelimelerden vb.",
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "C# Makale Yorumu",
            //    },
            //    new Comment
            //    {
            //        Id = 2,
            //        ArticleId = 2,
            //        Text = "Lorem Ipsum'un birçok pasaj varyasyonu mevcuttur, ancak çoğunluğu, enjekte edilen mizah veya biraz inandırıcı görünmeyen rastgele kelimelerle bir şekilde değişikliğe uğramıştır. Lorem Ipsum'dan bir pasaj kullanacaksanız, metnin ortasında utanç verici bir şey olmadığından emin olmalısınız. İnternetteki tüm Lorem Ipsum oluşturucular, önceden tanımlanmış parçaları gerektiği gibi tekrarlama eğilimindedir ve bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum'u oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince sözcükten oluşan bir sözlük kullanır. Üretilen Lorem Ipsum bu nedenle her zaman tekrardan, enjekte edilen mizahtan veya karakteristik olmayan kelimelerden vb.",
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "C++ Makale Yorumu"
            //    },
            //    new Comment
            //    {
            //        Id = 3,
            //        ArticleId = 3,
            //        Text = "Lorem Ipsum'un birçok pasaj varyasyonu mevcuttur, ancak çoğunluğu, enjekte edilen mizah veya biraz inandırıcı görünmeyen rastgele kelimelerle bir şekilde değişikliğe uğramıştır. Lorem Ipsum'dan bir pasaj kullanacaksanız, metnin ortasında utanç verici bir şey olmadığından emin olmalısınız. İnternetteki tüm Lorem Ipsum oluşturucular, önceden tanımlanmış parçaları gerektiği gibi tekrarlama eğilimindedir ve bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum'u oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince sözcükten oluşan bir sözlük kullanır. Üretilen Lorem Ipsum bu nedenle her zaman tekrardan, enjekte edilen mizahtan veya karakteristik olmayan kelimelerden vb.",
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "JavaScript Makale Yorumu",
            //    }
            //    );
        }
    }
}
