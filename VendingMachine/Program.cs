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
                                //[AD] ar trebui sa iei produsul din lista, sa il folosesti mai departe
                                ContainableItem containableItem = menu.containableItemsCollection.GetItem(position.row, position.column);
                                paymentTerminal.SelectProduct(containableItem.product.price);
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
                                    //[AD] nu ar trebui sa apelezi aici statistics daca e observer
                                    // in momentul in care se face livrarea produsului, e notificat si stie el ce sa faca.
                                    // daca faci asa, nu are nici un sens sa fie observer ca nu mai are ce sa faca
                                    //menu.statisticItemsCollection.IncrementNumberOfSoldProduct(menu.containableItemsCollection.GetItem(position.row, position.column).product);
                                    //dispenser.DecrementQuantity(position.row, position.column);
                                    paymentTerminal.Notify(containableItem);
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