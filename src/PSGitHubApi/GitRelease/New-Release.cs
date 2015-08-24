using System.Management.Automation;
using JetBrains.Annotations;
using Octokit;

namespace PSGitHubApi
{
    [PublicAPI]
    [Cmdlet(VerbsCommon.New, "GitHubRelease")]
    public class NewReleaseCmdlet : ReleaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The tag to create the release from",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public string Tag { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var newRelease = new NewRelease(Tag) ;

            if (!string.IsNullOrEmpty(Title))
            {
                newRelease.Name = Title;
            }

            if (!string.IsNullOrEmpty(Description))
            {
                newRelease.Body = Description;
            }

            if (IsPrelease.HasValue)
            {
                newRelease.Prerelease = IsPrelease.Value;
            }

            if (IsDraft.HasValue)
            {
                newRelease.Draft = IsDraft.Value;
            }

            Release release = GitHub.Release.Create(Owner, Repository, newRelease).Result;
            WriteObject(release);
        }
    }
}
