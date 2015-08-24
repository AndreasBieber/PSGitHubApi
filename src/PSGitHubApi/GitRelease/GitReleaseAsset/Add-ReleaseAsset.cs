using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using JetBrains.Annotations;
using Octokit;

namespace PSGitHubApi
{
    [PublicAPI]
    public class AddReleaseAssetCmdlet: RepositoryBasedCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The id of the release",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2
            )]
        public int ReleaseId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The path to the filename",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public string Filename { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Content-type like application/zip",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        public string ContentType { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!File.Exists(Filename))
            {
                throw new FileNotFoundException(Filename);
            }

            Release release = GitHub.Release.Get(Owner, Repository, ReleaseId).Result;

            if (release == null)
            {
                WriteError(new KeyNotFoundException(ReleaseId.ToString()), ErrorCategory.ObjectNotFound);
                return;
            }

            var fileStream = File.OpenRead(Filename);
            var releaseAssetUpload = new ReleaseAssetUpload
            {
                ContentType = ContentType,
                FileName = Path.GetFileName(Filename),
                RawData = fileStream
            };

            WriteObject(GitHub.Release.UploadAsset(release, releaseAssetUpload).Result);
        }
    }
}
