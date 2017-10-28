using UnityEngine;
using System.Collections;

public class ControlCmeraY : MonoBehaviour
{
	private ControlPC controlPC;

	bool isControl = false;
	float s = 1f;
	// Use this for initialization
	void Start () 
	{
		controlPC = transform.parent.gameObject.GetComponent<ControlPC>();
		//Debug.Log (controlPC.backValueX);
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isControl) {
			s = 0;

		} else
			s = 1;
		//Debug.Log (controlPC.backValueX);
		RotateCamera();
		//Debug.Log (transform.localRotation.x);
	}

	public void RotateCamera()
	{
		if (Input.GetMouseButton(0))
		{
			if (controlPC.backValueX == 2 || controlPC.backValueX == -2)
			{
				transform.Rotate (transform.right,controlPC.backValueX*Time.deltaTime*0.2f,Space.World);
				RotateY ();
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			RotateEndY ();
		}
	}

	float x ;
	float y ;
	Quaternion rotation;
	public void RotateY()
	{
		x += controlPC.backValueX*0.25f;
		y -= controlPC.backValueX*0.25f;
		y = ClamAngle (y,-15,30);
		rotation = Quaternion.Euler (y,transform.eulerAngles.y,0.0f);
		transform.rotation = rotation;
	}
	static float ClamAngle(float angle,float min,float max)
	{
		if (angle < -360.0f) 
		{
			angle += 360.0f;
		}
		if (angle > 360.0f)
		{
			angle -= 360.0f;
		}
		return Mathf.Clamp (angle,min,max);
	}
	/// <summary>
	/// 鼠标弹起的时候绕X旋转的角度返回初始值 0
	/// </summary>
	public void RotateEndY()
	{
		transform.rotation = Quaternion.Euler (0.0f,transform.rotation.eulerAngles.y,0.0f);
		//Debug.Log ("ddddd");
	}
//	public void OnTriggerEnter(Collider col){
//		isControl = true;
//		Debug.Log ("Enter");
//		transform.parent.Translate (Vector3.back * Time.deltaTime*5);
//	}
//	public void OnTriggerExit(Collider col){
//		//		
//		//		s = 1f;
//		Debug.Log ("Exit");
//		Debug.Log (s);
//		isControl = false;
//	}
}
