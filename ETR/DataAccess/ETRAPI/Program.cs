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
app.Logger.LogInformation("The app started");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();

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
//get all accounts
app.MapGet("/accounts", ([FromServices] AccountServices service) => {
    return service.GetAllAccounts();
    });

//login account
app.MapGet("/login", ([FromQuery] string workerID, [FromQuery] string Password, [FromServices] AccountServices service) => {
        if(workerID != null && Password != null){
            return service.loginUser(workerID,Password);
        }
        return null;
});

//Create account
app.MapPost("createAccount", ([FromQuery] string firstname, [FromQuery] string lastname,
    [FromQuery] char JobPosition,[FromQuery] int workerID, [FromQuery] string Password, [FromServices] AccountServices service)=>{
    if(JobPosition != ' ' && workerID != 0 && Password != null){
        Account acct = new();
        acct.firstName = firstname;
        acct.lastName = lastname;
        acct.workerType = JobPosition;
        acct.workId = workerID;
        acct.password = Password;
        return Results.Created("/createAccount", service.newAccount(acct));
    }
    return Results.BadRequest("Inputs are not valid or account already exists");
    
});

//submit ticket
app.MapPost("/submitTicket",([FromQuery] int workerID, [FromQuery] decimal amount, [FromQuery] string description, TicketServices service) => {
    Ticket ticket = new(workerID, amount, description);
    return Results.Created("/submitTicket", service.submitTicket(ticket));
});

//promote or demote employees
app.MapPut("/reviseEmployee", ([FromQuery] int employeeID, [FromQuery] char promotePosition, AccountServices serv) => {
    return Results.Created("/reviseEmployee", serv.employeeRevision(employeeID, promotePosition) );
});


//get submitted tickets
app.MapGet("/employeeSubmittedTickets", ([FromQuery] int employeeID, TicketServices service) => {
    if(employeeID != 0){
        return service.GetAllTickets(employeeID);
    }
    return null;
});

//view pending tickets
app.MapGet("/pendingTickets",([FromServices] TicketServices service) => {
    return service.searchTicketByStatus('P');
});

//reject or accept ticket 
app.MapPut("/updateTicket",([FromQuery] int ticketID, [FromQuery] char status, [FromQuery] int managerID, TicketServices service) => {
    Ticket T = new Ticket();
    T.status = status;
    T.idTicket = ticketID;
    T.approveBy = managerID;
    return service.ticketRevision(T);
});

//create account

app.Run();
