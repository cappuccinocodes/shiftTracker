using System;
using System.Collections.Generic;
using AutoMapper;
using cappuccino.shifttracker.Models;
using Cappuccino.Shifttracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace cappuccino.shifttracker.Controllers
{
    [ApiController] // Provides resources to help development
    [Route("api/shifts")]
    // [Route("api/categories/{categoryId}/shifts")]
    public class ShiftsController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ShiftsController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ??
            throw new ArgumentNullException(nameof(categoryRepository));

            _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()] 
        public ActionResult<IEnumerable<CategoryDto>> GetShifts()
        {
            var shiftsForCategoryFromRepo = _categoryRepository.GetShifts();

            return Ok(shiftsForCategoryFromRepo);
        }

        [HttpGet()] 
        public ActionResult<IEnumerable<CategoryDto>> GetShiftsByDate(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return GetShifts();
            }
            
            var shiftsForCategoryFromRepo = _categoryRepository.GetShifts();

            return Ok(shiftsForCategoryFromRepo);
        }

        // [HttpGet()] 
        // public ActionResult<IEnumerable<CategoryDto>> GetShiftsForCategory(int categoryId)
        // {
        //     if (!_categoryRepository.CategoryExists(categoryId))
        //     {
        //         return NotFound();
        //     }

        //     var shiftsForCategoryFromRepo = _categoryRepository.GetShifts(categoryId);

        //     return Ok(_mapper.Map<IEnumerable<ShiftDto>>(shiftsForCategoryFromRepo));
        // }

        [HttpGet("{shiftId}")] 
        public ActionResult<IEnumerable<CategoryDto>> GetShiftForCategory(int categoryId, int shiftId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
            {
                return NotFound();
            }
            
            var shiftForCategoryFromRepo = _categoryRepository.GetShift(categoryId, shiftId);

            if (shiftForCategoryFromRepo == null) 
            { 
                return NotFound();
            }

            return Ok(_mapper.Map<ShiftDto>(shiftForCategoryFromRepo));
        }
    }
}