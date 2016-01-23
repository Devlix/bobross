using UnityEngine;
using System.Collections;


public class MovieController : MonoBehaviour
{
    public MovieTexture movieTexture;
    private AudioSource aud;
    // Use this for initialization
    public void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.clip = movieTexture.audioClip;
        movieTexture.Play();
        aud.Play();
    }

    public void handleControls()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
        }
    }
}
