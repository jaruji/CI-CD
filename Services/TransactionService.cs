using System.Collections.Generic;
using System.Linq;
namespace InternetBanking
{
    
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository){
            _transactionRepository = transactionRepository;
        }
        public Transaction GetTransaction(decimal transactionId)
        {
            return _transactionRepository.GetTransactions().FirstOrDefault(x => x.TransactionId == transactionId);
        }

        public IList<Transaction> GetTransactions()
        {
            return _transactionRepository.GetTransactions().ToList();
        }
        public void SaveTransaction(Transaction transaction)
        {
            _transactionRepository.CreateTransaction(transaction);
        }
    }

    public interface ITransactionService
    {
        IList<Transaction> GetTransactions();
        Transaction GetTransaction(decimal transactionId);
        void SaveTransaction(Transaction transaction);

    }

}