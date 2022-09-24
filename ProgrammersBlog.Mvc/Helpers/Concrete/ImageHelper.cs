using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;

namespace ProgrammersBlog.Mvc.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;//wwwroot dosyasının yolunu işletim sistemi değişse bile dinamik olarak almak için.
        private readonly string _wwwroot;//wwwroot dosya yolu
        private readonly string imgFolder = "img";
        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }
        public async Task<IDataResult<UploadedImageDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages")
        {
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
            }
            //~/img/123.jpg

            //string fileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);//123
            //.jpg
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string newFileName = $"{userName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName); //path yolu oluşturuldu.
            await using (var stream = new FileStream(path, FileMode.Create)) //img ye kaydedildi.
            {
                await pictureFile.CopyToAsync(stream); //picture prop'una kopyası verildi.
            }
            return new DataResult<UploadedImageDto>(ResultStatus.Success, $"{userName} adlı kullanıcının resmi başarıyla yüklenmiştir.", new UploadedImageDto
            {
                FullName = $"{folderName}/{newFileName}",
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length
            }); //user_551_5_21_12_3_10_2022.jpg
        }
    }
}
