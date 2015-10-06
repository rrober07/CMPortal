using System.ComponentModel.DataAnnotations;
using Heroic.AutoMapper;
using Rma.CMPortal.WebUi.Core;
using System.Web.Mvc;

namespace Rma.CMPortal.WebUi.Models
{
	public class AddSubmitterForm : IMapTo<Submitter>
	{
        [HiddenInput]
        public int SubmitterId { get; set; }

        [Required, Display(Name = "First Name", Prompt = "ex: John")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name", Prompt = "ex: Doe")]
        public string LastName { get; set; }
        [Required, Display(Name = "Display Name", Prompt = "ex: Doe, John (CNTR) - RMA")]
        public string DisplayName { get; set; }
        public bool Active { get; set; }
	}
}