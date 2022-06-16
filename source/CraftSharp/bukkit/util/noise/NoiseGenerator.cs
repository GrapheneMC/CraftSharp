namespace CraftSharp.bukkit.util.noise;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NoiseGenerator
{
	protected int[] perm = new int[512];
	protected double offsetX;
	protected double offsetY;
	protected double offsetZ;

	public static int Floor(double x)
	{
		return x >= 0 ? (int)x : (int)x - 1;
	}

	public static double Fade(double x)
	{
		return x * x * x * (x * (x * 6 - 15) + 10);
	}

	public static double Lerp(double x, double y, double z)
	{
		return y + x * (z - y);
	}

	public static double Grad(int hash, double x, double y, double z)
	{
		hash &= 15;
		double u = hash < 8 ? x : y;
		double v = hash < 4 ? y : hash == 12 || hash == 14 ? x : z;
		return ((hash & 1) == 0 ? u : -u) + ((hash & 2) == 0 ? v : -v);
	}

	public virtual double Noise(double x)
	{
		return Noise(x, 0, 0);
	}

	public virtual double Noise(double x, double y)
	{
		return Noise(x, y, 0);
	}

	public virtual double Noise(double x, double y, double z) { return 0.0d; }

	public virtual double Noise(double x, int octaves, double frequency, double amplitude)
	{
		return Noise(x, 0, 0, octaves, frequency, amplitude);
	}

	public virtual double Noise(double x, int octaves, double frequency, double amplitude, bool normalized)
	{
		return Noise(x, 0, 0, octaves, frequency, amplitude, normalized);
	}

	public virtual double Noise(double x, double y, int octaves, double frequency, double amplitude)
	{
		return Noise(x, y, 0, octaves, frequency, amplitude);
	}

	public virtual double Noise(double x, double y, int octaves, double frequency, double amplitude, bool normalized)
	{
		return Noise(x, y, 0, octaves, frequency, amplitude, normalized);
	}

	public virtual double Noise(double x, double y, double z, int octaves, double frequency, double amplitude)
	{
		return Noise(x, y, z, octaves, frequency, amplitude, false);
	}

	public virtual double Noise(double x, double y, double z, int octaves, double frequency, double amplitude, bool normalized)
	{
		double result = 0;
		double amp = 1;
		double freq = 1;
		double max = 0;

		for (int i = 0; i < octaves; i++)
		{
			result += Noise(x * freq, y * freq, z * freq) * amp;
			max += amp;
			freq *= frequency;
			amp *= amplitude;
		}

		if (normalized)
		{
			result /= max;
		}

		return result;
	}
}
