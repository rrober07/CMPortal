using System.Data.Entity;
using System.Web.Mvc;

namespace Rma.CMPortal.WebUi.Controllers
{
    public class KPIController : CMControllerBase
    {

        private readonly DbContext _context;

        public KPIController(DbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}