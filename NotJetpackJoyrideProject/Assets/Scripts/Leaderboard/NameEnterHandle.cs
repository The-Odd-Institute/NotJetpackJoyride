using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameEnterHandle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterLimitText;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private UnityServiceInitialize unityService;
    [SerializeField] private int numberOfNameCharacterDisplay = 12;

    void Start()
    {
        submitButton.interactable = !(inputField.text == "");
        characterLimitText.text = "Character Limit: " + numberOfNameCharacterDisplay;
    }

    void Update()
    {  
        if(inputField.text == "" || inputField.text.Length > numberOfNameCharacterDisplay)
            submitButton.interactable = false;
        else if (inputField.text != "")
            submitButton.interactable = true;
    }

    public void ConfirmUpdateName()
    {
        if (inputField.text.Length <= 0) return;

        unityService.Rename(inputField.text);
    }
}
