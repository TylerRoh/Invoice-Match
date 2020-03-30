using System;
using System.Linq;
using System.Collections.Generic;

namespace Invoice_Matcher
{
    public class DbInteract
    {
        MyDbConnect SqlConn;
        public DbInteract(MyDbConnect sqlConn)
        {
            SqlConn = sqlConn;
        }
        public void InputSorter(int firstCol, int secondCol, List<int> listToFilter, List<int> matchedList, List<int> filed)
        {
            foreach (var po in listToFilter.ToList())
            {
                var check = SqlConn.SearchCommand(po.ToString());
                if (check.Count > 0)
                {
                    if ((string)check[3] == "Y")
                    {
                        filed.Add(po);
                        listToFilter.Remove(po);
                        continue;
                    }
                    if ((string)check[firstCol] != "Y")
                    {
                        continue;
                    }
                    if ((string)check[secondCol] == "Y")
                    {
                        listToFilter.Remove(po);
                        continue;
                    }
                    matchedList.Add(po);
                    listToFilter.Remove(po);
                }
            }
        }
        public void ChangeValue(List<int> matched, string columnToChange)
        {
            foreach (var po in matched.ToList())
            {
                SqlConn.ChangeRow(columnToChange, po.ToString(), "Y");
                Console.WriteLine("PO {0} status changed", po.ToString());
            }
        }
        public void AddNew(List<int> newLines, string columnValues)
        {
            Console.WriteLine("Added entires to database:");
            foreach (var po in newLines.ToList())
            {
                SqlConn.AddEntries("(" + po + columnValues + ")");
                Console.WriteLine(po);
            }

        }

    }
}
