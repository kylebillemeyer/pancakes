﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Caching
{
    public interface IResourceProvider<T>
    {
        T GetResource(string key);
        IEnumerable<Tuple<string, T>> GetResources();
        IEnumerable<T> GetResources(IEnumerable<string> keys);
    }
}
