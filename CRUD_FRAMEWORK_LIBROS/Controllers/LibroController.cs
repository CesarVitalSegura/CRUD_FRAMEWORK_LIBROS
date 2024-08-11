using CRUD_FRAMEWORK_LIBROS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_FRAMEWORK_LIBROS.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Libros.ToList());
            }
                
        }

        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Libros.Where(x  => x.ID == id).FirstOrDefault());
            }
           
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create(Libros libros)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Libros.Add(libros);
                    context.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Libros.Where(x => x.ID == id).FirstOrDefault());
            }

        }

        // POST: Libro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Libros libros)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(libros).State = System.Data.EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Libros.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Libro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               using (DbModels context = new DbModels())
                {
                    Libros libros = context.Libros.Where(x => x.ID == id).FirstOrDefault();
                    context.Libros.Remove(libros);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
