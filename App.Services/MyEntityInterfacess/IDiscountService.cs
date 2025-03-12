using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IDiscountService
    {
        Task AddDiscount(DiscountEntity discount);
        Task<DiscountEntity> GetDiscountById(int id);
        Task<IEnumerable<DiscountEntity>> GetDiscounts();
        Task UpdateDiscount(DiscountEntity discount);
        Task DeleteDiscountById(int id);
    }
}
