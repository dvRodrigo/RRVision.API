using RRVision.Application.Handlers.v1.ProcessFileWithOcr;
using Tesseract;

namespace RRVision.Application.Handlers.v1.Base
{
    public abstract class BaseProcessFileOcr
    {
        protected const string TESSDATA_PATH = @"..\RRVision.Application\tessdata\";
        protected const string TESSDATA_LANGUAGE = "por+eng+spa";
        protected Task<ProcessFileOcrCommandHandlerResponse> BuildResponseAsync(string? text)
        {
            var result = new ProcessFileOcrCommandHandlerResponse(text ?? string.Empty);
            return Task.FromResult(result);
        }

        protected virtual TesseractEngine CreateTesseractEngine()
        {
            return new TesseractEngine(TESSDATA_PATH, TESSDATA_LANGUAGE, EngineMode.Default);
        }
    }
}
