namespace New_Era.API.Controllers.Base
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public ActionResult resault<T>(ResponseModel<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                case HttpStatusCode.Unauthorized:
                    return Unauthorized(response);
                case HttpStatusCode.UnprocessableEntity:
                    return UnprocessableEntity(response);

                default: return BadRequest(response);
            }
        }
    }
}
