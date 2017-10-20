using UnityEngine;
using System.Collections;

public class ClickButtonR : MonoBehaviour 
{

	public bool isMove = false;
	public bool isMove2 = false;
	private Vector3 targetPosition = new Vector3 (-1.9f,14.7f,1.7f);
	private Quaternion targetRotation = Quaternion.Euler (new Vector3(80f,131.8f,0f));
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Click1 ();
	}
	public void ClickButton()
	{
		if (transform.position == targetPosition)
		{
			isMove = true;
		}
		if (transform.position == Tools.camaeraPositionNow) 
		{
			isMove2 = true;
		}
	}
	public void Click1()
	{
		if (isMove)
		{
			transform.position = Vector3.Lerp (transform.position,Tools.camaeraPositionNow,0.2f);
			transform.rotation = Quaternion.Lerp (transform.rotation,Tools.cameraRotationNow,0.2f);
			if (transform.position == Tools.camaeraPositionNow) 
			{
				isMove = false;
			}
		}
		if (isMove2) 
		{
			transform.position = Vector3.Lerp (transform.position,targetPosition,0.2f);
			transform.rotation = Quaternion.Lerp (transform.rotation,targetRotation,0.2f);
			if (transform.position == targetPosition) 
			{
				isMove2 = false;
			}
		}
	}
}