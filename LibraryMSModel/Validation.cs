using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public class Validation
    {
        /// <summary>
        /// account name: chararater or number, length more than 5
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public static bool accountNameValidation(String accountName)
        {
            string pattern = @"^[a-zA-Z0-9]{4,}$";
            return Regex.IsMatch(accountName, pattern);
        }


        public static bool passwordValidation(String password)
        {
            string pattern = @"^[a-zA-Z0-9]{4,}$";
            return Regex.IsMatch(password, pattern);
        }


        public static bool ISBNValidation(String ISBN) 
        {
            string pattern = @"^\d{13}$";
            return Regex.IsMatch(ISBN, pattern);
        }

        public static bool nameValidation(String name)
        {
            string pattern = @"^[A-Za-z]+(?:\s[A-Za-z]+)*$";
            return Regex.IsMatch(name, pattern);
        }

        public static bool telephoneValidation(String telephone)
        {
            string pattern = @"^(?:(?!0|1)(?:[2-9]\d{2})-)(?:(?!0|1)\d{3}-\d{4})$";
            return Regex.IsMatch(telephone, pattern);
        }

        public static bool bookNameValidation(String bookName)
        {
            string pattern = @"^(?!\s)[\w\s'.,?!-]{1,200}(?<!\s)$";
            return Regex.IsMatch(bookName, pattern);
        }

        public static bool priceValidation(String price)
        {
            string pattern = @"^\d+(\.\d{1,2})?$";
            return Regex.IsMatch(price, pattern);
        }

        public static bool QuantityValidation(String quantity)
        {
            string pattern = @"^[1-9]\d*$";
            return Regex.IsMatch(quantity, pattern);
        }

        public static bool publisherValidation(String publisher)
        {
            string pattern = @"^[A-Za-z0-9\s.&',-]+$"; ;
            return Regex.IsMatch(publisher, pattern);
        }



    }
}
