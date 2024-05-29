using BE_ABC.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;
using BE_ABC.AppSettings;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using BE_ABC.Middlewares;
using BE_ABC.Services;
using BE_ABC.Services.GenericService;
using BE_ABC.Models.ErdModel;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using BE_ABC.Services.StorageService;
using BE_ABC.Models.ErdModels;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    ConfigureServices(builder.Services);

    var app = builder.Build();

    ConfigureMiddleware(app);

    app.Run();

    #region config Service
    void ConfigureServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureOptions<ConfigureSwaggerOptions>();
        //add service repository
        services.AddTransient(typeof(GenericService<>), typeof(GenericService<>));

        services.AddScoped<DbContext, MyDbContext>();

        //business
        
        
        //service
        services.AddScoped<UserService, UserService>();
        services.AddScoped<PostTypeService, PostTypeService>();
        services.AddScoped<PostCommentService, PostCommentService>();
        services.AddScoped<PostLikeService, PostLikeService>();
        services.AddScoped<RequestTypeService, RequestTypeService>();
        services.AddScoped<DepartmentService, DepartmentService>();
        services.AddScoped<PostService, PostService>();
        services.AddScoped<ResourceTypeService, ResourceTypeService>();
        services.AddScoped<ResourceService, ResourceService>();
        services.AddScoped<ResourceUsingService, ResourceUsingService>();
        services.AddScoped<EventService, EventService>();

        services.AddSingleton<DriveService>(sp =>
        {
            var credentialsPath = "./credentials.json";
            using var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read);
            var credentials = GoogleCredential.FromStream(stream).CreateScoped(DriveService.Scope.DriveFile);
            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "BE_ABC"
            });
        });

        builder.Services.AddSingleton<GoogleDriveService>();

        services.AddDbContext<MyDbContext>(option =>
        {
            //local run
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            //docker container run
            //var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            //var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            //var dbPass = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");
            //var connectionString = $"Server={dbHost};Port=3306;Database={dbName};Uid=root;Pwd={dbPass};";
            option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }, ServiceLifetime.Scoped);

        ////cors
        services.AddCors(p => p.AddPolicy("MyCors", build =>
        {
            build.WithOrigins("*").AllowAnyHeader().AllowAnyHeader();
        }));

        services.Configure<IISServerOptions>(option =>
        {
            option.AllowSynchronousIO = true;
        });

        // Invoking action filters to validate the model state for all entities received in POST and PUT requests
        // https://code-maze.com/aspnetcore-modelstate-validation-web-api/
        services.AddScoped<ValidationFilterAttribute>();
        services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        builder.Host.ConfigureAppSettings();
        services
            .AddControllers()
            .AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddApiVersioning(option =>
        {
            option.AssumeDefaultVersionWhenUnspecified = true;
            option.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(0, 0);
            option.ReportApiVersions = true;
            option.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
    #endregion

    #region config middleware
    void ConfigureMiddleware(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

            dbContext.Database.Migrate();
        }

        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
            options.DocExpansion(DocExpansion.None);
        });
        app.UseDeveloperExceptionPage();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {

        }

        app.UseMiddleware<NotFoundMiddleware>();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseCors("MyCors");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
    #endregion

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}





