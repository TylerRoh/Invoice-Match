using System;
using System.Collections.Generic;
namespace Invoice_Matcher
{
    public class Operations
    {
        public static void DisplayEffected(List<int> effected)
        {
            foreach (var i in effected)
                Console.WriteLine(i);
        }
        public static void ListFill(List<int> listToBeFilled)
        {
            while (true)
            {
                string answer = Console.ReadLine().Trim();
                if (String.IsNullOrWhiteSpace(answer))
                {
                    break;
                }
                if (Int32.TryParse(answer, out int result))
                    listToBeFilled.Add(Int32.Parse(answer));
            }
        }
    }
}
