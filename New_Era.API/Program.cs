var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddInfrastructureDependencyInjection(builder.Configuration)
    .AddApiDependencyInjection()
    .AddCoreDependencyInjection()
    .AddServicesDependencyInjection();

#region Localization
builder.Services.AddLocalization(opt => opt.ResourcesPath = "");
builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var listOfLanguage = new List<CultureInfo>(){
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG")

    };
    opt.DefaultRequestCulture = new RequestCulture("ar-EG");
    opt.SupportedCultures = listOfLanguage;
    opt.SupportedUICultures = listOfLanguage;

});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRequestLocalization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
