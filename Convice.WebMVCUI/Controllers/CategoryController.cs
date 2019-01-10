using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Convice.Business.Abstract;
using Convice.Entities;
using Convice.Entities.IdentityEntities;
using Convice.WebMVCUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Convice.WebMVCUI.Controllers
{
    public class CategoryController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private IContentService _contentService;
        private ICategoryService _categoryService;

        public CategoryController(IContentService contentService, ICategoryService categoryService, UserManager<CustomIdentityUser> userManager)
        {
            _contentService = contentService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public async Task<IActionResult> List()
        {
            var categories = await _categoryService.GetAll();
            ListCategoryViewModel model = new ListCategoryViewModel
            {
                Categories = categories
            };
            return View(model);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel model = new AddCategoryViewModel
            {
                Category = new Category()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            if (!ModelState.IsValid)
            {
                AddCategoryViewModel model = new AddCategoryViewModel
                {
                    Category = new Category()
                };
                return View(model);
            }

            await _categoryService.Add(category);
            TempData["message"] = "Kategori Eklendi";
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            TempData["message"] = "Kategori Silindi.";
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetById(id);
            UpdateCategoryViewModel model = new UpdateCategoryViewModel
            {
                Category = category
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                UpdateCategoryViewModel model = new UpdateCategoryViewModel
                {
                    Category = category
                };
                return View(model);
            }
            await _categoryService.Update(category);
            TempData["message"] = $"Kategori Güncellendi {category.Id}";
            return RedirectToAction("List");
        }

        public async Task<IActionResult> AddtoUser()
        {
            var categories = await _categoryService.GetAll();
            var model = new AddtoUserViewModel
            {
                Category = new Category(),
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddtoUser(int category)
        {
            var getCategory = await _categoryService.GetById(category);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var catuser = new UserCategory { Category = getCategory, User = user };
            await _categoryService.AddUsertoCategory(catuser);
            return View();
        }

        // public async Task<string> myList()
        // {
        //     var category = await _categoryService.GetById(1);
        //     var catusers = await _categoryService.GetCategoryUsers(category);
        //     //var user = await _userManager.GetUserAsync(HttpContext.User);
        //     //var usercats = user.UserCategories;
        //     //var usercategories = await _categoryService.GetCategoriesByUser(user.Id);
        //     StringBuilder sd = new StringBuilder();

        //     foreach (var v in catusers)
        //     {
        //         foreach (var user in v.Users)
        //         {
        //             sd.Append(user.User.FirstName);
        //         }
        //     }
        //     return sd.ToString();
        // }

    }


}