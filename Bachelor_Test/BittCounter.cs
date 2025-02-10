using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Test
{
    internal class BittCounter
    {
        public ushort BittMassage { get; private set; }

        public BittCounter(int dotNumber, int Value)
        {
                try
                {

                    if (dotNumber == 0 && Value == 1)
                    {
                    BittMassage = 1;

                    }
                    else if (dotNumber == 1 && Value == 1) 
                    {
                    BittMassage = 2;
                    
                    }
                    else if (dotNumber == 2 && Value == 1)
                    {
                    BittMassage = 4;

                    }
                    else if (dotNumber == 3 && Value == 1)
                    {
                    BittMassage = 8;

                    }
                    else if (dotNumber == 4 && Value == 1)
                    {
                    BittMassage = 16;

                    }
                    else if (dotNumber == 5 && Value == 1)
                    {
                    BittMassage = 32;

                    }
                    else if (dotNumber == 6 && Value == 1)
                    {
                    BittMassage = 64;

                    }
                    else if (dotNumber == 7 && Value == 1)
                    {
                    BittMassage = 128;

                    }
                    else if (dotNumber == 8 && Value == 1)
                    {
                    BittMassage = 256;

                    }
                    else if (dotNumber == 9 && Value == 1)
                    {
                    BittMassage = 512;

                    }
                    else if (dotNumber == 10 && Value == 1)
                    {
                    BittMassage = 1024;

                    }
                    else if (dotNumber == 11 && Value == 1)
                    {
                    BittMassage = 2048;

                    }
                    else if (dotNumber == 12 && Value == 1)
                    {
                    BittMassage = 4096;

                    }
                    else if (dotNumber == 13 && Value == 1)
                    {
                    BittMassage = 8192;

                    }
                    else if (dotNumber == 14 && Value == 1)
                    {
                    BittMassage = 16384;

                    }
                    else if (dotNumber == 15 && Value == 1)
                    {
                    BittMassage = 32768;

                    }

                    else
                    {
                    BittMassage = 0;
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Unexpected Error");


                }
            
            
            
        
        }
    }
}
