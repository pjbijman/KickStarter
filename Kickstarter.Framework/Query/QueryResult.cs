using System;
using System.Collections.Generic;

namespace KickStarter.Framework.Query
{
    [Serializable]
    public class QueryResult<T>
    {
        public QueryResult()
        {
            Items = new List<T>();
        }

        public int TotalItems { get; set; }

        public IList<T> Items { get; set; }
    }
}