using System;
using System.Collections.Concurrent;
using System.IO;

namespace Backend.Services;

public class QuillService
{
	private string? _jsonDocument;
	private ConcurrentDictionary<string, (byte[] Data, string ContentType)> _images = new();

	public string? LoadDocument()
	{
		return _jsonDocument;
	}
	public void SaveDocument ( string jsonString )
	{
		_jsonDocument = jsonString;
	}

	public string UploadImage ( Stream stream, long Length, string contentType )
	{
		var id = Guid.NewGuid().ToString();

		using var ms = new MemoryStream();
		stream.CopyTo(ms);

		_images.TryAdd(id, (ms.ToArray(), contentType));

		return id;
	}

	public (Stream Data, string ContentType)? GetImage(string id)
	{
		if (!_images.TryGetValue(id, out var imageData))
			return null;

		var ms = new MemoryStream(imageData.Data);
		return (ms, imageData.ContentType);
	}
}
