using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class AdsReward : MonoBehaviour, IUnityAdsListener
{
    private string gameId = "3569993";
    private Button myButton;
    private string myPlacementId = "rewardedVideo";

    int killsOnStart;
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.interactable = Advertisement.IsReady(myPlacementId);
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, false);
    }

    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    public void OnUnityAdsReady(string placementId)
    { 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            PlayerPrefs.SetInt("kills", killsOnStart + 100);
            PlayerPrefs.Save();
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("dosmotri pozhaluysta nu pls");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        killsOnStart = PlayerPrefs.GetInt("kills");
    }
}