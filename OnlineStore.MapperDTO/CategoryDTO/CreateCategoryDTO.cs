using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.MapperDTO.CategoryDTO
{
    public class CreateCategoryDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
