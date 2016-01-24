using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Image = UnityEngine.UI.Image;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class HandleInput : MonoBehaviour {

        private Camera inputCamera;
        private BrushSelection brushSelector;
        private bool mixingEnabled = false;
        private Color selectedColorOne, selectedColorTwo;
        private GameObject prevCollider;

        // Use this for initialization
        public void Start() {
            inputCamera = Camera.main;
            brushSelector = new BrushSelection();
            brushSelector.Start();
            selectedColorOne = Color.gray;
            selectedColorTwo = Color.gray;
        }
        public static Color CombineColors(params Color[] aColors)
        {
            Color result = new Color(0, 0, 0, 0);
            foreach (Color c in aColors)
            {
                result += c;
            }
            result /= aColors.Length;
            return result;
        }
        public static void setTag()
        {
            GameObject.Find("mixball").tag = "ColorMix";
        }
        public void InputHandle()
        {
            if(Input.GetMouseButton(0)) //apply brush
            {
                RaycastHit brushHit;
                if(Physics.Raycast(inputCamera.transform.position, inputCamera.transform.forward, out brushHit)){
                    //Debug.DrawLine(m_Camera.transform.position, hit.point, Color.green, 5);
                    if (brushHit.transform.tag == "Easel")
                    {
                        GameObject instantiatedBrush = Instantiate(BrushSelection.brush, brushHit.point + (brushHit.normal / 1000), Quaternion.FromToRotation(Vector3.up, brushHit.normal)) as GameObject;

                    }

                }
            }

            RaycastHit colorHit;
            if (Physics.Raycast(inputCamera.transform.position, inputCamera.transform.forward, out colorHit))
            {
                if (colorHit.transform != null){
                    if (colorHit.transform.tag == "ColorSelect")
                    {
                        //Debug.DrawLine(inputCamera.transform.position, colorHit.point, Color.red, 10);
                        brushSelector.newColor(colorHit.transform.GetComponent<Renderer>().material.color);
                        foreach (ParticleSystem selectorParticles in GameObject.Find("pallette").GetComponentsInChildren<ParticleSystem>())
                        {
                            if (selectorParticles.enableEmission && selectorParticles.transform != colorHit.transform && selectorParticles.transform.tag == "ColorSelect")
                            {
                                if(mixingEnabled && selectorParticles.transform.GetComponent<Renderer>().material.color != selectedColorTwo && selectorParticles.transform.GetComponent<Renderer>().material.color != selectedColorOne)
                                {
                                    selectorParticles.enableEmission = false;
                                }
                                else if (!mixingEnabled)
                                {
                                    selectorParticles.enableEmission = false;
                                }
                                
                            }
                        }
                        if (colorHit.transform.GetComponent<ParticleSystem>().enableEmission == false)
                        {
                            colorHit.transform.GetComponent<ParticleSystem>().enableEmission = true;
                            if (mixingEnabled)
                            {
                                selectedColorTwo = selectedColorOne;
                                selectedColorOne = colorHit.transform.GetComponent<Renderer>().material.color;
                                
                            }
                        }
                        GameObject.Find("colorsample").GetComponent<Image>().color = colorHit.transform.GetComponent<Renderer>().material.color;

                        
                    }
                    if (colorHit.transform.tag == "ColorMix")
                    {
                        if (!mixingEnabled && colorHit.transform.gameObject != prevCollider)
                        {
                            mixingEnabled = true;

                            if (!colorHit.transform.GetComponent<ParticleSystem>().enableEmission)
                            {
                                colorHit.transform.GetComponent<ParticleSystem>().enableEmission = true;
                            }
                        } else if (mixingEnabled && selectedColorTwo != Color.gray)
                        {
                            mixingEnabled = false;
                            Color mixedColor = HandleInput.CombineColors(selectedColorOne, selectedColorTwo);
                            GameObject.Find("colorsample").GetComponent<Image>().color = mixedColor;
                            brushSelector.newColor(mixedColor);
                            if (colorHit.transform.GetComponent<ParticleSystem>().enableEmission)
                            {
                                colorHit.transform.GetComponent<ParticleSystem>().enableEmission = false;
                                selectedColorOne = Color.gray;
                                selectedColorTwo = Color.gray;
                            }
                        }
                        
                    }
                    prevCollider = colorHit.transform.gameObject;
                }
                
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                brushSelector.NextBrush();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                brushSelector.PreviousBrush();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                Application.LoadLevel("01a Start");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject[] clones = GameObject.FindGameObjectsWithTag("Brush");
                foreach (GameObject clone in clones)
                {
                    Destroy(clone);
                }
            }

        }

    }
}
