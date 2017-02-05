using System;

namespace IntersectToolkit.Database {
    public class Bans {
        public Int64 id { get; set; }
        public DateTime time { get; set; }
        public String user { get; set; }
        public String ip { get; set; }
        public DateTime duration { get; set; }
        public String reason { get; set; }
        public String banner { get; set; }
    }
}
