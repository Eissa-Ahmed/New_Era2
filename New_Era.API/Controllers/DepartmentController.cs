
namespace New_Era.API.Controllers
{
    [ApiController]
    public class DepartmentController : BaseController
    {
        [HttpGet(Router.DepartmentRouter.GetByIdAsync)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await mediator.Send(new DepartmentGetByIdQuery(id));
            return resault(res);
        }
        [HttpGet(Router.DepartmentRouter.GetAllAsync)]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await mediator.Send(new DepartmentGetAllAsyncQuery());
            return resault(res);
        }
    }
}
