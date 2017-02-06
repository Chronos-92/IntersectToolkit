using System;

namespace IntersectToolkit.Database {
    public class BlobObject {
        public Int64 id { get; set; }
        public Int64 deleted { get; set; }
        public Byte[] data { get; set; }
    }
}
