using adopteUnDev.Handlers.Mapper;
using adopteUnDev.Models;
using adopteUnDev.Models.ClientViewModel;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B = BLL.Entities;

namespace adopteUnDev.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository<B.Client, int> _services;

        public ClientController(IClientRepository<B.Client, int> services)
        {
            _services = services;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            IEnumerable<ClientListItem> model = _services.Get().Select(e=>e.ToListItem());
            return View(model);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            ClientDetails model = _services.Get(id).ToDetails();
            return View(model);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreateForm form)
        {
            if (!ModelState.IsValid)
            {
                form.CliPassword = null;
                return View(form);
            }
            
            else 
            {
                int id = _services.Insert(form.ToBLL());
                return RedirectToAction("Details", "ClientController", new { id = id });
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
