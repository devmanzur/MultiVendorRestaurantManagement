using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Utils
{
    public static class ValidationHelper
    {
        public static Func<IReadOnlyList<long>, bool> ContainValidItem()
        {
            return collection => collection == null || collection.Any(
                item => item != 0);
        }
    }
}