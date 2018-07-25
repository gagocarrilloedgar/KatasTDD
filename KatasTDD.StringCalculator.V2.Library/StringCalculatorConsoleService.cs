using System;
using KatasTDD.StringCalculator.V2.Library.Interface;

namespace KatasTDD.StringCalculator.V2.Library
{
    public class StringCalculatorConsoleService: IStringCalculatorConsoleService
    {
        private readonly ILogger logger;
        private readonly StringCalculatorService stringCalculatorService;
        string output;

        public StringCalculatorConsoleService(ILogger logger, StringCalculatorService stringCalculatorService)
        {
            this.logger = logger;
            this.stringCalculatorService = stringCalculatorService;
        }

        public void Main(string[] args)
        {
            CalculateAndOutputSumOf(args[0]);
        }

        private void CalculateAndOutputSumOf(string input)
        {
            if (SuccessCalculatingSumof(input))
            {
                output = GetOutput(output);
                logger.Write(output);
            }
            
        }

        private bool SuccessCalculatingSumof(string input)
        {
            var good = false;

            try
            {
                output = stringCalculatorService.Add(input).ToString();
                good = true;
            }
            catch (Exception ex)
            {

                GetError("Error" + ex.Message);
            }

            return good;
        }

        private void GetError(string v)
        {
            logger.Write(v);
        }

        private static string GetOutput(string value)
        {
            return "Result is: " + value;
        }
    }
}
