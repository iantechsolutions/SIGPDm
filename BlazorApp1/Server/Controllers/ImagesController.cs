using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ImagesController> _logger;

        public ImagesController(IWebHostEnvironment env, ILogger<ImagesController> logger)
        {
            _env = env;
            _logger = logger;
        }

        private string GetImagePath(string fileName) =>
            Path.Combine(_env.WebRootPath, "imagenes", fileName);

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file, [FromQuery] string fileName = "organigrama.png")
        {
            fileName ??= "organigrama.png";
            if (file == null || file.Length == 0)
            {
                _logger.LogError("El archivo no fue enviado o está vacío.");
                return BadRequest(new { Message = "No se subió ningún archivo." });
            }

            var filePath = GetImagePath(fileName);

            try
            {
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    _logger.LogInformation("Archivo existente eliminado: {FilePath}", filePath);
                }

                await using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                _logger.LogInformation("Imagen subida correctamente: {FilePath}", filePath);
                return Ok(new { Message = "Imagen subida exitosamente.", FilePath = filePath });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al subir la imagen: {Message}", ex.Message);
                return StatusCode(500, new { Message = "Error interno al subir la imagen.", Details = ex.Message });
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteImage([FromQuery] string fileName = "organigrama.png")
        {
            var filePath = GetImagePath(fileName);

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    _logger.LogInformation("Imagen eliminada correctamente: {FilePath}", filePath);
                    return Ok(new { Message = "Imagen eliminada exitosamente." });
                }

                _logger.LogWarning("El archivo no existe: {FilePath}", filePath);
                return NotFound(new { Message = "Imagen no encontrada." });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al eliminar la imagen: {Message}", ex.Message);
                return StatusCode(500, new { Message = "Error al eliminar la imagen." });
            }
        }
    }
}
