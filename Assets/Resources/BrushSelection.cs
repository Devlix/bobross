using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class BrushSelection : MonoBehaviour
    {
        private Texture[] brushTextures;
        public static GameObject brush;
        private List<GameObject> brushSelection;
        private int currentBrushIndex = 0;
        // Use this for initialization
        public void Start()
        {
            brushSelection = new List<GameObject>();
            brushTextures = Resources.LoadAll<Texture>("Brushes");
            print(brush);
            for(int i = 0; i < brushTextures.Length; i++)
            {
                GameObject instantiatedBrush = Instantiate(Resources.Load<GameObject>("brush"), new Vector3(100, 100, 100), Quaternion.identity) as GameObject;
                Renderer brushRenderer = instantiatedBrush.GetComponent<Renderer>();
                brushRenderer.material.mainTexture = brushTextures[i];
                print(instantiatedBrush);
                brushSelection.Add(instantiatedBrush);
            }
            brush = brushSelection[0];
        }

        public void NextBrush()
        {
            currentBrushIndex++;
            if (currentBrushIndex > brushSelection.Count)
            {
                currentBrushIndex = 0;
            }
            brush = brushSelection[currentBrushIndex];
        }

        public void PreviousBrush()
        {
            currentBrushIndex--;
            if (currentBrushIndex < 0)
            {
                currentBrushIndex = brushSelection.Count;
            }
            brush = brushSelection[currentBrushIndex];
            
        }

    }
}
