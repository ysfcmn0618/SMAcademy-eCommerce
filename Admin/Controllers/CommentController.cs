using App.Admin.Models.CommentViewModel;
using App.Data.MyDbContext;
using App.DbServices.MyEntityInterfacess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Admin.Controllers
{
    public class CommentController : Controller
    {
        private readonly IProductCommentService _dbContext;
        private readonly IMapper _mapper;

        public CommentController(IProductCommentService productCommentService, IMapper mapper)
        {
            _dbContext = productCommentService;
            _mapper = mapper;
        }
        [Route("/comment")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var commentList = await _dbContext.GetAllProductComments();
            var mappingList = _mapper.Map<IEnumerable<CommentViewModel>>(commentList);
            return View(mappingList);
        }

        [Route("/comment/{commentId:int}/approve")]
        [HttpPost]
        public async Task<IActionResult> Approve([FromRoute] int commentId)
        {
            var comment = await _dbContext.GetProductCommentById(commentId);
            comment.IsConfirmed = true;
            await _dbContext.UpdateProductComment(comment);

            return RedirectToAction(nameof(List));
        }
    }
}
