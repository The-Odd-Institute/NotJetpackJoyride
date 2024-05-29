using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine;

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

    private LeaderboardInformation leaderboardInformation = new LeaderboardInformation();
    private PlayerData playerData;

    [SerializeField] private GameObject LeaderboardDisplayPrefab;
    [SerializeField] private GameObject DisplayParentObject;
    [SerializeField] private int numberOfPlayerInfoReceived = 10;

    [SerializeField] private bool displayBoard = false;

    async void Awake()
    {
        if(UnityServices.State == ServicesInitializationState.Uninitialized)
            await UnityServices.InitializeAsync();

        if(!AuthenticationService.Instance.IsSignedIn)
            await SignInAnonymously();

        GetPlayerScore();

        if (displayBoard)
        {
            GetScoresBoard();
        }
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

    public async void AddScore(int score, int coin)
    {
        var metadata = new Dictionary<string, string>()
        {
            {"coin", coin.ToString()}
        };

        var options = new AddPlayerScoreOptions()
        {
            Metadata = metadata,
        };

        var scoreResponse = await LeaderboardsService.Instance.AddPlayerScoreAsync(
            LeaderboardId, 
            score,
            options);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));

        if(displayBoard)
        {
            GetScoresBoard();
        }
    }

    public async void GetScoresBoard()
    {
        var options = new GetScoresOptions()
        {
            IncludeMetadata = true,
            Limit = numberOfPlayerInfoReceived
        };

        var scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(
                LeaderboardId, 
                options);

        var playersJsonDatas = JsonConvert.SerializeObject(scoresResponse);

        Debug.Log(playersJsonDatas);

        leaderboardInformation = JsonConvert.DeserializeObject<LeaderboardInformation>(playersJsonDatas);

        DisplayLeaderBoard();
    }

    public async void GetPlayerScore()
    {
        var scoreResponse =
            await LeaderboardsService.Instance.GetPlayerScoreAsync(
                LeaderboardId);

        Debug.Log(JsonConvert.SerializeObject(scoreResponse));

        var playerJsonData = JsonConvert.SerializeObject(scoreResponse);

        playerData = JsonConvert.DeserializeObject<PlayerData>(playerJsonData);
    }

    public void DisplayLeaderBoard()
    {
        if(DisplayParentObject.transform.childCount > 0)
        {
            foreach (Transform child in DisplayParentObject.transform)
            {
                Destroy(child.gameObject);
            }
        }
        
        foreach(var player in leaderboardInformation.results)
        {
            GameObject newGameObject = Instantiate(LeaderboardDisplayPrefab, DisplayParentObject.transform);
            TextMeshProUGUI[] texts = newGameObject.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (player.rank + 1).ToString();
            var nameId = player.playerName.Split("#");
            texts[1].text = nameId[0] + "-" + nameId[1];
            var score = player.score.Split(".");
            texts[2].text = score[0];
        }
    }

    public PlayerData GetPlayer()
    {
        return playerData;
    }
}
