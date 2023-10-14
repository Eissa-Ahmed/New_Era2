namespace New_Era.API.Controllers
{
    [ApiController]
    public class StudentController : BaseController
    {

        [HttpGet(Router.StudentRouter.GetAllAsync)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await mediator.Send(new StudentGetAllAsyncQuery());
            return resault(response);
        }
        [HttpGet(Router.StudentRouter.GetByIdAsync)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var response = await mediator.Send(new StudentGetByIdAsyncQuery(id));
            return resault(response);
        }
        [HttpPost(Router.StudentRouter.CreateAsync)]
        public async Task<IActionResult> CreateAsync(StudentCreateAsyncCommand model)
        {
            var response = await mediator.Send(model);
            return resault(response);
        }
        [HttpDelete(Router.StudentRouter.DeleteAsync)]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            var response = await mediator.Send(new StudentDeleteAsyncCommand(id));
            return resault(response);
        }
        [HttpPut(Router.StudentRouter.UpdateAsync)]
        public async Task<IActionResult> UpdateAsync(StudentUpdateAsyncCommand model)
        {
            var response = await mediator.Send(model);
            return resault(response);
        }

        [HttpGet(Router.StudentRouter.GetAllAsyncPagination)]
        public async Task<IActionResult> GetAllAsyncPagination1(int Page, int PageCount, string? Search)
        {
            var response = await mediator.Send(new StudentGetAllPaginationQuery(Page, PageCount, Search));
            return resault(response);
        }
    }
}
