/*
    - Interface: used for only containing actions. Naming convention: name starts with I
    - This interface works as a repo interface
    Created by: Melanie Palomino
    Date: Febuary 15,2023
*/
using Models; 

namespace DataAccess; 
public interface IRepository{
    
    /// <summary>
    /// Retrieves all ticket submissions done by employee
    /// </summary>
    /// <returns>a list of ticket submissions</returns>
    List<Ticket> GetAllTicketSubmissions(int id);

     /// <summary>
    /// Retrieves all ticket submissions 
    /// </summary>
    /// <returns>a list of ticket submissions</returns>
    List<Ticket> GetAllTickets();

    Ticket updateTickets(Ticket updatedTicket);

    /// <summary>
    /// Retrieves all accounts
    /// </summary>
    /// <returns>a list of accounts</returns>
    List<Account> GetAllAccounts();

    /// <summary>
    /// Persists a new ticket to storage
    /// </summary>
    Ticket SubmitTicket(Ticket ticketToSubmit);

    void createNewAccount(Account accountToCreate);

    Account checkExistingAccount(int id, string? pwd);

    Account updateAccount(Account updatedAccount);
}