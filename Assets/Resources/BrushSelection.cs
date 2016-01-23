using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class BrushSelection : MonoBehaviour
    {
        private Texture[] brushSelection;
        public GameObject brush;
        private int currentBrushIndex = 0;
        // Use this for initialization
        void Start()
        {
            brushSelection = Resources.LoadAll<Texture>("Brushes");
            brush = Resources.Load<GameObject>("brush");
        }

        void NextBrush()
        {
            currentBrushIndex++;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
