namespace CachingSimpleExample.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Key
    {
        public Guid Id { get; set; }

        public string KeyName { get; set; }

        public string Type { get; set; }
    }
}
