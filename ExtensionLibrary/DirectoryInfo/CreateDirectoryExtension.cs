using System.IO;

namespace ExtensionLibrary
{
    public static class CreateDirectoryExtension
    {
        /// <summary>
        /// Recursively create directory
        /// </summary>
        /// <param name="this">Folder path to create.</param>
        public static void CreateDirectory(this DirectoryInfo @this)
        {
            if (@this.Parent != null) CreateDirectory(@this.Parent);
            if (!@this.Exists) @this.Create();
        }
    }
}
