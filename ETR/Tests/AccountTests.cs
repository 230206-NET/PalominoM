using Models; 
using Services;
using System; 

namespace Tests;

/*Run these to see test coverage*/
/* dotnet test --collect:"XPlat Code Coverage" 
    Tests\TestResults\0e96da46-9287-4c0b-ba2f-e91314e9061d
    Tests\TestResults\adef27c2-9e6e-4d0f-98ec-c6f82e073315
    D:\Projects\ETRAPI\Tests\TestResults\8859aea8-7c68-4385-83dc-caf118a1457c

    //different steps to make it work
    dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools
    tools/reportgenerator -reports:"./TestResults/0e96da46-9287-4c0b-ba2f-e91314e9061d/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
*/
/* reportgenerator -reports:"D:\Projects\ETRAPI\Tests\TestResults\0e96da46-9287-4c0b-ba2f-e91314e9061d\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html */

public class AccountTests{
    [Fact]
    public void AccountShouldCreate(){
        Account acct = new Account(22, "Yayasdd");

        Assert.NotNull(acct);
        Assert.False(acct.workId == 0);
        Assert.False(string.IsNullOrEmpty(acct.password));
    }

    [Fact]
    public void AccountShouldDisplay(){
        Account acct = new Account(22, "Yayasdd");

        Assert.False(string.IsNullOrEmpty(acct.ToString()));
    }

    [Fact]
    public void AccountShouldHaveWorkerType(){
        Account acct = new Account(22, "Yayasdd");
        acct.workerType = 'M';

        Assert.True(acct.workerType == 'M');
    }

    [Fact]
    public void AccountShouldAddTicketToList(){
        Account acct = new Account(22, "Yayasdd");
        Ticket t = new Ticket(22, 654.22M, "Hotel money");
        List<Ticket> tl = new();
        tl.Add(t);
        acct.ticketList = tl;


        Assert.Equal(acct.ticketList[0], tl[0]);
    }

    [Fact]
    public void TicketShouldHaveAccountID(){
        Account acct = new Account(22, "Yayasdd");
        Ticket t = new Ticket(acct.workId, 654.22M, "Hotel money");

        Assert.True(acct.workId == t.submittedBy);

    }
}