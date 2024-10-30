using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    internal class TransactionModel: IModel
    {
        public int id { get; set; }
        public string form_account_id { get; set; }
        public string branch_id { get; set; }
        public DateTime date_of_trans { get; set; }
        public float? amount {  get; set; }
        public string pin { get; set; }
        public string to_account_id { get; set; }
        public string employee_id { get; set; }
        public string content {  get; set; }

    }
}
