using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class Regular : Renter
    {
        public Regular() { }

        public Regular(string n, string cn, int i, string e, string pass, DateTime dob, string dln, DateTime dlexp, string ic, string addr, bool valid, DateTime validDate, int id, List<Booking> b) : base(n, cn, i, e, pass, dob, dln, dlexp, ic, addr, valid, validDate, id, b) { }
    }
}
