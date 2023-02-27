using UI; 
using Services; 
using DataAccess; 
using Serilog; 

/*
    - Look at Repo to see how to log
Download appropriate packages for serilog
dotnet add package serilog
dotnet add package serilog.sinks.console (for logging to console)
dotnet add package serilog.sinks.file (for logging to file)
*/  
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day)  //creates new logging file per day
    .CreateLogger();
try{
    Log.Information("Application Starting");
    
    IRepository repo = new DBRepository();
    //create service object with deep injection of repo object
    TicketServices tservice = new TicketServices(repo);
    AcctService aservice = new AcctService(repo);

    // How to inject dependencies upon instantiation
    // new MainMenu(new WorkoutService(new FileStorage())).Start();
    MainMenu menu = new MainMenu(tservice, aservice);
    menu.Start();

} catch(Exception ex){
    Log.Error("Something fatal happened, {0}", ex);
} finally{
    Log.CloseAndFlush();
}
    
