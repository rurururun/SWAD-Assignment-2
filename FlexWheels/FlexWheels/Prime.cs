using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class Prime:Renter
    {
        private string membershipId;
        private DateTime membershipStartDate;
        private DateTime membershipEndDate;
        private double monthlyRentalAmount;
        private double discountRate;
        private List<string> exclusiveOffers;

        public string MembershipId
        {
            get { return membershipId; }
            set { membershipId = value; }
        }

        public DateTime MembershipStartDate
        {
            get { return membershipStartDate; }
            set { membershipStartDate = value; }
        }

        public DateTime MembershipEndDate
        {
            get { return membershipEndDate; }
            set { membershipEndDate = value; }
        }

        public double MonthlyRentalAmount
        {
            get { return monthlyRentalAmount; }
            set { monthlyRentalAmount = value; }
        }

        public double DiscountRate
        {
            get { return discountRate; }
            set { discountRate = value; }
        }

        public List<string> ExclusiveOffers
        {
            get { return exclusiveOffers; }
            set { exclusiveOffers = value; }
        }

        public Prime(DateTime dob, string dln, DateTime dlexp, string ic, string addr, bool valid, DateTime validDate, string mid, DateTime msd, DateTime med, double mra, double dr, List<string> eo): base(dob, dln, dlexp, ic, addr, valid, validDate)
        {
            membershipId = mid;
            membershipStartDate = msd;
            membershipEndDate = med;
            monthlyRentalAmount = mra;
            discountRate = dr;
            exclusiveOffers = eo;
        }

        public string printExclusiveOffers(List<string> eo)
        {
            string exclusiveOffersToBePrinted = "";

            for (int i = 0; i < eo.Count; i++)
            {
                exclusiveOffersToBePrinted += eo[i] + "\n";
            }

            return exclusiveOffersToBePrinted;
        }

        public override string ToString()
        {
            return base.ToString() + "\nMembership ID: " + MembershipId + "\nMembership Start Date: " + MembershipStartDate.Day + "/" + MembershipStartDate.Month + "/" + MembershipStartDate.Year + "\nMembership End Date: " + MembershipEndDate.Day + "/" + MembershipEndDate.Month + "/" + MembershipEndDate.Year + "\nMonthly Rental Amount: $" + MonthlyRentalAmount + "\nDiscount Rate: " + DiscountRate + "%\nExclusive Offers:\n" + printExclusiveOffers(ExclusiveOffers);
        }
    }
}
