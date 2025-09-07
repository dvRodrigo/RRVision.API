using MediatR;
using Microsoft.AspNetCore.Mvc;
using RRVision.Application.Commands.v1.Dto;
using RRVision.Application.Commands.v1.ProcessFileWithOcr;

namespace RRVision.API.Controllers.v1
{
    [ApiController]
    [Route("api/ocr/")]
    public class RRVisionOCRController : ControllerBase
    {
        private readonly ILogger<RRVisionOCRController> _logger;
        private readonly IMediator _mediator;
        public RRVisionOCRController(ILogger<RRVisionOCRController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("process-file")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PostTextFile([FromForm] ProcessFileRequest request)
        {
            var command = new ProcessFileWithOcrCommand(request.File, request.Description);
            var result = await _mediator.Send(command);
            return Ok(new { Text = result });
        }
    }
}
