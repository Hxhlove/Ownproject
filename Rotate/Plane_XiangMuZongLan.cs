using UnityEngine;
using System.Collections;

public class Plane_XiangMuZongLan : MonoBehaviour 
{
	//public GameObject CameraMain;//主摄像机
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (Camera.main.transform);
	}
}
