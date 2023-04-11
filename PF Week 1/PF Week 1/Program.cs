using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PF_Week_1
{
   
    class Program
    {
        static int add(int num1, int num2)
        {
            return num1 + num2;
        }
        
        //                                      ################## SIGN IN PAGE #############################
         static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

         static void readdata(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                while ((record = filevariable.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                filevariable.Close();
            }
            else
            {
                Console.WriteLine(" Not Exists");
            }
        }

         static void signin(string n, string p, string[] names, string[] password)
        {
            bool flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == names[x] && p == password[x])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }

         static void signup(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
         static int menu()
        {
            int option;
            Console.WriteLine(" 1 Sign In ");
            Console.WriteLine(" 2 Sign Up ");
            Console.WriteLine(" Enter Option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        //                                      ################## HOME ASSIGNMENT ###########################

        static bool readdata(string path, string[] names, int orders, int orders1, int[] prices, int[] price1)
        {

            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                record = filevariable.ReadLine();
                names[0] = parseData(record, 1);
                orders = int.Parse(parseData(record, 2));
                int i = 0;
                for (int x = 3; x < 11; x++)
                {
                    prices[i] = int.Parse(parseData(record, x));
                    i++;
                }
                record = filevariable.ReadLine();
                names[1] = parseData(record, 1);
                orders1 = int.Parse(parseData(record, 2));
                int j = 0;
                for (int x = 3; x < 13; x++)
                {
                    price1[j] = int.Parse(parseData(record, x));
                    j++;
                }


                filevariable.Close();
                return true;
            }
            else
            {
                Console.WriteLine(" Not Exists");
                return false;
            }
        }
        static void calculate(string[] names, int orders, int orders1, int[] prices, int[] price1, int uOrder, int uprice)
        {
            int sum = 0;
            int ave = 0;
            for (int x = 0; x < uOrder; x++)
            {
                sum = sum + prices[x];
            }
            ave = sum / uOrder;

            if (ave > uprice)
            {
                Console.WriteLine(" " + names[0]);
            }
            int sum1 = 0;
            int ave1 = 0;

            for (int x = 0; x < uOrder; x++)
            {
                sum1 = sum1 + price1[x];
            }
            ave1 = sum1 / uOrder;
            if (ave1 > uprice)
            {
                Console.WriteLine(" " + names[1]);
            }
        }

        static void Main(string[] args)
        {

            //  Console.Write("Hello World!!");
            //  Console.WriteLine("Hello World!!");

            // Main1();
            // Main2();
            // Main3();
            // Main4();
            // Main5();
            // Main6();
            // Main7();
            // Main8();
            // Main9();
            // Main10();
            // Main11();
            // Main12();
            // Main13();
            // Main14();
            // Main15();
            // Main16();
            // Main17();
            // Main18();
            // Main19();
           //  Main20();
            Console.ReadKey();
        }
        static void Main1()
        {
            Console.WriteLine("Hello World!!");
            Console.WriteLine("Hello World!!");
            
        }
        static void Main2()
        {
            int value = 7;
            Console.WriteLine("Value: "+ value);
        }
        static void Main3()
        {
            string line = "I am String";
            Console.WriteLine("String: " + line);
        }
        static void Main4()
        {
            char alpha = 'A';
            Console.WriteLine("Character: ");
            Console.WriteLine(alpha);
        }
        static void Main5()
        {
            float varialbe = 3.4F;
            Console.WriteLine("Decimal : ");
            Console.WriteLine(varialbe);
        }
        static void Main6()
        {
            string str;
            Console.WriteLine("Enter Your Input : ");
            str = Console.ReadLine();
            Console.WriteLine("You have Inputed  : ");
            Console.WriteLine(str);
        }
        static void Main7()
        {
            
            int number;
            Console.WriteLine("Enter Your Number : ");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("You have Enter The Number  : ");
            Console.WriteLine(number);
        }
        static void Main8()
        {

            float number;
            Console.WriteLine("Enter Your Number : ");
            number = float.Parse(Console.ReadLine());
            Console.WriteLine("You have Enter The Number  : ");
            Console.WriteLine(number);
        }
        static void Main9()
        {

            float number;
            Console.WriteLine("Enter Your lenght : ");
            number = float.Parse(Console.ReadLine());
            Console.WriteLine("Area is  : ");
            Console.WriteLine(number*number);
        }
        static void Main10()
        {
            float marks;
            Console.WriteLine("Enter Your Marks : ");
            marks = float.Parse(Console.ReadLine());
            if (marks>50)
            {
                Console.WriteLine(" You Are Passed ");
            }
            else if (marks < 50)
            {
                Console.WriteLine(" You Are Failed ");
            }

        }
        static void Main11()
        {
            for (int x=0; x<5; x++)
            {
                Console.WriteLine(" Welcome JAck");
            }
        }
        static void Main12()
        {
            int num;
            int sum = 0;
            Console.WriteLine("Enter Your Number");
            num = int.Parse(Console.ReadLine());
            while(num!=-1)
            {
                Console.WriteLine("Enter Your Number");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            Console.WriteLine("Total Sum Is  " + sum);
        }
        static void Main13()
        {
            int num;
            int sum = 0;
            do
            {
                Console.WriteLine("Enter Your Number");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            while (num != -1);
            sum = sum + 1;
            Console.WriteLine("Total Sum Is  " + sum);
        }
        static void Main14()
        {
            int[] arr= new int[3];
            int largest = 0;
            for (int x=0; x<3; x++)
            {
                Console.WriteLine("Enter Your Number ");
                arr[x] = int.Parse(Console.ReadLine());
            }
            for (int x = 0; x < 3; x++)
            {
                if (largest<arr[x])
                {
                    largest = arr[x];
                }
            }
            Console.WriteLine("Largest Value Is  " + largest);
        }
        static void Main15()
        {
            int age=0, tPrice, saveMoney = 0, moneyR = 0, toys = 0, toySold=0, count =0, amountR=0 ; 
            float price=0;
            float WPrice;
            Console.WriteLine("Enter Lily Age ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Washing Machine Price ");
            WPrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Toy Price ");
            tPrice = int.Parse(Console.ReadLine());
            for(int x=1; x<=age; x++)
            {
                if (x%2==0)
                {
                    moneyR = moneyR + 10;
                    saveMoney = saveMoney + moneyR;
                    count++;
                }
                else if(x%2!=0)
                {
                    toys = toys + 1;
                }
            }
            toySold = toys * tPrice;
            amountR = saveMoney + toySold- count;
            price = amountR - WPrice;
            if (amountR > WPrice)
            {
                Console.Write("Yes!" + price );

            }
            if (amountR < WPrice)
            {
                price = -(price);
                Console.Write("No! " + price);

            }
        }
        static void Main16()
        {
            int num1, num2, sum;
            Console.WriteLine("Enter Number 1 ");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number 2 ");
            num2 = int.Parse(Console.ReadLine());
            sum = add(num1, num2);
            Console.WriteLine("Sum is " + sum);
        }
        static void Main17()
        {
            string path = "P:\\PF Week 1\\PF Week 1\\text.txt";
            if(File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine())!=null)
                {
                    Console.WriteLine(record);
                }
                 fileVariable.Close();
            }
            else
            {
                Console.WriteLine("NO DAta");
            }
        }
        static void Main18()
        {
            string path = "P:\\PF Week 1\\PF Week 1\\text.txt";            
                StreamWriter fileVariable = new StreamWriter(path, true);
                fileVariable.WriteLine("Hello");
                fileVariable.Flush();
                fileVariable.Close();
                        }
        static void Main19()
        {

                string path = "P:\\PF Week 1\\PF Week 1\\text2.txt";
            string n, p;
                string[] names = new string[5];
                string[] password = new string[5];
                int option;
                do
                {
                    readdata(path, names, password);
                    Console.Clear();
                    option = menu();
                    Console.Clear();
                    if (option == 1)
                    {
                        Console.WriteLine(" Enter name: ");
                         n = Console.ReadLine();
                        Console.WriteLine(" Enter password: ");
                         p = Console.ReadLine();
                        signin(n, p, names, password);
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine(" Enter new names: ");
                        n = Console.ReadLine();
                        Console.WriteLine("Enter New password: ");
                        p = Console.ReadLine();
                        signup(path, n, p);
                    }
                }
                while (option < 3);
                Console.Read();   
        }
        static void Main20()
        {


            string path = "P:\\PF Week 1\\PF Week 1\\text3.txt";
            string[] names = new string[100];
                int uOrder;
                int uprice;
                int orders = 1;
                int orders1 = 1;
                int[] prices = new int[100];
                int[] price1 = new int[100];

                bool check = readdata(path, names, orders, orders1, prices, price1);
                if (check == true)
                {
                    Console.Write("Enter No. of Order");
                    uOrder = int.Parse(Console.ReadLine());
                    Console.Write("Enter Minimum Price");
                    uprice = int.Parse(Console.ReadLine());
                    calculate(names, orders, orders1, prices, price1, uOrder, uprice);
                }
                else
                {
                    Console.WriteLine(" No Data ");

                }
            Console.ReadKey();
        }
    }
}
    

