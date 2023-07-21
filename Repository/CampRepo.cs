using TheChampions.Models;

namespace TheChampions.Repository
{
    public class CampRepo : ICamp
    {
        
        public Activity AddActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Registration AddRegisteree(Registration registeree)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> AllTransactions()
        {
            throw new NotImplementedException();
        }

        public Transaction createTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Activity DeleteActivity(int id)
        {
            throw new NotImplementedException();
        }

        public Registration DeleteRegisteree(int id)
        {
            throw new NotImplementedException();
        }

        public Activity GetActivitybyid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Activity> getAllActivity()
        {
            throw new NotImplementedException();
        }

        public List<Registration> getAllRegistrant()
        {
            throw new NotImplementedException();
        }

        public Registration getRegistrantbyid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Registration> Search(string term)
        {
            throw new NotImplementedException();
        }

        public Activity UpdateActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Registration UpdateRegisteree(Registration registeree)
        {
            throw new NotImplementedException();
        }

        public Transaction UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        List<CustomerReach> ICamp.custMessages()
        {
            throw new NotImplementedException();
        }
    }
}
