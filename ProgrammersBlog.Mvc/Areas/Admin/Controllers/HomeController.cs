using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin,Editor")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;
        public HomeController(ICategoryService categoryService, IArticleService articleService, /*ICommentService commentService*/UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            //_commentService = commentService;
            _userManager = userManager;
        }
        public async Task<IActionResult> AdminIndex()
        {
            var categoriesCountResult = await _categoryService.CountByNonDeletedAsync();
            var articlesCountResult = await _articleService.CountByNonDeletedAsync();
            //var commentsCountResult = await _commentService.CountByNonDeleted();
            var usersCount = await _userManager.Users.CountAsync();
            var articleResult = await _articleService.GetAllAsync();
            if (categoriesCountResult.ResultStatus == ResultStatus.Success && articlesCountResult.ResultStatus == ResultStatus.Success && /*commentsCountResult.ResultStatus == ResultStatus.Success &&*/ usersCount > -1)
            {
                return View(new DashboardViewModel
                {
                    CategoriesCount = categoriesCountResult.Data,
                    ArticlesCount = articlesCountResult.Data,
                    CommentsCount = 0,
                    UsersCount = usersCount,
                    Articles = articleResult.Data
                });
            }
            return NotFound();
        }
    }
}
