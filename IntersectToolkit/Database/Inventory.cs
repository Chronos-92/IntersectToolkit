using System;

namespace IntersectToolkit.Database {
    public class Inventory {
        public Int64 char_id { get; set; }
        public Int64 slot { get; set; }
        public Int64 itemnum { get; set; }
        public Int64 itemval { get; set; }
        public String itemstats { get; set; }
    }
}
