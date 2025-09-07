using MediatR;
using Microsoft.AspNetCore.Http;

namespace RRVision.Application.Commands.v1.ProcessFileWithOcr
{
    public record ProcessFileWithOcrCommand(IFormFile File, string Description) : IRequest<string>;
}
