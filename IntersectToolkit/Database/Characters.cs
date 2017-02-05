using System;

namespace IntersectToolkit.Database {
    public class Characters {
        public Int64 id { get; set; }
        public Int64 user_id { get; set; }
        public String name { get; set; }
        public Int64 map { get; set; }
        public Int64 x { get; set; }
        public Int64 y { get; set; }
        public Int64 z { get; set; }
        public Int64 dir { get; set; }
        public String sprite { get; set; }
        public String face { get; set; }
        public Int64 @class { get; set; }
        public Int64 gender { get; set; }
        public Int64 level { get; set; }
        public Int64 exp { get; set; }
        public String vitals { get; set; }
        public String maxvitals { get; set; }
        public String stats { get; set; }
        public Int64 statpoints { get; set; }
        public String equipment { get; set; }
    }
}
