using System;
using System.Collections.Generic;

namespace ShopOnlineApi.ModelsDTO;
public partial class ProductDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CategoryId { get; set; }

}