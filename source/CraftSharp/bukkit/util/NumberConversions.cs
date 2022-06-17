using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftSharp.Common.java.exceptions;
using CraftSharp.Common.java.functions;
namespace CraftSharp.bukkit.util;

public class NumberConversions
{
    private NumberConversions() { }

    public static int Floor(double num)
    {
        int floor = (int)num;

        return floor == num ? floor : floor - (int)(BitConverter.DoubleToInt64Bits(num).UnsignedRightShift(63));
    }

    public static int Ceil(double num)
    {
        int floor = (int)num;

        return floor == num ? floor : floor + (int)(~BitConverter.DoubleToInt64Bits(num).UnsignedRightShift(63));
    }

    public static int Round(double num)
    {
        return Floor(num + 0.5d);
    }

    public static double Square(double num)
    {
        return num * num;
    }

    /* ???
    public static int ToInt(object obj)
    {
        if (Int32.TryParse(obj, out int number))
            return number;


    }*/



}
