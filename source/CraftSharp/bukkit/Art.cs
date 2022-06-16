using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit;

public class Art
{
    public static readonly Art KEBAB = new(0, 1, 1);

    public static readonly Art AZTEC = new(1, 1, 1);

    public static readonly Art ALBAN = new(2, 1, 1);

    public static readonly Art AZTEC2 = new(3, 1, 1);

    public static readonly Art BOMB = new(4, 1, 1);

    public static readonly Art PLANT = new(5, 1, 1);

    public static readonly Art WASTELAND = new(6, 1, 1);

    public static readonly Art POOL = new(7, 2, 1);

    public static readonly Art COURBET = new(8, 2, 1);

    public static readonly Art SEA = new(9, 2, 1);

    public static readonly Art SUNSET = new(10, 2, 1);

    public static readonly Art CREEBET = new(11, 2, 1);

    public static readonly Art WANDERER = new(12, 1, 2);

    public static readonly Art GRAHAM = new(13, 1, 2);

    public static readonly Art MATCH = new(14, 2, 2);

    public static readonly Art BUST = new(15, 2, 2);

    public static readonly Art STAGE = new(16, 2, 2);

    public static readonly Art VOID = new(17, 2, 2);

    public static readonly Art SKULL_AND_ROSES = new(18, 2, 2);

    public static readonly Art WITHER = new(19, 2, 2);

    public static readonly Art FIGHTERS = new(20, 4, 2);

    public static readonly Art POINTER = new(21, 4, 4);

    public static readonly Art PIGSCENE = new(22, 4, 4);

    public static readonly Art BURNINGSKULL = new(23, 4, 4);

    public static readonly Art SKELETON = new(24, 4, 3);

    public static readonly Art DONKEYKONG = new(25, 4, 3);

    private int id, width, height;

    private static Dictionary<string, Art> BY_NAME = new Dictionary<string, Art>();
    private static Dictionary<int, Art> BY_ID = new Dictionary<int, Art>();

    static Art()
    {
        foreach (Art art in Values)
        {
            BY_ID.Add(art.id, art);
            BY_NAME.Add(art.ToString()!.ToLower().Replace("_", ""), art);
        }
    }

    private Art(int id, int width, int height)
    {
        this.id = id;
        this.width = width;
        this.height = height;
    }

    public int GetBlockWidth() => width;

    public int GetBlockHeight() => height;

    public int GetId() => id;

    [Obsolete]
    public static Art GetById(int id) => BY_ID[id];

    public static Art GetByName(string name)
    {
        return BY_NAME[name.ToLower().Replace("_", "")];
    }

    public static IEnumerable<Art> Values
    {
        get
        {
            yield return KEBAB;
            yield return AZTEC;
            yield return ALBAN;
            yield return AZTEC2;
            yield return BOMB;
            yield return PLANT;
            yield return WASTELAND;
            yield return POOL;
            yield return COURBET;
            yield return SEA;
            yield return SUNSET;
            yield return CREEBET;
            yield return WANDERER;
            yield return GRAHAM;
            yield return MATCH;
            yield return BUST;
            yield return STAGE;
            yield return VOID;
            yield return SKULL_AND_ROSES;
            yield return WITHER;
            yield return FIGHTERS;
            yield return POINTER;
            yield return PIGSCENE;
            yield return BURNINGSKULL;
            yield return SKELETON;
            yield return DONKEYKONG;
        }
    }
}
