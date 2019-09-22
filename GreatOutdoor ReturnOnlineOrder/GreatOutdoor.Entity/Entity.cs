using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;
using GreatOutdoor.Exception;

namespace GreatOutdoor.Entities

{
    public interface IOnlineReturn
    {
        string PurposeOfReturn {get; set;}
        int NoOfReturn { get; set; }
        int ReturnID { get; set; }
        int ProductID { get; set; }
        double ReturnAmount { get; set; }
        int OrderID { get; set; }
        
    }
    public class OnlineReturn : IOnlineReturn
    {
        //fields
        
        private string _purposeOfReturn;
        private int _noOfReturn;
        private int _returnID;
        private int _productID;
        private int _orderID;
        private double _returnAmount;



        public  int ReturnID { get => _returnID; set => _returnID = value; }
        public string PurposeOfReturn { get => _purposeOfReturn; set => _purposeOfReturn = value; }
        public int NoOfReturn { get => _noOfReturn; set => _noOfReturn = value; }
        public int ProductID { get => _productID; set => _productID = value; }
        public int OrderID { get => _orderID; set => _orderID = value; }
        public double ReturnAmount { get => _returnAmount; set => _returnAmount = value; }

        //constructor
        public OnlineReturn()
        {
            _purposeOfReturn = string.Empty;
            _noOfReturn = 0;
            _returnID = 0;
            _productID = 0;
            _returnAmount = 0.0;
            _orderID = 0;


        }



       
    }
}
