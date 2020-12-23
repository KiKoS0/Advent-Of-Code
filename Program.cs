using System;
using System.Linq;
using System.Collections.Generic;
using static Util.Utility;

foreach (var meth in typeof(Advent.Advent2020).GetMethods().Where(x => x.Name.Contains("Day")))
    meth.Invoke(null, null);
