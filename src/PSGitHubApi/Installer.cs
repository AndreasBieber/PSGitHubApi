using System.Management.Automation;
using JetBrains.Annotations;

namespace PSGitHubApi
{
    [PublicAPI]
    public class Installer : PSSnapIn
    {
        public override string Name { get; } = "PSGitHubApi";
        public override string Vendor { get; } = "Andreas Bieber";
        public override string Description { get; } = "";
    }
}
