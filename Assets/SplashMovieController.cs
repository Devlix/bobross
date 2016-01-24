using UnityEngine;
using System.Collections;


public class SplashMovieController : MonoBehaviour
{
    // Use this for initialization
    public MovieTexture movTexture;
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
    }
}

