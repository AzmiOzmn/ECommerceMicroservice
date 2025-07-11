﻿using ECommerce.Catalog.DTOs.CategoryDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Services.CategoryServices;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {

            var category = categoryDto.Adapt<Category>();
            await categoryService.CreateAsync(category);
            return Ok(category);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(string id)
        {
            var category = await categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return BadRequest("Category not found");
            }
            return Ok(category);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {
            var category = categoryDto.Adapt<Category>();
            await categoryService.UpdateAsync(category);
            return Ok("Category updated successfuly");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {

            await categoryService.DeleteAsync(id);
            return Ok("Kategori Başarıyla Silindi");
        }

        


    }
}
