using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            int op, i_temp1, i_temp2;
            string s_temp;
            ContainableItemsCollection CI = new ContainableItemsCollection();
            System.IO.StreamReader file = new System.IO.StreamReader("In.txt");
            System.IO.StreamWriter file2 = new System.IO.StreamWriter("Out.txt");

            Product P_temp;
            ContainableItem CI_temp;
            while ((s_temp = file.ReadLine()) != null)
            {
                op = Convert.ToInt32(s_temp);
                switch (op)
                {
                    case 1:
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
                            CI_temp.position.column = i_temp1;
                            CI_temp.position.row = i_temp2;

                            CI.Add(CI_temp);
                            break;
                        }
                    case 2:
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
                            CI_temp.position.column = i_temp1;
                            CI_temp.position.row = i_temp2;

                            CI.Remove(CI_temp);
                            break;
                        }
                    case 3:
                        {
                            for(int i=0; i<CI.Count(); i++)
                            {
                                file2.WriteLine(CI.GetItem(i).product.name + " | " + CI.GetItem(i).product.category.name + " | " + Convert.ToString(CI.GetItem(i).product.price) + " | " + CI.GetItem(i).product.quantity + " | " + CI.GetItem(i).product.size);
                            }
                            file2.WriteLine("");
                            break;
                        }
                    case 4:
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
                            CI_temp.position.column = i_temp1;
                            CI_temp.position.row = i_temp2;

                            Dispenser.update(ref CI, CI_temp);
                            break;
                        }
                }
            }
            file.Close();
            file2.Close();
        }
    }
}