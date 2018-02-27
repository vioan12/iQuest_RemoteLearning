using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        //static private Dispenser dispenser = new Dispenser();
        static Dispenser dispenser = new Dispenser();
        static private StatisticItemsCollection statisticitemscollection;
        static private void ReadFile()
        {
            int i_temp1, i_temp2;
            string s_temp, op;
            statisticitemscollection = new StatisticItemsCollection();
            Product P_temp;
            ContainableItem CI_temp;
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader("In.txt")) 
                    while ((s_temp = file.ReadLine()) != null)
                    {
                        s_temp = file.ReadLine(); // for "\n"
                        op = s_temp;
                        switch (op)
                        {
                            case "add":
                                {
                                    P_temp = new Product();
                                    CI_temp = new ContainableItem();
                                    s_temp = file.ReadLine();
                                    P_temp.name = s_temp;

                                    s_temp = file.ReadLine();
                                    P_temp.category = new ProductCategory();
                                    P_temp.category.name = s_temp;

                                    s_temp = file.ReadLine();
                                    P_temp.price = Convert.ToDouble(s_temp);

                                    s_temp = file.ReadLine();
                                    P_temp.quantity = Convert.ToInt32(s_temp);

                                    s_temp = file.ReadLine();
                                    P_temp.size = Convert.ToInt32(s_temp);

                                    s_temp = file.ReadLine();
                                    i_temp1 = Convert.ToInt32(s_temp);

                                    s_temp = file.ReadLine();
                                    i_temp2 = Convert.ToInt32(s_temp);

                                    CI_temp.product = P_temp;
                                    CI_temp.position = new Position(i_temp1, i_temp2);

                                    dispenser.Add(CI_temp);
                                    statisticitemscollection.Add(CI_temp.product);
                                    break;
                                }
                        }
                    }
            }
            catch(Exception exception)
            {
                throw exception;
            }         
        }
        static private int ConsoleSelectMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1)Write all porducts");
            Console.WriteLine("2)Buy a product");
            Console.WriteLine("3)Statistic of all porducts");
            Console.WriteLine("4)Exit");
            Console.WriteLine("Enter your option:");
            string selectedoption = Console.ReadLine();
            while ((selectedoption != "1") && (selectedoption != "2") && (selectedoption != "3") && (selectedoption != "4"))
            {
                Console.WriteLine("Reenter your option:");
                selectedoption = Console.ReadLine();
            }
            return int.Parse(selectedoption);
        }
        static private void ConsoleWriteAllPorducts()
        {
            for (int i = 0; i < dispenser.collection.Count(); i++)
            {
                Console.WriteLine("[" + dispenser.collection.GetItem(i).position.row + " " + dispenser.collection.GetItem(i).position.column + "] ---> " + dispenser.collection.GetItem(i).product.name + " | " + dispenser.collection.GetItem(i).product.category.name + " | " + Convert.ToString(dispenser.collection.GetItem(i).product.price) + " | " + dispenser.collection.GetItem(i).product.quantity + " | " + dispenser.collection.GetItem(i).product.size);
            }
            Console.WriteLine("");
        }
        static private void ConsoleWriteAllStatisticForProducts()
        {
            int sum1 = 0;
            double sum2 = 0;
            for (int i = 0; i < statisticitemscollection.Count(); i++)
            {
                Console.WriteLine("");
                Console.WriteLine(statisticitemscollection.GetItem(i).product.name + " | " + statisticitemscollection.GetItem(i).product.category.name + " | " + Convert.ToString(statisticitemscollection.GetItem(i).product.price));
                Console.WriteLine("Number of sold products:" + statisticitemscollection.GetItem(i).numberofsoldproduct);
                Console.WriteLine("Earnings:" + ( (statisticitemscollection.GetItem(i).profitpercentage / 100 * statisticitemscollection.GetItem(i).product.price) * statisticitemscollection.GetItem(i).numberofsoldproduct) + " $");
                sum1 = sum1 + statisticitemscollection.GetItem(i).numberofsoldproduct;
                sum2 = sum2 + ((statisticitemscollection.GetItem(i).profitpercentage / 100 * statisticitemscollection.GetItem(i).product.price) * statisticitemscollection.GetItem(i).numberofsoldproduct);
            }
            Console.WriteLine("");
            Console.WriteLine("Global number of sold products:" + sum1);
            Console.WriteLine("Global earnings:" + sum2 + " $");
            Console.WriteLine("");
        }
        static private Position ConsoleSelectProduct()
        {
            Position position;
            Console.WriteLine("Enter row of the product:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter column of the product:");
            int column = int.Parse(Console.ReadLine());
            position = new Position(row, column);
            return position;
        }
        static private int ConsoleSelectPaymentMethods()
        {
            Console.WriteLine("");
            Console.WriteLine("1)10 cent");
            Console.WriteLine("2)50 cent");
            Console.WriteLine("3)5 $");
            Console.WriteLine("4)10 $");
            Console.WriteLine("5)20 $");
            Console.WriteLine("6)50 $");
            Console.WriteLine("7)100 $");
            Console.WriteLine("8)200 $");
            Console.WriteLine("9)500 $");
            Console.WriteLine("10)Credit Card");
            Console.WriteLine("11)Cancel");
            Console.WriteLine("Enter your option:");
            string selectedoption = Console.ReadLine();
            while (!((int.Parse(selectedoption) >= 1) && (int.Parse(selectedoption) <= 11)))
            {
                Console.WriteLine("Reenter your option:");
                selectedoption = Console.ReadLine();
            }
            return int.Parse(selectedoption);
        }
        static private CreditCard ConsoleCreditCardInitialization()
        {
            CreditCard creditcard;
            string number, validdate, name, cvv;
            double amount;
            Console.WriteLine("Enter your credit card number:");
            number = Console.ReadLine();
            Console.WriteLine("Enter your the valid date:");
            validdate = Console.ReadLine();
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter the balance amount:");
            amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the CVV security key:");
            cvv = Console.ReadLine();
            creditcard = new CreditCard(number, validdate, name, amount, cvv);
            return creditcard;
        }
        static private bool ConsoleCreditCardValidation(CreditCard creditcard)
        {
            int nr = 0;
            Console.WriteLine("Enter your CVV:");
            string x = Console.ReadLine();
            try
            {
                creditcard.Validation(x);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            while ((creditcard.valid == false) && (nr < 2))
            {
                Console.WriteLine("Reenter your CVV:");
                x = Console.ReadLine();
                try
                {
                    creditcard.Validation(x);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    nr++;
                }
            }
            if (creditcard.valid == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void Main(string[] args)
        {
            int i_temp1, i_temp2, op;
            string s_temp;
            CreditCard creditcard = null;
            try
            {
                ReadFile();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            op = 0;
            do
            {
                op = ConsoleSelectMenu();
                switch (op)
                {
                    case 1:
                        {
                            //Write all porducts
                            ConsoleWriteAllPorducts();
                            break;
                        }
                    case 2:
                        {
                            //Buy a product
                            Payment payment;
                            Position position;
                            PaymentTerminal paymentterminal = new PaymentTerminal();
                            paymentterminal.Attach(dispenser);
                            position = ConsoleSelectProduct();
                            paymentterminal.SelectProduct(dispenser.collection.GetItem(position.row, position.column).product.price);
                            int op2 = 0;
                            bool sw = true;
                            do
                            {
                                Console.WriteLine("Your current amount:" + paymentterminal.amount + " $");
                                op2 = ConsoleSelectPaymentMethods();
                                switch (op2)
                                {
                                    case 1:
                                        {
                                            //10 cent
                                            payment = new Coins(0.1);
                                            paymentterminal.AddAmount(payment);
                                            break;
                                        }
                                    case 2:
                                        {
                                            //50 cent
                                            payment = new Coins(0.5);
                                            paymentterminal.AddAmount(payment);
                                            break;
                                        }

                                    case 3:
                                        {
                                            //5 $
                                            payment = new Banknote(5);
                                            paymentterminal.AddAmount(payment);
                                            break;
                                        }
                                    case 4:
                                        {
                                            //10 $
                                            payment = new Banknote(10);
                                            paymentterminal.AddAmount(payment);
                                            break;
                                        }
                                    case 5:
                                        {
                                            //20 $
                                            payment = new Banknote(20);
                                            paymentterminal.AddAmount(payment);
                                            break;
                                        }
                                    case 6:
                                        {
                                            //50 $
                                            payment = new Banknote(50);
                                            paymentterminal.AddAmount(payment);
                                            break;
                                        }
                                    case 7:
                                        {
                                            //100 $
                                            payment = new Banknote(100);
                                            paymentterminal.AddAmount(payment);
                                            break;
                                        }
                                    case 8:
                                        {
                                            //200 $
                                            payment = new Banknote(200);
                                            paymentterminal.AddAmount(payment);
                                            break;
                                        }
                                    case 9:
                                        {
                                            //500 $
                                            payment = new Banknote(500);
                                            paymentterminal.AddAmount(payment);
                                            break;
                                        }
                                    case 10:
                                        {
                                            //CreditCard
                                            if(creditcard == null)
                                            {
                                                creditcard = ConsoleCreditCardInitialization();
                                            }
                                            if(ConsoleCreditCardValidation(creditcard) == true)
                                            {
                                                try
                                                {
                                                    paymentterminal.AddAmount(creditcard);
                                                }
                                                catch(Exception exception)
                                                {
                                                    Console.WriteLine(exception.Message);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("The Credit Card is not valid!");
                                            }
                                            break;
                                        }
                                    case 11:
                                        {
                                            //Cancel
                                            sw = false;
                                            break;
                                        }
                                }
                            } while ((paymentterminal.IsComplete() == false) && (sw == true));
                            if(sw != false)
                            {
                                Console.WriteLine("The payment is completed!");
                                Console.WriteLine("Change:" + paymentterminal.GiveChange() + " $");
                                statisticitemscollection.IncrementNumberOfSoldProduct(dispenser.collection.GetItem(position.row, position.column).product);
                                //dispenser.DecrementQuantity(position.row, position.column);
                                paymentterminal.Notify(position.row, position.column);
                            }
                            else
                            {
                                Console.WriteLine("The payment is canceled!");
                                Console.WriteLine("Change:" + paymentterminal.Cancel() + " $");
                            }
                            break;
                        }
                    case 3:
                        {
                            //Statistic of all porducts
                            ConsoleWriteAllStatisticForProducts();
                            break;
                        }

                }
            } while (op != 4);
        }
    }
}