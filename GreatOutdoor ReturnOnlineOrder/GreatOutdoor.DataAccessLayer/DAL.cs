using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using GreatOutdoor.Entities;
using GreatOutdoor.Exception;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace GreatOutdoor.DataAccessLayer
{
    public abstract class OnlineReturnDALAbstract

    {
        public abstract bool AddOnlineReturnDAL(OnlineReturn newonlineReturn);
        public abstract List<OnlineReturn> GetAllOnlineReturnsDAL();
        public abstract OnlineReturn searchOnlineReturnDAL(int searchOnlineReturnID);
        public abstract bool UpdateOnlineReturnDetailDAL(OnlineReturn updateonlineReturn);
        public abstract bool DeleteOnlineReturnDAL(int deleteReturnID);
        public abstract void Serialize();
        public abstract void Deserialize();
    }

        [Serializable]
    public class OnlineReturnDAL : OnlineReturnDALAbstract
    {
        
        public static List<OnlineReturn> onlineReturnList = new List<OnlineReturn>();

        public List<OnlineReturn> onlineReturnListToSerialize = new List<OnlineReturn>();
        private string filePath = "C:\\CAPG\\onlineReturnList.txt";

        public override bool AddOnlineReturnDAL(OnlineReturn newonlineReturn)
        {
            bool OnlineReturnAdded = false;
            try
            {
                newonlineReturn.ReturnID = 1;
                onlineReturnList.Add(newonlineReturn);
                //Console.WriteLine($"Your ReturnID :  {newonlineReturn.ReturnID}");
                OnlineReturnAdded = true;
            }
            catch(SystemException ex)
            {
                throw new OnlineReturnException(ex.Message);
            }
            return OnlineReturnAdded;
        }

        public override List<OnlineReturn> GetAllOnlineReturnsDAL()
        {

            return onlineReturnList;
        }

        public override OnlineReturn searchOnlineReturnDAL(int searchOnlineReturnID)
        {
            OnlineReturn searchOnlineReturn = null;
            try
            {
                foreach(OnlineReturn item in onlineReturnList)
                {
                    if(item.ReturnID== searchOnlineReturnID)
                    {
                        searchOnlineReturn = item;
                    }
                }
            }
            catch (SystemException ex)
            {

                throw new OnlineReturnException(ex.Message);
            }
            return searchOnlineReturn;
        }

        public override bool UpdateOnlineReturnDetailDAL(OnlineReturn updateonlineReturn)
        {
            bool OnlineReturnDetailUpdated = false;
            try
            {
                for (int i = 0; i < onlineReturnList.Count; i++)
                {
                    if(onlineReturnList[i].ReturnID == updateonlineReturn.ReturnID)
                    {
                        updateonlineReturn.PurposeOfReturn = onlineReturnList[i].PurposeOfReturn;
                        updateonlineReturn.NoOfReturn = onlineReturnList[i].NoOfReturn;
                        updateonlineReturn.OrderID = onlineReturnList[i].OrderID;
                        updateonlineReturn.ProductID = onlineReturnList[i].ProductID;
                        updateonlineReturn.ReturnAmount = onlineReturnList[i].ReturnAmount;
                        //updateonlineReturn.ReturnID = onlineReturnList[i].ReturnID;
                        OnlineReturnDetailUpdated = true;
                    }
                }
            }
            catch(SystemException ex)
            {
                throw new OnlineReturnException(ex.Message);
            }
            return OnlineReturnDetailUpdated;
        }

        public override bool DeleteOnlineReturnDAL(int deleteReturnID)
        {
            bool OnlineReturnDeleted = false;
            try
            {
                OnlineReturn deleteOnlineReturn = null;
                foreach(OnlineReturn item in onlineReturnList)
                {
                    if(item.ReturnID==deleteReturnID)
                    {
                        deleteOnlineReturn = item;
                    }
                }
                if (deleteOnlineReturn != null)
                {
                    onlineReturnList.Remove(deleteOnlineReturn);
                    OnlineReturnDeleted = true;
                }
            }
            catch(System.Exception ex)
            {
                throw new OnlineReturnException(ex.Message);
            }
            return OnlineReturnDeleted;
        }

        public override void Serialize()
        {
            this.onlineReturnListToSerialize= onlineReturnList;
            FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fs1, this);
            fs1.Close();

        }

        public override void Deserialize()
        {
            FileStream fs2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
           OnlineReturnDAL onlineReturnDAL =(OnlineReturnDAL)binaryFormatter.Deserialize(fs2);
            

        }

    }


   
   
}
