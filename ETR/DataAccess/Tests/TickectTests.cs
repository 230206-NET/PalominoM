using Models; 
using Services;
using System;

namespace Tests;

/*Run these to see test coverage*/
/* dotnet test --collect:"XPlat Code Coverage" */
/* reportgenerator -reports:"./TestResults/{guid}\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html 
 tools/reportgenerator -reports:"./TestResults/0e96da46-9287-4c0b-ba2f-e91314e9061d/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
*/

public class TicketTests{
    [Fact]
    public void TicketShouldCreateValidTicket(){
        Ticket ticket = new();
        ticket.amount = 654.22M;
        ticket.submittedBy = 332211;
        ticket.description = "Hotel money";

        Assert.NotNull(ticket);
        Assert.False(ticket.amount == 0);
        Assert.Equal(654.22M, ticket.amount);
        Assert.Equal(332211, ticket.submittedBy);
        Assert.Equal("Hotel money", ticket.description);
        Assert.False(ticket.submittedBy == 0);
    }

    [Fact]
    public void TicketShouldHaveValidConstructor(){
        Ticket ticket = new Ticket(332211, 654.22M, "Hotel money");

        Assert.NotNull(ticket);
        Assert.False(ticket.amount == 0);
        Assert.Equal(654.22M, ticket.amount);
        Assert.Equal(332211, ticket.submittedBy);
        Assert.Equal("Hotel money", ticket.description);
        Assert.False(ticket.submittedBy == 0);
    }


    [Fact]
    public void TicketShouldHaveValidID(){
        Ticket t = new Ticket(332211, 654.22M, "Hotel money");
        
        t.idTicket = 13;

        Assert.True(t.idTicket == 13);
    }

    [Fact]
    public void TicketShouldHaveValidDate(){
        Ticket t = new Ticket(332211, 654.22M, "Hotel money");
        t.date =new DateTime(2023, 03, 02);
        DateTime secondValue = DateTime.Now;

        Assert.False(t.date > secondValue);
    }

    [Fact]
    public void TicketCanChangeStatus(){
        Ticket t = new Ticket(332211, 654.22M, "Hotel money");
        t.status = 'P';

        Assert.Equal(t.status, 'P');

        t.status = 'A';

        Assert.Equal(t.status, 'A');

        t.status = 'R';

        Assert.Equal(t.status, 'R');
        
    }

    [Fact]
    public void TicketShouldDisplay(){
        Ticket t = new Ticket(332211, 654.22M, "Hotel money");

        Assert.False(string.IsNullOrEmpty(t.ToString()));
    }
}
