using System;
using System.Web.Mvc;

namespace AspNetMvcMorrisCharts.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Random Getrandom = new Random();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetData(int count)
        {

            Entry[] data = new Entry[count];
            for (int i = 0; i < count; i++)
            {

                int year = DateTime.Now.AddYears(i * -1).Year;
                data[i] = new Entry
                {
                    value = GetRandomNumber(i * 30, year),
                    year = year.ToString()
                };
            }


            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (Getrandom) // synchronize
            {
                return Getrandom.Next(min, max);
            }
        }

        public class Entry
        {
            public string year { get; set; }
            public int value { get; set; }
        }
    }
}