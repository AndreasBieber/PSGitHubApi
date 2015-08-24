using System.Collections.Generic;
using System.Management.Automation;
using JetBrains.Annotations;
using Octokit;

namespace PSGitHubApi
{
    [PublicAPI]
    [Cmdlet(VerbsCommon.Get, "GitHubReleases")]
    public class GetReleasesCmdlet : AuthorizedCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The owner of the repository",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public string Owner { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the repository",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public string Repository { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The id of the release.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public int? Id { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var result = Id.HasValue ? new List<Release> { GitHub.Release.Get(Owner, Repository, Id.Value).Result } :
                                       GitHub.Release.GetAll(Owner, Repository).Result;

            WriteObject(result);
        }
    }
}
