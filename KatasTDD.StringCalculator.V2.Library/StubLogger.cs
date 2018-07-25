using System;
using KatasTDD.StringCalculator.V2.Library.Interface;

namespace KatasTDD.StringCalculator.V2.Library
{
    public class StubLogger : ILogger
    {
        public void Read()
        {
            throw new NullReferenceException();
        }

        public void Write(string s)
        {
            throw new NotImplementedException();
        }
    }
}
