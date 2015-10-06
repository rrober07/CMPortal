using Rma.CMPortal.WebUi.Models.Scores;
using System.Web.Mvc;
using AutoMapper;

namespace Rma.CMPortal.WebUi.Controllers
{
    public class ScoresController : CMControllerBase
    {
        // GET: Scores
        private ScoresVmBuilder _scoresVmBuilder = new ScoresVmBuilder();

        public ActionResult Index()
        {
            var model = Mapper.Map<ScoreVm>(_scoresVmBuilder.GetScoresVM());

            return View(model);
            //return Json(_scoresVmBuilder.GetScoresVM(), JsonRequestBehavior.AllowGet);
        }
    }
}