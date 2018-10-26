using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickHandle2 : MonoBehaviour {

    public Button backButton;
    public Button ShareButton;
    public Button FullScreenButton;

    // Use this for initialization
    void Start () {
        backButton.onClick.AddListener(OnBackClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnBackClick() {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("CurrentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }
        else
        {
            Application.Quit();
        }
    }

    private void ExitApp() {
            Application.Quit();
       
    }

    private void OnShareClick()
    {
        Debug.Log("Share click");

#if UNITY_ANDROID
        ShareTextInAnroid();

#else
        Debug.Log("No sharing set up for this platform.");
#endif
    }

#if UNITY_ANDROID
    public void ShareTextInAnroid()
    {

        var shareSubject = "Mira qué bicho me he encontrado!";
        var shareMessage = "Esta app es una pasada! Puedes descargarla desde:" +
        "\nhttps://play.google.com/store/apps/details?id=com.the8thwall.XRRemote";


        if (!Application.isEditor)
        {
            // Create intent for action send
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

            // Put text and subject extra
            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), shareSubject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareMessage);

            // Call createChooser method of activity class
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Comparte en...");
            currentActivity.Call("startActivity", chooser);
        }

    }
#endif

    private void OnFullScreenClick() {

        UIManager.instance.EnterFullScreen();
    }


}
