using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShopOnlineApi.ModelsSQL
{
    public partial class Category
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly? AddData { get; set; }
        public bool? Empty { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
