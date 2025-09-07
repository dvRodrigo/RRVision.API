using MediatR;
using RRVision.Application.Commands.v1.ProcessFileWithOcr;

namespace RRVision.Application.Handlers.v1.ProcessFileWithOcr
{
    public class ProcessFileWithOcrCommandHandler : IRequestHandler<ProcessFileWithOcrCommand, string>
    {
        public Task<string> Handle(ProcessFileWithOcrCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
