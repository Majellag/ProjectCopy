using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalClearUniversal
{
    class Tip
    {
        public string FamilyName { get; set; }
        public string ResidentNo { get; set; }
        public string EmailAdd { get; set; }
        public string DayNo { get; set; }
        public string Amount { get; set; }

        public string BillAmount { get; set; }
        public string TipAmount { get; set; }
        public string TotalAmount { get; set; }
   


        public Tip()
        {
            this.FamilyName = String.Empty;
            this.ResidentNo = String.Empty;
            this.EmailAdd = String.Empty;

            this.TipAmount = String.Empty;
            this.TotalAmount = String.Empty;
        }

        public void CalculateTip(string originalAmount, double tipPercentage)
        {
            double billAmount = 0.0;
            double tipAmount = 0.0;
            double totalAmount = 0.0;

            if (double.TryParse(originalAmount.Replace('€', ' '), out billAmount))
            {

                totalAmount = (billAmount / 100) * (tipPercentage) * 3.00;

            }

            this.BillAmount = String.Format("{0}", billAmount);
            this.TipAmount = String.Format("{0:C}", tipAmount);
            this.TotalAmount = String.Format("{0:C}", totalAmount);
        }

    }
}
