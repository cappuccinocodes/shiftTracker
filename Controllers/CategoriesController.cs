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
        public ActionResult<IEnumerable<CategoryDto>> GetCategories([FromQuery] CategoriesResourceParameters categoriesResourceParameters)
        {
            //throw new Exception("TestException");
            var categoriesFromRepo = _categoryRepository.GetCategories(categoriesResourceParameters);
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categoriesFromRepo));
        }

        [HttpGet("{categoryId}", Name = "GetAuthor")] 
        public IActionResult GetCategory(int categoryId)
        {
            var categoryFromRepo = _categoryRepository.GetCategory(categoryId);

            if (categoryFromRepo == null) 
            {
                return NotFound();
            }

            return Ok(categoryFromRepo);
        }

        [HttpPost]
        public ActionResult<CategoryDto> CreateCategory(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Entities.Category>(category);
            _categoryRepository.AddCategory(categoryEntity);
            _categoryRepository.Save();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
            return CreatedAtRoute("GetAuthor",
               new { categoryId = categoryToReturn.Id }, 
               categoryToReturn);
        }
    }
}