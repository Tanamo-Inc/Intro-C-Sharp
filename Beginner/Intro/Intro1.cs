//using is similar to import in Java. It brings in specify namespace.

using System;



/*
C# is a simple, modern, general-purpose, object-oriented programming 
language developed by Microsoft.
It was developed by Anders Hejlsberg and his team during the development of .Net Framework. 
*/

// A namespace is a collection of classes.

//Keyboard shortcuts  in Visual Studio.
/*
 1.Ctrl+K+C --- Comments.
 2.Ctrl+K+U --- Uncomments.
 3.Alt+F12  --- Definition
 4.Ctrl+D,Ctrl+K --- Format
 */



namespace Intro
{
    class Intro1


    {
        /*
        Main is spelled with a capital “M”, which is different than Java, C,C++ etc .
        All method names start with a capital letter in the .NET Framework for consistency
        */
        static void Main(string[] args)
        {
            //calling the function Load from the class Intro2.
            var cal = new Intro2();
            cal.Load();

            AuthUsers();
        }

        //This is our authentication method.
        private static void AuthUsers()
        {

            Console.WriteLine("*************   ******* ******   *****INTRODUCTION TO C# BY TANAMO INC.*****  ***** *******  *******************");

            Console.WriteLine("Please Fill The Instructions Below :");

            Console.WriteLine("What's your First Name");
            Console.Write("type your first name here :");

            //Variable of Type String.
            String firstName;  //Using camel Case
            firstName = Console.ReadLine();

            Console.WriteLine("What's your Last Name");
            Console.Write("type your last name:");

            //Variable of Type String.
            String lastName;  //Using camel Case
            lastName = Console.ReadLine();


            Console.WriteLine("Enter Your Email Address");
            Console.Write("type your email address here:");


            String eMail;
            eMail = Console.ReadLine();

            //Variable of Type int.
            int level = 0;

            Console.WriteLine("Enter Level");
            Console.Write("type level here:");

            try
            {
                level = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.Write("Please enter a number !");

            }



            //Print out a new Line.
            Console.WriteLine("\n");

            Console.WriteLine("Hello " + firstName + " " + lastName);

            Console.WriteLine("\n");

            //  Console.WriteLine("Welcome " + lastName + "  to the C# tutorials.");

            //String interpolation lets you piece together strings in a more concise and readable way.
            Console.WriteLine($"Welcome  {lastName.ToUpper()}  to the C# tutorials.");


            Console.WriteLine("\n");

            Console.WriteLine("Email :" + eMail + " has being verified");

            Console.WriteLine("\n");

            String message = "";

            //Using the if Statment...
            if (level == 100)
            {
                message = " you are in level 100";
            }

            //Using the else if Statement...
            else if (level == 200)
            {
                message = " you are in level 200";
            }

            else if (level == 300)
            {
                message = " you are in level 300";
            }

            else if (level == 400)
            {
                message = " you are in level 400";
            }

            //Using the else Statement...
            else
            {
                message = " level not found";

                message += " \n Please Try Later";

            }

            Console.WriteLine(lastName + "" + message);

            Console.WriteLine("\n");

            Console.WriteLine("Signature");

            Console.WriteLine("\n");

            Console.ReadLine();

        }


        //NB: Statements are terminated with a semicolon (;)

    }

}
