using System.Management.Automation;
using JetBrains.Annotations;

namespace PSGitHubApi
{
    [PublicAPI]
    public abstract class RepositoryBasedCmdlet : AuthorizedCmdlet
    {
        [Parameter(
             Mandatory = true,
             HelpMessage = "The owner of the repository",
             ValueFromPipeline = true,
             ValueFromPipelineByPropertyName = true,
             Position = 0
             )]
        public string Owner { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the repository",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1
            )]
        public string Repository { get; set; }
    }
}
