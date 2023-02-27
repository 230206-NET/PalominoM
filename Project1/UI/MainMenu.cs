using System; 
using DataAccess; 
using Services;

namespace UI;

/*Input authontication is done in UI*/
public class MainMenu{

    private readonly TicketServices _service; 
    private readonly AcctService _aservice; 
    public MainMenu(TicketServices service, AcctService aservice){
        this._service = service;
        this._aservice = aservice;
        
    }

    public void Start(){
        //Display Menu 
        Console.WriteLine("Welcome to Reimbursment System");

        while(true){
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("[1] Login");   //add bold to font
            Console.WriteLine("[2] Create account"); 
            Console.WriteLine("[x] Exit"); 

            string? input = Console.ReadLine();   //nullable reference
            char logintype = 'N';
            Account? acct = new();

            switch(input){
                case "1":         //Login user 
                    acct = loginUser();
                    if(acct is not null)
                    logintype = acct.workerType;
                break;
                case "2":         //create new account
                    acct = createAccount();
                    logintype = acct.workerType;
            
                break;
                case "x":         //create new account
                    System.Environment.Exit(0);
                break;
                default:       
                    Console.WriteLine("Please enter valid input");
                break;
            } 

            switch(logintype){
                case 'M':
                    if(acct is not null)
                    managerMenu(acct);
                break; 
                case 'E':
                    if(acct is not null)
                    employeeMenu(acct);
                    
                break;
            }
        }
        
    }

    /*
        This method creates new account. It validates input and creates new Account object
        to be added to db.
    */
    private Account createAccount(){
        Console.WriteLine("Creating Account");
        Account newAccount = new Account(); 

        Console.WriteLine("Are you a Manager? [Y/N]");
        string? type = Console.ReadLine();
        if(type is not null)
        if(type.ToLower()[0] == 'n')
         {
            newAccount.workerType = 'E';
         } else if(type.ToLower()[0] == 'y') {
            newAccount.workerType = 'M';
         }

        Console.WriteLine("Please enter your employee ID:");

        if(Int32.TryParse(Console.ReadLine(), out int WID)){
            newAccount.workId = WID;
        }

        while(true){
            Console.WriteLine("Please enter password");
            string? pwd = Console.ReadLine();
            try{
                newAccount.password = pwd;  //need to add password parameters in Account later
                break;
            } catch (ArgumentException ex){  //add exception file later
                Console.WriteLine(ex.Message);
                continue;
            }
        }

        //create account
        try{
            if( _aservice.newAccount(newAccount)){
                Console.WriteLine("Succesfully created account.");
                return newAccount;
            }

        }catch(Exception){
            Console.WriteLine("Something went wrong with SQL");
        }
        
        return newAccount;
    }

    /*This function does the login. Needs to verify account exists. If succesful, then pulls menus depending on employee type.*/
    private Account? loginUser(){
        Console.WriteLine("Please enter login information.");
        Console.WriteLine("WorkerID:");
        string? id = Console.ReadLine();
        Console.WriteLine("Password:");
        string? pwd = Console.ReadLine();
        //call account service
        return _aservice.loginUser(id,pwd);
    }


    /*This method calls MMenu */
    private void managerMenu(Account acct){
        MMenu mm = new MMenu(_service,acct);
        mm.Start();
    }


    /*This method calls employee Menu*/
    private void employeeMenu(Account acct){
        EMenu em = new EMenu(_service,acct);
        em.Start();
    }
}