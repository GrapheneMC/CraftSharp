using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit.util.noise;

public class PerlinNoiseGenerator : NoiseGenerator
{
  //  public static int[][] grad3 = {{1, 1, 0}, {-1, 1, 0}, {1, -1, 0}, {-1, -1, 0},
    //    {1, 0, 1}, {-1, 0, 1}, {1, 0, -1}, {-1, 0, -1},
      //  {0, 1, 1}, {0, -1, 1}, {0, 1, -1}, {0, -1, -1}};

    private static PerlinNoiseGenerator instance = new PerlinNoiseGenerator();

    public PerlinNoiseGenerator()
    {
        int[] p = {151, 160, 137, 91, 90, 15, 131, 13, 201,
            95, 96, 53, 194, 233, 7, 225, 140, 36, 103, 30, 69, 142, 8, 99, 37,
            240, 21, 10, 23, 190, 6, 148, 247, 120, 234, 75, 0, 26, 197, 62,
            94, 252, 219, 203, 117, 35, 11, 32, 57, 177, 33, 88, 237, 149, 56,
            87, 174, 20, 125, 136, 171, 168, 68, 175, 74, 165, 71, 134, 139,
            48, 27, 166, 77, 146, 158, 231, 83, 111, 229, 122, 60, 211, 133,
            230, 220, 105, 92, 41, 55, 46, 245, 40, 244, 102, 143, 54, 65, 25,
            63, 161, 1, 216, 80, 73, 209, 76, 132, 187, 208, 89, 18, 169, 200,
            196, 135, 130, 116, 188, 159, 86, 164, 100, 109, 198, 173, 186, 3,
            64, 52, 217, 226, 250, 124, 123, 5, 202, 38, 147, 118, 126, 255,
            82, 85, 212, 207, 206, 59, 227, 47, 16, 58, 17, 182, 189, 28, 42,
            223, 183, 170, 213, 119, 248, 152, 2, 44, 154, 163, 70, 221, 153,
            101, 155, 167, 43, 172, 9, 129, 22, 39, 253, 19, 98, 108, 110, 79,
            113, 224, 232, 178, 185, 112, 104, 218, 246, 97, 228, 251, 34, 242,
            193, 238, 210, 144, 12, 191, 179, 162, 241, 81, 51, 145, 235, 249,
            14, 239, 107, 49, 192, 214, 31, 181, 199, 106, 157, 184, 84, 204,
            176, 115, 121, 50, 45, 127, 4, 150, 254, 138, 236, 205, 93, 222,
            114, 67, 29, 24, 72, 243, 141, 128, 195, 78, 66, 215, 61, 156, 180};

        for (int i = 0; i < 512; i++)
            perm[i] = p[i & 255];
    }

    public PerlinNoiseGenerator(World world)
        : this(new Random((int)world.Seed)) { }
    
    //TODO: change random to (long)
    public PerlinNoiseGenerator(long seed)
        : this(new Random((int)seed)) { }

    public PerlinNoiseGenerator(Random rand)
    {
        offsetX = rand.NextDouble() * 256;
        offsetY = rand.NextDouble() * 256;
        offsetZ = rand.NextDouble() * 256;

        for (int i = 0; i < 256; i++)
            perm[i] = rand.Next(256);

        for (int i = 0; i < 256; i++)
        {
            int pos = rand.Next(256 - i) + i;
            int old = perm[i];

            perm[i] = perm[pos];
            perm[pos] = old;
            perm[i + 256] = perm[i];
        }
    }

    public static double GetNoise(double x) => instance.Noise(x);

    public static double GetNoise(double x, double y) => instance.Noise(x, y);

    public static double GetNoise(double x, double y, double z) => instance.Noise(x, y, z);

    public static PerlinNoiseGenerator GetInstance() => instance;

    public override double Noise(double x, double y, double z)
    {
        x += offsetX;
        y += offsetY;
        z += offsetZ;

        int floorX = Floor(x);
        int floorY = Floor(y);
        int floorZ = Floor(z);

        // Find unit cube containing the point
        int X = floorX & 255;
        int Y = floorY & 255;
        int Z = floorZ & 255;

        // Get relavtive xyz coordinates of the point within the cube
        x -= floorX;
        y -= floorY;
        z -= floorZ;

        // Compute fade curves for xyz
        double fX = Fade(x);
        double fY = Fade(y);
        double fZ = Fade(z);

        // Hash coordinates of the cube corners
        int A = perm[X] + Y;
        int AA = perm[A] + Z;
        int AB = perm[A + 1] + Z;
        int B = perm[X + 1] + Y;
        int BA = perm[B] + Z;
        int BB = perm[B + 1] + Z;

        return Lerp(fZ, Lerp(fY, Lerp(fX, Grad(perm[AA], x, y, z),
               Grad(perm[BA], x - 1, y, z)),
               Lerp(fX, Grad(perm[AB], x, y - 1, z),
               Grad(perm[BB], x - 1, y - 1, z))),
               Lerp(fY, Lerp(fX, Grad(perm[AA + 1], x, y, z - 1),
               Grad(perm[BA + 1], x - 1, y, z - 1)),
               Lerp(fX, Grad(perm[AB + 1], x, y - 1, z - 1),
               Grad(perm[BB + 1], x - 1, y - 1, z - 1))));
    }

    public static double GetNoise(double x, int octaves, double frequency, double amplitude)
        => instance.Noise(x, octaves, frequency, amplitude);

    public static double GetNoise(double x, double y, int octaves, double frequency, double amplitude)
        => instance.Noise(x, y, octaves, frequency, amplitude);

    public static double GetNoise(double x, double y, double z, int octaves, double frequency, double amplitude)
        => instance.Noise(x, y, z, octaves, frequency, amplitude);

}
