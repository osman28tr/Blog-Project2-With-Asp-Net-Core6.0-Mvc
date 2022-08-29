﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;

#nullable disable

namespace ProgrammersBlog.Data.Migrations
{
    [DbContext(typeof(ProgrammersBlogContext))]
    [Migration("20220825123842_mig_InitialCreate")]
    partial class mig_InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CommentCount")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SeoAuthor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SeoDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SeoTags")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ViewsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CommentCount = 1,
                            Content = "Lorem Ipsum , baskı ve dizgi endüstrisinin basit bir sahte metnidir. Lorem Ipsum, bilinmeyen bir matbaacının bir tip numune kitabı yapmak için bir yazı galerisini alıp karıştırdığı 1500'lerden beri endüstrinin standart sahte metni olmuştur. Sadece beş yüzyıl boyunca hayatta kalmayıp, aynı zamanda esasen değişmeden elektronik dizgiye sıçradı. 1960'larda Lorem Ipsum pasajları içeren Letraset sayfalarının yayınlanmasıyla ve daha yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümlerini içeren masaüstü yayıncılık yazılımlarıyla popüler hale geldi.",
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7708),
                            Date = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7707),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7709),
                            Note = "C# 9.0 ve .Net 5 Yenilikleri",
                            SeoAuthor = "Ali Yildiz",
                            SeoDescription = "C# 9.0 ve .Net 5 Yenilikleri",
                            SeoTags = "C#, C# 9, .Net5, .Net Framework, .Net Core",
                            Thumbnail = "Default.jpg",
                            Title = "C# 9.0 ve .Net 5 Yenilikleri",
                            UserId = 1,
                            ViewsCount = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CommentCount = 1,
                            Content = "Okuyucunun, sayfa düzenine bakarken sayfanın okunabilir içeriğinin dikkatini dağıtacağı uzun zamandır bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, 'İçerik burada, içerik burada' kullanılmasının aksine, harflerin az çok normal dağılımına sahip olması ve okunabilir İngilizce gibi görünmesini sağlamasıdır. Birçok masaüstü yayıncılık paketi ve web sayfası düzenleyicisi artık varsayılan model metni olarak Lorem Ipsum'u kullanıyor ve 'lorem ipsum' araması, henüz emekleme aşamasında olan birçok web sitesini ortaya çıkaracaktır. Yıllar içinde, bazen tesadüfen, bazen de bilerek (enjekte edilmiş mizah ve benzeri) çeşitli versiyonlar gelişti.",
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7713),
                            Date = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7712),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7713),
                            Note = "C++ 11.0 ve 19 Yenilikleri",
                            SeoAuthor = "Ali Yildiz",
                            SeoDescription = "C++ 11.0 ve 19 Yenilikleri",
                            SeoTags = "C++ 11.0 ve 19 Yenilikleri",
                            Thumbnail = "Default.jpg",
                            Title = "C++ 11.0 ve 19 Yenilikleri",
                            UserId = 1,
                            ViewsCount = 295
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CommentCount = 1,
                            Content = "Popüler inanışın aksine, Lorem Ipsum rastgele bir metin değildir. 45'ten kalma bir klasik Latin edebiyatı parçasında kökleri vardır ve 2000 yıldan daha eskidir. Virginia'daki Hampden-Sydney College'da Latince profesörü olan Richard McClintock, bir Lorem Ipsum pasajındaki daha anlaşılması güç Latince sözcüklerden biri olan consectetur'u aradı ve kelimenin klasik edebiyattaki örneklerini inceleyerek, şüphesiz kaynağı keşfetti. Lorem Ipsum, Cicero'nun MÖ 45 yılında yazdığı \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Noktaları) kitabının 1.10.32 ve 1.10.33 bölümlerinden gelmektedir. Bu kitap, Rönesans döneminde çok popüler olan etik teorisi üzerine bir incelemedir. Lorem Ipsum'un ilk satırı \"Lorem ipsum dolor sit amet..\", bölüm 1.10.32'deki bir satırdan gelmektedir.",
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7717),
                            Date = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7716),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7717),
                            Note = "JavaScript ES2019 ve ES2020 Yenilikleri",
                            SeoAuthor = "Ali Yildiz",
                            SeoDescription = "JavaScript ES2019 ve ES2020 Yenilikleri",
                            SeoTags = "JavaScript ES2019 ve ES2020 Yenilikleri",
                            Thumbnail = "Default.jpg",
                            Title = "JavaScript ES2019 ve ES2020 Yenilikleri",
                            UserId = 1,
                            ViewsCount = 12
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8818),
                            Description = "C# Programlama Dili ile İlgili En Güncel Bilgiler",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8819),
                            Name = "C#",
                            Note = "C# Blog Kategorisi"
                        },
                        new
                        {
                            Id = 2,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8822),
                            Description = "C++ Programlama Dili ile İlgili En Güncel Bilgiler",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8823),
                            Name = "C++",
                            Note = "C++ Blog Kategorisi"
                        },
                        new
                        {
                            Id = 3,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8825),
                            Description = "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8826),
                            Name = "JavaScript",
                            Note = "JavaScript Blog Kategorisi"
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comments", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 1,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(614),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(615),
                            Note = "C# Makale Yorumu",
                            Text = "Lorem Ipsum'un birçok pasaj varyasyonu mevcuttur, ancak çoğunluğu, enjekte edilen mizah veya biraz inandırıcı görünmeyen rastgele kelimelerle bir şekilde değişikliğe uğramıştır. Lorem Ipsum'dan bir pasaj kullanacaksanız, metnin ortasında utanç verici bir şey olmadığından emin olmalısınız. İnternetteki tüm Lorem Ipsum oluşturucular, önceden tanımlanmış parçaları gerektiği gibi tekrarlama eğilimindedir ve bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum'u oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince sözcükten oluşan bir sözlük kullanır. Üretilen Lorem Ipsum bu nedenle her zaman tekrardan, enjekte edilen mizahtan veya karakteristik olmayan kelimelerden vb."
                        },
                        new
                        {
                            Id = 2,
                            ArticleId = 2,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(617),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(618),
                            Note = "C++ Makale Yorumu",
                            Text = "Lorem Ipsum'un birçok pasaj varyasyonu mevcuttur, ancak çoğunluğu, enjekte edilen mizah veya biraz inandırıcı görünmeyen rastgele kelimelerle bir şekilde değişikliğe uğramıştır. Lorem Ipsum'dan bir pasaj kullanacaksanız, metnin ortasında utanç verici bir şey olmadığından emin olmalısınız. İnternetteki tüm Lorem Ipsum oluşturucular, önceden tanımlanmış parçaları gerektiği gibi tekrarlama eğilimindedir ve bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum'u oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince sözcükten oluşan bir sözlük kullanır. Üretilen Lorem Ipsum bu nedenle her zaman tekrardan, enjekte edilen mizahtan veya karakteristik olmayan kelimelerden vb."
                        },
                        new
                        {
                            Id = 3,
                            ArticleId = 3,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(620),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(621),
                            Note = "JavaScript Makale Yorumu",
                            Text = "Lorem Ipsum'un birçok pasaj varyasyonu mevcuttur, ancak çoğunluğu, enjekte edilen mizah veya biraz inandırıcı görünmeyen rastgele kelimelerle bir şekilde değişikliğe uğramıştır. Lorem Ipsum'dan bir pasaj kullanacaksanız, metnin ortasında utanç verici bir şey olmadığından emin olmalısınız. İnternetteki tüm Lorem Ipsum oluşturucular, önceden tanımlanmış parçaları gerektiği gibi tekrarlama eğilimindedir ve bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum'u oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince sözcükten oluşan bir sözlük kullanır. Üretilen Lorem Ipsum bu nedenle her zaman tekrardan, enjekte edilen mizahtan veya karakteristik olmayan kelimelerden vb."
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(1535),
                            Description = "Admin Rolü, Tüm Haklara Sahiptir.",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(1536),
                            Name = "Admin",
                            Note = "Admin Rolüdür."
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("VARBINARY(500)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(4384),
                            Description = "İlk Admin Kullanıcı",
                            Email = "ali@gmail.com",
                            FirstName = "Ali",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Yıldız",
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(4385),
                            Note = "Admin Kullanıcısı",
                            PasswordHash = new byte[] { 48, 49, 57, 50, 48, 50, 51, 97, 55, 98, 98, 100, 55, 51, 50, 53, 48, 53, 49, 54, 102, 48, 54, 57, 100, 102, 49, 56, 98, 53, 48, 48 },
                            Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
                            RoleId = 1,
                            UserName = "aliyildiz"
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.Article", b =>
                {
                    b.HasOne("ProgrammersBlog.Entities.Concrete.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgrammersBlog.Entities.Concrete.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.Comment", b =>
                {
                    b.HasOne("ProgrammersBlog.Entities.Concrete.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.User", b =>
                {
                    b.HasOne("ProgrammersBlog.Entities.Concrete.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.Article", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProgrammersBlog.Entities.Concrete.User", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}