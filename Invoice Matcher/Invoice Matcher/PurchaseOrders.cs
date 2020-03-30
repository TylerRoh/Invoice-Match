using System;
using System.Collections.Generic;

namespace Invoice_Matcher
{

    public class PurchaseOrders
    {
        readonly List<int> NewPOs;
        readonly List<int> Matched;
        readonly List<int> Filed;
        public PurchaseOrders()
        {
            NewPOs = new List<int>();
            Matched = new List<int>();
            Filed = new List<int>();
        }
        public List<int> ShowNew() { return NewPOs; }
        public List<int> ShowMatched() { return Matched; }
        public List<int> ShowFiled() { return Filed; }
        public void EnterPOs()
        {
            Operations.ListFill(NewPOs);
        }


        public void MatchCheck(DbInteract dbInteract)
        {
            dbInteract.InputSorter(1, 2, NewPOs, Matched, Filed);      
        }
        public void ChangeStatus(DbInteract dbInteract)
        {
            dbInteract.ChangeValue(Matched, "po");
            dbInteract.ChangeValue(Matched, "filed");

        }
        public void AddNew(DbInteract dbInteract)
        {
            dbInteract.AddNew(NewPOs, @", 'N', 'Y', 'N'");      
        }
    }
}
