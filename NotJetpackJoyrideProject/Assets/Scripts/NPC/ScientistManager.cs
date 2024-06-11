using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistManager : MonoBehaviour
{
    [SerializeField] GameObject scientist;
    public void SpawnScientist()
    {
        Instantiate(scientist, transform.position, Quaternion.identity);
    }
}