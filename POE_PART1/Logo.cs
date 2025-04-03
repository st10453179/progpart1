using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;

namespace POE_PART1
{
    public class Logo
    {

        //constroctor 
        public Logo()
        {

            //getting the full path 
            string path_project = AppDomain.CurrentDomain.BaseDirectory;

            //then replacing the bin\\Debug\\
            string new_path_project = path_project.Replace("bin\\Debug\\", "");

            //then combining the project full path and the image with the format
            string full_path = Path.Combine(new_path_project, "Logo.jpeg");

            //working on the logo with ASCII
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(100, 50));



            //for loop,for inner and outer 
            //nested
            for (int height = 0; height < image.Height; height++)
            {
                //working on the width
                for (int width = 0; width < image.Width; width++)
                {

                  //working on the ascii design 
                  Color pixecolor = image.GetPixel(width, height);
                    int color = (pixecolor.R + pixecolor.G + pixecolor.B) / 3;

                    //making use of char 
                    char ascii_design = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? '0' : color > 50 ? '#' : '@';
                    Console.Write(ascii_design);//output the design 

                }//end of the loop for inner
                Console.WriteLine();//skip  line 
           }//end of the loop for outer 
        }
    }
}