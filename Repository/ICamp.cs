using TheChampions.Models;

namespace TheChampions.Repository
{
    public interface ICamp
    {

        public Registration getRegistrantbyid(int id);
        public List<Registration> getAllRegistrant();
        public List<Registration> Search(string term);
        public Registration AddRegisteree(Registration registeree);
        public Registration UpdateRegisteree(Registration registeree);
        public Registration DeleteRegisteree(int id);
        public Activity GetActivitybyid(int id);
        public List<Activity> getAllActivity();
        public Activity AddActivity(Activity activity);
        public Activity UpdateActivity(Activity activity);
        public Activity DeleteActivity(int id);
        public Transaction createTransaction(Transaction transaction);
        public List<Transaction> AllTransactions();
        public Transaction UpdateTransaction(Transaction transaction);
        public List<CustomerReach> custMessages();




    }
}
