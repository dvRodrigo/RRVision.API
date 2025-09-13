using Microsoft.AspNetCore.Http;

namespace RRVision.Application.Commands.v1.Dto
{
    public record ProcessFileRequest(IFormFile File, string Description);
}
