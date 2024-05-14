using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RocketSpawner : MonoBehaviour
{
    private static RocketSpawner instance = null;
    [SerializeField] GameObject rocket;
    private RocketSpawner()
    {
    }

    public static RocketSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RocketSpawner();
            }
            return instance;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SpawnTwoStaticRockets();
        }
    }

    public void SpawnStaticRocket()
    {
        GameObject newRocket = Instantiate(rocket, this.transform);
        newRocket.transform.position = new Vector3(transform.parent.position.x, Random.Range(-3, 4), 0);
    }

    public void SpawnTargetedRocket()
    {
        GameObject newRocket = Instantiate(rocket,this.transform);
        newRocket.GetComponent<Rocket>().targetPlayer = true;
    }
    public void SpawnSeekingRocket()
    {
        GameObject newRocket = Instantiate(rocket, this.transform);
        newRocket.GetComponent<Rocket>().targetPlayer = true;
        newRocket.GetComponent<Rocket>().followPlayer = true;
    }

    public void SpawnTargetedRockets(int numRockets, float offsetTime)
    {
        for(int i = 0; i < numRockets; i++)
        {
            Invoke(nameof(SpawnTargetedRocket), i * offsetTime);
        }
    }

    public void SpawnTwoStaticRockets()
    {
        GameObject newRocket1 = Instantiate(rocket, this.transform);
        GameObject newRocket2 = Instantiate(rocket, this.transform);
        newRocket1.transform.position = new Vector3(transform.position.x,4,transform.position.z);
        newRocket2.transform.position = new Vector3(transform.position.x, -3, transform.position.z);
    }

    public void SpawnThreeStaticRockets()
    {
        GameObject newRocket1 = Instantiate(rocket, this.transform);
        GameObject newRocket2 = Instantiate(rocket, this.transform);
        GameObject newRocket3 = Instantiate(rocket, this.transform);
        newRocket1.transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        newRocket2.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        newRocket3.transform.position = new Vector3(transform.position.x, -3, transform.position.z);
    }
}