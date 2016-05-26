using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escyug.Nosology.Web.App.ViewModels
{
    public sealed class DocumentViewModel : BaseItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}