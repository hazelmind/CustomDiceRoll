using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomDiceRoll.Models;

namespace CustomDiceRoll.Controllers
{
    public class HomeController : Controller
    {
        private List<int> newList;

        public List<int> GetNewList()
        {
            return newList;
        }

        public void SetNewList(List<int> value)
        {
            newList = value;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Roll(int sides, int rolls)
        {
            int i = 0;

            while (i < rolls)
            {
                i++;
                Random random = new Random();
                int newDice = random.Next(1, sides + 1);
                AddRoll(newDice);
            }
            return View(GetNewList());
        }

        public List<int> AddRoll(int newDice)
        {
            List<int> ResultList = new List<int>();
            if (GetNewList() != null)
            {
                ResultList = GetNewList();
            }
            ResultList.Add(newDice);
            SetNewList(ResultList);
            return ResultList;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
