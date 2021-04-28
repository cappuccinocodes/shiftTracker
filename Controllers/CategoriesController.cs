using System;
using System.Collections.Generic;
using AutoMapper;
using cappuccino.shifttracker.Models;
using Cappuccino.Shifttracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace cappuccino.shifttracker.Controllers
{
    [ApiController] // Provides resources to help development
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ??
            throw new ArgumentNullException(nameof(categoryRepository));

            _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()] 
        public ActionResult<IEnumerable<CategoryDto>> GetCategories([FromQuery] string letter, string searchQuery)
        {
            //throw new Exception("TestException");
            var categoriesFromRepo = _categoryRepository.GetCategories(letter, searchQuery);
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categoriesFromRepo));
        }

        [HttpGet("{categoryId}")] 
        public IActionResult GetCategory(int categoryId)
        {
            var categoryFromRepo = _categoryRepository.GetCategory(categoryId);

            if (categoryFromRepo == null) 
            {
                return NotFound();
            }

            return Ok(categoryFromRepo);
        }
    }
}