using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GarantiPrisAttributes
    {
        public string Garantivognsnummer { get; set; }
        public string GarantiPeriodeHverdag { get; set; }
        public string GarantiPeriodeWeekend { get; set; }
        public string GarantiPeriodeHellidage { get; set; }
        public string TvungenFerieUgeNr { get; set; }
        public string TvungneLukkedage { get; set; }
        public string Timepris { get; set; }
    }
}
