using UnityEngine;
using System.Collections;
using admob;

public class AdManager : MonoBehaviour {

    public static AdManager Instance
    {
        set;
        get;
    }

	// Use this for initialization
	void Start () {
        Instance = this;
        //DontDestroyOnLoad(gameObject);

        #if UNITY_EDITOR
        #elif UNITY_ANDROID
            Admob.Instance().initAdmob("ca-app-pub-1360911154098061/4368829634", "ca-app-pub-1360911154098061/3721198033");
            Admob.Instance().setTesting(true);    
            Admob.Instance().loadInterstitial(); //calling the video ad in advance
        #endif
        }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowBanner()
    {
        #if UNITY_EDITOR
        #elif UNITY_ANDROID
            Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 5);
        #endif
        }
    public void ShowVideo()
    {
        #if UNITY_EDITOR
        #elif UNITY_ANDROID
            if (Admob.Instance().isInterstitialReady())
            {
                Admob.Instance().showInterstitial();
            }
        #endif
        }
}
