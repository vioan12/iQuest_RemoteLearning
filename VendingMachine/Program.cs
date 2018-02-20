using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static private Dispenser dispenser;
        static private PaymentTerminal paymentterminal;
        static private void ReadFile()
        {
            int i_temp1, i_temp2;
            string s_temp, op;
            dispenser = new Dispenser();
            System.IO.StreamReader file = new System.IO.StreamReader("In.txt");
            Product P_temp;
            ContainableItem CI_temp;
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
                            break;
                        }
                }
            }
            file.Close();
        }
        static private int ConsoleSelectMenu()
        {
            Console.WriteLine("1)Write all porducts");
            Console.WriteLine("2)Buy a product");
            Console.WriteLine("3)Exit");
            Console.WriteLine("Enter your option:");
            string x = Console.ReadLine();
            while((x != "1") && (x != "2") && (x != "3"))
            {
                Console.WriteLine("Reenter your option:");
                x = Console.ReadLine();
            }
            return int.Parse(x);
        }
        static private void ConsoleWriteAllPorducts()
        {
            for (int i = 0; i < dispenser.collection.Count(); i++)
            {
                Console.WriteLine("[" + dispenser.collection.GetItem(i).position.row + " " + dispenser.collection.GetItem(i).position.column + "] ---> " + dispenser.collection.GetItem(i).product.name + " | " + dispenser.collection.GetItem(i).product.category.name + " | " + Convert.ToString(dispenser.collection.GetItem(i).product.price) + " | " + dispenser.collection.GetItem(i).product.quantity + " | " + dispenser.collection.GetItem(i).product.size);
            }
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
            Console.WriteLine("1)Coins");
            Console.WriteLine("2)Banknote");
            Console.WriteLine("3)Credit Card");
            Console.WriteLine("4)Cancel");
            Console.WriteLine("Enter your option:");
            string x = Console.ReadLine();
            while ((x != "1") && (x != "2") && (x != "3") && (x != "4"))
            {
                Console.WriteLine("Reenter your option:");
                x = Console.ReadLine();
            }
            return int.Parse(x);
        }
        static private int ConsoleSelectPaymentCoins()
        {
            Console.WriteLine("1)10 cent");
            Console.WriteLine("2)50 cent");
            Console.WriteLine("3)Cancel");
            Console.WriteLine("Enter your option:");
            string x = Console.ReadLine();
            while ((x != "1") && (x != "2") && (x != "3"))
            {
                Console.WriteLine("Reenter your option:");
                x = Console.ReadLine();
            }
            return int.Parse(x);
        }
        static private int ConsoleSelectPaymentBanknote()
        {
            Console.WriteLine("1)5 €");
            Console.WriteLine("2)10 €");
            Console.WriteLine("3)20 €");
            Console.WriteLine("4)50 €");
            Console.WriteLine("5)100 €");
            Console.WriteLine("6)200 €");
            Console.WriteLine("7)500 €");
            Console.WriteLine("8)Cancel");
            Console.WriteLine("Enter your option:");
            string x = Console.ReadLine();
            while ((x != "1") && (x != "2") && (x != "3") && (x != "4") && (x != "5") && (x != "6") && (x != "7") && (x != "8"))
            {
                Console.WriteLine("Reenter your option:");
                x = Console.ReadLine();
            }
            return int.Parse(x);
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
            creditcard.Validation(x);
            while ((creditcard.valid == false) && (nr < 3))
            {
                Console.WriteLine("Wrong CVV!");
                Console.WriteLine("Reenter your CVV:");
                x = Console.ReadLine();
                creditcard.Validation(x);
                nr++;
            }
            if(creditcard.valid == false)
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
            ReadFile();
            ConsoleWriteAllPorducts();
            op = 0;
            do
            {
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
                            position = ConsoleSelectProduct();
                            paymentterminal.SelectProduct(dispenser.collection.GetItem(position.row, position.column).product.price);
                            int op2 = 0;
                            do
                            {
                                bool sw = false;
                                switch (op2)
                                {
                                    case 1:
                                        {
                                            //Coins
                                            int op21 = ConsoleSelectPaymentCoins();
                                            bool sw21 = false;
                                            switch (op21)
                                            {
                                                case 1:
                                                    {
                                                        //10 cent
                                                        sw21 = true;
                                                        payment = new Coins(0.1);
                                                        paymentterminal.AddAmount(payment);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        //50 cent
                                                        sw21 = true;
                                                        payment = new Coins(0.5);
                                                        paymentterminal.AddAmount(payment);
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        //Cancel
                                                        break;
                                                    }
                                            }
                                            if (sw21 == true)
                                            {
                                                sw = true;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            //Banknote
                                            int op22 = ConsoleSelectPaymentBanknote();
                                            bool sw22 = false;
                                            switch (op22)
                                            {
                                                case 1:
                                                    {
                                                        //5 €
                                                        sw22 = true;
                                                        payment = new Banknote(5);
                                                        paymentterminal.AddAmount(payment);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        //10 €
                                                        sw22 = true;
                                                        payment = new Banknote(10);
                                                        paymentterminal.AddAmount(payment);
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        //20 €
                                                        sw22 = true;
                                                        payment = new Banknote(20);
                                                        paymentterminal.AddAmount(payment);
                                                        break;
                                                    }
                                                case 4:
                                                    {
                                                        //50 €
                                                        sw22 = true;
                                                        payment = new Banknote(50);
                                                        paymentterminal.AddAmount(payment);
                                                        break;
                                                    }
                                                case 5:
                                                    {
                                                        //100 €
                                                        sw22 = true;
                                                        payment = new Banknote(100);
                                                        paymentterminal.AddAmount(payment);
                                                        break;
                                                    }
                                                case 6:
                                                    {
                                                        //200 €
                                                        sw22 = true;
                                                        payment = new Banknote(200);
                                                        paymentterminal.AddAmount(payment);
                                                        break;
                                                    }
                                                case 7:
                                                    {
                                                        //500 €
                                                        sw22 = true;
                                                        payment = new Banknote(500);
                                                        paymentterminal.AddAmount(payment);
                                                        break;
                                                    }
                                                case 8:
                                                    {
                                                        //Cancel
                                                        break;
                                                    }
                                            }
                                            if(sw22 == true)
                                            {
                                                sw = true;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            //CreditCard
                                            sw = true;
                                            int op23;
                                            break;
                                        }
                                    case 4:
                                        {
                                            //Cancel
                                            break;
                                        }
                                }
                                if(sw == false)
                                {
                                    break;
                                }
                                else
                                {

                                }
                                op2 = ConsoleSelectPaymentMethods();
                            } while ((op2 != 4) && (paymentterminal.IsComplete() == false));
                            if(paymentterminal.IsComplete() == true)
                            {
                                double change = paymentterminal.GiveChange();
                                dispenser.DecrementQuantity(position.row, position.column);
                            }
                            break;
                        }
                }
                op = ConsoleSelectMenu();
            } while (op != 3);
        }
    }
}