using System;
using System.Collections.Generic;
using System.Text;
using GreatOutdoor.Entities;
using GreatOutdoor.BusinessLayer;
using GreatOutdoor.Exception;

namespace GreatOutdoor.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddOnlineReturn();
                        break;
                    case 2:
                        GetAllOnlineReturns();
                        break;
                    case 3:
                        searchOnlineReturn();
                        break;
                    case 4:
                        UpdateOnlineReturn();
                        break;
                    case 5:
                        DeleteOnlineReturn();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void DeleteOnlineReturn()
        {
            try
            {
                int deleteReturnID;
                Console.WriteLine("Enter ReturnID to Delete:");
                deleteReturnID = Convert.ToInt32(Console.ReadLine());
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
              OnlineReturn onlineReturnDeleted = onlineReturnBL.searchOnlineReturnBL(deleteReturnID);
                if(onlineReturnDeleted!=null)
                {
                    bool onlineReturndeleted = onlineReturnBL.DeleteOnlineReturnBL(deleteReturnID);
                    if (onlineReturndeleted)
                        Console.WriteLine("Online Return Deleted");
                    else
                        Console.WriteLine("Online Return not Deleted");

                }
                else
                {
                    Console.WriteLine("No Online Return Detail Available");
                }

            }
            catch (OnlineReturnException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateOnlineReturn()
        {
            try
            {
                int updateOnlineReturnID;
                Console.WriteLine("Enter ReturnID to Update Details:");
                updateOnlineReturnID = Convert.ToInt32(Console.ReadLine());
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
               OnlineReturn updateonlineReturn = onlineReturnBL.UpdateOnlineReturnBL(updateOnlineReturnID);
                if (updateonlineReturn != null)
                {
                    Console.WriteLine("Update Purpose Of Return :");
                   updateonlineReturn.PurposeOfReturn = Console.ReadLine();
                    Console.WriteLine("Update Number Of Return :");
                    updateonlineReturn.NoOfReturn = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update OrderID :");
                    updateonlineReturn.OrderID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update ProductID :");
                    updateonlineReturn.ProductID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update Return Amount :");
                    updateonlineReturn.ReturnAmount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update Return ID :");
                    updateonlineReturn.ReturnID = Convert.ToInt32(Console.ReadLine());


                    bool OnlineReturnUpdated = onlineReturnBL.UpdateOnlineReturnBL(updateonlineReturn);
                    if (OnlineReturnUpdated)
                        Console.WriteLine("OnlineReturn Details Updated");
                    else
                        Console.WriteLine("OnlineReturn Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No OnlineReturn Details Available");
                }


            }
            catch (OnlineReturnException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void searchOnlineReturn()
        {
            try
            {
                int searchReturnID;
                Console.WriteLine("Enter ReturnID to Search:");
                searchReturnID = Convert.ToInt32(Console.ReadLine());
               OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
                OnlineReturn searchonlineReturn = onlineReturnBL.searchOnlineReturnBL(searchReturnID);
                if (searchonlineReturn != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("ReturnID\t\tPurposeOfReturn\t\tNoOfReturn\t\tOrderID\t\tProductID\t\tReturnAmount");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", searchonlineReturn.ReturnID, searchonlineReturn.PurposeOfReturn, searchonlineReturn.NoOfReturn, searchonlineReturn.OrderID, searchonlineReturn.ProductID, searchonlineReturn.ReturnAmount);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No OnlineReturn Details Available");
                }

            }
            catch (OnlineReturnException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void  AddOnlineReturn()
        {
            try
            {
                OnlineReturn newOnlineReturn = new OnlineReturn();
               
                Console.WriteLine("Add OnlineReturn");
                Console.WriteLine("Enter OrderID");
                newOnlineReturn.OrderID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter ProductID");
                newOnlineReturn.ProductID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Purpose Of Return");
                newOnlineReturn.PurposeOfReturn = Console.ReadLine();
                Console.WriteLine("Enter No Of Return");
                newOnlineReturn.NoOfReturn = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ReturnID generated :" + " " + newOnlineReturn.ReturnID);
                OnlineReturnBL onlineReturn = new OnlineReturnBL();
                bool OnlineReturnAdded = onlineReturn.AddOnlineReturnBL(newOnlineReturn);
                if (OnlineReturnAdded)
                {
                   
                    Console.WriteLine("Online Return Added");
                    Console.WriteLine("Your ReturnID =" + " " + newOnlineReturn.ReturnID);

                }
                else
                    Console.WriteLine("Online Return Not Added");

            }
            catch (OnlineReturnException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetAllOnlineReturns()
        {
            try
            {
                int searchReturnID;
                Console.WriteLine("Enter Return ID to search");
                searchReturnID = Convert.ToInt32(Console.ReadLine());
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
                OnlineReturn searchOnlineReturn = onlineReturnBL.GetOnlineReturnsBL(searchReturnID);
                if(searchOnlineReturn!= null)
                {
                   
                  Console.WriteLine("******************************************************************************");
                  Console.WriteLine("ReturnID\t\tPurposeOfReturn\t\tNoOfReturn\t\tOrderID\t\tProductID\t\tReturnAmount");
                  Console.WriteLine("******************************************************************************");
                  Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", searchOnlineReturn.ReturnID, searchOnlineReturn.PurposeOfReturn, searchOnlineReturn.NoOfReturn, searchOnlineReturn.OrderID, searchOnlineReturn.ProductID, searchOnlineReturn.ReturnAmount);
                  Console.WriteLine("******************************************************************************");
                }
                else
                {
                        Console.WriteLine("No OnlineReturn Details Available");
                }

                
            }
            catch (SystemException)
            {

                throw;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n***********Online Return Menu***********");
            Console.WriteLine("1. Add Online Return");
            Console.WriteLine("2. List All Online Return");
            Console.WriteLine("3. Search Online Return");
            Console.WriteLine("4. Update Online Return");
            Console.WriteLine("5. Delete Online Return");
            Console.WriteLine("6. Exit");
            Console.WriteLine("******************************************\n");

        }
    }
}
