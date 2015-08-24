using System;
using System.Management.Automation;
using Octokit;

namespace PSGitHubApi
{
    public abstract class AuthorizedCmdlet : BaseCmdlet
    {
        private string Token => SessionState.PSVariable.Get("GITHUB_TOKEN")?.Value?.ToString();

        protected override void ProcessRecord()
        {
            if (string.IsNullOrEmpty(Token))
            {
                WriteError(new ApplicationException("Please invoke Enter-GitHubSession."), ErrorCategory.AuthenticationError);
                return;
            }
            GitHub.Connection.Credentials = new Credentials(Token);
        }
    }
}
