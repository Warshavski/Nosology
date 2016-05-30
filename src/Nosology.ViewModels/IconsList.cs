using System.Collections.Generic;

namespace Escyug.Nosology.ViewModels
{
    public sealed class IconsList
    {
        private static readonly Dictionary<string, string> _filesIcons = new Dictionary<string, string>()
        {
            {"pdf", "info_outline"},
            {"file", "insert_drive_file"}
        };

        public static string GetIconTypeName(string fileTypeName)
        {
            return _filesIcons[fileTypeName];
        }
    }
}