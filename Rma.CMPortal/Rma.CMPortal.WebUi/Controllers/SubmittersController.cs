using Rma.CMPortal.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rma.CMPortal.WebUi.Core;
using Rma.CMPortal.WebUi.Data;

namespace Rma.CMPortal.WebUi.Controllers
{
    public class SubmittersController : CMControllerBase
    {
        private readonly PortalModel _context;

        public SubmittersController(PortalModel context)
        {
            _context = context;
            AutoMapper.Mapper.CreateMap<Submitter, SubmitterViewModel>();

        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult All()
        {
            var submitterModels = _context.Submitters
                .OrderByDescending(x => x.DateUpdated)
                .Project().To<SubmitterViewModel>();

            return BetterJson(submitterModels.ToArray());
        }

        public JsonResult Add(AddSubmitterForm form)
        {
            var submitter = Mapper.Map<Submitter>(form);
            _context.Submitters.Add(submitter);
            _context.SaveChanges();

            var model = Mapper.Map<SubmitterViewModel>(submitter);
            return BetterJson(model);
        }

        public JsonResult Update(EditSubmitterForm form)
        {
            var target = _context.Submitters.Find(form.SubmitterId);

            Mapper.Map(form, target);

            _context.SaveChanges();

            var updatedSubmitter = _context.Submitters.Project().To<SubmitterViewModel>().Single(x => x.SubmitterId == form.SubmitterId);

            return BetterJson(updatedSubmitter);
        }
	}

}