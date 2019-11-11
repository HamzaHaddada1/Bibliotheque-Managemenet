using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AuteurController : Controller
    {
        IAuteurService AS = new AuteurService();
        // GET: Auteur
        public ActionResult Index()
        {
          
            List<AuteurViewModel> list = new List<AuteurViewModel>();
          
            foreach (var item in AS.GetAll())
            {
                AuteurViewModel PVM = new AuteurViewModel();
                PVM.AuteurCode = item.AuteurCode;
             //   PVM.CIN = item.CIN;
               // PVM.Adresse = item.Adresse;
                PVM.NomComplet = new Models.NomCompletViewModel
                {
                    Nom =
                item.NomComplet.Nom,
                    Prenom = item.NomComplet.Prenom
                };

                list.Add(PVM);
            }
            return View(list);
        }

        // GET: Auteur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auteur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auteur/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Auteur a = new Auteur();
            AuteurViewModel AVM = new AuteurViewModel();
           // a.Adresse = AVM.Adresse;
            AVM.NomComplet = new NomCompletViewModel
            {
                Nom = AVM.NomComplet.Nom,
                Prenom =
            AVM.NomComplet.Prenom
            };
            AVM.AuteurCode = AVM.AuteurCode;
            //a.CIN = AVM.CIN;
            AS.Add(AVM);
            AS.Commit();
            return RedirectToAction("Index");
        }

        // GET: Auteur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auteur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auteur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auteur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



      
[HttpPost]
        public ActionResult Index(string recherche)
        {
            List<AuteurViewModel> List = new List<AuteurViewModel>();
            foreach (var item in AS.GetAll())
            {
                AuteurViewModel PVM = new AuteurViewModel();
                PVM.AuteurCode = item.AuteurCode;
               
                PVM.NomComplet = new Models.NomCompletViewModel
                {
                    Nom =
                item.NomComplet.Nom,
                    Prenom = item.NomComplet.Prenom
                };

                List.Add(PVM);
            }
            if (!String.IsNullOrEmpty(recherche))
            {
                List = List.Where(m =>
                m.NomComplet.Nom.Contains(recherche)).ToList();
            }
            return View(List);
        }


    }
}
