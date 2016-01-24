using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	private float maxX;
	private float maxY;
	public static float zoom = 6;

	// Update is called once per frame
	void Start()
	{
		maxX = GameObject.Find("BoundRight").transform.position.x - (zoom * Screen.width / Screen.height);
		maxY = GameObject.Find("BoundTop").transform.position.y-zoom;
	}
	void Update () 
	{
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			destination.x = Mathf.Clamp(destination.x, 0, maxX);
			destination.y = Mathf.Clamp(destination.y, zoom, maxY);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

			//GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView,zoom,Time.deltaTime*5.0f);
			GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize,zoom,Time.deltaTime*5);;
		}
		
	}

}
