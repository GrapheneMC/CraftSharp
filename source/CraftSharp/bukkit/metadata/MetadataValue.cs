using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit.metadata;

public interface MetadataValue
{
    public Object Value { get; set; }

    public Int32 AsInt();

    public Single AsFloat();

    public Double AsDouble();

    public Int64 AsLong();

    public Int16 AsShort();

    public Byte AsByte();

    public Boolean AsBoolean();

    public String AsString();

    /*public Plugin GetOwningPlugin(); */

    public void Invalidate();
}
