using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Test
{
    internal class BittCounter
    {
        //This class makes calculations based on the number of the bit that is getting changed by user. This way the appropriate bit
        //will be changed based on the bit number after the dot. It ensures it will only happen when user has inputted 1 in the textbox
        //for values.
        public ushort bitValue { get; private set; }

        public BittCounter(int bitNumber, int value)
        {
                try
                {

                    if (bitNumber == 0 && value == 1)
                    {
                    bitValue = 1;

                    }
                    else if (bitNumber == 1 && value == 1) 
                    {
                    bitValue = 2;
                    
                    }
                    else if (bitNumber == 2 && value == 1)
                    {
                    bitValue = 4;

                    }
                    else if (bitNumber == 3 && value == 1)
                    {
                    bitValue = 8;

                    }
                    else if (bitNumber == 4 && value == 1)
                    {
                    bitValue = 16;

                    }
                    else if (bitNumber == 5 && value == 1)
                    {
                    bitValue = 32;

                    }
                    else if (bitNumber == 6 && value == 1)
                    {
                    bitValue = 64;

                    }
                    else if (bitNumber == 7 && value == 1)
                    {
                    bitValue = 128;

                    }
                    else if (bitNumber == 8 && value == 1)
                    {
                    bitValue = 256;

                    }
                    else if (bitNumber == 9 && value == 1)
                    {
                    bitValue = 512;

                    }
                    else if (bitNumber == 10 && value == 1)
                    {
                    bitValue = 1024;

                    }
                    else if (bitNumber == 11 && value == 1)
                    {
                    bitValue = 2048;

                    }
                    else if (bitNumber == 12 && value == 1)
                    {
                    bitValue = 4096;

                    }
                    else if (bitNumber == 13 && value == 1)
                    {
                    bitValue = 8192;

                    }
                    else if (bitNumber == 14 && value == 1)
                    {
                    bitValue = 16384;

                    }
                    else if (bitNumber == 15 && value == 1)
                    {
                    bitValue = 32768;

                    }
                    //If user has not inputted 1 then the bit value will be 0
                    else
                    {
                    bitValue = 0;
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Unexpected Error");


                }
            
            
            
        
        }
    }
}
