using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit.metadata;

public interface MetadataStore<T>
{

    public void SetMetadata(T subject, String metadataKey, MetadataValue newMetadataValue);

    public List<MetadataValue> GetMetadata(T subject, String metadataKey);

    public Boolean HasMetadata(T subject, String metadataKey);

    public void removeMetadata(T subject, String metadataKey /*, Plugin owningPlugin */);

    public void InvalidateAll(/*Plugin owningPlugin */);
}
