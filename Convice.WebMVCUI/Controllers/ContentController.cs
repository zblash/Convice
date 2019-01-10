using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convice.Business.Abstract;
using Convice.Entities;
using Convice.WebMVCUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Convice.WebMVCUI.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        private IContentService _contentManager;
        private ICategoryService _categoryManager;
        private IPlatformService _platformManager;

        public ContentController(IContentService contentManager, ICategoryService categoryManager,IPlatformService platformManager)
        {
            _platformManager = platformManager;
            _contentManager = contentManager;
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Select()
        {
            var categories = await _contentManager.GetAll();
            var platforms = await _platformManager.GetAll();
            var model = new SelectContentsViewModel
            {
                Categories = categories,
                Platforms = platforms,
                SelectedCategories = new List<Category>(),
                SelectedPlatforms = new List<Platform>()
            };

            return View(model);

        }
        [HttpPost]
        public string Select(Category category, Platform platform)
        {
            return "helel1";
        }

        public async Task<IActionResult> Add()
        {
            var categories = await _categoryManager.GetAll();
            AddContentViewModel model = new AddContentViewModel
            {
                Content = new Content(),
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Content content)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryManager.GetAll();
                AddContentViewModel model = new AddContentViewModel
                {
                    Content = new Content(),
                    Categories = categories
                };
                return View(model);
            }
            await _contentManager.Add(content);
            TempData["message"] = "Yeni İçerik Eklendi";
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List()
        {
            var contents = await _contentManager.GetAll();
            ListContentViewModel model = new ListContentViewModel
            {
                Contents = contents
            };
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _contentManager.Delete(id);
            TempData["message"] = "İçerik Silindi";
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            Console.WriteLine(id);
            var content = await _contentManager.GetById(id);
            var categories = await _categoryManager.GetAll();
            UpdateContentViewModel model = new UpdateContentViewModel
            {
                Content = content,
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Content content)
        {
            
            await _contentManager.Update(content);
            TempData["message"] = $"İçerik Düzenlendi {content.Id}";
            return RedirectToAction("List");
        }
        
    }

    
}