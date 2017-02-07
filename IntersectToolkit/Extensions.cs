using System;

namespace IntersectToolkit {
    public static class Extensions {
        public static Int32 ToInt32(this String input) {
            var output = default(Int32);
            Int32.TryParse(input, out output);
            return output;
        }
        public static Int64 ToInt64(this String input) {
            var output = default(Int64);
            Int64.TryParse(input, out output);
            return output;
        }
    }
}
