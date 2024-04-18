<h1>Blog Proje</h1>
<h3>1. Giriş</h3>
<p align="justify">Geliştirilen bu blog projesi, kullanıcıların çeşitli konularda makale yazdığı ve bunları diğer kullanıcılar ile paylaştığı bir platformdur. Projede ayrıca admin paneli bulunmaktadır. Gerçekleştirilen bu işlemler güvenilir ve ölçeklenebilir bir alt yapıda ele alınmıştır.</p>

<h3>2. Kullanılan Teknolojiler</h3>
Asp.Net Core Mvc, EntityFramework Core, N-Tier Architecture, AutoMapper, Ajax, MSSQL

<b>Kullanılan Dil:</b> C#

<h3>3. Projede Kullanılan Mimarinin Genel Hatları</h3>

<img src="ProgrammersBlog.Mvc/wwwroot/ProjectArchImages/BlogArch1.PNG" height="450px" width="780px">

<h3>4. Proje Ekran Görüntüleri</h3>

<img src="ProgrammersBlog.Mvc/wwwroot/ProjectScrennshots/BlogImage1.png" height="450px" width="780px">

<img src="ProgrammersBlog.Mvc/wwwroot/ProjectScrennshots/BlogImage2.png" height="450px" width="780px">

<img src="ProgrammersBlog.Mvc/wwwroot/ProjectScrennshots/BlogImage3.png" height="450px" width="780px">

<img src="ProgrammersBlog.Mvc/wwwroot/ProjectScrennshots/BlogImage4.png" height="450px" width="780px">

<h3>5. Kurulum: </h3>
 - Projede ProgrammersBlog.Mvc katmanında appsettings.json dosyasını açınız, ConnectionStrings kısmında belirtilen veritabanı bağlantı dizesini kendi veritabanı bağlantı dizenize göre güncelleyiniz.<br>
 - Ardından Visual Studio aracının üst sekmesinden view -> other windows -> package manager console kısmına tıklayınız.<br>
 - Ardından açılan pencerede default project yazan yere tıklayıp açılan seçim ekranından ProgrammersBlog.Data katmanını seçiniz.<br>
 - Açılan pencereye "update-database" yazıp enter'a tıklayınız.(ilgili veritabanı ve tabloları SSMS'de oluşacaktır.)<br>
 - Ardından ProgrammersBlog.Mvc projesine sağ tık yapıp "Set as Startup Project" deyiniz ve projeyi ayağa kaldırınız.

<b>Not: </b> Kullandığım veritabanı dosyası(uygulamaya hazır entegre etmek isteyenler için): ProgrammersBlog.bak

