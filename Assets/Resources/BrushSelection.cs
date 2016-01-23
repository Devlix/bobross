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
        public void Start()
        {
            brushSelection = Resources.LoadAll<Texture>("Brushes");
            brush = Resources.Load<GameObject>("brush");
        }

        public void NextBrush()
        {
            currentBrushIndex++;
            if (currentBrushIndex > brushSelection.Length)
            {
                currentBrushIndex = 0;
            }
            Renderer brushRenderer = brush.GetComponent<Renderer>();
            brushRenderer.material.mainTexture = brushSelection[currentBrushIndex];
        }

        public void PreviousBrush()
        {
            currentBrushIndex--;
            if (currentBrushIndex < brushSelection.Length)
            {
                currentBrushIndex = brushSelection.Length;
            }
            Renderer brushRenderer = brush.GetComponent<Renderer>();
            brushRenderer.material.mainTexture = brushSelection[currentBrushIndex];
        }

    }
}
