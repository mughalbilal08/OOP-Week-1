using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//role = Signin(names,passwords, name, password, count, count1);

namespace Application_ochoice_
{

    class Program
    {

        static void Main(string[] args)
        {

            // ############################################## ARRAYS ###########################################################

            int count1 = 0;
            int bookCount = 0;
            int count = 0;
            //  int complainCount = 0;
            // int reviewCount = 0;
            string[] reviews = new string[100];
            int[] months = new int[100];
            int[] dates = new int[100];
            string[] fines = new string[100];
            string[] bookBorrow = new string[100];
            bool[] bookWidraw = new bool[100];
            string[] bookList = new string[100];
            string[] names = new string[100];
            string[] passwords = new string[100];
            string[] roles = new string[100];
            string[] bookAuthur = new string[100];
            string[] bookPublish = new string[100];
            string[] userComplaints = new string[100];
            bool[] complaintCheck = new bool[100];
            bool[] reviewCheck = new bool[100];

            // ############################################## VARIABLES ###########################################################

            string option;

            int n = 1;
            int n2 = 1;
            loadData(ref names, ref passwords, ref dates, ref months, ref userComplaints, ref bookBorrow, ref reviews, bookWidraw, complaintCheck, reviewCheck, ref count, ref count1);
            loadData1(ref bookList, ref bookPublish, ref bookAuthur, ref bookCount);

            // ############################################## MAIN FUNCTION ###########################################################

            while (n == 1)
            {
                string role = "";
                Console.Clear();
                header();
                n2 = 1;
                option = menu();

                if (option == "1")
                {
                    for (int x = 0; x < 6; x++)
                    {
                        Console.Clear();
                        header();


                        string Uname, Upassword;
                        Console.WriteLine(" ---------------------------------------------------------");
                        Console.WriteLine(" | Note: If Your're Admin Enter Only Predefined Admin ID |");
                        Console.WriteLine(" ---------------------------------------------------------");
                        Console.WriteLine("");


                        Console.WriteLine(" Enter your Name: ");
                        Uname = Console.ReadLine();

                        Console.WriteLine(" Enter your Password (Password Must be 8 Character ");
                        Upassword = Console.ReadLine();

                        role = signin(ref names, ref passwords, ref Uname, ref Upassword, ref count, ref count1);
                        Console.WriteLine(role);
                        Console.Read();

                        if (role == "Invalid")
                        {
                            Console.WriteLine(" User is not Present: ");
                            Console.WriteLine(" Please enter valid data");

                            continue;
                        }
                        if (role == "admin" || role == "student")
                        {
                            break;
                        }

                        if (x >= 5)
                        {
                            n2 = 0;
                            break;
                        }

                    }

                    if (n2 == 0)
                    {
                        Console.WriteLine(" You Have Entered Data Wrong data 5-times, We are going to sign-in page again ");
                        continue;
                    }

                    while (true)
                    {

                        if (role == "admin")
                        {
                            Console.Clear();
                            adminMenu(ref names, ref passwords, ref dates, ref months, ref userComplaints, ref bookBorrow, ref reviews, bookWidraw, complaintCheck, reviewCheck, ref count, ref count1, ref bookList, ref bookPublish, ref bookAuthur, ref bookCount);
                            break;
                        }

                        else if (role == "student")
                        {
                            Console.Clear();
                            Console.Write("Welcome TO Student");
                            Console.ReadKey();
                            break;
                        }
                    }

                }

                else if (option == "2")
                {

                    Console.Clear();
                    header();
                    string Uname;
                    string Upassword;
                    Console.Write(" Enter your Name: ");
                    Uname = Console.ReadLine();
                    bool isName = name_check(Uname);
                    if (isName == true)
                    {
                        Console.Write(" Enter the password (Must Be 8 Characters)");
                        Upassword = Console.ReadLine();
                        bool valid = password_check(Upassword);
                        if (valid == true)
                        {
                            bool isCheck = Signup(ref names, ref passwords, ref roles, ref Uname, ref Upassword, ref role, ref count);
                            if (isCheck == true)
                            {
                                Console.WriteLine(" Already Exit");
                            }
                            if (isCheck == false)
                            {

                                Console.Clear();
                                header();
                                Console.Write(" THE ID HAS BEEN CREATED Successfully !! ");
                                Console.ReadKey();
                            }
                        }
                        else if (valid == false)
                        {
                            Console.Clear();
                            header();
                            Console.Write(" Please Enter a strong password . ");
                        }
                    }
                    else if (isName == false)
                    {
                        Console.Clear();
                        header();
                        Console.Write(" Please Enter a Name without integers");
                    }
                }
                else if (option == "3")
                {
                    saveData(ref names, ref passwords, ref dates, ref months, ref userComplaints, ref bookBorrow, ref reviews, bookWidraw, complaintCheck, reviewCheck, ref count);
                    saveData1(ref bookList, ref bookPublish, ref bookAuthur, ref bookCount);
                    n = 0;
                }

            }


        }

        // ############################# MAIN MENU ###############################################

        static string menu()
        {
            string choice;
            Console.WriteLine(" Press 1 to Sign IN: ");
            Console.WriteLine(" Press 2 to Sign UP: ");
            Console.WriteLine(" Press 3 to Exit: ");
            Console.WriteLine(" Press (1 - 3) to Enter: ");
            choice = Console.ReadLine();
            return choice;
        }

        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue..."); ;
            Console.ReadKey();
            Console.Clear();
        }

        public static void header()
        {

            Console.WriteLine(""); ;
            Console.WriteLine("              #######################################################################################################################################################################");
            Console.WriteLine("              #                                                                                                                                                                     #");
            Console.WriteLine("              #  $     $  $$$$$$   $$$$$  $$$$$  $$$$$  $    $    $$$$$$$ $$$$$$ $$$$$ $$$$$$ $$$$$$  $$$$$ $$$$$$$ $$$$$ $$$$$ $$$$$    $$$$$$ $    $ $$$$$$ $$$$$ $$$$$  $$$$$$$  #");
            Console.WriteLine("              #  $     $  $     $   $   $  $   $ $    $ $    $    $  $  $ $    $ $   $ $    $ $    $  $     $  $  $ $     $   $   $      $      $    $ $        $   $      $  $  $  #");
            Console.WriteLine("              #  $$    $$ $$$$$$$$ $$$$$$ $$$$$$ $$$$$$ $$$$$$    $$ $  $ $$$$$$ $$  $ $$$$$$ $$      $$$$$ $$ $  $ $$$$$ $$  $   $$     $$$$$$ $$$$$$ $$$$$$   $$  $$$$$  $$ $  $  #");
            Console.WriteLine("              #  $$    $$ $$     $ $$   $ $$   $ $$   $   $$      $$ $  $ $$   $ $$  $ $$   $ $$ $$$$ $$    $$ $  $ $$    $$  $   $$         $$   $$       $$   $$  $$     $$ $  $  #");
            Console.WriteLine("              #  $$$$$ $$ $$$$$$$$ $$   $ $$   $ $$   $   $$      $$ $  $ $$   $ $$  $ $$   $ $$$$$ $ $$$$$ $$ $  $ $$$$$ $$  $   $$     $$$$$$   $$   $$$$$$   $$  $$$$$  $$ $  $  #");
            Console.WriteLine("              #                                                                                                                                                                     #");
            Console.WriteLine("              #######################################################################################################################################################################");
            Console.WriteLine(""); ;
            Console.WriteLine(""); ;
            Console.WriteLine("                                        <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine("                                        <><><>---<>---<>---<>---<>---<>---<>---< LIBRARY MANAGEMENT SYSTEM >---<>---<>---<>---<>---<>---<>---<><><>");
            Console.WriteLine("                                        <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine(""); ;
        }

        public static void clear()
        {
            Console.WriteLine();
            Console.Write(" Press any Key to Continue ....... ");
            Console.ReadKey();
            Console.Clear();
        }


        // ############################# Sign In ###############################################

        public static string signin(ref string[] names, ref string[] passwords, ref string userName, ref string userPassword, ref int count, ref int count1)
        {

            for (int index = 0; index < count; index++)
            {
                if (userName == names[index] && userPassword == passwords[index])
                {
                    if (index == 0)
                    {
                        count1 = 0;
                        return "admin";
                    }
                    else
                    {
                        count1 = index;
                        return "student";
                    }

                }
            }

            return "isAbsent";

        }


        // ############################# Sign In ###############################################

        public static bool Signup(ref string[] names, ref string[] passwords, ref string[] roles, ref string name, ref string password, ref string role, ref int count)
        {
            bool isCheck = false;

            for (int index = 0; index < count; index++)
            {
                if (names[index] == name && passwords[index] == password && roles[index] == role)
                {
                    isCheck = true;
                    break;
                }


            }

            if (isCheck == false)
            {
                names[count] = name;
                passwords[count] = password;
                roles[count] = "student";
                count++;
            }


            return isCheck;
        }

        // ############################# Validations ###############################################

        public static bool name_check(string name)
        {
            bool flag = false;
            int i = 0;
            while (i < name.Length)
            {
                if ((name[i] > 63 && name[i] < 91) || (name[i] > 96 && name[i] < 123))
                {
                    i++;
                    if (i >= 5)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        public static bool password_check(string password)
        {
            bool flag = false;
            int i = 0;
            while (i < password.Length)
            {
                if ((password[i] > 63 && password[i] < 91) || (password[i] > 96 && password[i] < 123) || (password[i] > 47 && password[i] < 58) || (password[i] > 34 && password[i] < 39))
                {
                    i++;
                    if (i >= 8)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        //############################################ myFile HANDING ##########################################################

        static string getfield(string record, int field)
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

        public static void loadData(ref string[] names, ref string[] passwords, ref int[] dates, ref int[] months, ref string[] userComplaints, ref string[] bookBorrow, ref string[] reviews, bool[] bookWidraw, bool[] complaintCheck, bool[] reviewCheck, ref int count, ref int count1)
        {
            int index = 0;
            string line;
            string widraw, complain, check;
            string path = "P:\\BussinessAPP(C-Sharp)\\BussinessAPP(C-Sharp)\\userData.txt";
            StreamReader myFile = new StreamReader(path);
            while ((line = myFile.ReadLine()) != null)
            {
                names[index] = getfield(line, 1);
                passwords[index] = getfield(line, 2);
                dates[index] = int.Parse(getfield(line, 3));
                months[index] = int.Parse(getfield(line, 4));
                userComplaints[index] = getfield(line, 5);
                bookBorrow[index] = getfield(line, 6);
                reviews[index] = getfield(line, 7);
                widraw = getfield(line, 8);
                complain = getfield(line, 9);
                check = getfield(line, 10);
                helper(bookWidraw, complaintCheck, reviewCheck, widraw, complain, check, count);
                index++;
            }
            count = index;
            myFile.Close();
        }

        public static void helper(bool[] bookWidraw, bool[] complaintCheck, bool[] reviewCheck, string widraw, string complain, string check, int count)
        {
            if (widraw == "1")
            {
                bookWidraw[count] = true;
            }
            if (widraw == "0")
            {
                bookWidraw[count] = false;
            }
            if (complain == "1")
            {
                complaintCheck[count] = true;
            }
            if (complain == "0")
            {
                complaintCheck[count] = false;
            }
            if (check == "1")
            {
                reviewCheck[count] = true;
            }
            if (check == "0")
            {
                reviewCheck[count] = false;
            }
        }

        public static void saveData(ref string[] names, ref string[] passwords, ref int[] dates, ref int[] months, ref string[] userComplaints, ref string[] bookBorrow, ref string[] reviews, bool[] bookWidraw, bool[] complaintCheck, bool[] reviewCheck, ref int count)
        {
            string path = "P:\\BussinessAPP(C-Sharp)\\BussinessAPP(C-Sharp)\\userData.txt";
            StreamWriter myFile = new StreamWriter(path, false);
            for (int x = 0; x < count; x++)
            {
                myFile.Write(names[x] + ",");
                myFile.Write(passwords[x] + ",");
                myFile.Write(dates[x] + ",");
                myFile.Write(months[x] + ",");
                myFile.Write(userComplaints[x] + ",");
                myFile.Write(bookBorrow[x] + ",");
                myFile.Write(reviews[x] + ",");
                myFile.Write(bookWidraw[x] + ",");
                myFile.Write(complaintCheck[x] + ",");
                myFile.WriteLine(reviewCheck[x]);

            }

            myFile.Close();
        }

        public static void loadData1(ref string[] bookList, ref string[] bookPublish, ref string[] bookAuthur, ref int bookCount)
        {
            int index = 0;
            string line;
            string path = "P:\\BussinessAPP(C-Sharp)\\BussinessAPP(C-Sharp)\\bookData.txt";
            StreamReader myFile = new StreamReader(path);
            while ((line = myFile.ReadLine()) != null)
            {
                bookList[index] = getfield(line, 1);
                bookPublish[index] = getfield(line, 2);
                bookAuthur[index] = getfield(line, 3);
                index++;
            }
             bookCount = index;
            myFile.Close();

        }
        public static void saveData1(ref string[] bookList, ref string[] bookPublish, ref string[] bookAuthur, ref int bookCount)
        {
            string path = "P:\\BussinessAPP(C-Sharp)\\BussinessAPP(C-Sharp)\\bookData.txt";
            StreamWriter myFile = new StreamWriter(path, false);
            for (int x = 0; x < bookCount; x++)
            {
                myFile.Write(bookList[x] + ",");
                myFile.Write(bookPublish[x] + ",");
                myFile.WriteLine(bookAuthur[x]);               
            }
            myFile.Close();
        }

        public static string getField2(string record, int number)
        {
            int commaCount = 1;
            string items = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == '-')
                {
                    commaCount++;
                }
                else if (commaCount == number)
                {
                    items = items + record[x];
                }
            }
            return items;
        }

        //############################################ Admin Functionalities ##########################################################

        public static void adminMenu(ref string[] names, ref string[] passwords, ref int[] dates, ref int[] months, ref string[] userComplaints, ref string[] bookBorrow, ref string[] reviews, bool[] bookWidraw, bool[] complaintCheck, bool[] reviewCheck, ref int count, ref int count1, ref string[] bookList, ref string[] bookPublish, ref string[] bookAuthur, ref int bookCount)
        {

            string choice;
            bool logout = false;
            while (true)
            {

                Console.Clear();
                header();
                Console.WriteLine();
                Console.WriteLine(" -------------------------------------");
                Console.WriteLine(" |  Welcome To Admin Functionalities |  ");
                Console.WriteLine(" -------------------------------------");
                Console.WriteLine();
                Console.WriteLine(" Press Any Of Following to Enter:");
                Console.WriteLine(" 1. Modify/ Add Books: ");
                Console.WriteLine(" 2. Search Books: ");
                Console.WriteLine(" 3. View Book List (Details): ");
                Console.WriteLine(" 4. Remove Books: ");
                Console.WriteLine(" 5. View List of Registered Students : ");
                Console.WriteLine(" 6. View List Of Students who Lend The Books: ");
                Console.WriteLine(" 7. Remove User: ");
                Console.WriteLine(" 8. Change Admin Username And Password: ");
                Console.WriteLine(" 9. Check Complaints of Students: ");
                Console.WriteLine(" 10. Check Reviews of Students: ");
                Console.WriteLine(" 11. Return to Main Menu: ");
                Console.WriteLine(" 12. Exit Program: ");
                Console.WriteLine(" Enter Your Choice (1-12): ");

                choice = Console.ReadLine();



                if (choice == "1")
                {
                    Console.Clear();
                    header();
                    int size;
                    Console.Write(" Enter no. of Books You Want to ENTER: ");
                    size = int.Parse(Console.ReadLine());

                    string isCheck = addbooks(ref bookList, ref bookPublish, ref bookAuthur, ref bookCount, ref size);

                    if (isCheck == "true")
                    {
                        Console.Write(" Book Has Been Added:");
                    }

                    else
                    {
                        Console.Write(" No Book Is Available. ");
                        Console.Write(" It Will be Available Soon !! ");
                    }

                    Console.Read();

                }

                else if (choice == "2")
                {
                    Console.Clear();
                    header();
                    string search;
                    Console.Write(" Enter Book Name You Want To Search: ");
                    search = Console.ReadLine();

                    bool isCheck = searchBooks(ref bookList, ref bookCount, search);

                    if (isCheck == true)
                    {
                        Console.Write(" Book Is Available: ");
                    }

                    if (isCheck == false)
                    {
                        Console.Write(" Book Is Not Available: ");
                    }

                    clear();
                }

                else if (choice == "3")
                {
                    Console.Clear();
                    header();
                    if (bookCount != 0)
                    {
                        Console.Clear();
                        header();
                        Console.Write(" Book Details Are ");
                        Console.Write(" .............................");
                        Console.WriteLine();
                        viewDetails(ref bookList, ref bookPublish, ref bookAuthur, ref bookCount);
                    }

                    else
                    {
                        Console.Write(" No Data Has Been Found ");
                    }

                    clear();
                }

                else if (choice == "4")
                {

                    Console.Clear();
                    header();
                    string remove, auth;

                    Console.Write(" Enter Book Name You Want to Remove: ");
                    remove = Console.ReadLine();
                    Console.Write(" Enter Author Name You Want to Remove: ");
                    auth = Console.ReadLine();

                    checkRbooks(ref bookList, ref bookPublish, ref bookAuthur, ref bookCount, ref remove, ref auth);

                    clear();
                }

                else if (choice == "5")
                {

                    Console.Clear();
                    header();
                    bool reg = registeredStudents(ref names, ref passwords, ref count);
                    if (reg == false)
                    {
                        Console.Write(" No student has been Found. ");
                    }

                    clear();
                }

                else if (choice == "6")
                {
                    Console.Clear();
                    header();
                    borrowlist(ref names, ref bookBorrow, ref bookWidraw, ref count1, ref count);

                }

                else if (choice == "7")
                {

                    Console.Clear();
                    header();

                    string removeName, userPassword;

                    Console.Write(" Enter username You Want to Remove: ");
                    removeName = Console.ReadLine();

                    Console.Write(" Enter password of Username You Want to Remove: ");
                    userPassword = Console.ReadLine();


                    bool rem = removeUser(ref names, ref passwords, ref removeName, ref userPassword, ref count);

                    if (rem == true)
                    {
                        Console.Write(" User Has Been Removed ");
                        count--;
                        userR(ref names, ref passwords, ref count);
                    }

                    else
                    {
                        Console.Write(" No user Found ");
                    }

                    clear();

                }

                else if (choice == "8")
                {

                    Console.Clear();
                    header();
                    string name, password;
                    Console.Write(" Enter Your Current Admin Name: ");
                    name = Console.ReadLine();

                    Console.Write(" ENter Your Current Admin Password: ");
                    password = Console.ReadLine();



                    Console.Clear();
                    header();


                    string check = changedetails(ref names, ref passwords, ref name, ref password);

                    if (check == "true")
                    {
                        Console.Clear();
                        header();

                        Console.Write(" ID Has Been Updated !  ");
                        saveData(ref names, ref passwords, ref dates, ref months, ref userComplaints, ref bookBorrow, ref reviews, bookWidraw, complaintCheck, reviewCheck, ref count);
                    }

                    if (check == "false")
                    {
                        Console.Write("Irrelevent Credentials");
                    }
                    clear();

                }

                else if (choice == "9")
                {
                    Console.Clear();
                    header();

                    checkComplaint(ref names, ref userComplaints, complaintCheck, ref count);
                    clear();

                }

                else if (choice == "10")
                {
                    Console.Clear();
                    header();

                    checkReview(ref names, ref userComplaints, ref reviews, reviewCheck, ref count);
                    clear();

                }

                else if (choice == "11")
                {
                    logout = true;

                }

                else if (choice == "12")
                {
                    Console.Clear();
                    Console.Write("Programs End ");
                    while (true)
                    {
                        Console.ReadKey();
                    }
                }
                if (logout == true)
                {
                    break;
                }

            }
        }

        public static string addbooks(ref string[] bookList, ref string[] bookPublish, ref string[] bookAuthur, ref int bookCount, ref int size)
        {
            string isAdd = "false";
            for (int index = bookCount; index < bookCount + size; index++)
            {
                Console.Write(" Enter Book Name: ");
                string Bname = Console.ReadLine();
                bookList[index] = Bname;
                Console.Write(" Enter Authuor Name: ");
                string Bauth = Console.ReadLine();
                bookAuthur[index] = Bauth;
                Console.Write(" Enter Publish Year: ");
                string Bpub = Console.ReadLine();
                bookPublish[index] = Bpub;
                Console.WriteLine();
                isAdd = "true";
            }

            bookCount =  size;        
            saveData1(ref bookList, ref bookPublish, ref bookAuthur, ref bookCount);
            return isAdd;
            clear();
        }

        public static bool searchBooks(ref string[] bookList, ref int bookCount, string search)
        {
            bool isCheck = false;
            for (int index = 0; index < bookCount; index++)
            {
                if (search == bookList[index])
                {
                    isCheck = true;
                    break;
                }
            }
            return isCheck;
        }

        public static void viewDetails(ref string[] bookList, ref string[] bookPublish, ref string[] bookAuthur, ref int bookCount)
        {
            for (int i = 0; i < bookCount; i++)
            {
                Console.WriteLine();
                Console.WriteLine(" Book Name " + i + 1 + " is: " + bookList[i]);
                Console.WriteLine(" Author of book " + i + 1 + " is: " + bookAuthur[i]);
                Console.WriteLine(" Publish Date of Book " + i + 1 + " is: " + bookPublish[i]);
                Console.WriteLine();
            }
        }

        public static void checkRbooks(ref string[] bookList, ref string[] bookPublish, ref string[] bookAuthur, ref int bookCount, ref string remove, ref string auhtor)
        {

            bool ischeck = false;
            for (int index = 0; index < bookCount; index++)
            {
                if (remove == bookList[index] && auhtor == bookAuthur[index])
                {
                    bookList[index] = " ";
                    bookAuthur[index] = " ";
                    bookPublish[index] = " ";
                    ischeck = true;
                    break;
                }
            }
            if (ischeck == true)
            {
                for (int index = 0; index < bookCount; index++)
                {
                    if (bookList[index] == " ")
                    {
                        bookList[index] = bookList[index + 1];
                        bookAuthur[index] = bookAuthur[index + 1];
                        bookPublish[index] = bookPublish[index + 1];
                        bookList[index + 1] = " ";
                        bookAuthur[index + 1] = " ";
                        bookPublish[index + 1] = " ";
                    }
                }
                bookCount--;
                Console.Write(" Book Has Been Removed.");
            }
            if (ischeck == false)
            {
                Console.Write(" Irrelevent Details. ");
            }
        }

        public static bool registeredStudents(ref string[] names, ref string[] passwords, ref int count)
        {

            bool isCheck = false;
            for (int i = 1; i < count; i++)
            {

                if (names[i] != " " && passwords[i] != " ")
                {
                    isCheck = true;
                    Console.Write(" Name of Student: " + names[i]);
                    Console.Write(" Password of Student: " + passwords[i]);
                    Console.WriteLine();
                }
            }
            return isCheck;
        }

        public static void borrowlist(ref string[] names, ref string[] bookBorrow, ref bool[] bookWidraw, ref int count1, ref int count)

        {

            string bname = getField2(bookBorrow[count1], 1);
            for (int x = 1; x < count; x++)
            {
                if (bookWidraw[x] == true)
                {
                    Console.WriteLine();
                    Console.Write(" Names OF Students Who Borrow The Books Are: " + names[x]);
                    Console.Write(" Book name Is: " + bname[x]);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(" Names OF Student is: " + names[x]);
                    Console.WriteLine(" Status: No book Has been Borrowed ");
                }
            }

            clear();
        }

        public static bool removeUser(ref string[] names, ref string[] passwords, ref string name, ref string password, ref int count)
        {

            bool isCheck = false;
            for (int index = 1; index < count; index++)
            {
                if (name == names[index] && password == passwords[index])
                {
                    names[index] = " ";

                    passwords[index] = " ";
                    isCheck = true;
                    break;
                }
            }
            return isCheck;
        }

        public static void userR(ref string[] names, ref string[] passwords, ref int count)
        {

            for (int index = 1; index < count; index++)
            {
                if (names[index] == " ")
                {
                    names[index] = names[index + 1];
                    passwords[index] = passwords[index + 1];

                    names[index + 1] = " ";
                    passwords[index + 1] = " ";

                }
            }
        }

        public static string changedetails(ref string[] names, ref string[] passwords, ref string name, ref string password)
        {

            string isCheck = "false";
            if (name == names[0] && password == passwords[0])
            {

                Console.Write(" Enter New Admin Name: ");
                names[0] = Console.ReadLine();

                Console.Write(" Enter New Admin Password: ");
                passwords[0] = Console.ReadLine(); ;



                Console.WriteLine(" Your Id Has Been Updated :");
                isCheck = "true";
            }
            return isCheck;
        }

        public static void checkComplaint(ref string[] names, ref string[] userComplaints, bool[] complaintCheck, ref int count)
        {

            for (int x = 1; x < count; x++)
            {

                if (complaintCheck[x] == true)
                {
                    Console.Write(" Name of Student is: " + names[x]);
                    Console.Write(" Complaint is: " + userComplaints[x]);
                }
                else if (complaintCheck[x] == false)
                {
                    Console.Write(" Name of Student is: " + names[x]);
                    Console.Write(" Complaint Status :  NO complaint has been submitted. ");
                }
                Console.WriteLine();
            }
        }

        public static void checkReview(ref string[] names, ref string[] userComplaints, ref string[] reviews, bool[] reviewCheck, ref int count)
        {
            for (int x = 1; x < count; x++)
            {

                if (reviewCheck[x] == true)
                {
                    Console.Write(" Name of Student is: " + names[x]);
                    Console.Write(" Review : " + reviews[x]);
                }
                else if (reviewCheck[x] == false)
                {
                    Console.Write(" Name of Student is: " + names[x]);
                    Console.WriteLine(" Review Status :  NO review has been added. ");
                }
                Console.WriteLine();
            }
        }

    }
}
