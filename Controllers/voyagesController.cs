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
    public class voyagesController : Controller
    {
        private CompagnieVoyageEntities db = new CompagnieVoyageEntities();

        // GET: voyages
        public async Task<ActionResult> Index()
        {
            var voyage = db.voyage.Include(v => v.chauffeur).Include(v => v.Vehicule);
            return View(await voyage.ToListAsync());
        }

        // GET: voyages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voyage voyage = await db.voyage.FindAsync(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // GET: voyages/Create
        public ActionResult Create()
        {
            ViewBag.ID_chauffeur = new SelectList(db.chauffeur, "ID_chauffeur", "Nom");
            ViewBag.Immatricule = new SelectList(db.Vehicule, "Immatricule", "Marque");
            return View();
        }

        // POST: voyages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_Voyage,Date_Voyage,Ville_Depart,Ville_Arrive,Duree,Nbre_Voyageurs,Place_libre,Tarif,ID_chauffeur,Immatricule")] voyage voyage)
        {
            if (ModelState.IsValid)
            {
                db.voyage.Add(voyage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_chauffeur = new SelectList(db.chauffeur, "ID_chauffeur", "Nom", voyage.ID_chauffeur);
            ViewBag.Immatricule = new SelectList(db.Vehicule, "Immatricule", "Marque", voyage.Immatricule);
            return View(voyage);
        }

        // GET: voyages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voyage voyage = await db.voyage.FindAsync(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_chauffeur = new SelectList(db.chauffeur, "ID_chauffeur", "Nom", voyage.ID_chauffeur);
            ViewBag.Immatricule = new SelectList(db.Vehicule, "Immatricule", "Marque", voyage.Immatricule);
            return View(voyage);
        }

        // POST: voyages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_Voyage,Date_Voyage,Ville_Depart,Ville_Arrive,Duree,Nbre_Voyageurs,Place_libre,Tarif,ID_chauffeur,Immatricule")] voyage voyage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voyage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_chauffeur = new SelectList(db.chauffeur, "ID_chauffeur", "Nom", voyage.ID_chauffeur);
            ViewBag.Immatricule = new SelectList(db.Vehicule, "Immatricule", "Marque", voyage.Immatricule);
            return View(voyage);
        }

        // GET: voyages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voyage voyage = await db.voyage.FindAsync(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // POST: voyages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            voyage voyage = await db.voyage.FindAsync(id);
            db.voyage.Remove(voyage);
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
