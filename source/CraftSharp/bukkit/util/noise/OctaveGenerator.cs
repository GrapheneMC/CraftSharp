namespace CraftSharp.bukkit.util.noise;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OctaveGenerator
{
    public NoiseGenerator[] octaves;
    double xScale = 1;
    double yScale = 1;
    double zScale = 1;

    public OctaveGenerator(NoiseGenerator[] octaves)
    {
        this.octaves = octaves;
    }

    public void SetScale(double scale)
    {
        XScale = scale;
        YScale = scale;
        ZScale = scale;
    }

    public double XScale
    {
        get { return xScale; }
        set { xScale = value; }
    }

    public double YScale
    {
        get { return yScale; }
        set { yScale = value; }
    }

    public double ZScale
    {
        get { return zScale; }
        set { zScale = value; }
    }


    /*IDK how to clone sorry.
        public NoiseGenerator[] getOctaves() {
        return octaves.clone();
    }
    */

    public double Noise(double x, double frequency, double amplitude)
    {
        return Noise(x, 0, 0, frequency, amplitude);
    }

    public double Noise(double x, double frequency, double amplitude, bool normalized)
    {
        return Noise(x, 0, 0, frequency, amplitude, normalized);
    }

    public double Noise(double x, double y, double frequency, double amplitude)
    {
        return Noise(x, y, 0, frequency, amplitude);
    }

    public double Noise(double x, double y, double frequency, double amplitude, bool normalized)
    {
        return Noise(x, y, 0, frequency, amplitude, normalized);
    }

    public double Noise(double x, double y, double z, double frequency, double amplitude)
    {
        return Noise(x, y, z, frequency, amplitude, false);
    }

    public double Noise(double x, double y, double z, double frequency, double amplitude, bool normalized)
    {
        double result = 0;
        double amp = 1;
        double freq = 1;
        double max = 0;

        x *= xScale;
        y *= yScale;
        z *= zScale;

        foreach (NoiseGenerator octave in octaves)
        {
            result += octave.Noise(x * freq, y * freq, z * freq) * amp;
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
