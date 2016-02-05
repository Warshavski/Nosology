using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Nosology.MVP.Presentation.ModelView
{
    public sealed class TemplateFileMV
    {
        private string _title;
        public string Title { get { return _title; } }

        private string _link;
        public string Link { get { return _link; } }

        private string _description;
        public string Description { get { return _description; } }

        private string _icon;
        public string Icon { get { return _icon; } }

        public TemplateFileMV()
        {
        
        }

        public TemplateFileMV(string title, string link, string description, string icon)
        {
            _title = title;
            _link = link;
            _description = description;
            _icon = icon;
        }
    }
}
