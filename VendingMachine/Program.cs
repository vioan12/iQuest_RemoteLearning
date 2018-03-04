using System;

namespace VendingMachine
{
    public class Program
    {
        private static Menu menu;
        static void Main(string[] args)
        {
            menu = new Menu();
            int option;
            CreditCard creditCard = null;
            try
            {
                menu.ReadFile();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            option = 0;
            do
            {
                option = menu.ConsoleSelectMenu();
                switch (option)
                {
                    case 1:
                        {
                            //Write all porducts
                            menu.ConsoleWriteAllProducts();
                            break;
                        }
                    case 2:
                        {
                            //Buy a product
                            Payment payment;
                            Position position;
                            PaymentTerminal paymentTerminal = new PaymentTerminal();
                            paymentTerminal.Attach(menu.dispenser);
                            try
                            {
                                position = menu.ConsoleSelectProduct();
                                paymentTerminal.SelectProduct(menu.dispenser.collection.GetItem(position.row, position.column).product.price);
                                int op2 = 0;
                                bool sw = true;
                                do
                                {
                                    Console.WriteLine("Your current amount:" + paymentTerminal.amount + " $");
                                    op2 = menu.ConsoleSelectPaymentMethods();
                                    switch (op2)
                                    {
                                        case 1:
                                            {
                                                //10 cent
                                                payment = new Coins(0.1);
                                                paymentTerminal.AddAmount(payment);
                                                break;
                                            }
                                        case 2:
                                            {
                                                //50 cent
                                                payment = new Coins(0.5);
                                                paymentTerminal.AddAmount(payment);
                                                break;
                                            }

                                        case 3:
                                            {
                                                //5 $
                                                payment = new Banknote(5);
                                                paymentTerminal.AddAmount(payment);
                                                break;
                                            }
                                        case 4:
                                            {
                                                //10 $
                                                payment = new Banknote(10);
                                                paymentTerminal.AddAmount(payment);
                                                break;
                                            }
                                        case 5:
                                            {
                                                //20 $
                                                payment = new Banknote(20);
                                                paymentTerminal.AddAmount(payment);
                                                break;
                                            }
                                        case 6:
                                            {
                                                //50 $
                                                payment = new Banknote(50);
                                                paymentTerminal.AddAmount(payment);
                                                break;
                                            }
                                        case 7:
                                            {
                                                //100 $
                                                payment = new Banknote(100);
                                                paymentTerminal.AddAmount(payment);
                                                break;
                                            }
                                        case 8:
                                            {
                                                //200 $
                                                payment = new Banknote(200);
                                                paymentTerminal.AddAmount(payment);
                                                break;
                                            }
                                        case 9:
                                            {
                                                //500 $
                                                payment = new Banknote(500);
                                                paymentTerminal.AddAmount(payment);
                                                break;
                                            }
                                        case 10:
                                            {
                                                //CreditCard
                                                if (creditCard == null)
                                                {
                                                    creditCard = menu.ConsoleCreditCardInitialization();
                                                }
                                                if (menu.ConsoleCreditCardIsValid(creditCard) == true)
                                                {
                                                    try
                                                    {
                                                        paymentTerminal.AddAmount(creditCard);
                                                    }
                                                    catch (Exception exception)
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
                                } while ((paymentTerminal.IsComplete() == false) && (sw == true));
                                if (sw != false)
                                {
                                    Console.WriteLine("The payment is completed!");
                                    Console.WriteLine("Change:" + paymentTerminal.GiveChange() + " $");
                                    menu.statisticItemsCollection.IncrementNumberOfSoldProduct(menu.dispenser.collection.GetItem(position.row, position.column).product);
                                    //dispenser.DecrementQuantity(position.row, position.column);
                                    paymentTerminal.Notify(position.row, position.column, null);
                                }
                                else
                                {
                                    Console.WriteLine("The payment is canceled!");
                                    Console.WriteLine("Change:" + paymentTerminal.Cancel() + " $");
                                }
                            }
                            catch(Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            //Statistic of all porducts
                            menu.ConsoleWriteAllStatisticForProducts();
                            break;
                        }
                }
            } while (option != 4);
        }
    }
}