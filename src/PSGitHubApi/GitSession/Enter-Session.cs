using System;
using System.Management.Automation;
using JetBrains.Annotations;
using Octokit;

namespace PSGitHubApi
{
    [PublicAPI]
    [Cmdlet(VerbsCommon.Enter, "GitHubSession")]
    public class EnterSessionCmdlet : BaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Your GitHub Token",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public string Token { get; set; }

        protected override void ProcessRecord()
        {
            GitHub.Connection.Credentials = new Credentials(Token);
            try
            {
                GitHub.User.Current().Wait();
                SessionState.PSVariable.Set("GITHUB_TOKEN", Token);
            }
            catch (AggregateException aex)
            {
                var apiError = aex.InnerException as AuthorizationException;

                if (apiError != null)
                {
                    throw apiError;
                }
            }
        }
    }
}
