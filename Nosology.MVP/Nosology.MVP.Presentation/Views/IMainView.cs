﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escyug.Nosology.MVP.Presentation.Views
{
    public interface IMainView
    {
        event Action PageLoad;

        string TextBlock { set; }
    }
}
