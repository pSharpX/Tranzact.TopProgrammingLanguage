using System;
using System.IO;

namespace Tranzact.TopProgrammingLanguage.UnitTest.Helpers
{
    public static class TestHelper
    {
        public static string SUCCESSFUL_GOOGLE_RESPONSE = "GoogleResponse.json";

        public static string SUCCESSFUL_BING_RESPONSE = "BingResponse.json";

        public static string GetContent(string file)
        {
            var filePath = Path.IsPathRooted(file) ? file: Path.GetRelativePath(Directory.GetCurrentDirectory(), $"{file}");
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"Could not find file at path: {filePath}");
            }
            return File.ReadAllText(filePath);
        }

    }
}
