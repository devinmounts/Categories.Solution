using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Categories.Models;

namespace Categories.Controllers
{
    public class FoodController : Controller
    {
        [HttpGet("/food/search")]
        public ActionResult Search()
        {
            return View();
        }

        [HttpGet("/food/add")]
        public ActionResult AddForm()
        {
            List<Category> results = Category.GetAll();
            return View(results);
        }

        [HttpPost("/food/add")]
        public ActionResult Add(int category, string name)
        {
            int id = 0;
            Food newFood = new Food(id, category, name);
            newFood.Save();
            return RedirectToAction("All");
        }

        [HttpGet("/food/all/{id}/update")]
        public ActionResult UpdateForm(int id)
        {
            Food thisFood = Food.Find(id);
            return View("Update", thisFood);
        }

        [HttpPost("/food/all/{id}/update")]
        public ActionResult Update(int id, string newname)
        {
            Food thisFood = Food.Find(id);
            thisFood.Edit(newname);
            return RedirectToAction("All");
        }


        [HttpGet("/food/all")]
        public ActionResult All()
        {
            List<Food> results = Food.GetAll();
            return View(results);
        }

        [HttpPost("/food/results")]
        public ActionResult Results(int id, int categoryId, string name)
        {
            int thisId = id;
            int thisCategoryId = categoryId;
            string thisName = name;
            Food newFood = new Food(thisId, thisCategoryId, thisName);
            newFood.Save();
            List<Food> results = Food.GetAll();
            return View(results);
        }

        [HttpPost("/food/all/{id}/delete")]
        public ActionResult DeletePage(int id)
        {

            Food.DeleteFood(id);
            return RedirectToAction("All");
        }


    }
}
