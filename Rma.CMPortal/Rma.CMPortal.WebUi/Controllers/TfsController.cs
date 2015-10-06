using Rma.CMPortal.WebUi.Models.Scores;
using System.Web.Mvc;
using AutoMapper;
using System;
using Rma.CMPortal.WebUi.Utilities;
using Rma.CMPortal.WebUi.Data;
using System.Linq;

namespace Rma.CMPortal.WebUi.Controllers
{
	public class TfsController : CMControllerBase
	{


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuildDef()
        {
            return View();
        }
        public ActionResult Branches()
        {
            return View();
        }



        public JsonResult TFSBuildDef()
		{
			var startOfMonth = DateTime.Today.ToStartOfMonth();
			var endOfMonth = DateTime.Today.ToEndOfMonth();

            var context = TfsContext.CreateTFSContext().GetTfsBuildDef();


            var filterlist = from vm in context
                             where vm.LastModifiedDate >= startOfMonth && vm.Enabled == true
                             orderby vm.LastModifiedDate
                             select vm;

            //var customers = _context.Customers.Where(x => x.CreateDate >= startOfMonth && x.CreateDate <= endOfMonth)
            //    .Project().To<NewCustomerReportViewModel>().ToArray();

            return BetterJson(filterlist);
		}

        public JsonResult TFSBranches()
		{

            TimeSpan ts = new TimeSpan(30,0,0,0,0);
			var startOfMonth = DateTime.Today.ToStartOfMonth().Subtract(ts);
			var endOfMonth = DateTime.Today.ToEndOfMonth();

            var context = TfsContext.CreateTFSContext().GetTfsBranches();

            var filterlist = from vm in context
                             where vm.DateCreated >= startOfMonth && vm.IsDeleted == false
                             orderby vm.DateCreated
                             select vm;

            //var customers = _context.Customers.Where(x => x.TerminationDate >= startOfMonth && x.TerminationDate <= endOfMonth)
            //    .Project().To<LostCustomerReportViewModel>().ToArray();

            return BetterJson(filterlist);
		}
	}
}