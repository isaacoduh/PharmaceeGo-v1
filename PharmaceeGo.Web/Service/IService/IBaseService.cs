using PharmaceeGo.Web.Models;

namespace PharmaceeGo.Web.Service.IService;

public interface IBaseService
{
    Task<ResponseDto?> SendAsync(RequestDto requestDto);
}