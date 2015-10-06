using Heroic.AutoMapper;
using Microsoft.TeamFoundation.Build.Client;
using System;
using System.Collections.Generic;

namespace Rma.CMPortal.WebUi.Models
{
    public class TfsBuildDefViewModel : IHaveCustomMappings
    {
        public TfsBuildDefViewModel()
        {
            //bo.
            //DateUpdated = DateTime.Today;
        }

        public string Id { get; private set; }

        public string TeamProject { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string DefaultDropLocation { get; private set; }

        public List<IWorkspaceMapping> WorkspaceMappings { get; private set; }

        public DateTime LastModifiedDate { get; private set; }

        public string LastModifiedBy { get; private set; }

        public bool Enabled { get; private set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<IBuildDefinition, TfsBuildDefViewModel>()
                .ForMember(vm => vm.LastModifiedBy, m => m.MapFrom(bd => bd.Workspace.LastModifiedBy))
                .ForMember(vm => vm.LastModifiedDate, m => m.MapFrom(bd => bd.Workspace.LastModifiedDate))
                .ForMember(vm => vm.WorkspaceMappings, m => m.MapFrom(bd => bd.Workspace.Mappings))
                .ForMember(vm => vm.Enabled, m => m.MapFrom(bd => bd.Enabled));
        }
    }
}