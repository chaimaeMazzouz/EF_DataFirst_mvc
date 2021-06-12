using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AtelierPratique_16.Models;

namespace AtelierPratique_16.Controllers
{
    public class VehiculesController : Controller
    {
        private CompagnieVoyageEntities db = new CompagnieVoyageEntities();

        // GET: Vehicules
        public async Task<ActionResult> Index()
        {
            return View(await db.Vehicule.ToListAsync());
        }

        // GET: Vehicules/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicule vehicule = await db.Vehicule.FindAsync(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // GET: Vehicules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Immatricule,Marque,Type_Vehicule,Dt_Mise_Service")] Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Vehicule.Add(vehicule);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vehicule);
        }

        // GET: Vehicules/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicule vehicule = await db.Vehicule.FindAsync(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // POST: Vehicules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Immatricule,Marque,Type_Vehicule,Dt_Mise_Service")] Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehicule);
        }

        // GET: Vehicules/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicule vehicule = await db.Vehicule.FindAsync(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // POST: Vehicules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Vehicule vehicule = await db.Vehicule.FindAsync(id);
            db.Vehicule.Remove(vehicule);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
