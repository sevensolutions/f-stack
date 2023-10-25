using Backend.Services;
using Backend.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<QuillService>();
builder.Services.AddSingleton<NotificationService>();

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

app.UseWebSockets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    System.Net.ServicePointManager.ServerCertificateValidationCallback += ( sender, cert, chain, sslPolicyErrors ) => true;

	app.UseSwagger();
	app.UseSwaggerUI();

	app.UseCors( config =>
	{
		config.AllowAnyMethod();
		//config.AllowAnyOrigin();
		config.AllowAnyHeader();
		config.SetIsOriginAllowed((host) => true);
        config.AllowCredentials();
		//config.WithExposedHeaders("Content-Disposition");
	} );
}

app.UseForwardedHeaders();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationsHub>("/signalr/notifications");
//app.MapHub<ChatHub>( "/signalr/chat" );
	//.RequireAuthorization();

app.Run();
