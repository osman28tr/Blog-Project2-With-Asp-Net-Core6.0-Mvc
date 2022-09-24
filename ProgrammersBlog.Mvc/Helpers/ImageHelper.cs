using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.Mvc.Helpers
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;//wwwroot dosyasının yolunu işletim sistemi değişse bile dinamik olarak almak için.
        private readonly string _wwwroot;//wwwroot dosya yolu
        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }
        public async Task<IDataResult<UploadedImageDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName)
        {
            //~/img/123.jpg
             
            //string fileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);//123
            //.jpg
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string fileName = $"{userName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{wwwroot}/img", fileName); //path yolu oluşturuldu.
            await using (var stream = new FileStream(path, FileMode.Create)) //img ye kaydedildi.
            {
                await pictureFile.CopyToAsync(stream); //picture prop'una kopyası verildi.
            }
            return fileName; //user_551_5_21_12_3_10_2022.jpg
        }
    }
}
