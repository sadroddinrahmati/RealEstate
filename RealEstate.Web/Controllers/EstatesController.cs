using System; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using RealEstate.Core.Domain;
using RealEstate.Core.Interface.Services;
using RealEstate.Infrastructure;

namespace RealEstate.Web.Controllers
{
    public class EstatesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEstateService _estateService;

        public EstatesController(ApplicationDbContext context, IEstateService estateService)
        {
            _context = context;
            _estateService = estateService;
        }
    
        public async Task<IActionResult> Index(string term = "")
        { 
            return View(await _estateService.GetAllEstates(term));
        }

        //[HttpPost]
        //public async Task<IActionResult> Search(string term = "")
        //{
        //    return View("~/Views/Estates/Index.cshtml", await _estateService.GetAllEstates(term));
        //}

        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "LastName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,OwnerId,Address,Area,EstateType")] Estate estate)
        {
            if (ModelState.IsValid)
            {
                estate.Id = Guid.NewGuid();
                estate.CreatedTime = DateTime.Now;
                estate.LastModified = DateTime.Now;
                estate.UserId = 1;
                estate.IsDelete = false;

                _estateService.InsertEstate(estate);

                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "LastName", estate.OwnerId);
            return View(estate);
        }
         
        public IActionResult Edit(Guid id)
        {
            if (id == null) return NotFound();

            var estate = _estateService.GetEstateById(id);
             
            if (estate == null) return NotFound();
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "LastName", estate.OwnerId);
            return View(estate);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(Guid id, [Bind("Id,Name,OwnerId,Address,Area,EstateType,IsDelete,CreatedTime,UserId")] Estate estate)
        {
            if (id != estate.Id) return NotFound();

            if (ModelState.IsValid)
            {
                estate.LastModified = DateTime.Now;
                _estateService.UpdateEstate(estate); 
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "LastName", estate.OwnerId);
            return View(estate);
        }
           
        public IActionResult Delete(Guid id)
        {
            if (id == null) return NotFound(); 
            var estate = _estateService.GetEstateById(id);
            _estateService.DeleteEstate(estate); 
            return RedirectToAction(nameof(Index));
        }
         
    }
}
