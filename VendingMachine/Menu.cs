using System;

namespace VendingMachine
{
    public class Menu
    {
        public Dispenser dispenser { set; get; }
        public StatisticItemsCollection statisticItemsCollection { set; get; }
        public ContainableItemsCollection containableItemsCollection { set; get; }
        public Menu()
        {
            dispenser = new Dispenser();
            statisticItemsCollection = new StatisticItemsCollection();
            containableItemsCollection = new ContainableItemsCollection();
            dispenser.Attach(containableItemsCollection);
            dispenser.Attach(statisticItemsCollection);
        }
        public void ReadFile()
        {
            int temp1, temp2;
            string temp3, op;
            Product product;
            ContainableItem item;
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader("In.txt"))
                    while ((temp3 = file.ReadLine()) != null)
                    {
                        temp3 = file.ReadLine(); // for "\n"
                        op = temp3;
                        switch (op)
                        {
                            case "add":
                                {
                                    product = new Product();
                                    item = new ContainableItem();
                                    temp3 = file.ReadLine();
                                    product.name = temp3;

                                    temp3 = file.ReadLine();
                                    product.category = new ProductCategory();
                                    product.category.name = temp3;

                                    temp3 = file.ReadLine();
                                    product.price = Convert.ToDouble(temp3);

                                    temp3 = file.ReadLine();
                                    product.quantity = Convert.ToInt32(temp3);

                                    temp3 = file.ReadLine();
                                    product.size = Convert.ToInt32(temp3);

                                    temp3 = file.ReadLine();
                                    temp1 = Convert.ToInt32(temp3);

                                    temp3 = file.ReadLine();
                                    temp2 = Convert.ToInt32(temp3);

                                    item.product = product;
                                    item.position = new Position(temp1, temp2);

                                    if(containableItemsCollection.Add(item) == true)
                                    {
                                        statisticItemsCollection.Add(item.product);
                                    }
                                    break;
                                }
                        }
                    }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public int ConsoleSelectMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1)Write all products");
            Console.WriteLine("2)Buy a product");
            Console.WriteLine("3)Statistic of all products");
            Console.WriteLine("4)Exit");
            Console.WriteLine("Enter your option:");
            string selectedOption = Console.ReadLine();
            while ((selectedOption != "1") && (selectedOption != "2") && (selectedOption != "3") && (selectedOption != "4"))
            {
                Console.WriteLine("Reenter your option:");
                selectedOption = Console.ReadLine();
            }
            return int.Parse(selectedOption);
        }
        public void ConsoleWriteAllProducts()
        {
            for (int i = 0; i < containableItemsCollection.Count(); i++)
            {
                Console.WriteLine("[" + containableItemsCollection.GetItem(i).position.row + " " + containableItemsCollection.GetItem(i).position.column + "] ---> " + containableItemsCollection.GetItem(i).product.name + "  (" + containableItemsCollection.GetItem(i).product.category.name + ")");
                Console.WriteLine("             Price:" + Convert.ToString(containableItemsCollection.GetItem(i).product.price) + " $");
                Console.WriteLine("             Quantity:" + Convert.ToString(containableItemsCollection.GetItem(i).product.quantity));
        }
        Console.WriteLine("");
        }
        public void ConsoleWriteAllStatisticForProducts()
        {
            int soldProducts = 0;
            double totalSum = 0;
            for (int i = 0; i < statisticItemsCollection.Count(); i++)
            {
                Console.WriteLine("");
                Console.WriteLine(statisticItemsCollection.GetItem(i).product.name + " | " + statisticItemsCollection.GetItem(i).product.category.name + " | " + Convert.ToString(statisticItemsCollection.GetItem(i).product.price));
                Console.WriteLine("Number of sold products:" + statisticItemsCollection.GetItem(i).numberOfSoldProduct);
                Console.WriteLine("Earnings:" + ((statisticItemsCollection.GetItem(i).profitPercentage / 100 * statisticItemsCollection.GetItem(i).product.price) * statisticItemsCollection.GetItem(i).numberOfSoldProduct) + " $");
                soldProducts = soldProducts + statisticItemsCollection.GetItem(i).numberOfSoldProduct;
                totalSum = totalSum + ((statisticItemsCollection.GetItem(i).profitPercentage / 100 * statisticItemsCollection.GetItem(i).product.price) * statisticItemsCollection.GetItem(i).numberOfSoldProduct);
            }
            Console.WriteLine("");
            Console.WriteLine("Global number of sold products:" + soldProducts);
            Console.WriteLine("Global earnings:" + totalSum + " $");
            Console.WriteLine("");
        }
        public Position ConsoleSelectProduct()
        {
            Position position;
            Console.WriteLine("Enter row of the product:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter column of the product:");
            int column = int.Parse(Console.ReadLine());
            try
            {
                position = new Position(row, column);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return position;
        }
        public int ConsoleSelectPaymentMethods()
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
        public CreditCard ConsoleCreditCardInitialization()
        {
            CreditCard creditcard;
            string number, validDate, name, cvv;
            double amount;
            Console.WriteLine("Enter your credit card number:");
            number = Console.ReadLine();
            Console.WriteLine("Enter your the valid date:");
            validDate = Console.ReadLine();
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter the balance amount:");
            amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the CVV security key:");
            cvv = Console.ReadLine();
            creditcard = new CreditCard(number, validDate, name, amount, cvv);
            return creditcard;
        }
        public bool ConsoleCreditCardIsValid(CreditCard creditCard)
        {
            int counter = 0;
            Console.WriteLine("Enter your CVV:");
            string readValue = Console.ReadLine();
            try
            {
                creditCard.IsValid(readValue);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            while ((creditCard.valid == false) && (counter < 2))
            {
                Console.WriteLine("Reenter your CVV:");
                readValue = Console.ReadLine();
                try
                {
                    creditCard.IsValid(readValue);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    counter++;
                }
            }
            if (creditCard.valid == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
