using Backend.Services;
using Backend.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<QuillService>();

builder.Services.AddProblemDetails( config =>
{
	// TODOPEI: Find a better way to do this...
	config.CustomizeProblemDetails = details =>
	{
		if ( details.ProblemDetails.Title == "Backend.Services.Security.SecurityService+BackendSecurityException" )
		{
			details.HttpContext.Response.StatusCode = 403;
			details.ProblemDetails.Status = 403;
			details.ProblemDetails.Title = "Forbidden";
		}
	};
} );

builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>( "/signalr/chat" );
	//.RequireAuthorization();

app.Run();
