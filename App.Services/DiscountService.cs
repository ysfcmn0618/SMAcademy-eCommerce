using App.Data.Entities;
using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IGenericRepository<DiscountEntity> _discountService;
        public DiscountService(IGenericRepository<DiscountEntity> genericRepository)
        {
            _discountService = genericRepository;
        }
        public async Task AddDiscount(DiscountEntity discount)
        {
            await _discountService.Add(discount);
        }

        public async Task DeleteDiscountById(int id)
        {
            await _discountService.Delete(id);
        }

        public async Task<DiscountEntity> GetDiscountById(int id)
        {
            return await _discountService.GetById(id);
        }

        public async Task<IEnumerable<DiscountEntity>> GetDiscounts()
        {
            return await _discountService.GetAll();
        }

        public async Task UpdateDiscount(DiscountEntity discount)
        {
            await _discountService.Update(discount);
        }
    }
}
