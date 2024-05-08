using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class UnityServiceInitialize : MonoBehaviour
{
    async void Awake()
    {
        if (UnityServices.State == ServicesInitializationState.Uninitialized)
            await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
            await SignInAnonymously();
    }

    async Task SignInAnonymously()
    {
        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in as: " + AuthenticationService.Instance.PlayerId);
        };
        AuthenticationService.Instance.SignInFailed += s =>
        {
            // Take some action here...
            Debug.Log(s);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void Rename(string name)
    {
        var correctName = name.Split(" ");
        string finalName = "";
        if(correctName.Length > 1)
        {
            Debug.Log("Cannot have space");
            foreach(var sepName in correctName)
            {
                finalName = finalName + sepName;
            }
        }
        else
        {
            finalName = name;
        }

        await AuthenticationService.Instance.UpdatePlayerNameAsync(finalName);
    }

    public string GetPlayerName()
    {
        string name = AuthenticationService.Instance.GetPlayerNameAsync().Result;
        return name;
    }
}
