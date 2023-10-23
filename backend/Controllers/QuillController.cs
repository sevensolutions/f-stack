using Backend.ApiModel;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Backend.Controllers;

[ApiController]
[Route("api/quill")]
public class QuillController : ControllerBase
{
	private readonly ILogger<QuillController> _logger;
	private readonly QuillService _quillService;

	public QuillController(ILogger<QuillController> logger, QuillService quillService)
    {
        _logger = logger;
		_quillService = quillService;
    }

	[HttpGet]
	public IActionResult LoadDocument()
	{
		return Content(_quillService.LoadDocument(), "application/json");
	}

    [HttpPost]
    public async Task<IActionResult> SaveDocument()
    {
		string jsonString;
        using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
        {
            jsonString = await reader.ReadToEndAsync();
        }
		
		_quillService.SaveDocument(jsonString);

        return Ok(new {});
    }

	[HttpPost("upload-image")]
	public async Task<UploadQuillImageResponse> UploadImage([FromForm]IFormFile file)
	{
		await Task.Delay(2000);

		using var stream = file.OpenReadStream();

		var id = _quillService.UploadImage(stream, file.Length, file.ContentType);

		return new UploadQuillImageResponse()
		{
			Url = Url.Action(nameof(DownloadImage), new { id = id })!
		};
	}

	[HttpGet("images/{id}")]
	public IActionResult DownloadImage(string id)
	{
		var image = _quillService.GetImage(id);

		if (image is null)
			return NotFound();

		return File(image.Value.Data, image.Value.ContentType);
	}
}
