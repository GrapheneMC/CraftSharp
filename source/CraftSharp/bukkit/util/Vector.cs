using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CraftSharp.Common.java.functions;

namespace CraftSharp.bukkit.util;

/*SerializableAs*/
public class Vector : ICloneable, IFormattable /*: Cloneable?, ConfigurationSerializable */
{ 

    private static long serialVersionUID = -2657651106777219169L;

    private static Random random = new Random();

    /// <summary>
    /// Threshold for fuzzy equals().
    /// </summary>
    private static double epsilon = 0.000001;

    protected double x;
    protected double y;
    protected double z;

    /// <summary>
    /// Construct the vector with all components as 0.
    /// </summary>
    public Vector()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }

    /// <summary>
    /// Construct the vector with provided integer components.
    /// </summary>
    /// <param name="x">X component</param>
    /// <param name="y">Y component</param>
    /// <param name="z">Z component</param>
    public Vector(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /// <summary>
    /// Construct the vector with provided double components.
    /// </summary>
    /// <param name="x">X component</param>
    /// <param name="y">Y component</param>
    /// <param name="z">Z component</param>
    public Vector(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /// <summary>
    /// Construct the vector with provided float components.
    /// </summary>
    /// <param name="x">X component</param>
    /// <param name="y">Y component</param>
    /// <param name="z">Z component</param>
    public Vector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /// <summary>
    /// dds a vector to this one
    /// </summary>
    /// <param name="vector">The other vector</param>
    /// <returns>the same vector</returns>
    public Vector Add(Vector vector)
    {
        x += vector.x;
        y += vector.y;
        z += vector.z;

        return this;
    }

    /// <summary>
    /// Subtracts a vector from this one.
    /// </summary>
    /// <param name="vector">The other vector</param>
    /// <returns>the same vector</returns>
    public Vector Subtract(Vector vector)
    {
        x -= vector.x;
        y -= vector.y;
        z -= vector.z;

        return this;
    }

    /// <summary>
    /// Multiplies the vector by another.
    /// </summary>
    /// <param name="vector">The other vector</param>
    /// <returns>the same vector</returns>
    public Vector Multiply(Vector vector)
    {
        x *= vector.x;
        y *= vector.y;
        z *= vector.z;

        return this;
    }

    /// <summary>
    /// Divides the vector by another.
    /// </summary>
    /// <param name="vector">The other vector</param>
    /// <returns>the same vector</returns>
    public Vector Divide(Vector vector)
    {
        x /= vector.x;
        y /= vector.y;
        z /= vector.z;

        return this;
    }

    /// <summary>
    /// Copies another vector
    /// </summary>
    /// <param name="vector">The other vector</param>
    /// <returns>the same vector</returns>
    public Vector Copy(Vector vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;

        return this;
    }

    public double Length() => Math.Sqrt(NumberConversions.Square(x) + NumberConversions.Square(y) + NumberConversions.Square(z));

    public double LengthSquared() => NumberConversions.Square(x) + NumberConversions.Square(y) + NumberConversions.Square(z);

    public double Distance(Vector o) => Math.Sqrt(NumberConversions.Square(x - o.x) + NumberConversions.Square(y - o.y) + NumberConversions.Square(z - o.z));

    public double DistanceSquared(Vector o) => NumberConversions.Square(x - o.x) + NumberConversions.Square(y - o.y) + NumberConversions.Square(z - o.z);

    public float Angle(Vector other)
    {
        double dot = Dot(other) / (Length() * other.Length());

        return (float)Math.Acos(dot);
    }

    public Vector Midpoint(Vector other)
    {
        x = (x + other.x) / 2;
        y = (y + other.y) / 2;
        z = (z + other.z) / 2;

        return this;
    }

    public Vector GetMidpoint(Vector other)
    {
        double x = (this.x + other.x) / 2;
        double y = (this.y + other.y) / 2;
        double z = (this.z + other.z) / 2;

        return new Vector(x, y, z);
    }

    public Vector Multiply(int m)
    {
        x *= m;
        y *= m;
        z *= m;

        return this;
    }

    public Vector Multiply(double m)
    {
        x *= m;
        y *= m;
        z *= m;

        return this;
    }

    public Vector Multiply(float m)
    {
        x *= m;
        y *= m;
        z *= m;

        return this;
    }

    public double Dot(Vector other)
    {
        return x * other.x + y * other.y + z * other.z;
    }

    public Vector CrossProduct(Vector other)
    {
        double newX = y * other.z - other.y * z;
        double newY = z * other.x - other.z * x;
        double newZ = x * other.y - other.x * y;

        x = newX;
        y = newY;
        z = newZ;

        return this;
    }

    public Vector Normalize()
    {
        double length = Length();

        x /= length;
        y /= length;
        z /= length;

        return this;
    }

    public Vector Zero()
    {
        x = 0;
        y = 0;
        z = 0;

        return this;
    }

    public bool IsInAABB(Vector min, Vector max)
    {
        return x >= min.x && x <= max.x && y >= min.y && y <= max.y && z >= min.z && z <= max.z;
    }

    public bool IsInSphere(Vector origin, double radius)
    {
        return (NumberConversions.Square(origin.x - x) + NumberConversions.Square(origin.y - y) + NumberConversions.Square(origin.z - z)) <= NumberConversions.Square(radius);
    }

    public double GetX() => x;

    public int GetBlockX() => NumberConversions.Floor(x);

    public double GetY() => y;

    public int GetBlockY() => NumberConversions.Floor(y);

    public double GetZ() => z;

    public int GetBlockZ() => NumberConversions.Floor(z);

    public Vector SetX(int x)
    {
        this.x = x;

        return this;
    }

    public Vector SetX(double x)
    {
        this.x = x;

        return this;
    }

    public Vector SetX(float x)
    {
        this.x = x;

        return this;
    }
    
    public Vector SetY(int y)
    {
        this.y = y;

        return this;
    }

    public Vector SetY(double y)
    {
        this.y = y;

        return this;
    }

    public Vector SetY(float y)
    {
        this.y = y;

        return this;
    }

    public Vector SetZ(int z)
    {
        this.z = z;

        return this;
    }

    public Vector SetZ(double z)
    {
        this.z = z;

        return this;
    }

    public Vector SetZ(float z)
    {
        this.z = z;

        return this;
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Vector)) return false;

        Vector other = (Vector)obj;

        Type refClass = this.GetType();
        Type targetClass = obj.GetType();

        return Math.Abs(x - other.x) < epsilon && Math.Abs(y - other.y) < epsilon && Math.Abs(z - other.z) < epsilon && (refClass.Equals(targetClass));
    }

    public override int GetHashCode()
    {
        int hash = 7;

        hash = 79 * hash + (int)(BitConverter.DoubleToInt64Bits(this.x) ^ (BitConverter.DoubleToInt64Bits(this.x).UnsignedRightShift(32)));
        hash = 79 * hash + (int)(BitConverter.DoubleToInt64Bits(this.y) ^ (BitConverter.DoubleToInt64Bits(this.y).UnsignedRightShift(32)));
        hash = 79 * hash + (int)(BitConverter.DoubleToInt64Bits(this.z) ^ (BitConverter.DoubleToInt64Bits(this.z).UnsignedRightShift(32)));

        return hash;
    }

    /*IDK anymore*/
    public object Clone()
    {
        try
        {
            return (Vector)this.Clone();
        } 
        catch (Exception _) /*Replace with 'CloneNotSupportedException' */
        {
            /*throw new error(e);*/

        }

        return new object();
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return $"{x},{y},{z}";
    }

    /*public location tolocation*/
}
