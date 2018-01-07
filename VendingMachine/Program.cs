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
            ContainableItem CI = new ContainableItem();
            System.IO.StreamReader file = new System.IO.StreamReader("In.txt");
            System.IO.StreamWriter file2 = new System.IO.StreamWriter("Out.txt");

            Product P_temp;
            while ((s_temp = file.ReadLine()) != null)
            {
                op = Convert.ToInt32(s_temp);
                switch (op)
                {
                    case 1:
                        {
                            P_temp = new Product();
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

                            CI.Add(P_temp, i_temp1, i_temp2);
                            break;
                        }
                    case 2:
                        {
                            s_temp = file.ReadLine();
                            i_temp1 = Convert.ToInt32(s_temp);

                            s_temp = file.ReadLine();
                            i_temp2 = Convert.ToInt32(s_temp);

                            CI.Remove(i_temp1,i_temp2);
                            break;
                        }
                    case 3:
                        {
                            List<Product> list = CI.GetAllItem();
                            foreach (Product prod in list)
                            {
                                file2.WriteLine(prod.name + " | " + prod.category.name + " | " + Convert.ToString(prod.price) + " | " + prod.quantity + " | " + prod.size);
                            }
                            file2.WriteLine("");
                            break;
                        }
                    case 4:
                        {
                            s_temp = file.ReadLine();
                            i_temp1 = Convert.ToInt32(s_temp);
                            s_temp = file.ReadLine();
                            i_temp2 = Convert.ToInt32(s_temp);
                            Product prod = new Product();
                            prod = CI.GetItem(i_temp1, i_temp2);
                            if (prod != null)
                            {
                                file2.WriteLine(prod.name + " | " + prod.category.name + " | " + Convert.ToString(prod.price) + " | " + prod.quantity + " | " + prod.size);
                                file2.WriteLine("");
                            }
                            break;
                        }
                }
            }
            file.Close();
            file2.Close();
        }
    }
}