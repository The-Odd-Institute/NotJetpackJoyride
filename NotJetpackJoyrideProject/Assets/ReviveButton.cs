using UnityEngine;
using UnityEngine.Advertisements;

public class ReviveButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string androidAdUnitId = "Rewarded_Android";
    [SerializeField] private string iosAdUnitId = "Rewarded_iOS";
    private string adUnitId;

    void Start()
    {
        // Configura el ID de unidad de anuncio según la plataforma.
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iosAdUnitId
            : androidAdUnitId;

        LoadAd();
    }

    // Método para cargar el anuncio.
    public void LoadAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    // Método para mostrar el anuncio cuando se llama.
    public void ShowAd()
    {
        Advertisement.Show(adUnitId, this);
     
    }

    // Llamadas de retorno para manejo de eventos.
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }

    public void OnUnityAdsShowClick(string adUnitId) { }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            RevivePlayer();
        }
        else if (showCompletionState == UnityAdsShowCompletionState.SKIPPED)
        {
            Debug.Log("Unity Ads Rewarded Ad Skipped");

            GoToDeathScrren();

        }
       /* else if (showCompletionState == UnityAdsShowCompletionState.FAILED)
        {
            Debug.Log("Unity Ads Rewarded Ad Failed");
        }*/
    }

    public void RevivePlayer()
    {
        Debug.Log("Player revives");
        gameManager.RevivePlayer();
    }

    public void GoToDeathScrren()
    {
        gameManager.LoadRevivalScreen();
    }    
}
