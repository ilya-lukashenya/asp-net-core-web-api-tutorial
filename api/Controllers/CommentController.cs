using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepo) 
        {
            _commentRepo = commentRepo;
        }

        public async Task<IActionResult> GetAll() 
        {
            var comment = await _commentRepo.GetAllAsync();

            var CommentDto = comment.Select(s => s.ToCommentDto());

            return Ok(comment);
        }
    }

}