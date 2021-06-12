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
    public class billetsController : Controller
    {
        private CompagnieVoyageEntities db = new CompagnieVoyageEntities();

        // GET: billets
        public async Task<ActionResult> Index()
        {
            var billet = db.billet.Include(b => b.voyage);
            return View(await billet.ToListAsync());
        }

        // GET: billets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billet billet = await db.billet.FindAsync(id);
            if (billet == null)
            {
                return HttpNotFound();
            }
            return View(billet);
        }

        // GET: billets/Create
        public ActionResult Create()
        {
            ViewBag.ID_Voyage = new SelectList(db.voyage, "ID_Voyage", "Ville_Depart");
            return View();
        }

        // POST: billets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "N_Billet,Date_Delivrance,ID_Voyage")] billet billet)
        {
            if (ModelState.IsValid)
            {
                db.billet.Add(billet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Voyage = new SelectList(db.voyage, "ID_Voyage", "Ville_Depart", billet.ID_Voyage);
            return View(billet);
        }

        // GET: billets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billet billet = await db.billet.FindAsync(id);
            if (billet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Voyage = new SelectList(db.voyage, "ID_Voyage", "Ville_Depart", billet.ID_Voyage);
            return View(billet);
        }

        // POST: billets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "N_Billet,Date_Delivrance,ID_Voyage")] billet billet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Voyage = new SelectList(db.voyage, "ID_Voyage", "Ville_Depart", billet.ID_Voyage);
            return View(billet);
        }

        // GET: billets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billet billet = await db.billet.FindAsync(id);
            if (billet == null)
            {
                return HttpNotFound();
            }
            return View(billet);
        }

        // POST: billets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            billet billet = await db.billet.FindAsync(id);
            db.billet.Remove(billet);
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
