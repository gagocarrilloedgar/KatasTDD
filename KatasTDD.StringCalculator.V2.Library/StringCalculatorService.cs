using KatasTDD.StringCalculator.V2.Library.Interface;
using System;

namespace KatasTDD.StringCalculator.V2.Library
{

    public class StringCalculatorService : IStringCalculatorService, IFilterString
    {
        #region Properties
        public ILogger Logger { get; set; }
        public IWebService WebService { get; set; }

        StubLogger stubLogger = new StubLogger();
        #endregion


        public int Add(string numbers)
        {
            int resultado = 0;
            resultado = GettingNumbersByConditions(numbers, resultado);
            OutputLine(resultado.ToString());
            TryWebServiLogger();
            return resultado;
        }

        private void TryWebServiLogger()
        {
            try
            {
                stubLogger.Read();
                  
            }
            catch (NullReferenceException ex )
            {
                WebService.RegisterExecption(ex.Message);
            }
        }

        private bool HandleEmptyNumbers(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            { 

                return true;
            }

            return false;
            
        }

        private int GettingNumbersByConditions(string numbers, int resultado)
        {
            string filteredString = GetFilteredNumbers(numbers);
            char[] delimeters = { ',', ';', '\n', ' ', '*' };
            string[] values = filteredString.Split(delimeters);

            if (HandleEmptyNumbers(numbers) == true)
            {
                resultado = 0;
            }
            else
            {
                foreach (var v in values)
                {
                    var number = Int32.Parse(v);
                    HandleNegativeNumbers(number);
                    resultado = HandleHighNumber(resultado, v, number);
                }
            }

            return resultado;
        }

        private static int HandleHighNumber(int resultado, string v, int number)
        {
            if (number > 1000)
            {
                resultado += 0;
            }
            else
            {
                resultado += Int32.Parse(v);
            }

            return resultado;
        }

        private void HandleNegativeNumbers(int number)
        {
            if (number < 0)
            {
                OutputLine("Error NegativesAreNotAllow");
                throw new ArgumentException();
            }
        }

        private void OutputLine(string resultado)
        {
            if (Logger != null)
            {
                Logger.Write(resultado.ToString());
            }
        }

        public string GetFilteredNumbers(string Numbers)
        {
            string filteredNumbers = "";

            if (Numbers.StartsWith("//"))
            {
                filteredNumbers = TrimTheBeginOfString(ref filteredNumbers, Numbers);
                filteredNumbers = TrimLongDelimeters(ref filteredNumbers);
            }
            else
            {
                filteredNumbers = Numbers;
                filteredNumbers = TrimLongDelimeters(ref filteredNumbers);
            }

            return filteredNumbers;
        }

        private string TrimLongDelimeters(ref string filteredNumbers)
        {
            char[] delimeters = { ',', ';', '\n', ' ', '*' };
            var filteredChars = filteredNumbers.ToCharArray();

            for (int i = 1; i < filteredChars.Length - 1; i++)
            {
                foreach (var item in delimeters)
                {
                    if (item == filteredChars[i])
                    {
                        var j = i;
                        var count = 0;

                        for (int k = i; k < filteredChars.Length - 1; k++)
                        {
                            if (filteredChars[i] == filteredChars[k + 1])
                            {
                                count += 1;
                            }
                        }

                        filteredNumbers.Remove(i, count);
                    }
                }
            }

            return filteredNumbers;
        }

        private string TrimTheBeginOfString(ref string filteredNumbers, string Numbers)
        {
            filteredNumbers = Numbers.Trim(new Char[] { '/' });
            filteredNumbers = filteredNumbers.Remove(0, 1);

            return filteredNumbers;
        }

    }
}
