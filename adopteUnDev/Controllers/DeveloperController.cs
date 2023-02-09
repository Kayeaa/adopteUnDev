using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B = BLL.Entities;
using adopteUnDev.Models;
using Common.Repositories;
using adopteUnDev.Models.DeveloperViewModel;
using adopteUnDev.Handlers.Mapper;

namespace adopteUnDev.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperRepository<B.Developer, int> _services;

        public DeveloperController(IDeveloperRepository<B.Developer, int> services)
        {
            _services = services;
        }

        // GET: DeveloperController
        public ActionResult Index()
        {
            IEnumerable<DeveloperListItem> model = _services.Get().Select(e => e.ToListItem());
            return View(model);
        }

        // GET: DeveloperController/Details/5
        public ActionResult Details(int id)
        {
            DeveloperDetails model = _services.Get(id).ToDetails();
            return View(model);
        }

        // GET: DeveloperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeveloperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeveloperCreateFrom form)
        {
            if (!ModelState.IsValid) return View(form);
            else
            {
                int id = _services.Insert(form.ToBLL());
                return RedirectToAction("Details", "DeveloperController", new { id = id });
            }
        }

        // GET: DeveloperController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeveloperController/Edit/5
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

        // GET: DeveloperController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeveloperController/Delete/5
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
