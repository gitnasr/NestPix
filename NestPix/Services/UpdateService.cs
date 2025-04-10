using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace NestPix.Services
{
    internal class UpdateService
    {
        private readonly string ReleasesUrl = "https://api.github.com/repos/gitnasr/NestPix/releases/latest";
        private readonly string CurrentVersion = "v1.0.0";

        public string? LatestVersion { get; private set; }
        public string? LatestVersionUrl { get; private set; }

        private static readonly HttpClient client = new HttpClient();

        public UpdateService()
        {


        }
        public async Task CheckForUpdateAsync()
        {
            try
            {
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("NextPix", "1.0"));
                var response = await client.GetAsync(ReleasesUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(json);

                    LatestVersion = data["tag_name"]?.ToString();
                    LatestVersionUrl = data["html_url"]?.ToString();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error checking for updates", ex);
            }
        }
        public bool IsUpdateAvailable()
        {
            if (LatestVersion == null)
            {
                return false;
            }
            return !LatestVersion.Equals(CurrentVersion);
        }

        public string? DownloadUpdate()
        {

            return LatestVersionUrl;

        }

    }
}
