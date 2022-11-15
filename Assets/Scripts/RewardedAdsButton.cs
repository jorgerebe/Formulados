﻿using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{

    const string gameId = "1431733";
    string RewardedId = "Android_Rewarded";

    Preguntas scriptPreguntas;
    void Start()
    {
    }

    public void Inicializar()
    {
        Advertisement.Initialize(gameId, false, this);
    }

    public void addScriptPreguntas(Preguntas scriptPreguntas)
    {
        this.scriptPreguntas = scriptPreguntas;
    }

    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + RewardedId);
        Advertisement.Load(RewardedId, this);
        scriptPreguntas.activarBotones();
    }

    public void ShowAd()
    {
        // Disable the button:
        scriptPreguntas.desactivarBotones();
        // Then show the ad:
        Advertisement.Show(RewardedId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded: " + placementId);

        if (placementId.Equals(RewardedId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            // Enable the button for users to click:
            scriptPreguntas.activarBotones();
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError(error + message);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        scriptPreguntas.activarBotones();
        Debug.LogError(error + message);
    }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            scriptPreguntas.Eliminar2RespuestasIncorrectas();
        }
        else if (showCompletionState == UnityAdsShowCompletionState.SKIPPED || showCompletionState == UnityAdsShowCompletionState.UNKNOWN)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnInitializationComplete()
    {
        LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }
}

/*
using UnityEngine;
using System;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Mediation;


public class RewardedAdsButton : MonoBehaviour, IDisposable
{
    IRewardedAd ad;
    string adUnitId = "Android_Rewarded";
    string gameId = "1431733";

    Preguntas scriptPreguntas;

    public void Inicializar()
    {
        InitServices();
    }

    public async Task InitServices()
    {
        try
        {
            InitializationOptions initializationOptions = new InitializationOptions();
            initializationOptions.SetGameId(gameId);
            await UnityServices.InitializeAsync(initializationOptions);

            InitializationComplete();
        }
        catch (Exception e)
        {
            InitializationFailed(e);
        }
    }

    public void SetupAd()
    {
        //Create
        ad = MediationService.Instance.CreateRewardedAd(adUnitId);

        //Subscribe to events
        ad.OnClosed += AdClosed;
        ad.OnClicked += AdClicked;
        ad.OnLoaded += AdLoaded;
        ad.OnFailedLoad += AdFailedLoad;
        ad.OnUserRewarded += UserRewarded;

        // Impression Event
        MediationService.Instance.ImpressionEventPublisher.OnImpression += ImpressionEvent;
    }

    public void Dispose() => ad?.Dispose();


    public async void ShowAd()
    {
        if (ad.AdState == AdState.Loaded)
        {
            try
            {
                RewardedAdShowOptions showOptions = new RewardedAdShowOptions();
                showOptions.AutoReload = true;
                await ad.ShowAsync(showOptions);
                AdShown();
            }
            catch (ShowFailedException e)
            {
                AdFailedShow(e);
            }
        }
    }

    public void addScriptPreguntas(Preguntas scriptPreguntas)
    {
        this.scriptPreguntas = scriptPreguntas;
    }


    void InitializationComplete()
    {
        SetupAd();
        LoadAd();
    }

    async Task LoadAd()
    {
        try
        {
            await ad.LoadAsync();
        }
        catch (LoadFailedException)
        {
            // We will handle the failure in the OnFailedLoad callback
        }
    }

    void InitializationFailed(Exception e)
    {
        Debug.Log("Initialization Failed: " + e.Message);
    }

    void AdLoaded(object sender, EventArgs e)
    {
        scriptPreguntas.activarBotones();
        Debug.Log("Ad loaded");
    }

    void AdFailedLoad(object sender, LoadErrorEventArgs e)
    {
        Debug.Log("Failed to load ad");
        Debug.Log(e.Message);
    }

    void AdShown()
    {
        Debug.Log("Ad shown!");
    }

    void AdClosed(object sender, EventArgs e)
    {
        Debug.Log("Ad has closed");
        // Execute logic after an ad has been closed.
    }

    void AdClicked(object sender, EventArgs e)
    {
        Debug.Log("Ad has been clicked");
        // Execute logic after an ad has been clicked.
    }

    void AdFailedShow(ShowFailedException e)
    {
        Debug.Log(e.Message);
    }

    void ImpressionEvent(object sender, ImpressionEventArgs args)
    {
        var impressionData = args.ImpressionData != null ? JsonUtility.ToJson(args.ImpressionData, true) : "null";
        Debug.Log("Impression event from ad unit id " + args.AdUnitId + " " + impressionData);
    }

    void UserRewarded(object sender, RewardEventArgs e)
    {
        scriptPreguntas.Eliminar2RespuestasIncorrectas();
        Debug.Log($"Received reward: type:{e.Type}; amount:{e.Amount}");
    }

}*/