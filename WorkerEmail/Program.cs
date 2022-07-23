using WorkerEmail.Bus;
using WorkerEmail.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<EmailConsumer>();
builder.Services.Configure<CredenciaisConfig>(builder.Configuration.GetSection("CredenciaisConfig"));

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(builder =>
	{
		builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
	});
});

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();