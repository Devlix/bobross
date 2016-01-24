using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{

    public float fadeInTime = 2f;

    private Image fadePanel;
    private Color currentColor = Color.white;
    private static bool alreadyPlayed = false;

	// Use this for initialization
	void Start ()
	{
	    fadePanel = GetComponent<Image>();
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.timeSinceLevelLoad < fadeInTime && !alreadyPlayed)
	    {
	        float alphaChange = Time.deltaTime/fadeInTime;
	        currentColor.a -= alphaChange;
	        fadePanel.color = currentColor;
	    }
	    else
	    {
	        gameObject.SetActive(false);
            alreadyPlayed = true;
        }
	}
}
