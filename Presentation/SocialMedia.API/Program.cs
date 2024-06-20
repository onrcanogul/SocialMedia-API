using SocialMedia.Application;
using SocialMedia.Infrastructure;
using SocialMedia.Infrastructure.Services.Storage.Azure;
using SocialMedia.Infrastructure.Services.Storage.Local;
using SocialMedia.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));
builder.Services.AddControllers();
builder.Services.AddStorage<AzureStorage>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
