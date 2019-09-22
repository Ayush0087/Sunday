using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoor.Exceptions;
using GreatOutdoor.Entities;
using GreatOutdoor.BusinessLayer;
using GreatOutdoor.DataAccessLayer;

namespace GreatOutdoor.PresentationLayer

{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu1();
                Console.WriteLine("Enter Your Choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddSalesPerson();
                        break;
                    case 2:
                        GetSalesPersonByID();
                        break;
                    case 3:
                        UpdateSalesPerson();
                        break;
                    case 4:
                        DeleteSalesPerson();
                        break;
                    

                }
            } while(choice != -1);
        }

            private static void DeleteSalesPerson()
            {
                try
                {
                    int deleteSalesPersonID;
                    Console.WriteLine("Enter SalesPersonID to Delete:");
                    deleteSalesPersonID = Convert.ToInt32(Console.ReadLine());
                    SalesPersonBL salesPersonBL = new SalesPersonBL();
                   SalesPerson deleteSalesPerson = salesPersonBL.GetSalesPersonByIDBL(deleteSalesPersonID);
                    if (deleteSalesPerson != null)
                    {
                        bool SalesPersondeleted = salesPersonBL.DeleteSalesPersonBL(deleteSalesPersonID);
                        if (SalesPersondeleted)
                            Console.WriteLine("SalesPerson Deleted");
                        else
                            Console.WriteLine("SalesPerson not Deleted ");
                    }
                    else
                    {
                        Console.WriteLine("No SalesPerson Details Available");
                    }


               

            }
                catch (GreatOutdoorException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            private static void UpdateSalesPerson()
            {
                try
                {
                    int updateSalesPersonID;
                    Console.WriteLine("Enter SalesPersonID to Update Details:");
                    updateSalesPersonID = Convert.ToInt32(Console.ReadLine());
                    SalesPersonBL salesPersonBL = new SalesPersonBL();
                    SalesPerson updatedSalesPerson = salesPersonBL.GetSalesPersonByIDBL(updateSalesPersonID);
                    if (updatedSalesPerson != null)
                    {
                        Console.WriteLine("New SalesPerson Name :");
                        updatedSalesPerson.SalesPersonName = Console.ReadLine();
                        Console.WriteLine("New PhoneNumber :");
                        updatedSalesPerson.SalesPersonMobile = Console.ReadLine();
                        Console.WriteLine("New SalesPerson Email");
                        updatedSalesPerson.SalesPersonEmail = Console.ReadLine();
                        bool salesPersonUpdated = salesPersonBL.UpdateSalesPersonBL(updatedSalesPerson);
                        if (salesPersonUpdated)
                            Console.WriteLine("SalesPerson Details Updated");
                        else
                            Console.WriteLine("SalesPerson Details not Updated ");
                    }
                    else
                    {
                        Console.WriteLine("No SalesPerson Details Available");
                    }


                }
                catch (GreatOutdoorException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            private static void GetSalesPersonByID()
            {
                try
                {
                    int searchSalesPersonID;
                    Console.WriteLine("Enter SalesPersonID to Search:");
                    searchSalesPersonID = Convert.ToInt32(Console.ReadLine());
                    SalesPersonBL SalesPersonsBL = new SalesPersonBL();
                    SalesPerson searchSalesPersons = SalesPersonsBL.GetSalesPersonByIDBL(searchSalesPersonID);
                    if (searchSalesPersons != null)
                    {
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("SalesPersonID\t\tName\t\tPhoneNumber");
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", searchSalesPersons.SalesPersonID, searchSalesPersons.SalesPersonName, searchSalesPersons.SalesPersonMobile);
                        Console.WriteLine("******************************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("No SalesPerson Details Available");
                    }

                }
                catch (GreatOutdoorException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            private static void AddSalesPerson()
            {
                try
                {

                    SalesPerson newSalesPerson = new SalesPerson();
                    Console.WriteLine("Enter SalesPerson Name :");
                    newSalesPerson.SalesPersonName = Console.ReadLine();
                    Console.WriteLine("Enter PhoneNumber :");
                    newSalesPerson.SalesPersonMobile = Console.ReadLine();
                    Console.WriteLine("Enter SalesPersons Email");
                    newSalesPerson.SalesPersonEmail = Console.ReadLine();
                    SalesPersonBL SalesPerson = new SalesPersonBL();
                    bool SalesPersonAdded = SalesPerson.AddSalesPersonBL(newSalesPerson);
                    if (SalesPersonAdded)
                    {
                        Console.WriteLine("SalesPerson Added");
                        Console.WriteLine("Your SalesPerson ID= ", newSalesPerson.SalesPersonID);
                    }
                    else
                        Console.WriteLine("SalesPerson Not Added");

                }
                catch (GreatOutdoorException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            private static void PrintMenu1()
            {
                Console.WriteLine("\n***********SalesPerson PhoneBook Menu***********");
                Console.WriteLine("1. Add SalesPerson");
                Console.WriteLine("2. Search SalesPerson by ID");
                Console.WriteLine("3. Update SalesPerson");
                Console.WriteLine("4. Delete SalesPerson");
                Console.WriteLine("5. Exit");
                Console.WriteLine("******************************************\n");

            }

        
    }
}
