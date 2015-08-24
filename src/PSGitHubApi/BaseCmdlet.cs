using System;
using System.Management.Automation;
using Octokit;

namespace PSGitHubApi
{
    public abstract class BaseCmdlet: PSCmdlet
    {
        protected readonly IGitHubClient GitHub;

        protected BaseCmdlet()
        {
            GitHub = new GitHubClient(new ProductHeaderValue("PSGitHubApi"));
        }

        protected void WriteError(Exception exception, ErrorCategory category)
        {
            WriteError(new ErrorRecord(exception, "1", category, null));
        }
    }
}
