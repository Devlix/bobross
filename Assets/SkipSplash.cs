using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SkipSplash : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Z))
	    {
            Debug.Log("New Level load: 01a Start");
            Application.LoadLevel("01a Start");
        }
	}
}
