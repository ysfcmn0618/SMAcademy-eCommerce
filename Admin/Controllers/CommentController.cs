using App.Admin.Models.CommentViewModel;
using App.Data.Entities;
using App.Data.MyDbContext;
using App.DbServices.MyEntityInterfacess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Admin.Controllers
{
    public class CommentController : Controller
    {
        private readonly BaseDbService<ProductCommentEntity> _dbContext;
        private readonly IMapper _mapper;

        public CommentController(BaseDbService<ProductCommentEntity> productCommentService, IMapper mapper)
        {
            _dbContext = productCommentService;
            _mapper = mapper;
        }
        [Route("/comment")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var commentList = await _dbContext.GetAll();
            var mappingList = _mapper.Map<IEnumerable<CommentViewModel>>(commentList);
            return View(mappingList);
        }

        [Route("/comment/{commentId:int}/approve")]
        [HttpPost]
        public async Task<IActionResult> Approve([FromRoute] int commentId)
        {
            var comment = await _dbContext.GetById(commentId);
            comment.IsConfirmed = false;
            await _dbContext.Update(comment);

            return RedirectToAction(nameof(List));
        }
    }
}
