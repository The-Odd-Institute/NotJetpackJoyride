using Newtonsoft.Json;
using System.Collections.Generic;
[System.Serializable]
public class PlayerData
{
    public string playerId { get; set; }
    public string playerName { get; set; }
    public int rank { get; set; }
    public string score { get; set; }
    public string metadata { get; set; }

    [JsonIgnore]
    public Dictionary<string, string> Metadata
    {
        get
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(metadata);
        }
    }
}
