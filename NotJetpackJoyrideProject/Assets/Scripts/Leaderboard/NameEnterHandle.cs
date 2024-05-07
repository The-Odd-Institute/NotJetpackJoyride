using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameEnterHandle : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private UnityServiceInitialize unityService;

    void Start()
    {
        submitButton.interactable = !(inputField.text == "");
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField.text != "")
            submitButton.interactable = true;
        else
            submitButton.interactable = false;
    }

    public void ConfirmUpdateName()
    {
        unityService.Rename(inputField.text);
    }
}
