using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourInfo.Domain.DomainModel
{
    public class VisitLog:Base.GuidEntity
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int PV { get; set; }
        public int UV { get; set; }
        public int NewUsersAmount { get; set; }
    }
}
