using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models; 
using Services;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options=>{
    options.SerializerOptions.PropertyNamingPolicy = null;
});

// Add services to the container.

// AddSingleton => The same instance is shared across the entire app over the lifetime of the application
// AddScoped => The instance is created every new request
// AddTransient => The instance is created every single time it is required as a dependency 
builder.Services.AddScoped<IRepository,DB2Repository>(ctx => new DB2Repository(builder.Configuration.GetConnectionString("EtrDB")));
builder.Services.AddScoped<TicketServices>();
builder.Services.AddScoped<AccountServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();

app.MapGet("/hello", (string? name) => "WELCOME TO ETRAPI"); //does not show up on swagger

// Query parameters don't get defined in the route it self, but you look for it in the argument/parameter of the lambda exp that is handling this request
app.MapGet("/greet", (string? name, string? region) => {
        if(string.IsNullOrWhiteSpace(name)) {
            return Results.BadRequest("Name must not be empty or white spaces");
        }
        else
        {
            return Results.Ok($"Hello {name ?? "humans"} from {region ?? "a mysterious location"}!");
        }
    }
);

// Route params
app.MapGet("/greet/{name}", (string name) => $"Hello {name} from route param!");

app.MapGet("/accounts", ([FromServices] AccountServices service) => {
    return service.GetAllAccounts();
    });

app.MapGet("/login", ([FromQuery] string id, [FromQuery] string pwd, [FromServices] AccountServices service) => {
        if(id != null && pwd != null){
            return service.loginUser(id,pwd);
        }
        return null;
});

app.Run();
