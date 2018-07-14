

namespace SimpleMvc.Framework.Common
{
    using System.IO;

    public static class LocalPathInfo
    {
        public static string LocalPath { get; private set; }

        static LocalPathInfo()
        {
            LocalPath = GetLocalPath();
        }

        private static string GetLocalPath()
        {
            var path = Directory.GetCurrentDirectory();

            for (int i = 0; i < 4; i++)
            {
                path = Directory.GetParent(path).FullName;
            }

            return path;
        }
    }
}
