using System;

namespace IntersectToolkit {
    public static class Extensions {
        public static Int32 ToInt32(this String input) {
            var output = default(Int32);
            Int32.TryParse(input, out output);
            return output;
        }
    }
}
