using MediatR;
using Microsoft.AspNetCore.Http;
using RRVision.Application.Handlers.v1.ProcessFileWithOcr;

namespace RRVision.Application.Commands.v1.ProcessFileWithOcr
{
    public record ProcessFileOcrCommand(IFormFile File) : IRequest<ProcessFileOcrCommandHandlerResponse>;
}
