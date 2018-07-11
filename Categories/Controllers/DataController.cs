using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Categories.Models;

namespace Categories.Controllers
{
    public class DataController : Controller
    {
        [HttpGet("/search")]
        public ActionResult Search()
        {
            return View();
        }

        [HttpGet("/add")]
        public ActionResult AddForm()
        {
            return View();
        }

        [HttpPost("/add")]
        public ActionResult Add(int category, string name)
        {
            int id = 0;
            Food newFood = new Food(id, category, name);
            newFood.Save();
            return RedirectToAction("All");
        }

        [HttpGet("/all/{id}/update")]
        public ActionResult UpdateForm(int id)
        {
            Food thisFood = Food.Find(id);
            return View("Update", thisFood);
        }

        [HttpPost("/all/{id}/update")]
        public ActionResult Update(int id, string newname)
        {
            Food thisFood = Food.Find(id);
            thisFood.Edit(newname);
            return RedirectToAction("All");
        }


        [HttpGet("/all")]
        public ActionResult All()
        {
            List<Food> results = Food.GetAll();
            return View(results);
        }

        [HttpPost("/results")]
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

        [HttpPost("/all/{id}/delete")]
        public ActionResult DeletePage(int id)
        {

            Food.DeleteFood(id);
            return RedirectToAction("All");
        }


    }
}
