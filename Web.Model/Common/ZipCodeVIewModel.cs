using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model.Common
{
    public class ZipCodeVIewModel
    {

        public long ZipCode { get; set; }
        public string ZipCodeWithZero { get { return ZipCode.ToString().PadLeft(5, '0'); } }

        public double lat { get; set; }

        public double log { get; set; }

    }
}
