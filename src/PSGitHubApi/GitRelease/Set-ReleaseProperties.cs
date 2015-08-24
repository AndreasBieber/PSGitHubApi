using System.Management.Automation;
using JetBrains.Annotations;
using Octokit;

namespace PSGitHubApi
{
    [PublicAPI]
    [Cmdlet(VerbsCommon.Set, "GitHubReleaseProperties")]
    public class SetReleasePropertiesCmdlet : ReleaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The id of the release",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2
            )]
        public int ReleaseId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var releaseUpdate = new ReleaseUpdate();

            bool isDirty = false;

            if (!string.IsNullOrEmpty(Title))
            {
                releaseUpdate.Name = Title;
                isDirty = true;
            }

            if (!string.IsNullOrEmpty(Description))
            {
                releaseUpdate.Body = Description;
                isDirty = true;
            }

            if (IsPrelease.HasValue)
            {
                releaseUpdate.Prerelease = IsPrelease.Value;
                isDirty = true;
            }

            if (IsDraft.HasValue)
            {
                releaseUpdate.Draft = IsDraft.Value;
                isDirty = true;
            }

            if (isDirty)
            {
                var result = GitHub.Release.Edit(Owner, Repository, ReleaseId, releaseUpdate).Result;
                WriteObject(result);
                return;
            }

            WriteVerbose("Nothing to update.");
        }
    }
}
