using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit.metadata;

public interface Metadatable
{
    public void SetMetadata(String metadataKey, MetadataValue newMetadataValue);

    public List<MetadataValue> GetMetadata(String metadataKey);

    public Boolean HasMetadata(String metadataKey);

    public void RemoveMetadata(String metadataKey /*, Plugin owningPlugin */);
}
