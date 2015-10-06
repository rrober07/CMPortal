using Heroic.AutoMapper;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using Rma.CMPortal.WebUi.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Rma.CMPortal.WebUi.AutoMapperConfig), "Configure")]

namespace Rma.CMPortal.WebUi
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            //NOTE: By default, the current project and all referenced projects will be scanned.
            //		You can customize this by passing in a lambda to filter the assemblies by name,
            //		like so:
            HeroicAutoMapperConfigurator.LoadMapsFromCallerAndReferencedAssemblies(x => x.Name.StartsWith("Rma."));
            //HeroicAutoMapperConfigurator.LoadMapsFromCallerAndReferencedAssemblies();

            
        }
    }
}