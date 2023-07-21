using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TheChampions.Models;


namespace TheChampions.Repository
{
    public class CampImp : ICamp
    {
        private readonly CampContext _context;
        private readonly CustReachContext _con;

        public CampImp(CampContext context, CustReachContext con)
        {
            _context = context;
            _con = con;
        }
        public Activity AddActivity(Activity activity)
        {
            _context.activities.Add(activity);
            _context.SaveChanges();
            return activity;

        }

        public Registration AddRegisteree(Registration registeree)
        {
            _context.registrations.Add(registeree);
            _context.SaveChanges();
            return registeree;
        }

        public List<Transaction> AllTransactions()
        {
            return _context.transactions.ToList();
        }

        public Transaction createTransaction(Transaction transaction)
        {
            _context.transactions.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }

        public List<CustomerReach> custMessages()
        {
            return _con.CustomerReach.ToList();
        }

        public Activity DeleteActivity(int id)
        {
            Activity? activity = _context.activities.Find(id);
            if (activity != null)
            {
                _context.activities.Remove(activity);
                _context.SaveChanges();

            }
            return activity;
        }

        public Registration DeleteRegisteree(int id)
        {
            Registration? registration = _context.registrations.Find(id);
            if (registration != null)
            {
                _context.registrations.Remove(registration);
                _context.SaveChanges();
            }
            return registration;
        }

        public Activity GetActivitybyid(int id)
        {
            return _context.activities.Find(id);

        }

        public List<Activity> getAllActivity()
        {
            return _context.activities.ToList();
        }

        public List<Registration> getAllRegistrant()
        {
            return _context.registrations.ToList();
        }

        public Registration getRegistrantbyid(int id)
        {
            return _context.registrations.Find(id);
        }

        public List<Registration> Search(string term)
        {
            if (term == null)
            {
                
                return new List<Registration>();
            }
            List<Registration> registration = _context.registrations.ToList<Registration>();
            List<Registration> searchResult = registration.Where(r => r.FirstName.Contains(term)).ToList();
            return searchResult;
        }

        public Activity UpdateActivity(Activity uactivity)
        {
            var updateactivity = _context.activities.Attach(uactivity);
            updateactivity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return uactivity;
        }

        public Registration UpdateRegisteree(Registration uregisteree)
        {
            var updateregistrant = _context.registrations.Attach(uregisteree);
            updateregistrant.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return uregisteree;
        }

        public Transaction UpdateTransaction(Transaction utransaction)
        {
            var updateTransaction = _context.transactions.Attach(utransaction);
            updateTransaction.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return utransaction;
        }
    }
}
