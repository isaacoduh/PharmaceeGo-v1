using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmaceeGo.Web.Models;
using PharmaceeGo.Web.Service.IService;

namespace PharmaceeGo.Web.Controllers;

public class CouponController : Controller
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    public async Task<IActionResult> CouponIndex()
    {
        List<CouponDto>? couponList = new();
        ResponseDto? response = await _couponService.GetAllCouponsAsync();

        if (response != null && response.IsSuccess)
        {
            couponList = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
        }

        return View(couponList);
    }

    public async Task<IActionResult> CouponCreate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CouponCreate(CouponDto model)
    {
        if (ModelState.IsValid)
        {
            ResponseDto? response = await _couponService.CreateCouponsAsync(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(CouponIndex));
            }
        }

        return View(model);
    }
}