/*
    -This class inherits from IRepository. 
    - This class will not be doing: 
        - Input Validation
        - Console I/O
        - Any complex application logic
    - This class will read and write to SQL databse hosted by Azure.
*/

/*
Reading/writing to DB
1. Connect to DB
2. Assemble/Write the query
3. Execute it
4. Process the data or check that it's been successful
*/
using Models;
using Serilog; 
using System.Data.SqlClient; 


namespace DataAccess; 

public class DBRepository : IRepository{


    /*
        Returns all accounts in database
    */
    List<Account> IRepository.GetAllAccounts()
    {
        List<Account> accounts = new();
        // Connecting to Azure server
        try{
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString()); 
            
            //opening connection 
            connection.Open();

            //executing query 
            using SqlCommand cmd = new SqlCommand("Select * FROM USERS",connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            Account acct = new();

            while(reader.Read()){
                int accountID = (int) reader["EID"];
                string pwd = (string) reader ["EPassword"];
                string stype = (string) reader ["WorkerType"];
                char type = stype[0];
                if(accounts.Count == 0 || accountID != accounts.Last().workId){
                    acct = new Account {
                    workId = accountID,
                    password = pwd,
                    workerType = type,
                    };
                    accounts.Add(acct);
                }
                
            }


        } catch (Exception ex){
            Log.Warning("Caught SQL Exception trying to get all accounts {0}", ex);
            throw ex;
        }
        return accounts; 
    }

    /*
        This method adds account to database
    */
    public void createNewAccount(Account accountToCreate){
        try{
            //connect to database on Azure
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString()); 
            connection.Open();   //open connection
            //run insert query 
            //NO SEMICOLON ON QUERY STRING!!!!!!!!
            string query =  "INSERT INTO USERS(EID, WorkerType, EPassword) VALUES (@id, @wType, @pwd)";
            using SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@id",accountToCreate.workId);
            cmd.Parameters.AddWithValue("@wType",accountToCreate.workerType);
            cmd.Parameters.AddWithValue("@pwd",accountToCreate.password);

            cmd.ExecuteNonQuery();
            connection.Close();

        }catch(SqlException ex){
            Log.Warning("Caught SQL Exception trying to create new account {0}", ex);
            throw ex;
        }
    }


    /*
      - Checks if account exists. 
      - This can be used for login and registration check
      - returns Account object
      */
    public Account checkExistingAccount(int id, string? pwd){
        Account existingAcct = new();

        try{
            using SqlConnection con = new SqlConnection(Secrets.getConnectionString());
            con.Open();
            //Select * FROM EUSERS WHERE EID = 123 AND EPassword = '123857' 
            string query = "SELECT * FROM USERS WHERE EID = @id AND EPassword = @pwd";
            using SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pwd", pwd);

            using SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()){
                int accountID = (int) reader["EID"];
                string ipwd = (string) reader ["EPassword"];
                string stype = (string) reader ["WorkerType"];
                char type = stype[0];
                existingAcct = new Account{
                    workId = accountID,
                    password = ipwd,
                    workerType = type,
                };
            }

            con.Close();

        } catch(SqlException ex){
            Log.Warning($"Caught SQL Exception trying to find account {ex}");
            throw ex;
        }
        return existingAcct;
    }




    /// <summary>
    /// Retrieves all ticket submissions done by employee
    /// </summary>
    /// <returns>a list of ticket submissions</returns>
    public List<Ticket> GetAllTicketSubmissions(int id)
    {
        List<Ticket> ticketList = new();
        using SqlConnection con = new SqlConnection(Secrets.getConnectionString());
        con.Open();
        string query = "SELECT * FROM TICKETS WHERE SubmitedBy = @EID";
        using SqlCommand cmd = new SqlCommand(query,con);

        cmd.Parameters.AddWithValue("@EID",id);

        using SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read()){
                ticketList.Add(new Ticket {
                    idTicket = (int) reader["ID"],
                    amount = (decimal) reader["Amount"],
                    description = (string) reader["TDescription"]
                });
        }
        con.Close();  //just bc I am paranoid 
        return ticketList; 
    }


    /// <summary>
    /// Persists a new ticket to storage (Adds ticket to database)
    /// </summary>
    public bool SubmitTicket(Ticket ticketToSubmit)
    {
        try{
            using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
            conn.Open();
            string query = "INSERT INTO TICKETS(Amount,TDescription,SubmitedBy, SStatus) VALUES (@amt, @desc, @EID, 'P')";
            using SqlCommand cmd = new SqlCommand(query,conn);

            cmd.Parameters.AddWithValue("@EID", ticketToSubmit.submittedBy);
            cmd.Parameters.AddWithValue("@amt", ticketToSubmit.amount);
            cmd.Parameters.AddWithValue("@desc", ticketToSubmit.description);

            cmd.ExecuteNonQuery();
            conn.Close();

            return true;

        } catch(SqlException ex){
            Log.Warning("Caught SQL Exception trying to add ticket {0}", ex);
            throw ex;
        }
    
    }

     /// <summary>
    /// Retrieves all ticket submissions 
    /// </summary>
    /// <returns>a list of ticket submissions</returns>
    public List<Ticket> GetAllTickets(){
        List<Ticket> ticketList = new();
        try{
            using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
            conn.Open();
            string query = "SELECT * FROM TICKETS";
            using SqlCommand cmd = new SqlCommand(query,conn);

            using SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()){
                    string s = (string) reader["SStatus"];
                    ticketList.Add(new Ticket {
                        idTicket = (int) reader["ID"],
                        amount = (decimal) reader["Amount"],
                        description = (string) reader["TDescription"],
                        status = s[0]
                    });
            }
            conn.Close();  //just bc I am paranoid 
            return ticketList; 

        }catch(SqlException ex){
            Log.Warning("Caught SQL Exception trying to retrieve all tickets {0}", ex);
            throw ex; 
        }
    }

    /// <summary>
    /// Updates ticket information  
    /// </summary>
    /// <returns> bool if succesfull update or not</returns>
    public bool updateTickets(Ticket updatedTicket){

        try{
            using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
            conn.Open();
            string query = "UPDATE TICKETS SET SStatus = @stat WHERE ID = @id";
            using SqlCommand cmd = new SqlCommand(query,conn);

            cmd.Parameters.AddWithValue("@stat", updatedTicket.status);
            cmd.Parameters.AddWithValue("@id", updatedTicket.idTicket);

            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Close();  //just bc I am paranoid 
            return true; 

        }catch(SqlException ex){
            Log.Warning("Caught SQL Exception trying to update ticket{0}",ex);
            throw ex; 
        }
    
    }
}