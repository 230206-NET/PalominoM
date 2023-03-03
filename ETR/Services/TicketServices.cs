using Models; 
using DataAccess;

namespace Services;

/*Dependency Injection: is a design pattern where the dependency of a class is injected 
through the constructor instead of the class itself having a specific knowledge 
of its dependency, or instantiating itself (instead of inheritng)*/

/*This method checks if ticket submission was approved*/
/*This method checks if account exists in database*/

public class TicketServices {
    private readonly IRepository _repo;      //private of repo interface

    //Implementationof dependecy injection. Needs Irepo to initialize class
    public TicketServices(IRepository repo){
        _repo = repo; 
    }

    //Method gets tickets by calling repo class. Practing abstraction
    public List<Ticket> GetAllTickets(int id){
        return _repo.GetAllTicketSubmissions(id);
    }

    //Business logic that is not UI or DataAcess, so a method that provides a service that 
    //does not belong to a specifi UI or DA, just a system service
    public List<Ticket> searchTicketByStatus(char status){
        List<Ticket> filtered = new List<Ticket>();
        //logic for filtering list to return list of desire status
        foreach(Ticket t in _repo.GetAllTickets()){
            if(t.status == 'P'){
                filtered.Add(t);
                //Console.WriteLine(t.ToString());
            } 
        }
        return filtered; 
    }

    /*
        - Calls dbrepo to submit ticket to db. 
        - checks info before sending to db 
    */
    public Ticket submitTicket(Ticket ticket){
        ticket.status = 'P';
        return _repo.SubmitTicket(ticket);
    }

    public Ticket ticketRevision(Ticket t){
        return _repo.updateTickets(t);
    }
}
