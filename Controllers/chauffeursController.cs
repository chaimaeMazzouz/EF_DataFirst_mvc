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
    public class chauffeursController : Controller
    {
        private CompagnieVoyageEntities db = new CompagnieVoyageEntities();

        // GET: chauffeurs
        public async Task<ActionResult> Index()
        {
            return View(await db.chauffeur.ToListAsync());
        }

        // GET: chauffeurs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chauffeur chauffeur = await db.chauffeur.FindAsync(id);
            if (chauffeur == null)
            {
                return HttpNotFound();
            }
            return View(chauffeur);
        }

        // GET: chauffeurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: chauffeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_chauffeur,Nom,Prenom,Adresse,Date_Recrutement,Salaire")] chauffeur chauffeur)
        {
            if (ModelState.IsValid)
            {
                db.chauffeur.Add(chauffeur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(chauffeur);
        }

        // GET: chauffeurs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chauffeur chauffeur = await db.chauffeur.FindAsync(id);
            if (chauffeur == null)
            {
                return HttpNotFound();
            }
            return View(chauffeur);
        }

        // POST: chauffeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_chauffeur,Nom,Prenom,Adresse,Date_Recrutement,Salaire")] chauffeur chauffeur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chauffeur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chauffeur);
        }

        // GET: chauffeurs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chauffeur chauffeur = await db.chauffeur.FindAsync(id);
            if (chauffeur == null)
            {
                return HttpNotFound();
            }
            return View(chauffeur);
        }

        // POST: chauffeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            chauffeur chauffeur = await db.chauffeur.FindAsync(id);
            db.chauffeur.Remove(chauffeur);
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
