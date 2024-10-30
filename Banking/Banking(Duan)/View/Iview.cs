using Banking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Banking.Model.IModel;
namespace Banking.View
{
    internal interface IView
    {
        
         void GetDataFromText();
         void SetDataToText(object item);
         void ClearFields();
        
    }

}

