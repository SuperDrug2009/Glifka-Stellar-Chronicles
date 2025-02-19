using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Privacy : MonoBehaviour
{
    private UniWebView ObjectC;
    public void PrivacyObject()
    {
        UniWebView.SetAllowInlinePlay(true);
        ObjectC = gameObject.AddComponent<UniWebView>();
        ObjectC.Frame = new Rect(0, 0, Screen.width, Screen.height);
        ObjectC.EmbeddedToolbar.Show();
        ObjectC.SetAllowBackForwardNavigationGestures(true);
        ObjectC.Load(privacyPolicy);
        ObjectC.Show();
    }
    public string privacyPolicy;
}
