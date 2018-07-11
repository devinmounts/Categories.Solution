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
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet("/all/{id}/update")]
        public ActionResult UpdateForm(int id)
        {
            Food thisFood = Food.Find(id);
            return View(thisFood);
        }

        [HttpGet("/all")]
        public ActionResult All()
        {
            return View();
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
    }
}
