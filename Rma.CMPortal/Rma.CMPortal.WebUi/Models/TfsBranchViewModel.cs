using Heroic.AutoMapper;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;

namespace Rma.CMPortal.WebUi.Models
{
    public class TfsBranchViewModel : IHaveCustomMappings
    {
        public TfsBranchViewModel()
        {
            //bo.
            //DateUpdated = DateTime.Today;
        }

        public int Version { get; set; }

        public string Branch { get; set; }

        public string Owner { get; set; }

        public string Parent { get; set; }

        public string Project { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateCreated { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<BranchObject, TfsBranchViewModel>()
                .ForMember(vm => vm.Project, m => m.MapFrom(bo => bo.Properties.RootItem.Item.Substring(0, bo.Properties.RootItem.Item.IndexOf('/', 2))))
                .ForMember(vm => vm.IsDeleted, m => m.MapFrom(bo => bo.Properties.RootItem.IsDeleted))
                .ForMember(vm => vm.Branch, m => m.MapFrom(bo => bo.Properties.RootItem.Item.Replace(bo.Properties.RootItem.Item.Substring(0, bo.Properties.RootItem.Item.IndexOf('/', 2)), "")))
                .ForMember(vm => vm.Version, m => m.MapFrom(bo => (bo.Properties.RootItem.Version as ChangesetVersionSpec).ChangesetId))
                .ForMember(vm => vm.Owner, m => m.MapFrom(bo => bo.Properties.Owner))
                .ForMember(vm => vm.Parent, m => m.MapFrom(bo => bo.Properties.ParentBranch != null ? bo.Properties.ParentBranch.Item.Replace(bo.Properties.RootItem.Item.Substring(0, bo.Properties.RootItem.Item.IndexOf('/', 2)), "") : ""));
        }
    }
}