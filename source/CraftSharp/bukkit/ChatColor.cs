using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit;

public class ChatColor
{
    public static readonly ChatColor BLACK = new('0', 0x00);

    public static readonly ChatColor DARK_BLUE = new('1', 0x1);

    public static readonly ChatColor DARK_GREEN = new('2', 0x2);

    public static readonly ChatColor DARK_AQUA = new('3', 0x3);

    public static readonly ChatColor DARK_RED = new('4', 0x4);

    public static readonly ChatColor DARK_PURPLE = new('5', 0x5);

    public static readonly ChatColor GOLD = new('6', 0x6);

    public static readonly ChatColor GRAY = new('7', 0x7);

    public static readonly ChatColor DARK_GRAY = new('8', 0x8);

    public static readonly ChatColor BLUE = new('9', 0x9);

    public static readonly ChatColor GREEN = new('a', 0xA);

    public static readonly ChatColor AQUA = new('b', 0xB);

    public static readonly ChatColor RED = new('c', 0xC);

    public static readonly ChatColor LIGHT_PURPLE = new('d', 0xD);

    public static readonly ChatColor YELLOW = new('e', 0xE);

    public static readonly ChatColor WHITE = new('f', 0xF);

    public static readonly ChatColor MAGIC = new('k', 0x10, true);

    public static readonly ChatColor BOLD = new('l', 0x11, true);

    public static readonly ChatColor STRIKETHROUGH = new('m', 0x12, true);

    public static readonly ChatColor UNDERLINE = new('n', 0x13, true);

    public static readonly ChatColor ITALIC = new('o', 0x14, true);

    public static readonly ChatColor RESET = new('r', 0x15);

    public const char COLOR_CHAR = '\u00A7';
    private int intCode;
    private char code;
    private bool isFormat;
    private string toString;
    private static Dictionary<int, ChatColor> BY_ID = new Dictionary<int, ChatColor>();
    private static Dictionary<char, ChatColor> BY_CHAR = new Dictionary<char, ChatColor>();

    internal ChatColor(char code, int intCode)
        : this (code, intCode, false) { }

    internal ChatColor(char code, int intCode, bool isFormat)
    {
        this.code = code;
        this.intCode = intCode;
        this.isFormat = isFormat;
        this.toString = new string(new char[] { COLOR_CHAR, code });
    }

    public char Char => code;

    public override string ToString()
    {
        return toString;
    }

    public bool IsFormat => IsFormat;

    public bool IsColor() => false; //TODO: fix

    public static ChatColor GetByChar(char code) => BY_CHAR[code];

    public static ChatColor GetByChar(string code)
    {
        /*   return BY_CHAR.get(code.charAt(0)); */
        return BY_CHAR[code[0]];
    }
}
