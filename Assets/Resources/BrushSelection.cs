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
        public static Color currentColor;
        // Use this for initialization
        public void Start()
        {
            if (currentColor == null)
            {
                currentColor = Color.black;
            }
            brushSelection = new List<GameObject>();
            brushTextures = Resources.LoadAll<Texture>("Brushes");
            brush = Instantiate(Resources.Load<GameObject>("brush"), new Vector3(100, 100, 100), Quaternion.identity) as GameObject;
            brush.GetComponent<Renderer>().material.mainTexture = brushTextures[currentBrushIndex];
            brush.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            brush.GetComponent<Renderer>().material.SetColor("_EmissionColor", currentColor);   
        }

        public void NextBrush()
        {
            currentBrushIndex++;
            if (currentBrushIndex > brushTextures.Length)
            {
                currentBrushIndex = 0;
            }
            brush = Instantiate(Resources.Load<GameObject>("brush"), new Vector3(100, 100, 100), Quaternion.identity) as GameObject;
            print(brushTextures[currentBrushIndex]);
            brush.GetComponent<Renderer>().material.mainTexture = brushTextures[currentBrushIndex];
            brush.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            brush.GetComponent<Renderer>().material.SetColor("_EmissionColor", currentColor);
        }

        public void PreviousBrush()
        {
            currentBrushIndex--;
            if (currentBrushIndex < 0)
            {
                currentBrushIndex = brushTextures.Length;
            }
            brush = Instantiate(Resources.Load<GameObject>("brush"), new Vector3(100, 100, 100), Quaternion.identity) as GameObject;
            brush.GetComponent<Renderer>().material.mainTexture = brushTextures[currentBrushIndex];
            brush.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            brush.GetComponent<Renderer>().material.SetColor("_EmissionColor", currentColor);
            

        }

        public void newColor(Color color)
        {
            print(color);
            brush = Instantiate(Resources.Load<GameObject>("brush"), new Vector3(100, 100, 100), Quaternion.identity) as GameObject;
            brush.GetComponent<Renderer>().material.mainTexture = brushTextures[currentBrushIndex];
            brush.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            brush.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
            currentColor = color;
        }

       void update()
        {
            print(currentColor);
        }
    }
}
