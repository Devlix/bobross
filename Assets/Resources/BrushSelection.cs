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
            for(int i = 0; i < brushSelection.Length; i++)
            {

            }
        }

        public void NextBrush()
        {
            currentBrushIndex++;
            if (currentBrushIndex > brushSelection.Length)
            {
                currentBrushIndex = 0;
            }
            Renderer brushRenderer = brush.GetComponent<Renderer>();
            brushRenderer.sharedMaterial.mainTexture = brushSelection[currentBrushIndex];
        }

        public void PreviousBrush()
        {
            currentBrushIndex--;
            if (currentBrushIndex < 0)
            {
                currentBrushIndex = brushSelection.Length;
            }
            Renderer brushRenderer = brush.GetComponent<Renderer>();
            brushRenderer.sharedMaterial.mainTexture = brushSelection[currentBrushIndex];
        }

    }
}
