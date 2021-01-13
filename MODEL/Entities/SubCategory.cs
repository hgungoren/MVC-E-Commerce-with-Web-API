using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.CoreEntity;

namespace MODEL.Entities
{

    public class SubCategory : EntityRepository
    {
        public string SubCategoryName { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Product> Products { get; set; }

    }

}
