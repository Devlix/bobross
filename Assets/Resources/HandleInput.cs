using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class HandleInput : MonoBehaviour {

        private Camera inputCamera;
        private GameObject brush;
        private BrushSelection brushSelector;
        private MovieController movieInput;

        // Use this for initialization
        public void Start() {
            inputCamera = Camera.main;
            brush = Resources.Load<GameObject>("brush");
            brushSelector = new BrushSelection();
            brushSelector.Start();
            movieInput = new MovieController();
        }

        public void InputHandle()
        {
            movieInput.handleControls();
            if(Input.GetMouseButton(0)) //apply brush
            {
                RaycastHit brushHit;
                if(Physics.Raycast(inputCamera.transform.position, inputCamera.transform.forward, out brushHit)){
                    //Debug.DrawLine(m_Camera.transform.position, hit.point, Color.green, 5);
                    GameObject instantiatedBrush = Instantiate(brush, brushHit.point + (brushHit.normal / 1000), Quaternion.FromToRotation(Vector3.up, brushHit.normal)) as GameObject;

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
