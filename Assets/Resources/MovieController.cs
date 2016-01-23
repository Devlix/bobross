using UnityEngine;
using System.Collections;


public class MovieController : MonoBehaviour
{
    public MovieTexture[] movieTexture;
    public string[] movieMeshes;
    private AudioSource aud;
    public int currentMovie = 0;
    public Renderer rend;
    public Texture[] textures;
    // Use this for initialization

    public void Update()
    {
        rend = GetComponent<Renderer>();
        rend.material.mainTexture = textures[currentMovie];
        aud = GetComponent<AudioSource>();
        aud.clip = movieTexture[currentMovie].audioClip;
        if (Input.GetKeyDown(KeyCode.J) & !(movieTexture[currentMovie].isPlaying))
        {
            movieTexture[currentMovie].Play();
            aud.Play();
        }
        if (Input.GetKeyDown(KeyCode.K) & movieTexture[currentMovie].isPlaying)
        {
            movieTexture[currentMovie].Pause();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            movieTexture[currentMovie].Stop();
        }
        if (Input.GetKeyDown(KeyCode.N) & currentMovie >= 1)
        {
            currentMovie--;
        }
        if (Input.GetKeyDown(KeyCode.M) & currentMovie <= 3)
        {
            currentMovie++;
        }
    }
}
