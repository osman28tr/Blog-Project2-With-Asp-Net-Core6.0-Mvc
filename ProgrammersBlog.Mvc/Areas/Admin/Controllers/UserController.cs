using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _env; //wwwroot dosyasının yolunu işletim sistemi değişse bile dinamik olarak almak için.
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager, IWebHostEnvironment env, IMapper mapper)
        {
            _userManager = userManager;
            _env = env;
            _mapper = mapper;
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
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userListDto = System.Text.Json.JsonSerializer.Serialize(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success
            }, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(userListDto);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid) //frontend valid annotations
            {
                userAddDto.Picture = await ImageUpload(userAddDto.UserName, userAddDto.PictureFile);
                var user = _mapper.Map<User>(userAddDto);
                var result = await _userManager.CreateAsync(user, userAddDto.Password);
                if (result.Succeeded) //backend valid
                {
                    var userAddAjaxModel = System.Text.Json.JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{user.UserName} adlı kullanıcı adına sahip, kullanıcı " +
                        $"başarıyla eklenmiştir.",
                            User = user
                        },
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("  ", error.Description);
                    }
                    var userAddAjaxErrorModel = System.Text.Json.JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserAddDto = userAddDto,
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxErrorModel); //frontend'e veriler döndü.
                }
            }
            var userAddAjaxModelStateErrorModel = System.Text.Json.JsonSerializer.Serialize(new UserAddAjaxViewModel
            {
                UserAddDto = userAddDto,
                UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
            });
            return Json(userAddAjaxModelStateErrorModel);
        }
        public async Task<JsonResult> Delete(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                var deletedUser = System.Text.Json.JsonSerializer.Serialize(new UserDto
                {
                    ResultStatus = ResultStatus.Success,
                    Message = $"{user.UserName} adlı kullanıcı başarıyla silinmiştir.",
                    User = user
                });
                return Json(deletedUser);
            }
            else
            {
                string errorMessages = string.Empty;
                foreach (var error in result.Errors)
                {
                    errorMessages = $"*{error.Description}\n";
                }
                var deletedUserErrorModel = System.Text.Json.JsonSerializer.Serialize(new UserDto
                {
                    ResultStatus = ResultStatus.Error,
                    Message = $"{user.UserName} adlı kullanıcı silinirken bazı hatalar oluştu.\n{errorMessages}",
                    User = user
                });
                return Json(deletedUserErrorModel);
            }
        }
        [HttpGet]
        public async Task<PartialViewResult> Update(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var userUpdateDto = _mapper.Map<UserUpdateDto>(user);
            return PartialView("_UserUpdatePartial", userUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isNewPictureUploaded = false;
                var oldUser = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
                var oldUserPicture = oldUser.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    userUpdateDto.Picture = await ImageUpload(userUpdateDto.UserName, userUpdateDto.PictureFile);
                    isNewPictureUploaded = true;
                }
                var updatedUser = _mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser
                    );
                var result = await _userManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    if (isNewPictureUploaded)
                    {
                        ImageDelete(oldUserPicture);
                    }
                    var userUpdateViewModel = System.Text.Json.JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                        UserDto = new UserDto { ResultStatus = ResultStatus.Success, Message = $"{updatedUser.UserName} adlı kullanıcı başarıyla güncellenmiştir.", User = updatedUser },
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                    });
                    return Json(userUpdateViewModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    var userUpdateErrorViewModel = System.Text.Json.JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                        UserUpdateDto = userUpdateDto,
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                    });
                    return Json(userUpdateErrorViewModel);
                }
            }
            else
            {
                var userUpdateModelStateErrorViewModel = System.Text.Json.JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                {
                    UserUpdateDto = userUpdateDto,
                    UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                });
                return Json(userUpdateModelStateErrorViewModel);
            }
        }
        public async Task<string> ImageUpload(string userName, IFormFile pictureFile)
        {
            //~/img/123.jpg
            string wwwroot = _env.WebRootPath; //wwwroot dosya yolu
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
        public bool ImageDelete(string pictureName)
        {
            string wwwroot = _env.WebRootPath;
            var fileToDelete = Path.Combine($"{wwwroot}/img", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                System.IO.File.Delete(fileToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
//password: aliyildiz123
