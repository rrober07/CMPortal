using Microsoft.TeamFoundation.VersionControl.Client;
using Rma.ReleaseManager.TFSContainer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.TeamFoundation.Build.Client;
using Rma.CMPortal.WebUi.Models;


namespace Rma.CMPortal.WebUi.Data
{
    public class TfsContext
    {
        #region local variables

        private static List<TfsBranchViewModel> _listOfBranchesVM = new List<TfsBranchViewModel>();
        private static List<BranchObject> _listOfBranchesObj = new List<BranchObject>();
        private static List<TfsBuildDefViewModel> _buildDefVmList = new List<TfsBuildDefViewModel>();
        private static string _urlString = "http://rmapp08bv1:8080/tfs/defaultcollection ";

        #endregion local variables

        #region Contructors

        private TfsContext() { }

        public static TfsContext CreateTFSContext()
        {
            return new TfsContext();
        }

        #endregion Contructors

        public IEnumerable<TfsBuildDefViewModel> GetTfsBuildDef()
        {
            //Initialize();

            using (var tfs = TfsRequestContainer.CreateTfsRequestContainer(_urlString))
            {
                var buildServer = (IBuildServer)tfs.ProjectCollection.GetService<IBuildServer>();
                VersionControlServer vcs = tfs.ProjectCollection.GetService<VersionControlServer>();
                var teamProjects = new List<TeamProject>(vcs.GetAllTeamProjects(false));


                foreach (TeamProject tp in teamProjects)
                {
                    var bld = buildServer.QueryBuildDefinitions(tp.Name).ToList();
                    _buildDefVmList.AddRange(AutoMapper.Mapper.Map<List<IBuildDefinition>, List<TfsBuildDefViewModel>>(bld));
                }

            }
            return _buildDefVmList;
        }

        public IEnumerable<TfsBranchViewModel> GetTfsBranches()
        {

           // Initialize();

            using (var tfs = TfsRequestContainer.CreateTfsRequestContainer(_urlString))
            {
                VersionControlServer vcs = tfs.ProjectCollection.GetService<VersionControlServer>();
                var bos = vcs.QueryRootBranchObjects(RecursionType.OneLevel);
                Array.ForEach(bos, (bo) => LoadBranchObjects(bo, vcs, false));

                _listOfBranchesVM = AutoMapper.Mapper.Map<List<BranchObject>, List<TfsBranchViewModel>>(_listOfBranchesObj);

            }
            return _listOfBranchesVM;
        }


        #region private helpers
        private void LoadBranchObjects(BranchObject bo, VersionControlServer vcs, bool isDeleted)
        {
            if (bo.Properties.RootItem.IsDeleted == isDeleted)
                _listOfBranchesObj.Add(bo);

            var childBos = vcs.QueryBranchObjects(bo.Properties.RootItem, RecursionType.OneLevel);
            foreach (var child in childBos)
            {
                if (child.Properties.RootItem.Item == bo.Properties.RootItem.Item)
                    continue;

                LoadBranchObjects(child, vcs, isDeleted);
            }
        }

        private void Initialize()
        {
            AutoMapper.Mapper.CreateMap<BranchObject, TfsBranchViewModel>()
                .ForMember(vm => vm.Project, m => m.MapFrom(bo => bo.Properties.RootItem.Item.Substring(0, bo.Properties.RootItem.Item.IndexOf('/', 2))))
                .ForMember(vm => vm.IsDeleted, m => m.MapFrom(bo => bo.Properties.RootItem.IsDeleted))
                .ForMember(vm => vm.Branch, m => m.MapFrom(bo => bo.Properties.RootItem.Item.Replace(bo.Properties.RootItem.Item.Substring(0, bo.Properties.RootItem.Item.IndexOf('/', 2)), "")))
                .ForMember(vm => vm.Version, m => m.MapFrom(bo => (bo.Properties.RootItem.Version as ChangesetVersionSpec).ChangesetId))
                .ForMember(vm => vm.Owner, m => m.MapFrom(bo => bo.Properties.Owner))
                .ForMember(vm => vm.Parent, m => m.MapFrom(bo => bo.Properties.ParentBranch != null ? bo.Properties.ParentBranch.Item.Replace(bo.Properties.RootItem.Item.Substring(0, bo.Properties.RootItem.Item.IndexOf('/', 2)), "") : ""));

            AutoMapper.Mapper.CreateMap<IBuildDefinition, TfsBuildDefViewModel>()
                .ForMember(vm => vm.LastModifiedBy, m => m.MapFrom(bd => bd.Workspace.LastModifiedBy))
                .ForMember(vm => vm.LastModifiedDate, m => m.MapFrom(bd => bd.Workspace.LastModifiedDate))
                .ForMember(vm => vm.WorkspaceMappings, m => m.MapFrom(bd => bd.Workspace.Mappings))
                .ForMember(vm => vm.Enabled, m => m.MapFrom(bd => bd.Enabled));

        }

        #endregion private helpers

    }
}