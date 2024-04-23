using UnityEngine;

[CreateAssetMenu(fileName = "New SOSaveData")]
public class SOSaveData : ScriptableObject
{
    [SerializeField] private int highDistance = default;
    public int HighestDistance => highDistance;

    public void UpdateHighDistance(int newDistance, bool forceOverride = false)
    {
        if (forceOverride)
            highDistance = newDistance;

        if (newDistance > highDistance)
            highDistance = newDistance;
    }
}