
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;


namespace POE_PART1
{
    public class Basic
    {
        private string user_name = string.Empty;
        private string user_asking = string.Empty;
        ArrayList replies = new ArrayList();
        ArrayList keywords = new ArrayList();
        string userInput;
        private string user;

        public Basic()
        {

            //getting the full path
            string path_project = AppDomain.CurrentDomain.BaseDirectory;

            // then replace the bin\\Debug
            string new_path_project = path_project.Replace("bin\\Debug\\", "");

            //then combine the project full path and the image name
            //format
            string full_path = Path.Combine(new_path_project, "Logo.jpeg");

            //then start working on the logo
            //with the Ascii
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(100, 50));

            //for loop,for inner and the outer
            //nested
            for (int height = 0; height < image.Height; height++)
            {
                //then now work on the width
                for (int width = 0; width < image.Width; width++)
                {
                    //now lets work on the Ascii
                    Color pixelColor = image.GetPixel(width, height);
                    int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    //now make user of the char
                    char ascii_design = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? '*' : color > 50 ? '*' : '0';
                    Console.Write(ascii_design);//output the design

                }// end of the for loop inner
                Console.WriteLine();//skip the line


            }//end of for Loop outer

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=================================================================================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                      Welcome To ChatBot_AI  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================================================================================================");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" ChatBot :->");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hi! Please enter your name:");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" User :->");
            Console.ForegroundColor = ConsoleColor.White;
            user = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(user))
            {
                user = "Guest";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ChatBot :-> I will call you Guest since  name was not provided.");
                Console.ResetColor();
            }
            //calling the method that have questions and answers
            InitializeRepliesAndKeywords();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" ChatBot :->");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" Hey!! {user}, how can I assist you today?");

            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{user}:->");
                Console.ResetColor();
                userInput = Console.ReadLine();

                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    exit = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("ChatBot:->");
                    Console.ResetColor();
                    Console.WriteLine("Thank you for using Cybersecurity Bot. Stay safe online!");
                    break;
                }
                else if (userInput == "how are you")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("ChatBot:->");
                    Console.ResetColor();
                    Console.WriteLine("I'm good but i will be grate after i help you ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{user}:->");
                    Console.ResetColor();
                    userInput = Console.ReadLine();

                }
                else if (userInput == "what can i ask about")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("ChatBot:->");
                    Console.ResetColor();
                    Console.WriteLine($"you can ask about Phishing emails,safe passwords practices and to recognise suspicious links");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{user}:->");
                    Console.ResetColor();
                    userInput = Console.ReadLine();
                }

                ProcessUserInput(userInput);
            }
        }//end of constructor

        private void InitializeRepliesAndKeywords()
        {
            replies.Add("Password should be strong and unique.Use a mix of letters, numbers, and symbols.");
            replies.Add("Phishing emails often ask for sensitive information. Always verify the sender.\"");
            replies.Add("Attacking phones often involves phishing.");
            replies.Add("Safe browsing includes avoiding suspicious links and ensuring websites use HTTPS.");
            replies.Add("Install antivirus software and keep it updated to protect against malware.");
            replies.Add("My purpose is to help you stay safe online");

            keywords.Add("password");
            keywords.Add("phishing");
            keywords.Add("phone");
            keywords.Add("browse");
            keywords.Add("malware");
            keywords.Add("purpose");
        }

        private void ProcessUserInput(string input)
        {
            string[] words = input.Split(' ');
            bool found = false;
            string response = "";

            foreach (string word in words)
            {
                for (int i = 0; i < keywords.Count; i++)
                {
                    if (word.Equals(keywords[i].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        response += replies[i] + "\n";
                        found = true;
                    }
                }
            }

            if (found)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("ChatBot:->");
                Console.ResetColor();
                Console.Write($" {response}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("ChatBot:->");
                Console.ResetColor();
                Console.WriteLine("Anything else I can assist you with?");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("ChatBot:->");
                Console.ResetColor();
                Console.WriteLine("I didn't quite understand that could you rephrase ?");

            }
        }
    }
}