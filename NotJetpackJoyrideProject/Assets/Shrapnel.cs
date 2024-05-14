using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrapnel : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    private float currentLifeTime = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        currentLifeTime += Time.deltaTime;
        if(currentLifeTime >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
