using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammersBlog.Data.Migrations
{
    public partial class mig_InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8818), "C# Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8819), "C#", "C# Blog Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8822), "C++ Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8823), "C++", "C++ Blog Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8825), "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(8826), "JavaScript", "JavaScript Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(1535), "Admin Rolü, Tüm Haklara Sahiptir.", true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(1536), "Admin", "Admin Rolüdür." });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Note", "PasswordHash", "Picture", "RoleId", "UserName" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(4384), "İlk Admin Kullanıcı", "ali@gmail.com", "Ali", true, false, "Yıldız", "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(4385), "Admin Kullanıcısı", new byte[] { 48, 49, 57, 50, 48, 50, 51, 97, 55, 98, 98, 100, 55, 51, 50, 53, 48, 53, 49, 54, 102, 48, 54, 57, 100, 102, 49, 56, 98, 53, 48, 48 }, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU", 1, "aliyildiz" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 1, 1, 1, "Lorem Ipsum , baskı ve dizgi endüstrisinin basit bir sahte metnidir. Lorem Ipsum, bilinmeyen bir matbaacının bir tip numune kitabı yapmak için bir yazı galerisini alıp karıştırdığı 1500'lerden beri endüstrinin standart sahte metni olmuştur. Sadece beş yüzyıl boyunca hayatta kalmayıp, aynı zamanda esasen değişmeden elektronik dizgiye sıçradı. 1960'larda Lorem Ipsum pasajları içeren Letraset sayfalarının yayınlanmasıyla ve daha yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümlerini içeren masaüstü yayıncılık yazılımlarıyla popüler hale geldi.", "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7708), new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7707), true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7709), "C# 9.0 ve .Net 5 Yenilikleri", "Ali Yildiz", "C# 9.0 ve .Net 5 Yenilikleri", "C#, C# 9, .Net5, .Net Framework, .Net Core", "Default.jpg", "C# 9.0 ve .Net 5 Yenilikleri", 1, 100 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 2, 2, 1, "Okuyucunun, sayfa düzenine bakarken sayfanın okunabilir içeriğinin dikkatini dağıtacağı uzun zamandır bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, 'İçerik burada, içerik burada' kullanılmasının aksine, harflerin az çok normal dağılımına sahip olması ve okunabilir İngilizce gibi görünmesini sağlamasıdır. Birçok masaüstü yayıncılık paketi ve web sayfası düzenleyicisi artık varsayılan model metni olarak Lorem Ipsum'u kullanıyor ve 'lorem ipsum' araması, henüz emekleme aşamasında olan birçok web sitesini ortaya çıkaracaktır. Yıllar içinde, bazen tesadüfen, bazen de bilerek (enjekte edilmiş mizah ve benzeri) çeşitli versiyonlar gelişti.", "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7713), new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7712), true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7713), "C++ 11.0 ve 19 Yenilikleri", "Ali Yildiz", "C++ 11.0 ve 19 Yenilikleri", "C++ 11.0 ve 19 Yenilikleri", "Default.jpg", "C++ 11.0 ve 19 Yenilikleri", 1, 295 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 3, 3, 1, "Popüler inanışın aksine, Lorem Ipsum rastgele bir metin değildir. 45'ten kalma bir klasik Latin edebiyatı parçasında kökleri vardır ve 2000 yıldan daha eskidir. Virginia'daki Hampden-Sydney College'da Latince profesörü olan Richard McClintock, bir Lorem Ipsum pasajındaki daha anlaşılması güç Latince sözcüklerden biri olan consectetur'u aradı ve kelimenin klasik edebiyattaki örneklerini inceleyerek, şüphesiz kaynağı keşfetti. Lorem Ipsum, Cicero'nun MÖ 45 yılında yazdığı \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Noktaları) kitabının 1.10.32 ve 1.10.33 bölümlerinden gelmektedir. Bu kitap, Rönesans döneminde çok popüler olan etik teorisi üzerine bir incelemedir. Lorem Ipsum'un ilk satırı \"Lorem ipsum dolor sit amet..\", bölüm 1.10.32'deki bir satırdan gelmektedir.", "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7717), new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7716), true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 605, DateTimeKind.Local).AddTicks(7717), "JavaScript ES2019 ve ES2020 Yenilikleri", "Ali Yildiz", "JavaScript ES2019 ve ES2020 Yenilikleri", "JavaScript ES2019 ve ES2020 Yenilikleri", "Default.jpg", "JavaScript ES2019 ve ES2020 Yenilikleri", 1, 12 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 1, 1, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(614), true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(615), "C# Makale Yorumu", "Lorem Ipsum'un birçok pasaj varyasyonu mevcuttur, ancak çoğunluğu, enjekte edilen mizah veya biraz inandırıcı görünmeyen rastgele kelimelerle bir şekilde değişikliğe uğramıştır. Lorem Ipsum'dan bir pasaj kullanacaksanız, metnin ortasında utanç verici bir şey olmadığından emin olmalısınız. İnternetteki tüm Lorem Ipsum oluşturucular, önceden tanımlanmış parçaları gerektiği gibi tekrarlama eğilimindedir ve bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum'u oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince sözcükten oluşan bir sözlük kullanır. Üretilen Lorem Ipsum bu nedenle her zaman tekrardan, enjekte edilen mizahtan veya karakteristik olmayan kelimelerden vb." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 2, 2, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(617), true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(618), "C++ Makale Yorumu", "Lorem Ipsum'un birçok pasaj varyasyonu mevcuttur, ancak çoğunluğu, enjekte edilen mizah veya biraz inandırıcı görünmeyen rastgele kelimelerle bir şekilde değişikliğe uğramıştır. Lorem Ipsum'dan bir pasaj kullanacaksanız, metnin ortasında utanç verici bir şey olmadığından emin olmalısınız. İnternetteki tüm Lorem Ipsum oluşturucular, önceden tanımlanmış parçaları gerektiği gibi tekrarlama eğilimindedir ve bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum'u oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince sözcükten oluşan bir sözlük kullanır. Üretilen Lorem Ipsum bu nedenle her zaman tekrardan, enjekte edilen mizahtan veya karakteristik olmayan kelimelerden vb." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 3, 3, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(620), true, false, "InitialCreate", new DateTime(2022, 8, 25, 15, 38, 42, 606, DateTimeKind.Local).AddTicks(621), "JavaScript Makale Yorumu", "Lorem Ipsum'un birçok pasaj varyasyonu mevcuttur, ancak çoğunluğu, enjekte edilen mizah veya biraz inandırıcı görünmeyen rastgele kelimelerle bir şekilde değişikliğe uğramıştır. Lorem Ipsum'dan bir pasaj kullanacaksanız, metnin ortasında utanç verici bir şey olmadığından emin olmalısınız. İnternetteki tüm Lorem Ipsum oluşturucular, önceden tanımlanmış parçaları gerektiği gibi tekrarlama eğilimindedir ve bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum'u oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince sözcükten oluşan bir sözlük kullanır. Üretilen Lorem Ipsum bu nedenle her zaman tekrardan, enjekte edilen mizahtan veya karakteristik olmayan kelimelerden vb." });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
