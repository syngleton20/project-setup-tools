using System.IO;
using UnityEditor;
using UnityEngine;

namespace syngleton.ProjectSetupTools
{
    public sealed class DirectoryTools
    {
        private static void CreateDirectories(string root, params string[] directories)
        {
            string fullpath = Path.Combine(Application.dataPath, root);
            foreach (string newDirectory in directories) Directory.CreateDirectory(Path.Combine(fullpath, newDirectory));
        }

        [MenuItem("Tools/Setup/Create Default Folders", false, 10)]
        public static void CreateDefaultFolders()
        {
            CreateDirectories("_Project", "Audio", "Animations", "Animators", "Materials", "Scenes", "Scripts", "Sprites", "Textures");
            AssetDatabase.Refresh();
        }
    }
}