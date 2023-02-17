using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.Web.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight SF;
        IServicePlane sp;

        public FlightController(IServiceFlight sF, IServicePlane sp)
        {
            SF = sF;
            this.sp = sp;
        }


        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                return View(SF.GetMany());
            else
                return View(SF.GetMany(f => f.FlightDate.Date.Equals(dateDepart)));

        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
          

            ViewBag.PlanesList = new SelectList(sp.GetAll(), "PlaneId", "Information");
            return View();

            
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight , IFormFile AirlineLogo)
        {
            if (AirlineLogo != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                   "wwwroot", "uploads", AirlineLogo.FileName);
                Stream stream = new FileStream(path, FileMode.Create);
                AirlineLogo.CopyTo(stream);
                flight.AirlineLogo = AirlineLogo.FileName;
            }

            SF.Add(flight);
            SF.Commit();


            return RedirectToAction(nameof(Index));
        }
        

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
