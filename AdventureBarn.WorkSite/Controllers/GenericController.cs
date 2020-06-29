using AdventureBarn.Contracts.Models;
using AdventureBarn.Contracts.Repositories;
using log4net;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AdventureBarn.WorkSite.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(MvcApplication));
        protected IGenericRepository<T> _repository;

        public GenericController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        // GET: Generic
        public virtual ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        // GET: Generic/Details/5
        public virtual ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T foundObject = _repository.GetByID(id.Value);
            if (foundObject == null)
            {
                return HttpNotFound();
            }
            return View(foundObject);
        }

        // GET: Generic/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // GET: Generic/Edit/5
        public virtual ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T foundObject = _repository.GetByID(id.Value);
            if (foundObject == null)
            {
                return HttpNotFound();
            }
            return View(foundObject);
        }

        // GET: Generic/Delete/5
        public virtual ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T foundObject = _repository.GetByID(id.Value);
            if (foundObject == null)
            {
                return HttpNotFound();
            }
            return View(foundObject);
        }

        // POST: Generic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(long id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        #region Protected Methods
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

        protected ActionResult UnboundCreate(T foundObject)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(foundObject);
                return RedirectToAction("Index");
            }

            return View(foundObject);
        }

        protected ActionResult UnboundEdit(T foundObject)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(foundObject);
                return RedirectToAction("Index");
            }
            return View(foundObject);
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            //Log the error!!
            _log.Error(filterContext.Exception);
            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index", "Error");
            // OR 
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Error/Index.cshtml"
            };
        }
        #endregion
    }
}
