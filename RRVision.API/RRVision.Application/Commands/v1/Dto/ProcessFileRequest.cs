using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RRVision.Application.Commands.v1.Dto
{
    public class ProcessFileRequest
    {
        [Required]
        public IFormFile File { get; set; }
        public string Description { get; set; }
    }
}
