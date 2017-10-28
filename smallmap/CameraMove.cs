using UnityEngine;
using System.Collections;


public class CameraMove : MonoBehaviour {

	public Transform targetPosition1;//目标点
	public Transform targetPosition2;//目标点2
	private Transform startPosition;//起始点
	private Transform AimsPosition;//目标点
	private float SlerpNumber = 0.1f;
	public Transform cameraPostion;//摄像机位置
	private bool isMoveToTargetPosition1 = false;
	// Use this for initialization
	void Start () 
	{
//		Vector3 angles = transform.eulerAngles;
//		x = angles.y;
//		y = angles.x; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		CameraMoveToTargetPosition ();
		//Debug.Log (distance);
		//LimitXAndY();
		//InputEnd();
		//UpdateDriction2 ();
	}
	public void CameraMoveToTargetPosition1()
	{
		startPosition = cameraPostion;
		isMoveToTargetPosition1 = !isMoveToTargetPosition1;
		if (isMoveToTargetPosition1)
		{
			AimsPosition = targetPosition2;
		} else {
			AimsPosition = targetPosition1;
		}
	}
	public void CameraMoveToTargetPosition()
	{
		if (AimsPosition != null) 
		{
			
			cameraPostion.position = Vector3.Slerp (startPosition.position,AimsPosition.position,SlerpNumber);
			cameraPostion.rotation = Quaternion.Lerp (startPosition.rotation,AimsPosition.rotation,SlerpNumber);
			if (Vector3.Distance(cameraPostion.position,AimsPosition.position) < 0.2f)
			{
				cameraPostion.position = AimsPosition.position;
			}
			if (Vector3.Distance(cameraPostion.eulerAngles,AimsPosition.eulerAngles) < 0.2f)
			{
				cameraPostion.rotation = AimsPosition.rotation;
			}
			if (cameraPostion.position == AimsPosition.position && cameraPostion.rotation == AimsPosition.rotation)
			{
				AimsPosition = null;
			}
		}
	}
}
