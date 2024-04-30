using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSubmit : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private LeaderboadHandler leaderboad;
    [SerializeField] private TMP_InputField inputField;

    private void Update()
    {
        if(leaderboad.GetPlayer() != null)
            nameText.text = leaderboad.GetPlayer().playerName;
    }

    public void OnSubmit()
    {
        var IScore = int.Parse(inputField.text);

        Debug.Log("Submit " + IScore + " to cloud");

        leaderboad.AddScore(IScore);
    }
}
