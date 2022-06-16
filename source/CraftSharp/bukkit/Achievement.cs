using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit;

public class Achievement
{
    public static readonly Achievement OPEN_INVENTORY = new();

    public static readonly Achievement MINE_WOOD = new(OPEN_INVENTORY);

    public static readonly Achievement BUILD_WORKBENCH = new(MINE_WOOD);

    public static readonly Achievement BUILD_PICKAXE = new(BUILD_WORKBENCH);

    public static readonly Achievement BUILD_FURNACE = new(BUILD_PICKAXE);

    public static readonly Achievement ACQUIRE_IRON = new(BUILD_FURNACE);

    public static readonly Achievement BUILD_HOE = new(BUILD_WORKBENCH);

    public static readonly Achievement MAKE_BREAD = new(BUILD_HOE);

    public static readonly Achievement BAKE_CAKE = new(BUILD_HOE);

    public static readonly Achievement BUILD_BETTER_PICKAXE = new(BUILD_PICKAXE);

    public static readonly Achievement COOK_FISH = new(BUILD_FURNACE);

    public static readonly Achievement ON_A_RAIL = new(ACQUIRE_IRON);

    public static readonly Achievement BUILD_SWORD = new(BUILD_WORKBENCH);

    public static readonly Achievement KILL_ENEMY = new(BUILD_SWORD);

    public static readonly Achievement KILL_COW = new(BUILD_SWORD);

    public static readonly Achievement FLY_PIG = new(KILL_COW);

    public static readonly Achievement SNIPE_SKELETON = new(KILL_ENEMY);

    public static readonly Achievement GET_DIAMONDS = new(ACQUIRE_IRON);

    public static readonly Achievement NETHER_PORTAL = new(GET_DIAMONDS);

    public static readonly Achievement GHAST_RETURN = new(NETHER_PORTAL);

    public static readonly Achievement GET_BLAZE_ROD = new(NETHER_PORTAL);

    public static readonly Achievement BREW_POTION = new(GET_BLAZE_ROD);

    public static readonly Achievement END_PORTAL = new(GET_BLAZE_ROD);

    public static readonly Achievement THE_END = new(END_PORTAL);

    public static readonly Achievement ENCHANTMENTS = new(GET_DIAMONDS);

    public static readonly Achievement OVERKILL = new(ENCHANTMENTS);

    public static readonly Achievement BOOKCASE = new(ENCHANTMENTS);

    public static readonly Achievement EXPLORE_ALL_BIOMES = new(END_PORTAL);

    public static readonly Achievement SPAWN_WITHER = new(THE_END);

    public static readonly Achievement KILL_WITHER = new(SPAWN_WITHER);

    public static readonly Achievement FULL_BEACON = new(KILL_WITHER);

    public static readonly Achievement BREED_COW = new(KILL_COW);

    public static readonly Achievement DIAMONDS_TO_YOU = new(GET_DIAMONDS);

    private Achievement? parent;

    private Achievement()
    {
        parent = null;
    }

    private Achievement(Achievement parent)
    {
        this.parent = parent;
    }

    /// <summary>
    /// Returns whether or not this achievement has a parent achievement.
    /// </summary>
    /// <returns>whether the achievement has a parent achievement</returns>
    public bool HasParent() => parent != null;

    /// <summary>
    /// Returns the parent achievement of this achievement, or null if none.
    /// </summary>
    /// <returns>the parent achievement or null</returns>
    public Achievement GetParent() => parent!;
}
