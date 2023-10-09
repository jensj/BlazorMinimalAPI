using BlazorMinimalApis.Lib.Routing;

namespace BlazorMinimalApis.Endpoints.Pages.Home;

public class HomeHandler : PageHandler
{
    public IResult Index()
    {
        return Page<Home>();
    }

    public IResult RandomNumber()
    {
        return Page<RandomNumber>(new { Num = new Random().Next() });
    }
}