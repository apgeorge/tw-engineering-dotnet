﻿using System.Collections.Generic;
using VideoWorld.Models;

namespace VideoWorld.Repositories
{
    public class TransactionRepository : ListBasedRepository<Transaction>, ITransactionRepository
    {
        public IEnumerable<Transaction> TransactionsBy(Customer customer)
        {
            return SelectSatisfying(TransactionSpecification.ByCustomer(customer));
        }
    }
}