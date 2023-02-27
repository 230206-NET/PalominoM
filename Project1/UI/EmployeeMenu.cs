using System; 
using DataAccess; 
using Services;

namespace UI;
/*
    This class is just to show employee menu
*/ 
public class EMenu{

    private readonly Account _acct; 
    private readonly TicketServices _service;
    
    //private readonly AcctService _aservice; 
    public EMenu(TicketServices service, Account acct){
        this._service = service;
        this._acct = acct;
    }

    public void Start(){
         while(true){
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("[1] Submit Ticket");   //add bold to font
            Console.WriteLine("[2] View Submitted Tickets");
            Console.WriteLine("[3] Log out");
            Console.WriteLine("[x] Exit");   

            string? input = Console.ReadLine();   //nullable reference
            switch(input){
                case "1":
                submitTicket(_acct.workId);
                continue;
                case "2":
                    getSubmittedTickets(_acct.workId);
                continue;
                case "3":  //change to char
                    Console.WriteLine("Going back to start of program");
                break;
                case "x":
                    System.Environment.Exit(0);
                break;
            }
            break;
        }
    }

    /*
        Submits ticket for reimbursment review
    */
    private void submitTicket(int id){

        while(true){
            Console.WriteLine("Please enter amount:");
            string? amt = Console.ReadLine();
            Console.WriteLine("Please enter description of expense");
            string? des = Console.ReadLine();
            if(decimal.TryParse(amt, out decimal amtd)){
                if(_service.submitTicket(amtd,id, des)){
                    Console.WriteLine("Succefully submitted ticket.");
                }
            }
            
            Console.WriteLine("Want to submit another ticket for reimbursement? [Y/N]");
            string ? ans = Console.ReadLine();
            if(ans is not null) if(ans.ToLower()[0]  == 'n') break;
                 
        }

    }

    /*
        - Returns list of tickets submitted by user
    */
    private void getSubmittedTickets(int id){
        if(_service.GetAllTickets(id) is null){
            Console.WriteLine("No tickets to show.");
        }
        foreach(Ticket t in _service.GetAllTickets(id)){
            Console.WriteLine(t.ToString());
        };
    }
}