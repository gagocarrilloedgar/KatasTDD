using System;
using KatasTDD.StringCalculator.Library.Interface;

namespace KatasTDD.StringCalculator.Library
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string v)
        {
            int resultado = 0;
            int value1 = 0, value2 = 0;


            if (v != "")
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\n','*' };
                
                String[] values = v.Split(delimiterChars);
                int[] negativeValues = new int[values.Length];
                
                try
                {
                    if (values.Length == 1)
                    {
                        value1 = Int32.Parse(values[0]);
                        resultado = value1;
                    }
                    else if (values.Length == 2)
                    {
                        value1 = Int32.Parse(values[0]);
                        value2 = Int32.Parse(values[1]);
                        resultado = value1 + value2;
                    }
                    else
                    {
                        resultado = 0;
                    }
                }
                catch (Exception e )
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (values[i] == "-")
                        {
                            negativeValues[i] = Int32.Parse(values[i + 1]);
                            Console.WriteLine(negativeValues[i]);
                            
                        }
                    }
                    throw e;

                }

            }
            else
            {
                resultado = 0;
            }

            return resultado;
        }
    }
}
