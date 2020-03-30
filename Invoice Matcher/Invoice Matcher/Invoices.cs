using System.Collections.Generic;

namespace Invoice_Matcher
{
    public class Invoices
    {
        readonly List<int> NewInvoices;
        readonly List<int> Matched;
        readonly List<int> Filed;

        public Invoices()
        {
            NewInvoices = new List<int>();
            Matched = new List<int>();
            Filed = new List<int>();

        }
        public List<int> ShowNew() { return NewInvoices; }
        public List<int> ShowMatched() { return Matched; }
        public List<int> ShowFiled() { return Filed; }
        public void EnterPOs()
        {
            Operations.ListFill(NewInvoices);
        }
        public void InvoicesPOs()
        {
            Operations.ListFill(NewInvoices);
        }

        public void MatchCheck(DbInteract dbInteract)
        {
            dbInteract.InputSorter(2, 1, NewInvoices, Matched, Filed);
        }
        public void ChangeStatus(DbInteract dbInteract)
        {
            dbInteract.ChangeValue(Matched, "invoice");
            dbInteract.ChangeValue(Matched, "filed");

        }
        public void AddNew(DbInteract dbInteract)
        {
            dbInteract.AddNew(NewInvoices, @", 'Y', 'N', 'N'");
        }
    }
}
