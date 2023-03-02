using System;

namespace Models;
/* MVP:
- As a user, I should be able to create a new account in the system
- As an employee, I should be able to submit reimbursement tickets
- As an employee, I should be able to view my previous submitted tickets
- As a user, I should be able to see and edit my profile
*/

public class Account{   //make to abstract, meaning I need to make abstract getters and setters for everything too
    public string? firstName{get; set;}   //change back to non-nullable later
    public string? lastName{get; set;} //change back to non-nullable later
    public string? password{get; set;} //change back to non-nullable later

    public int workId{get;  set;} 
    public char workerType{get; set;}
    
    public List<Ticket>? ticketList {get; set;}
    //constructor 
    public Account(){}

    public Account(string password, int workId){
        this.password = password;
        this.workId = workId;
    }

    //change this to recursive to send back string until list is empty 
    public List<Ticket>? displayTickets() => this.ticketList;

     public override string ToString(){
        return "Username: " + this.workId + "Name: " + firstName + " " + lastName +  "Position: " + this.workerType;
    }

}