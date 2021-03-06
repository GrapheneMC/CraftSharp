using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.Common.java.functions;

public static class DataTypes
{
    public static bool IsNumber(this object value)
    {
        return value is sbyte ||
               value is byte ||
               value is short ||
               value is ushort ||
               value is int ||
               value is uint ||
               value is long ||
               value is ulong ||
               value is float ||
               value is double ||
               value is decimal ||
               value is BigInteger;
    }
}
