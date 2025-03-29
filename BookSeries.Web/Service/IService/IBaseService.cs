using BookSeries.Web.Models;
using BookSeries.Web.Models;

namespace BookSeries.Web.Service.IService
{
    public interface IBaseService
    {
        Task<Response?> SendAsync(Request request, bool withBearer = true);

    }
}
