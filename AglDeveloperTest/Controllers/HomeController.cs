using AglDeveloperTest.BusinessLayer;
using AglDeveloperTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AglDeveloperTest.Controllers
{
    public class HomeController : Controller
    {
        private IDataService dataService;

        public HomeController(IDataService _dataService)
        {
            this.dataService = _dataService;
        }
        // GET: Home
        public async Task<ActionResult> Index()
        {
            try
            {
                List<CatsByGender> data = await dataService.GetCatsDataByOwnerGender();
                return View(data);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}