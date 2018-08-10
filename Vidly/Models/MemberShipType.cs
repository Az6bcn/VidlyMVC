using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public int Id { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
        public string Name { get; set; }


        public static readonly byte Unkown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}