﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class apideneme2 : Controller
    {
        // GET: apideneme2
        public ActionResult Index()
        {
            return View();
        }

        // GET: apideneme2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: apideneme2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: apideneme2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: apideneme2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: apideneme2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: apideneme2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: apideneme2/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
