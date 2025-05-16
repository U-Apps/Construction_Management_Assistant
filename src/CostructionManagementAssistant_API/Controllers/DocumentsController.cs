using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionManagementAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController(IUnitOfWork unitOfWork) : ControllerBase
    {
    }
}
