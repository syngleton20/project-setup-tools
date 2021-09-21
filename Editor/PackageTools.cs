using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace syngleton.ProjectSetupTools
{
    public static class PackageTools
    {
        private static string GetGistURL(string id, string user = "syngleton20") => $"https://gist.githubusercontent.com/{user}/{id}/raw";

        [MenuItem("Tools/Setup/Load Default 2D Packages")]
        private static async void LoadDefault2DPackages()
        {
            string url = GetGistURL("7a34e69a48e025e17d46985142b6d6f8"), content = await GetContents(url);
            ReplacePackageFile(content);
        }

        [MenuItem("Tools/Setup/Load Default 3D Packages")]
        private static async void LoadDefault3DPackages()
        {
            string url = GetGistURL("507d4d807e37f3157a1eddbf4c04af49"), content = await GetContents(url);
            ReplacePackageFile(content);
        }

        private static void ReplacePackageFile(string content)
        {
            string existingPath = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            File.WriteAllText(existingPath, content);
            UnityEditor.PackageManager.Client.Resolve();
        }

        private static async Task<string> GetContents(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}