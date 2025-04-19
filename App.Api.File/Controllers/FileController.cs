using App.Data.Entities;
using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Api.File.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        private readonly IGenericRepository<ProductImageEntity> _repo;

        public FileController(IGenericRepository<ProductImageEntity> repo)
        {
            _repo = repo;
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        // 1. Dosya Yükleme
        /// <summary>
        /// Yüklenen dosyayı kaydeder.
        /// </summary>
        /// <param name="file">Yüklenecek dosya</param>
        /// <returns>Başarılı yanıt</returns>
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, int productId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya seçilmedi.");

            var filePath = Path.Combine(_storagePath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var existProduct = await _repo.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (existProduct != null)
            {
                existProduct.Url = filePath;
                await _repo.Update(existProduct);
                return Ok(new { message = "Dosya güncellendi.", fileName = file.FileName });
            }

            await _repo.Add(new ProductImageEntity
            {
                ProductId = productId,
                Url = filePath,
                CreatedAt = DateTime.Now
            });

            return Ok(new { message = "Dosya yüklendi.", fileName = file.FileName });
        }

        // 2. Dosya İndirme
        /// <summary>
        /// Mevcut dosyayı indirir.
        /// </summary>
        /// <param name="fileName">İndirilecek dosya</param>
        /// <returns>Başarılı yanıt</returns>
        [HttpGet("download/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            var filePath = Path.Combine(_storagePath, fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound("Dosya bulunamadı.");

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName);
        }
        /// <summary>
        /// Mevcut dosyayı siler.
        /// </summary>
        /// <param name="fileName">Silinecek dosya</param>
        /// <returns>Başarılı yanıt</returns>
        [HttpDelete("delete/{fileName}")]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            var filePath = Path.Combine(_storagePath, fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound("Dosya bulunamadı.");

            System.IO.File.Delete(filePath);
            var file = await _repo.GetAll();
            var afile = file.Where(p => p.Url == filePath).FirstOrDefault();
            if (afile == null)
                return NotFound("Veritabanında dosya bulunamadı.");

            //Veritabanından dosyayı silmeden önce product kullanılıyormu actifmi gibi bir kontrol daha gerekli diye düşünüyorum fakat su an direk silme işlemini gerçekleştiriyorum.

            await _repo.Delete(afile.Id);

            return Ok(new { message = "Dosya silindi.", fileName });
        }

        // 4. Tüm Dosyaları Listeleme
        /// <summary>
        /// Tüm dosyaların adını ve path ini döndürür.
        /// </summary>
        /// <returns>Başarılı yanıt</returns>
        [HttpGet("list")]
        public async Task<IActionResult> GetAllFiles()
        {
            // burdaki yaklaşımdaki amaç seed sahte dalar hazırlanırken eklenen dosyaların url lerini de dosya sistemimize eklemek amaçlanmıştır.Farklı dosya konumu işaret eden dataları da eklemektir.
            var productImages = await _repo.GetAll();
            var fileUrls = productImages.Select(p => p.Url).ToList();
            var files = Directory.GetFiles(_storagePath);
            var fileNames = files.Select(Path.GetFileName).ToList();
            fileNames.AddRange(fileUrls);
            return Ok(fileNames);
        }
        // 4. Tüm Dosyaları Listeleme
        /// <summary>
        /// Product a ait dosyaları döndürür
        /// </summary>
        /// /// <param name="productId">Product ın dosyaları</param>
        /// <returns>Başarılı yanıt</returns>
        [HttpGet("productFiles")]
        public async Task<IActionResult> GetProductFiles(int productId)
        {
            var productImages = await _repo.GetAllIncludingAsync(p => p.Product.Id == productId);

            if (productImages == null || !productImages.Any())
                return NotFound("Ürüne ait dosya bulunamadı.");
            var productFileUrls = productImages.Select(p => p.Url).ToList();

            return Ok(productFileUrls);
        }
    }
}
