using ECommerce.Core.DataAccess.EntityFramework;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EFEntityFramework
{
    public class EFProductDal:EFEntityFrameworkRepositoryBase<Product,NorthwindContext>,IProductDal
    {
        public EFProductDal(NorthwindContext context)
         : base(context)
        {
        }
    }
}
