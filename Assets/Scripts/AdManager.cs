using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour {

	public static AdManager instance;

	public RewardBasedVideoAd rewardBasedVideo;

	private BannerView bannerView;

	public bool repeat = true;

	void Awake(){
		DontDestroyOnLoad (this.gameObject);

		if (instance == null) {
			instance = this;
		} 
		else {
			Destroy (this.gameObject);
		}
	}


		void Start()
		
	{

		this.rewardBasedVideo = RewardBasedVideoAd.Instance;

		rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
		rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;




		#if UNITY_ANDROID
		string appId = "ca-app-pub-3940256099942544~3347511713";
		#else
		string appId = "unexpected_platform";
		#endif
	
		MobileAds.Initialize(appId);

		this.RequestBanner();

		this.RequestRewardedVideo();


	}

		
	private void RequestBanner()
		
	{
		
			#if UNITY_ANDROID
			string adUnitId = "ca-app-pub-3940256099942544/6300978111";
			#else
			string adUnitId = "unexpected_platform";
			#endif

		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

		bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;

	}


	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		
		LoadBanner ();
	}
	public void LoadBanner(){

		AdRequest request = new AdRequest.Builder().Build();

		bannerView.LoadAd(request);
	}


	public void RequestRewardedVideo()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-3940256099942544/5224354917";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		AdRequest request = new AdRequest.Builder().Build();

		this.rewardBasedVideo.LoadAd(request, adUnitId);

		}
		

	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
		if (AudioListener.pause == true) {
			AudioListener.pause = true;
		} else {
			AudioListener.pause = false;
		}
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		this.RequestRewardedVideo();

		if (AudioListener.pause == true) {
		
			AudioListener.pause = true;
		} else {
			AudioListener.pause = false;
		
		}


	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		
		PlayerPrefs.SetInt ("ScoreReward", 1);
		SceneManager.LoadScene ("Game");
	}


	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		this.RequestRewardedVideo();
	}

}
