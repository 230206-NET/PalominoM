using System;

namespace Models; 

public class Ticket{

    public Ticket(){}
    public Ticket(int sb, decimal amt, string description){
        this.description = description;
        this.amount = amt; 
        this.submittedBy = sb;
    }

    public string? type {get; set; } //change back to non-nullable later
    public string? description {get; set; } //change back to non-nullable later
    public decimal amount {get; set; }

    public int submittedBy {get; set; }

    public int approveBy {get; set; }
    public DateTime date {get; set; }
    public int idTicket {get; set; }

    public char status {get; set;}      //approved by manager or not

    //display ticket info
    public override string ToString()
    {
        return $"Submission Date: {this.date} \n Description: {this.description} \n Amount: {this.amount}";
    }
}