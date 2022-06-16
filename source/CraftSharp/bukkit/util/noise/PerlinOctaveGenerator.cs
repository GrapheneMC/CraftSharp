using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit.util.noise;

public class PerlinOctaveGenerator : OctaveGenerator
{
    public PerlinOctaveGenerator(World world, int octaves)
        : this (new Random((int)world.Seed), octaves) { }

    public PerlinOctaveGenerator(long seed, int octaves)
        : this (new Random((int)seed), octaves) { }

    public PerlinOctaveGenerator(Random rand, int octaves) : base (createOctaves(rand, octaves)) { }

    private static NoiseGenerator[] createOctaves(Random rand, int octaves)
    {
        NoiseGenerator[] result = new NoiseGenerator[octaves];

        for (int i = 0; i < octaves; i++)
        {
            result[i] = new PerlinNoiseGenerator(rand);
        }

        return result;
    }
}
