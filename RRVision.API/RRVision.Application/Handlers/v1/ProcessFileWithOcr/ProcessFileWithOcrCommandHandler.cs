using MediatR;
using RRVision.Application.Commands.v1.ProcessFileWithOcr;
using Tesseract;

namespace RRVision.Application.Handlers.v1.ProcessFileWithOcr
{
    public class ProcessFileWithOcrCommandHandler : IRequestHandler<ProcessFileWithOcrCommand, string>
    {
        public Task<string> Handle(ProcessFileWithOcrCommand request, CancellationToken cancellationToken)
        {
            using (var engine = new TesseractEngine(@"..\RRVision.Application\tessdata\", "por", EngineMode.Default))
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
                        return text != null ? Task.FromResult(text) : Task.FromResult(string.Empty);
                    }
                }
            }
        }
    }
}
