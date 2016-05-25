using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using GarageII_TheParking.Models.ViewModels;

namespace GarageII_TheParking.Controllers {
    public class MembersController : Controller {
        private Context db = new Context();
        private Page<Member> Page;

        public MembersController() {
            Page = new Page<Member>(db.Members, 4, new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>[] {
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("Address",false,n=> n.OrderBy(o=> o.Address)),
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("Address",true,n=> n.OrderByDescending(o=> o.Address)),
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("Name",false,n=> n.OrderBy(o=> o.Name)),
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("Name",true,n=> n.OrderByDescending(o=> o.Name)),
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("LastName",false,n=> n.OrderBy(o=> o.LastName)),
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("LastName",true,n=> n.OrderByDescending(o=> o.LastName)),
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("PersonIdNumber",false,n=> n.OrderBy(o=> o.PersonIdNumber)),
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("PersonIdNumber",true,n=> n.OrderByDescending(o=> o.PersonIdNumber)),
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("PhoneNr",false,n=> n.OrderBy(o=> o.PhoneNr)),
                new Tuple<string, bool, Func<IEnumerable<Member>, IEnumerable<Member>>>("PhoneNr",true,n=> n.OrderByDescending(o=> o.PhoneNr)),
            }, new Tuple<string, Func<string, IEnumerable<Member>, IEnumerable<Member>>>[] {
                  new Tuple<string, Func<string, IEnumerable<Member>, IEnumerable<Member>>>("Address",(search,list)=> list.Where(n=> n.Address.ToLower().Contains(search.ToLower() ))),
                  new Tuple<string, Func<string, IEnumerable<Member>, IEnumerable<Member>>>("Name",(search,list)=> list.Where(n=> n.Name.ToLower().Contains(search.ToLower() ))),
                  new Tuple<string, Func<string, IEnumerable<Member>, IEnumerable<Member>>>("LastName",(search,list)=> list.Where(n=> n.LastName.ToLower().Contains(search.ToLower()))),
                  new Tuple<string, Func<string, IEnumerable<Member>, IEnumerable<Member>>>("PersonIdNumber",(search,list)=> list.Where(n=> n.PersonIdNumber.ToLower().Contains(search.ToLower()))),
                  new Tuple<string, Func<string, IEnumerable<Member>, IEnumerable<Member>>>("PhoneNr",(search,list)=> list.Where(n=> n.PhoneNr.Contains(search))),
                  new Tuple<string, Func<string, IEnumerable<Member>, IEnumerable<Member>>>("All",(search ,list)=> {

                      return list.Where(n=>
                      n.Address.ToLower().Contains(search.ToLower()) ||
                      n.LastName.ToLower().Contains(search.ToLower()) ||
                      n.Name.ToLower().Contains(search.ToLower()) ||
                      n.PersonIdNumber.Contains(search) ||
                      n.PhoneNr.Contains(search)
                      );

                      }),

            });
        }


        // GET: Members
        public ActionResult Index(Page<Member>.PageResult result = null) {
            result = Page.GetResult(result);
            return View(result);
        }

        // GET: Members/Details/5
        public ActionResult Details(Guid? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null) {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,PersonIdNumber,PhoneNr,Address")] Member member) {
            if (ModelState.IsValid) {
                member.Id = Guid.NewGuid();
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(Guid? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null) {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,PersonIdNumber,PhoneNr,Address")] Member member) {
            if (ModelState.IsValid) {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(Guid? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null) {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id) {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
