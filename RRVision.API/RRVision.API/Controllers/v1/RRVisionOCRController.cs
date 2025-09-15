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

        [HttpPost("extract-text")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ExtractFromFile([FromForm] ProcessFileRequest request)
        {
            var command = new ProcessFileOcrCommand(request.File);
            var result = await _mediator.Send(command);
            return Ok(new { Text = result });
        }
        [HttpPost("extract-text-base64")]
        [Consumes("application/json")]
        public async Task<IActionResult> ExtractFromBase64(string base64)
        {
            var command = new ProcessFileBase64OcrCommand(base64);
            var result = await _mediator.Send(command);
            return Ok(new { Text = result });
        }
    }
}
