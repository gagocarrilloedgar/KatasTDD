using System;
using KatasTDD.PasswordVerifier.Library.Interface;

namespace KatasTDD.PasswordVerifier.Library.Services
{
   
    public class PasswordVerifierServices : IPasswordVerfierServices
    {
        #region Properties & Variables
        int passwordminlength = 8;
        bool passwordOk;
        #endregion

        #region Exception Messages
        string NullPassWordMessage = "Password can not be null";
        string PassWordLength = "Password shoul be at least 8 characters long";
        string CapitalLetter = "Password should have at least one Uppercase letter";
        string ContainsNumber = "Password should have at least one Number letter";
        #endregion

        public bool Verify(string psswd)
        {
            return ThreeConditoinAreGood(psswd);
        }
        private bool ThreeConditoinAreGood(string psswd)
        {
            bool conditions = ( (PasswordLength(psswd) && NullPassword(psswd) && CapitalLetterControl(psswd)) || (PasswordLength(psswd) && NullPassword(psswd) &&  CotainsNumbers(psswd)) ||
             (PasswordLength(psswd) &&  CapitalLetterControl(psswd) && CotainsNumbers(psswd))  || (NullPassword(psswd) && CapitalLetterControl(psswd) && CotainsNumbers(psswd)) 
             || (PasswordLength(psswd) && NullPassword(psswd) && CapitalLetterControl(psswd) && CotainsNumbers(psswd) ) );
            
           if( conditions == true)
            {
                 return true;
            
            }
            else
            {
                return false;
            }

        }
        private bool NullPassword(string psswd)
        {
            var condition = string.IsNullOrEmpty(psswd);
            var result = ApprovalMehod(condition, NullPassWordMessage);
            return result;
        }

        private bool PasswordLength(string psswd)
        {
            var condition = psswd.Length < passwordminlength;
            var result = ApprovalMehod(condition, PassWordLength);
            return result;
        }

        private bool CapitalLetterControl(string psswd)
        {
            var count = CapitalLettercount(psswd);
            var condition = count < 1;
            var result = ApprovalMehod(condition, CapitalLetter);

            return result;
        }

        private bool CotainsNumbers(string psswd)
        {
            var count = NumbersCount(psswd);
            var condition = count < 1;
            var result = ApprovalMehod(condition,ContainsNumber);

            return result;

        }

        private bool ApprovalMehod(bool condition, string Message)
        {
            if (condition)
            {
                passwordOk = false;
                throw new Exception(Message);

            }
            else
            {
                passwordOk = true;
            }

            return passwordOk;
        }

        private static int NumbersCount(string psswd)
        {
            var count = 0;

            foreach (var letter in psswd)
            {
                if (char.IsDigit(letter))
                {
                    count += 1;
                }
            }

            return count;
        }

        private static int CapitalLettercount(string psswd)
        {
            var count = 0;
            foreach (var letter in psswd)
            {
                if (char.IsUpper(letter))
                {
                    count += 1;
                }
               
            }

            return count;
        }
    }
}
