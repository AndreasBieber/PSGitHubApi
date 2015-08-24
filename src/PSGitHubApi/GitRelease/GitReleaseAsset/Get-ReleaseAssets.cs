using System.Management.Automation;
using JetBrains.Annotations;

namespace PSGitHubApi
{
    [PublicAPI]
    [Cmdlet(VerbsCommon.Get, "GitHubReleaseAssets", DefaultParameterSetName = "AllAssets")]
    public class GetReleaseAssetsCmdlet: RepositoryBasedCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "The id of the asset",
           ValueFromPipeline = true,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = "ByAssetId"
           )]
        public int? AssetId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The id of the release to get the assets from",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "AllAssets"
            )]
        public int? ReleaseId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (AssetId.HasValue)
            {
                WriteObject(GitHub.Release.GetAsset(Owner, Repository, AssetId.Value).Result);
            }
            else if (ReleaseId.HasValue)
            {
                WriteObject(GitHub.Release.GetAllAssets(Owner, Repository, ReleaseId.Value).Result);
            }
        }
    }
}
