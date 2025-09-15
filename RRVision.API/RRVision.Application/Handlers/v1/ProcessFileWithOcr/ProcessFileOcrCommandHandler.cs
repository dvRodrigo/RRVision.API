using MediatR;
using Tesseract;
using RRVision.Application.Handlers.v1.Base;
using RRVision.Application.Commands.v1.ProcessFileWithOcr;

namespace RRVision.Application.Handlers.v1.ProcessFileWithOcr
{
    public class ProcessFileOcrCommandHandler : BaseProcessFileOcr, IRequestHandler<ProcessFileOcrCommand, ProcessFileOcrCommandHandlerResponse>
    {
        public async Task<ProcessFileOcrCommandHandlerResponse> Handle(ProcessFileOcrCommand request, CancellationToken cancellationToken)
        {
            using (var engine = CreateTesseractEngine())
            {
                using var memoryStream = new MemoryStream();
                request.File.CopyTo(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();
                using (var img = Pix.LoadFromMemory(fileBytes))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();
                        Console.WriteLine($"Texto detectado: {text}");
                        return await BuildResponseAsync(text);
                    }
                }
            }
        }

    }
}
