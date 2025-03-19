using System.Diagnostics;
using System.Threading.Tasks;
using App.Data.Entities;
using App.Data.MyDbContext;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models;
using App.eCommerce.Models.ViewModels.HomeControllerViewModels;
using App.eCommerce.Models.ViewModels.ProductViewModels;
using App.Eticaret.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.eCommerce.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ECommerceDbContext _dbContext;
        private readonly IMapper _mapper;

        public HomeController(ECommerceDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        //Anasayfa
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "Index";
            return View();
        }
        [Route("/about-us")]
        //Hakkımızda
        public IActionResult AboutUs()
        {
            ViewData["ActivePage"] = "AboutUs";
            return View();
        }
        //İletişim
        [Route("/contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["ActivePage"] = "Contact";
            return View();
        }

        [Route("/contact")]
        [HttpPost]
        public async Task<IActionResult> Contact([FromForm] NewContactFormMessageViewModel newContactMessage)
        {
            ViewData["ActivePage"] = "Contact";
            if (!ModelState.IsValid)
            {
                return View(newContactMessage);
            }
            var contactMessageEntity = _mapper.Map<ContactFormEntity>(newContactMessage);
            _dbContext.ContactForms.Add(contactMessageEntity);
            await _dbContext.SaveChangesAsync();
            ViewBag.SuccessMessage = "Mesajın başarıyla gönderildi.";
            return View();
        }

        [Route("/product/list")]
        [HttpGet]
        public IActionResult Listing()
        {
            
            ViewData["ActivePage"] = "Listing";
            // TODO: add paging support
            var products =  _dbContext.Products
                .Where(p => p.Enabled)
                .Select(p => _mapper.Map<ProductListingViewModel>(p))               
                .ToList();

            return View(products);
        }

        [Route("/product/{productId:int}/details")]
        [HttpGet]
        public async Task<IActionResult> ProductDetail([FromRoute] int productId)
        {
            ViewData["ActivePage"] = "ProductDetail";

            var productEntity = await _dbContext.Products
                .Include(p => p.Discount)
                .Include(p => p.Seller)
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)  // Kullanıcı bilgileri de çekilmeli!
                .Where(p => p.Enabled && p.Id == productId)
                .FirstOrDefaultAsync();

            if (productEntity == null)
            {
                return NotFound();
            }

            // AutoMapper ile dönüşüm
            var productViewModel = _mapper.Map<HomeProductDetailViewModel>(productEntity);

            // **Sadece onaylı yorumları ekle**
            productViewModel.Reviews = productEntity.Comments
                .Where(c => c.IsConfirmed) // Sadece onaylı yorumları al
                .Select(c => _mapper.Map<ProductReviewViewModel>(c))
                .ToArray();

            return View(productViewModel);
        }



    }
}
