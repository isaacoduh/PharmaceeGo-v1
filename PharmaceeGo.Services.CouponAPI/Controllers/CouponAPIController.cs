using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmaceeGo.Services.CouponAPI.Data;
using PharmaceeGo.Services.CouponAPI.Dto;
using PharmaceeGo.Services.CouponAPI.Models;

namespace PharmaceeGo.Services.CouponAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CouponAPIController: ControllerBase
{
    
    private readonly AppDbContext _db;
    private ResponseDto _response;
    private IMapper _mapper;

    private CouponAPIController(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _response = new ResponseDto();
        _mapper = mapper;
    }

    [HttpGet]
    public ResponseDto Get()
    {
        try
        {
            IEnumerable<Coupon> couponsList = _db.Coupons.ToList();
             _response.Result = _mapper.Map<IEnumerable<CouponDto>>(couponsList);
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.Message = e.Message;
        }

        return _response;
    }

    [HttpGet]
    [Route("{id:int}")]
    public ResponseDto Get(int id)
    {
        try
        {
            Coupon coupon = _db.Coupons.First(u => u.CouponId == id);
            _response.Result = _mapper.Map<CouponDto>(coupon);
        }
        catch (Exception e)
        {
            _response.Result = false;
            _response.Message = e.Message;
        }

        return _response;
    }
}