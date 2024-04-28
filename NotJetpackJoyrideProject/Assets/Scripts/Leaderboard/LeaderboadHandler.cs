using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardInformation
{ 
    public int limit {  get; set; }
    public int total { get; set; }
    public List<PlayerData> results { get; set; }
}

public class LeaderboadHandler : MonoBehaviour
{
    // Create a leaderboard with this ID in the Unity Cloud Dashboard
    const string LeaderboardId = "JetpackLeaderboard";

    private LeaderboardInformation leaderboardInformation;

    [SerializeField] private GameObject LeaderboardDisplayPrefab;
    [SerializeField] private GameObject DisplayParentObject;

    string VersionId { get; set; }
    int Offset { get; set; }
    int Limit { get; set; }
    int RangeLimit { get; set; }
    List<string> FriendIds { get; set; }

    async void Awake()
    {
        if(UnityServices.State == ServicesInitializationState.Uninitialized)
            await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsAuthorized)
        {
            await SignInAnonymously();
            leaderboardInformation = new LeaderboardInformation();
        }

        GetScores();
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

    public async void AddScore()
    {
        var scoreResponse = await LeaderboardsService.Instance.AddPlayerScoreAsync(LeaderboardId, 3203);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }

    public async void GetScores()
    {
        var scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId);
        var playerJsonDatas = JsonConvert.SerializeObject(scoresResponse);

        Debug.Log(playerJsonDatas);

        leaderboardInformation = JsonConvert.DeserializeObject<LeaderboardInformation>(playerJsonDatas);

        DisplayeLeaderBoard();
    }

    public async void GetPlayerScore()
    {
        var scoreResponse =
            await LeaderboardsService.Instance.GetPlayerScoreAsync(LeaderboardId);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }

    public void DisplayeLeaderBoard()
    {
        foreach(var player in leaderboardInformation.results)
        {
            GameObject newGameObject = Instantiate(LeaderboardDisplayPrefab, DisplayParentObject.transform);
            TextMeshProUGUI[] texts = newGameObject.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (player.rank + 1).ToString();
            texts[1].text = player.playerName.ToString();
            texts[2].text = player.score.ToString();
        }
    }
}
