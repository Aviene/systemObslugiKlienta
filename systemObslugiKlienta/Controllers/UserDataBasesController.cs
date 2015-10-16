using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using systemObslugiKlienta.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

namespace systemObslugiKlienta.Controllers
{
    [Authorize]
    public class DataBasesController : Controller
    {
        private SystemObslugiKlientaContext db = new SystemObslugiKlientaContext();
        private UserManager _userManager;

        public DataBasesController()
        {

        }
        public DataBasesController(UserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
        }


        public UserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: DataBases
         [AllowAnonymous]
        public ActionResult Index()
        {
            var DataBases = db.DataBases.Include(b => b.User);
            return View(DataBases.ToList());
        }

        // GET: DataBases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDataBase UserDataBase = db.DataBases.Find(id);
            if (UserDataBase == null)
            {
                return HttpNotFound();
            }
            return View(UserDataBase);
        }

        // GET: DataBases/Create
        public ActionResult Create()
        {
            
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: DataBases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HttpPostedFileBase upload)
        {
            UserDataBase UserDataBase = new UserDataBase();
            var eMail = await UserManager.FindByEmailAsync(this.HttpContext.User.Identity.Name);
            try
            {

                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var baza = new UserDataBase
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            DataContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            baza.DataContent = reader.ReadBytes(upload.ContentLength);
                        }
                        var user1 = db.User.First(user => user.Id == eMail.Id);
                        user1.DataBases.Add(baza);
                    }
                    db.DataBases.Add(UserDataBase);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(UserDataBase);


            //if (ModelState.IsValid)
            //{
            //    db.DataBases.Add(UserDataBase);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", UserDataBase.UserId);
            
            
            //return View(UserDataBase);
        }

        // GET: DataBases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDataBase UserDataBase = db.DataBases.Find(id);
            if (UserDataBase == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", UserDataBase.UserId);
            return View(UserDataBase);
        }

        // POST: DataBases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FileId,FileName,DataContentType,DataContent,TypPliku,AddDate,UserId")] UserDataBase UserDataBase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(UserDataBase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", UserDataBase.UserId);
            return View(UserDataBase);
        }

        // GET: DataBases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDataBase UserDataBase = db.DataBases.Find(id);
            if (UserDataBase == null)
            {
                return HttpNotFound();
            }
            return View(UserDataBase);
        }

        // POST: DataBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDataBase UserDataBase = db.DataBases.Find(id);
            db.DataBases.Remove(UserDataBase);
            db.SaveChanges();
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
