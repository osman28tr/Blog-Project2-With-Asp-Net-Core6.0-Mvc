using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _env; //wwwroot dosyasının yolunu işletim sistemi değişse bile dinamik olarak almak için.
        public UserController(UserManager<User> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success
            });
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }
        public async Task<string> ImageUpload(UserAddDto userAddDto)
        {
            //~/img/123.jpg
            string wwwroot = _env.WebRootPath; //wwwroot dosya yolu
            //string fileName = Path.GetFileNameWithoutExtension(userAddDto.PictureFile.FileName);//123
            //.jpg
            string fileExtension = Path.GetExtension(userAddDto.PictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string fileName = $"{userAddDto.UserName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{wwwroot}/img", fileName); //path yolu oluşturuldu.
            await using(var stream=new FileStream(path, FileMode.Create)) //img ye kaydedildi.
            {
                await userAddDto.PictureFile.CopyToAsync(stream); //picture prop'una kopyası verildi.
            }
            return fileName; //user_551_5_21_12_3_10_2022.jpg
        }
    }
}
