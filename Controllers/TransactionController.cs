using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InternetBanking {
    [ApiController]
    [Route("api/transaction")]

    public class TransactionController: ControllerBase
    {
        private static List<Transaction> _dummyList = new List<Transaction>{
            new Transaction { TransactionId = 1, TransactionType = TransactionType.Incoming},
            new Transaction { TransactionId = 2, TransactionType = TransactionType.Outgoing},
            new TransactionWithdraw { TransactionId = 3, TransactionType = TransactionType.Withdraw}
        };

        private ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService){
            _transactionService = transactionService;
        }

        [HttpGet]
        public IList<Transaction> GetAll()
        {
            return _transactionService.GetTransactions();
        }

        [HttpGet("{id}")]
        public IActionResult Get(decimal id)
        {
            var transaction = _transactionService.GetTransaction(id);
            if(transaction == null){
                return NotFound();
            }
            return new JsonResult(transaction);
        }

        [HttpPost]
        public IActionResult SaveTransaction(Transaction transaction){
            _transactionService.SaveTransaction(transaction);
            return Ok();
        }
    }
}