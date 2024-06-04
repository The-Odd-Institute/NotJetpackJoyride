using Newtonsoft.Json;
using System;
using System.Collections.Generic;

[Serializable]
public class Metadata
{
    public string coin;
}

[Serializable]
public class PlayerData
{
    public string playerId { get; set; }
    public string playerName { get; set; }
    public int rank { get; set; }
    public string score { get; set; }
    public string updatedTime { get; set; }

    [JsonProperty("metadata")]
    public string MetadataJson { get; set; }

    [JsonIgnore]
    public Metadata Metadata { get; set; }

    public void ParseMetadata()
    {
        if (!string.IsNullOrEmpty(MetadataJson))
        {
            Metadata = JsonConvert.DeserializeObject<Metadata>(MetadataJson);
        }
    }
}