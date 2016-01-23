using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class BrushSelection : MonoBehaviour
    {
        private Texture[] brushTextures;
        public GameObject brush;
        private GameObject[] brushSelection;
        private int currentBrushIndex = 0;
        // Use this for initialization
        public void Start()
        {
            brushTextures = Resources.LoadAll<Texture>("Brushes");
            brush = Resources.Load<GameObject>("brush");
            for(int i = 0; i < brushTextures.Length; i++)
            {
                GameObject instantiatedBrush = Instantiate(brush, new Vector3(100, 100, 100), Quaternion.identity) as GameObject;
                Renderer brushRenderer = instantiatedBrush.GetComponent<Renderer>();
                brushRenderer.sharedMaterial.mainTexture = brushTextures[i];
                brushSelection[i] = instantiatedBrush;
            }
        }

        public void NextBrush()
        {
            currentBrushIndex++;
            if (currentBrushIndex > brushSelection.Length)
            {
                currentBrushIndex = 0;
            }
            
        }

        public void PreviousBrush()
        {
            currentBrushIndex--;
            if (currentBrushIndex < 0)
            {
                currentBrushIndex = brushSelection.Length;
            }
            
        }

    }
}
