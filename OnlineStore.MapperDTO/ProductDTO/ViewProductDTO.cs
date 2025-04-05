using OnlineStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.MapperDTO.ProductDTO
{
    public class ViewProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }

        public required int CategoryId { get; set; }
        public required string CategoryName { get; set; }
    }
}
