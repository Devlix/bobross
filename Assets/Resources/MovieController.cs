using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class MovieController : MonoBehaviour
    {

        public MovieTexture movieTexture;
        private AudioSource aud;
        // Use this for initialization
        void Start()
        {
            AudioSource aud = GetComponent<AudioSource>();
            aud.clip = movieTexture.audioClip;
            movieTexture.Play();
            aud.Play();
        }
        public void handleControls()
        {

        }

    }
}
