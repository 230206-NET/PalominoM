using System; 
using Services;

namespace UI; 
/*
    This class is just to show manager menu
*/
public class MMenu{
    private readonly Account _acct; 
    private readonly TicketServices _service;
    
    //private readonly AcctService _aservice; 
    public MMenu(TicketServices service, Account acct){
        this._service = service;
        this._acct = acct;
    }

    public void Start(){
        while(true){
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("[1] View tickets that need approval");   //add bold to font
            Console.WriteLine("[2] Assess Employee"); 
            Console.WriteLine("[3] Log out");       //or exit system
            Console.WriteLine("[x] Exit");

            string? input = Console.ReadLine();   //nullable reference

            switch(input){
                case "1":
                    viewPendingTickets();
                continue;
                case "2":
                    employeeRevision();
                continue;
                case "3":
                break;
                case "x":
                    System.Environment.Exit(0);
                break;
            }
            break;
        }
    }


    private void viewPendingTickets(){
        int i = 1; 
        if(_service.searchTicketByStatus('P') is null){
            Console.WriteLine("No tickets to show.");
        }
        foreach(Ticket t in _service.searchTicketByStatus('P')){
                Console.WriteLine($"{i,-5}{t.ToString()}");
                Console.WriteLine(("").PadRight(50, '-'));
                i++;
                ticketApproval(t);
        }
        

    }

    private void ticketApproval(Ticket t){
        Console.WriteLine("Approve ticket? [Y/N]");
                string? type = Console.ReadLine();
                if(type is not null)
                if(type.ToLower()[0] == 'n'){
                    t.status = 'R';
                    t.approveBy = _acct.workId;
               } else if(type.ToLower()[0] == 'y'){
                    t.status = 'A';
                    t.approveBy = _acct.workId;
               } 
        _service.ticketRevision(t);
    }

    private void employeeRevision(){
        throw new NotSupportedException();
    }
}