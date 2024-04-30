using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Transform[] backgroundPanels; // array of backgrounds
    [SerializeField] private float moveSpeed; //will likely get this value from somewhere else later

    private float panelWidth = 18f; //width of screen is 18
    void Start()
    {
        for (int i = 0; i < backgroundPanels.Length; i++) //set panels starting positions
        {
            var panel = backgroundPanels[i];
            panel.transform.position = new Vector3(panelWidth * i, 0, 0);
        }
    }

    void Update()
    {
        foreach(Transform panel in backgroundPanels)
        {
            Vector3 newPosition = new Vector3();
            newPosition.x = panel.position.x - (Time.deltaTime * moveSpeed);
            panel.position = newPosition;

            if(panel.position.x < -18) //check is panel is fully off screen
            {
                newPosition.x = panel.position.x + (backgroundPanels.Length * 18); 
                panel.position = newPosition; // push to the end (furthest right)
            }
        }
    }
}