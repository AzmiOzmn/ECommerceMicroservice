using Ecommerce.Discount.Context;
using Ecommerce.Discount.DTOs;
using Ecommerce.Discount.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController(AppDbContext context) : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var coupons = await context.Coupons.ToListAsync();
            var values = coupons.Select(c => new
            {
                CouponId = c.CouponId,
                Code = c.Code,
                DiscountRate = c.DiscountRate,
                ExpireDate = c.ExpireDate,
                ProductId = c.ProductId

            }).ToList();

            return Ok(values);


        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateCouponDto model)
        {
            var coupon = new Entities.Coupon
            {
                Code = model.Code,
                DiscountRate = model.DiscountRate,
                ExpireDate = model.ExpireDate,
                ProductId = model.ProductId
            };
            await context.AddAsync(coupon);
            await context.SaveChangesAsync();
            return Ok("Coupon created successfully");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var coupon = await context.Coupons.FindAsync(id);
            if (coupon is null)
            {
                return BadRequest("Coupon not found");
            }
            var value = new ResultCouponDto
            {
                CouponId = coupon.CouponId,
                Code = coupon.Code,
                DiscountRate = coupon.DiscountRate,
                ExpireDate = coupon.ExpireDate,
                ProductId = coupon.ProductId
            };
            return Ok(value);


        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var coupon = await context.Coupons.FindAsync(id);
            if (coupon is null)
            {
                return BadRequest("Coupon not found");
            }
            context.Remove(coupon);
            await context.SaveChangesAsync();
            return Ok("Coupon deleted successfully");
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateCouponDto model)
        {
            var coupon = new Coupon
            {
                CouponId = model.CouponId,
                Code = model.Code,
                DiscountRate = model.DiscountRate,
                ExpireDate = model.ExpireDate,
                ProductId = model.ProductId
            };
            if (coupon is null)
            {
                return BadRequest("Coupon not found");
            }


            context.Update(coupon);
            await context.SaveChangesAsync();
            return Ok("Coupon updated successfully");
        }
    }
}