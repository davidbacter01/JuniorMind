﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}
