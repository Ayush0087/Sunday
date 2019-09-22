using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoor.Entities;
using GreatOutdoor.DataAccessLayer;
using GreatOutdoor.Exception;
using System.Text.RegularExpressions;


namespace GreatOutdoor.BusinessLayer
{
   
    public class OnlineReturnBL
    {
        //validate OnlineReturn before Adding and updating
        private  bool ValidateOnlineReturn(OnlineReturn onlineReturn)
        {
            //create String Builder
            StringBuilder sb = new StringBuilder();
            bool validOnlineReturn = true;


            if (onlineReturn.ReturnID <= 0)
            {
                validOnlineReturn = false;
                sb.Append(Environment.NewLine + "Invalid Online Return ID");

            }

            if(onlineReturn.NoOfReturn<=0)
            {
                validOnlineReturn = false;
                sb.Append(Environment.NewLine + "Invalid Number of Return");

            }

            if (onlineReturn.OrderID <= 0)
            {
                validOnlineReturn = false;
                sb.Append(Environment.NewLine + "Invalid OrderID");

            }


            if (onlineReturn.ProductID <= 0)
            {
                validOnlineReturn = false;
                sb.Append(Environment.NewLine + "Invalid ProductID");

            }

            if (onlineReturn.PurposeOfReturn ==null)
            {
                validOnlineReturn = false;
                sb.Append(Environment.NewLine + "Invalid Purpose Of Return");

            }

            if (onlineReturn.ReturnAmount <= 0)
            {
                validOnlineReturn = false;
                sb.Append(Environment.NewLine + "Invalid Return Amount");

            }

            //   if (onlineReturn.DateOfReturn.AddDays(10) < DateTime.Now)
            //   {
            //       validOnlineReturnBL = false;
            //      sb.Append(Environment.NewLine + "Online Return Valid Only for 10 Days from Order");
            //   }


            if (validOnlineReturn== false)
            throw new OnlineReturnException(sb.ToString());

            return validOnlineReturn;
            
        }


        //Adding OnlineReturn To List
       public bool AddOnlineReturnBL(OnlineReturn newOnlineReturn)
       {
            bool onlineReturnAdded = false;
            try
            {
                if (ValidateOnlineReturn(newOnlineReturn)) //Validating OnlineReturn
                {
                    OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                    onlineReturnAdded = onlineReturnDAL.AddOnlineReturnDAL(newOnlineReturn); //Adding Data To List
                }
            }
            catch (SystemException ex)
            {
                throw new OnlineReturnException(ex.Message);
            }
           

            return onlineReturnAdded;
       }

        public List<OnlineReturn> GetOnlineReturnsBL()
        {
            List<OnlineReturn> onlineReturnList = null;
            {
                try
                {
                    OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                    onlineReturnList = onlineReturnDAL.GetAllOnlineReturnsDAL();
                }
                catch (SystemException ex)
                {

                    throw ex;
                }
                return onlineReturnList;
            }
            
        }

          //searching OnlineReturn By ReturnID
        public  OnlineReturn searchOnlineReturnBL(int searchOnlineReturnID)
        {
          
            OnlineReturn searchOnlineReturn = null;
            try
            {
                OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                searchOnlineReturn = onlineReturnDAL.searchOnlineReturnDAL(searchOnlineReturnID);
            }
            catch (SystemException ex)
            {

                throw new OnlineReturnException(ex.Message);
            }
            return searchOnlineReturn;
        }


        

       
       public  bool UpdateOnlineReturnBL(OnlineReturn updateonlineReturn)
       {
             bool onlineReturnUpdated = false;
            try
            {
                if (ValidateOnlineReturn(updateonlineReturn))
                {
                    OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                    onlineReturnUpdated = onlineReturnDAL.UpdateOnlineReturnDetailDAL(updateonlineReturn);
                }
            }
            catch (SystemException)
            {
                throw;
            }
           

            return onlineReturnUpdated;
       }

       public bool DeleteOnlineReturnBL(int deleteReturnID)
         {
            bool onlineReturnDeleted = false;
            try
            {
                if (deleteReturnID > 0)
                {
                    OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                    onlineReturnDeleted = onlineReturnDAL.DeleteOnlineReturnDAL(deleteReturnID);
                }
                else
                {
                    throw new OnlineReturnException("Invalid Return ID");
                }
            }
            catch (OnlineReturnException)
            {
                throw;
            }
           

            return onlineReturnDeleted;
         }
         //Serialize
        public void Serialize()
        {
            try
            {
                OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                onlineReturnDAL.Serialize();
            }
            catch(SystemException ex)
            {
                throw new OnlineReturnException(ex.Message);
            }
        }
         //Deserialize
        public void Deserialize()
        {
            try
            {
                OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                onlineReturnDAL.Deserialize();
            }
            catch (SystemException)
            {

                throw;
            }
        }



    }

    


}
