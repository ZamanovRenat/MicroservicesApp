using System;
using System.Threading.Tasks;
using MicroservicesApp.Web.Models;

namespace MicroservicesApp.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
