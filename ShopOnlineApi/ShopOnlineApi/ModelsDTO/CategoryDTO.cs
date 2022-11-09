using System;
using System.Collections.Generic;

namespace ShopOnlineApi.ModelsDTO
{
    public partial class CategoryDTO
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly? AddData { get; set; }
        public bool? Empty { get; set; }

    }
}
