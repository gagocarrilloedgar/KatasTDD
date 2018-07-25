using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasTDD.StringCalculator.V2.Library.Interface
{
    public interface ILogger
    {
        void Write(string s);

        void Read();

    }
}
