using System.Management.Automation;
using JetBrains.Annotations;

namespace PSGitHubApi
{
    [PublicAPI]
    [Cmdlet(VerbsCommon.Exit, "GitHubSession")]
    public class ExitSessionCmdlet : BaseCmdlet
    {
        protected override void ProcessRecord()
        {
            if (SessionState.PSVariable.Get("GITHUB_TOKEN") != null)
            {
                SessionState.PSVariable.Remove("GITHUB_TOKEN");
            }
        }
    }
}
