using System;

namespace Invoice_Matcher
{
    public class Menu
    {
        public void Main()
        {
            Console.Clear();
            var answer = "i";
            while (answer != "i" || answer != "p")
            {
                Console.WriteLine("Would you like to enter invoices, po's or exit?\n(I) Invoices\n(P) Purchase orders\n(Any key) Exit");
                answer = Console.ReadLine();
                if (answer.Trim().ToLower() == "i")
                {
                    Invoices();
                }
                else if (answer.Trim().ToLower() == "p")
                {
                    PO();
                }
                else
                {
                    break;
                }

            }
        }
        public void Invoices()
        {
            Console.Clear();
            var SqlConn = new MyDbConnect("server=localhost;user=****;database=invoice_match;port=3306;password=****");
            var dbInteract = new DbInteract(SqlConn);
            var invoices = new Invoices();
            Console.WriteLine("Enter invoiced PO numbers, when the last has been entered press enter again.");
            invoices.EnterPOs();
            invoices.MatchCheck(dbInteract);
            Console.WriteLine("The following POs are already filed:");
            Operations.DisplayEffected(invoices.ShowFiled());
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
            Console.WriteLine("The following orders are ready to file:");
            Operations.DisplayEffected(invoices.ShowMatched());
            Console.WriteLine("\n\nPress enter to change status to filed.");
            Console.ReadLine();
            invoices.ChangeStatus(dbInteract);
            Console.WriteLine("\n\nThe following orders need a database entry:");
            Operations.DisplayEffected(invoices.ShowNew());
            Console.WriteLine("\n\nPress enter to create entries.");
            Console.ReadLine();
            invoices.AddNew(dbInteract);
            Console.WriteLine("\nProcess Finished...\n");
        }
        public void PO()
        {
            Console.Clear();
            var SqlConn = new MyDbConnect("server=localhost;user=*****;database=invoice_match;port=3306;password=*****");
            var dbInteract = new DbInteract(SqlConn);
            var purchaseOrders = new PurchaseOrders();
            Console.WriteLine("Enter PO numbers, when the last has been entered press enter again.");
            purchaseOrders.EnterPOs();
            purchaseOrders.MatchCheck(dbInteract);
            Console.WriteLine("The following POs are already filed:");
            Operations.DisplayEffected(purchaseOrders.ShowFiled());
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
            Console.WriteLine("The following orders are ready to file:");
            Operations.DisplayEffected(purchaseOrders.ShowMatched());
            Console.WriteLine("\n\nPress enter to change status to filed.");
            Console.ReadLine();
            purchaseOrders.ChangeStatus(dbInteract);
            Console.WriteLine("\n\nThe following orders need a database entry:");
            Operations.DisplayEffected(purchaseOrders.ShowNew());
            Console.WriteLine("\n\nPress enter to create entries.");
            Console.ReadLine();
            purchaseOrders.AddNew(dbInteract);
            Console.WriteLine("\nProcess Finished...\n");
        }
    }
}
