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

        // Use this for initialization
        public void Start() {
            inputCamera = Camera.main;
            brushSelector = new BrushSelection();
            brushSelector.Start();
        }

        public void InputHandle()
        {
            if(Input.GetMouseButton(0)) //apply brush
            {
                RaycastHit brushHit;
                if(Physics.Raycast(inputCamera.transform.position, inputCamera.transform.forward, out brushHit)){
                    //Debug.DrawLine(m_Camera.transform.position, hit.point, Color.green, 5);
                    GameObject instantiatedBrush = Instantiate(BrushSelection.brush, brushHit.point + (brushHit.normal / 1000), Quaternion.FromToRotation(Vector3.up, brushHit.normal)) as GameObject;

                }
            }

            RaycastHit colorHit;
            if (Physics.Raycast(inputCamera.transform.position, inputCamera.transform.forward, out colorHit)) { }
            {
                if(colorHit.transform != null){
                    if (colorHit.transform.tag == "ColorSelect")
                    {
                        Debug.DrawLine(inputCamera.transform.position, colorHit.point, Color.red, 10);
                        brushSelector.newColor(colorHit.transform.GetComponent<Renderer>().material.color);
                    }
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


        }

    }
}
