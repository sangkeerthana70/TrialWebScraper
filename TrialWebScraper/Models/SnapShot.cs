using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrialWebScraper.Models
{
    public class SnapShot
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public DateTime SnapShotTime { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
