using MediatR;
using RRVision.Application.Handlers.v1.ProcessFileWithOcr;

namespace RRVision.Application.Commands.v1.ProcessFileWithOcr
{
    public record ProcessFileBase64OcrCommand(string File) : IRequest<ProcessFileOcrCommandHandlerResponse>;
}
