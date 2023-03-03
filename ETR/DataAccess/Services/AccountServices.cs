using System; 
using Models; 
using DataAccess;

namespace Services;

public class AccountServices {
    private readonly IRepository _repo;      //private of repo interface

    //Implementationof dependecy injection. Needs Irepo to initialize class
    public AccountServices(IRepository repo){
        _repo = repo; 
    }

    public List<Account> GetAllAccounts(){
        return _repo.GetAllAccounts();
    }
    
    /*This method checks if account exists in order to login user
        This could potentially be replaced with query later on
    */
    public Account? loginUser(string? sid, string? pwd){
        //check if account is in db
        Account acct = new();
        if(Int32.TryParse(sid, out int id)){
          return acct = _repo.checkExistingAccount(id,pwd);
        }
        return null;
    }

    public bool newAccount(Account newAccount){
       // Account acct = new();
        //acct = _repo.checkExistingAccount(newAccount.workId,newAccount.password);
        if(_repo.checkExistingAccount(newAccount.workId,newAccount.password).workerType == 0){
            _repo.createNewAccount(newAccount);
            return true;
        }
       return false;
    } 

    public Account editProfile(Account accountToEdit){
        return accountToEdit;
    }

    public Account employeeRevision(int id, char type){
        List<Account> acctList = _repo.GetAllAccounts();
        Account acct = new();
        foreach(Account a in acctList){
            if(a.workId == id){
                acct.workId = a.workId;
                acct.lastName = a.lastName;
                acct.firstName = a.firstName;
                acct.password = a.password;
            }
        }
        acct.workerType = type;
        return _repo.updateAccount(acct);
    }

}
