using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trgovina.DAL;
using Trgovina.Models;

namespace Trgovina.Controllers
{
    public class ProductsController : Controller
    {
        private TrgovinaContext db = new TrgovinaContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Store);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.storeID = new SelectList(db.Stores, "storeID", "storeName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productID,productName,quantity,storeID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.storeID = new SelectList(db.Stores, "storeID", "storeName", product.storeID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.storeID = new SelectList(db.Stores, "storeID", "storeName", product.storeID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productID,productName,quantity,storeID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.storeID = new SelectList(db.Stores, "storeID", "storeName", product.storeID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
            public ActionResult dohvatiSveProizvode(int? storeid)
            {
                if (storeid != null)
                {
                    //Serialize nece raditi ako se koristi lazy loading
                    using (var newDb = new TrgovinaContext())
                    {
                        newDb.Configuration.ProxyCreationEnabled = false;
                        var newProducts = newDb.Products.Where(x => x.storeID == storeid).ToList();
                        return Json(newProducts, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    using (var newDb = new TrgovinaContext())
                    {
                        newDb.Configuration.ProxyCreationEnabled = false;
                        var newProducts = newDb.Products.ToList();
                        return Json(newProducts, JsonRequestBehavior.AllowGet);
                    }

            }
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
