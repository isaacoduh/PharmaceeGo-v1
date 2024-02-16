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
}