using MediatR;
using RRVision.Application.Commands.v1.ProcessFileWithOcr;
using RRVision.Application.Handlers.v1.Base;
using System.Drawing;
using Tesseract;

namespace RRVision.Application.Handlers.v1.ProcessFileWithOcr
{
    public class ProcessFileBase64OcrCommandHandler : BaseProcessFileOcr, IRequestHandler<ProcessFileBase64OcrCommand, ProcessFileOcrCommandHandlerResponse>
    {
        public async Task<ProcessFileOcrCommandHandlerResponse> Handle(ProcessFileBase64OcrCommand request, CancellationToken cancellationToken)
        {
            using (var engine = CreateTesseractEngine())
            {
                var bytes = Convert.FromBase64String(request.File);
                using var memoryStream = new MemoryStream(bytes);
                using var image = new Bitmap(memoryStream);
                using (var img = Pix.LoadFromMemory(bytes))
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
