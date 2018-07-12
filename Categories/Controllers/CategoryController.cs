using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Categories.Models;

namespace Categories.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet("/category/search")]
        public ActionResult Search()
        {
            return View();
        }

        [HttpGet("/category/add")]
        public ActionResult AddForm()
        {
            return View();
        }

        [HttpPost("/category/add")]
        public ActionResult Add(string name, int id)
        {
            id = 0;
            Category newCategory = new Category(name, id);
            newCategory.Save();
            return RedirectToAction("All");
        }

        [HttpGet("/category/all/{id}/update")]
        public ActionResult UpdateForm(int id)
        {
            Category thisCategory = Category.Find(id);
            return View("Update", thisCategory);
        }

        [HttpPost("/category/all/{id}/update")]
        public ActionResult Update(int id, string newname)
        {
            Category thisCategory = Category.Find(id);
            thisCategory.Edit(newname);
            return RedirectToAction("All");
        }


        [HttpGet("/category/all")]
        public ActionResult All()
        {
            List<Category> results = Category.GetAll();
            return View(results);
        }

        [HttpPost("/category/results")]
        public ActionResult Results(int id, string name)
        {
            int thisId = id;
            string thisName = name;
            Category newCategory = new Category(thisName, thisId);
            newCategory.Save();
            List<Category> results = Category.GetAll();
            return View(results);
        }

        [HttpPost("/category/all/{id}/delete")]
        public ActionResult DeletePage(int id)
        {

            Category.DeleteCategory(id);
            return RedirectToAction("All");
        }


    }
}
