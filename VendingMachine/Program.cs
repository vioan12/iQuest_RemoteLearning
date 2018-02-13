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
            int i_temp1, i_temp2;
            string s_temp, op;
            ContainableItemsCollection CIC = new ContainableItemsCollection();
            System.IO.StreamReader file = new System.IO.StreamReader("In.txt");
            System.IO.StreamWriter file2 = new System.IO.StreamWriter("Out.txt");

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

                            CIC.Add(CI_temp);
                            break;
                        }
                    case "rmv":
                        {
                            s_temp = file.ReadLine();
                            i_temp1 = Convert.ToInt32(s_temp);

                            s_temp = file.ReadLine();
                            i_temp2 = Convert.ToInt32(s_temp);

                            CIC.Remove(i_temp1, i_temp2);
                            break;
                        }
                    case "wrt":
                        {
                            for(int i=0; i<CIC.Count(); i++)
                            {
                                file2.WriteLine(CIC.GetItem(i).product.name + " | " + CIC.GetItem(i).product.category.name + " | " + Convert.ToString(CIC.GetItem(i).product.price) + " | " + CIC.GetItem(i).product.quantity + " | " + CIC.GetItem(i).product.size);
                            }
                            file2.WriteLine("");
                            break;
                        }
                    case "upd":
                        {
                            s_temp = file.ReadLine();
                            i_temp1 = Convert.ToInt32(s_temp);

                            s_temp = file.ReadLine();
                            i_temp2 = Convert.ToInt32(s_temp);

                            Dispenser.update(ref CIC, i_temp1, i_temp2);
                            break;
                        }
                }
            }
            file.Close();
            file2.Close();
        }
    }
}