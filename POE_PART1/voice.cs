using System.IO;
using System.Media;
using System;

namespace POE_PART1
{
     public class voice
    {

        //constructor 
        public voice()
        {
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            //replace bin/Debug/
            string new_path = full_location.Replace("bin\\Debug\\", "");

            //combine the paths
            string full_path = Path.Combine(new_path, "voice_greeting.wav");

            //try and catch to playy the audio 
            try
            {
                //making use of using function
                using (SoundPlayer play = new SoundPlayer(full_path))
                {
                    //play the file 
                    play.PlaySync();
                }


            }
            catch (Exception error) { Console.WriteLine(error.Message); }//end of catch




        }//end of constructor
    }//end of class


}//end of namespace

        
