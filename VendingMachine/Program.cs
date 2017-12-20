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
            ContainableItem PC = new ContainableItem();
            System.IO.StreamReader file = new System.IO.StreamReader("In.txt"); // Fisierele astea nu erau puse intre " " si nu inteleg cum ti-a mers tie ceva...
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

                            // TODO FIX THIS !
                            //PC.Add(P_temp);
                            break;
                        }
                    case 2:
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

                            // TODO FIX THIS !
                            //PC.Remove(P_temp);
                            break;
                        }
                    case 3:
                        {
                            for (int i = 0; i < PC.Count(); i++)
                            {
                                // TODO FIX THIS
                                //file2.WriteLine(PC.GetItem(i).name + " | " + PC.GetItem(i).category.name + " | " + Convert.ToString(PC.GetItem(i).price) + " | " + PC.GetItem(i).quantity + " | " + PC.GetItem(i).size);
                            }
                            file2.WriteLine("");
                            break;
                        }
                    case 4:
                        {
                            s_temp = file.ReadLine();
                            int i = Convert.ToInt32(s_temp);
                            // TODO FIX THIS
                            //file2.WriteLine(PC.GetItem(i).name + " | " + PC.GetItem(i).category.name + " | " + Convert.ToString(PC.GetItem(i).price) + " | " + PC.GetItem(i).quantity + " | " + PC.GetItem(i).size);
                            file2.WriteLine("");
                            break;
                        }
                }
            }
            file.Close();
            file2.Close();
        }
    }
}