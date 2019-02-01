using System;
using System.Collections.Generic;

namespace EntityModel
{
    public class ApiResult<T, V>
    {
        public T obj { get; set; }

        public List<V> rows { get; set; }

        public bool success { get; set; }

        public int count { get; set; }

        public string message { get; set; }
    }
}
