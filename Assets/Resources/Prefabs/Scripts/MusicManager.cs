using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicChangeArray;

    private AudioSource music;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Dont destroy on load" + name);
    }

    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];

        Debug.Log("Playing clip: " + thisLevelMusic);

        if(thisLevelMusic) // If there's some music attached
        {
            music.clip = thisLevelMusic;
            music.loop = true;
            music.Play();
        }
    }

    public void ChangeVolume(float volume)
    {
        music.volume = volume;
    }
}
