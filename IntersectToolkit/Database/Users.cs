using System;

namespace IntersectToolkit.Database {
    public class Users {
        public Int64 id { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        public String salt { get; set; }
        public String email { get; set; }
        public Int64 power { get; set; }
    }
}
