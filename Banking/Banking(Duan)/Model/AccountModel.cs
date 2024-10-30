using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    internal class AccountModel : IModel
    {
  
        public  string id {  get; set; }
        public string customerid { get; set; }
        public DateTime date_opened { get; set; }
        public float balance { get; set; }

        }
    }


