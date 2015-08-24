using System.Management.Automation;
using JetBrains.Annotations;

namespace PSGitHubApi
{
    [PublicAPI]
    public abstract class ReleaseCmdlet : RepositoryBasedCmdlet
    {
        [Parameter(
           Mandatory = false,
           HelpMessage = "The release title",
           ValueFromPipeline = true,
           ValueFromPipelineByPropertyName = true
           )]
        public string Title { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Description/changelog of the release",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public string Description { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Indicating whether the release will be shown as non-production ready or not",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public bool? IsPrelease { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Indicating whether the release is a draft or not.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public bool? IsDraft { get; set; }
    }
}
