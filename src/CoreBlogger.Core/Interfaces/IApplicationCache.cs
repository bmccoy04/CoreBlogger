using System;
using System.Collections.Generic;
using CoreBlogger.Core.Models;

namespace CoreBlogger.Core.Interfaces
{
    public interface IApplicationCacheProvider
    {
        object Get(string key);
        void Insert(string key, object items, DateTime experation);
    }
}