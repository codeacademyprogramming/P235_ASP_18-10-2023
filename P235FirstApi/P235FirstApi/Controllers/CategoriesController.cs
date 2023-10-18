using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P235FirstApi.DataAccesslayer;
using P235FirstApi.DTOs.CategoriesDTOs;
using P235FirstApi.Entities;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace P235FirstApi.Controllers
{
    /// <summary>
    /// Category Services
    /// </summary>
    [Authorize(Roles ="Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Category Create Service P235
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Categories
        ///     {        
        ///       "name": "Elektronika",
        ///       "isMain": "true",
        ///       "image": "sekil1.jpg",
        ///       "parentId": "2"
        ///     }
        /// </remarks>
        /// <param name="categoryPostDTO"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Same Name Error</response>      
        /// <response code="409">Parent Id In Correct</response>      
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CategoryPostDTO categoryPostDTO)
        {
            string token = Request.Headers.Authorization.ToString().Split(' ')[1];

            JwtSecurityToken jwtTokjen = new JwtSecurityTokenHandler().ReadJwtToken(token);

            string email = jwtTokjen.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Email).Value;

            //if (categoryPostDTO.Image != null)
            //{
            //    string fileName = "";
            //}
            //Old Mapping
            //Category category = new Category
            //{
            //    Name = categoryPostDTO.Name.Trim(),
            //    IsMain = categoryPostDTO.IsMain,
            //    ParentId = categoryPostDTO.ParentId,
            //    Image = "sekil.jpg"
            //};

            //category.Name = category.Name.Trim();

            Category category = _mapper.Map<Category>(categoryPostDTO);
            category.CreatedBy = email;

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created,category.Id);
        }

        /// <summary>
        /// Get List Category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getlist")]
        public async Task<IActionResult> Get()
        {
            List<Category> categories = await _context.Categories
                .Include(c => c.Children.Where(c=>c.IsDeleted == false))
                .Where(c=>c.IsDeleted == false && c.IsMain).ToListAsync();

            List<CategoryListDTO> categoryListDTOs = _mapper.Map<List<CategoryListDTO>>(categories);

            return Ok(categoryListDTOs);
        }

        [HttpGet]
        [Route("getbyid/{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if(id == null) return BadRequest();

            Category category = await _context.Categories.Include(c => c.Children.Where(ch => ch.IsDeleted == false))
                .Where(c =>c.Id == id && c.IsDeleted == false).FirstOrDefaultAsync();

            if(category == null) return BadRequest();

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return Ok(categoryGetDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int? id,[FromForm] CategoryPutDTO categoryPutDTO)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            category.Name = categoryPutDTO.Name.Trim();
            category.IsMain = categoryPutDTO.IsMain;
            category.ParentId = categoryPutDTO.ParentId;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
