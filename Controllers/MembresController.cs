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
    public class MembresController : Controller
    {
        private CompagnieVoyageEntities db = new CompagnieVoyageEntities();

        // GET: Membres
        public async Task<ActionResult> Index()
        {
            return View(await db.Membre.ToListAsync());
        }

        // GET: Membres/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = await db.Membre.FindAsync(id);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // GET: Membres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Membres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "pseudo,pass,matricule,nom,prenom,service_,mail,categorie")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                db.Membre.Add(membre);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(membre);
        }

        // GET: Membres/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = await db.Membre.FindAsync(id);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // POST: Membres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pseudo,pass,matricule,nom,prenom,service_,mail,categorie")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membre).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(membre);
        }

        // GET: Membres/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = await db.Membre.FindAsync(id);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // POST: Membres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Membre membre = await db.Membre.FindAsync(id);
            db.Membre.Remove(membre);
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
