using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class apideneme : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
