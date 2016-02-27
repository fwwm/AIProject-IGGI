using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public Camera Cam1;
	public Camera Cam2;
	public Camera Cam3;

	void Start () {
		Cam1.enabled = true;
		Cam2.enabled = false;
		Cam3.enabled = false;
	}

	void PatrolCam ()
	{
		Cam3.enabled = true;
		Cam1.enabled = false;
		Cam2.enabled = false;
	}
	
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Alpha1))
		{
			Cam1.enabled = true;
			Cam2.enabled = false;
			Cam3.enabled = false;
			Debug.Log ("Cam1 active");
		}
		if(Input.GetKeyUp(KeyCode.Alpha2))
		{

			Cam2.enabled = true;
			Cam1.enabled = false;
			Cam3.enabled = false;
			Debug.Log ("Cam2 active");
		}
		if(Input.GetKeyUp(KeyCode.Alpha3))
		{
			Cam3.enabled = true;
			Cam2.enabled = false;
			Cam1.enabled = false;
			Debug.Log ("Cam3 active");
		}
	}
}
