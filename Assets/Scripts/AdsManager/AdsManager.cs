using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = false;
    // Start is called before the first frame update
    private void Awake()
    {
        InitializeAds();
    }
    public void InitializeAds()
    {
        string _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameId : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, true, this);
        Debug.Log("initializing ads system: " + _gameId);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Unity Ads initialization complete: "+ error.ToString() + " - "+ message);
    }
}
