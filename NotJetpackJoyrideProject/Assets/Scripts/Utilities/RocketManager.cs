using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    [SerializeField] private RocketSpawner rocketGenerator;

    private int rocketType;
    public void SpawnRockets()
    {
        rocketType = Random.Range(0, 5);
        switch(rocketType)
        {
            case 0:
                {
                    rocketGenerator.SpawnSeekingRocket();
                    break;
                }
            case 1:
                {
                    rocketGenerator.SpawnStaticRocket();
                    break;
                }
            case 2:
                {
                    rocketGenerator.SpawnTargetedRockets(Random.Range(0, 4), 1);
                    break;
                }
            case 3:
                {
                    rocketGenerator.SpawnTwoStaticRockets();
                    break;
                }
            case 4:
                {
                    rocketGenerator.SpawnThreeStaticRockets();
                    break;
                }
            default:
                break;
        }
    }
}
