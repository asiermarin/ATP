namespace NCacheExample.Models
{
    using System.Collections.Generic;

    public class Book
    {
        public string Id { get; set; }

        public string Isbn { get; set; }

        public int Pages { get; set; }

#pragma warning disable SA1201 // Elements should appear in the correct order
        public List<string> Capitules = new List<string>();
#pragma warning restore SA1201 // Elements should appear in the correct order
    }
}
