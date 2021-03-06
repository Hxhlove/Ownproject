﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 摄像机的旋转,旋转结束,以及移动的动画
/// </summary>
public class RotateCameraMain
{
	public static Transform target;//摄像机围绕旋转的目标点,全局
	public static Transform moveTarget;//摄像机移动到的位置
	public static bool controlMoveAnimation = false;//控制移动，为true时，摄像机移动到目标点

	private float minView = 50f;//摄像机视角最小
	private float maxView = 70f;//摄像机视角最大
	private float speedView = 5f;//摄像机视角变化的速度
	private float distance = 50f;//摄像机距离围绕目标的距离
	private float xSpeed = 2.0f;//x方向的速度
	private float ySpeed = 2.0f;//Y方向的速度
	private float yMinLimit = 10.0f;//Y方向最小的角度
	private float yMaxLimit = 80.0f;//Y方向最大的角度
	private float x = 0.0f;
	private float y = 0.0f;
	private Vector3 startFingerPos;  
	private Vector3 nowFingerPos;  
	private float xMoveDistance;  
	private float yMoveDistance;  
	private int backValueX = 0;
	private int backValueY = 0;
	private Quaternion rotation;
	private Vector3 position;
	private bool control = false;
	private float upX;
	private float upY;
	private bool controlMouseUp;
	/// <summary>
	/// 摄像机围绕旋转，点击鼠标左键，并滑动进行操作
	/// </summary>
	/// <param name="MainCameraRotate">Main camera rotate.</param>
	/// <param name="target">Target.</param>
	public void UpdateDriction (Transform MainCameraRotate) 
	{  
		SpeedOfRotate = VectorDistanceX ();
		distance = Vector3.Distance (MainCameraRotate.position,target.position);
		//开始点击屏幕
		if (Input.GetMouseButtonDown(0)) 
		{  
			startFingerPos = Input.mousePosition;  
		}
		//一直点击并且滑动
		if (Input.GetMouseButton(0))
		{
			control = true;
			xSpeed = Mathf.Abs (SpeedOfRotate.x);//xMoveDistance;//2.0f
			ySpeed = Mathf.Abs (SpeedOfRotate.y);//yMoveDistance;//2.0f
			if (xSpeed > 10f)
			{
				xSpeed = 10f;
			}
			if (ySpeed > 10f) {
				ySpeed = 10f;
			}
			nowFingerPos = Input.mousePosition;
		}
		//抬起鼠标时
		if (Input.GetMouseButtonUp(0)) 
		{  
			startFingerPos = nowFingerPos;
			if (upX != 0 || upY != 0)
			{
				controlMouseUp = true;
			}
		}
		if (startFingerPos == nowFingerPos) 
		{  
			return;  
		}  
		xMoveDistance = Mathf.Abs (nowFingerPos.x - startFingerPos.x);

		yMoveDistance = Mathf.Abs (nowFingerPos.y - startFingerPos.y); 

		//Debug.Log (xMoveDistance + ">>>>>>>>>>>>>" +yMoveDistance);
		if (xMoveDistance > yMoveDistance) 
		{  
			if (nowFingerPos.x - startFingerPos.x > 0) 
			{ 
				//Debug.Log("=======沿着X轴负方向移动=====");  
				backValueX = 1; //沿着X轴负方向移动  
			}
			else if(nowFingerPos.x - startFingerPos.x < 0)
			{  
				//Debug.Log("=======沿着X轴正方向移动=====");  
				backValueX = -1; //沿着X轴正方向移动  
			} else {
				backValueX = 0;
			}
		} 
		else 
		{  
			if (nowFingerPos.y - startFingerPos.y > 0)
			{ 
				//Debug.Log("=======沿着Y轴正方向移动=====");  
				backValueY = 1; //沿着Y轴正方向移动  
			}
			else if(nowFingerPos.y - startFingerPos.y < 0)
			{ 
				//Debug.Log("=======沿着Y轴负方向移动=====");  
				backValueY = -1; //沿着Y轴负方向移动 
			}
			else
			{
				backValueY = 0;
			} 
		}  
		//Debug.Log (x + "yyyyyyyyyyy" + y);
		if (control) 
		{
			if (target)
			{
				x += backValueX*xSpeed;
				y -= backValueY*ySpeed;
				y = ClamAngle (y,yMinLimit,yMaxLimit);

				MainCameraRotate.transform.LookAt (target.position);

				rotation = Quaternion.Euler (y,x,0.0f);
				position = rotation * (new Vector3 (0.0f, 0.0f, -distance)) + target.position;
				MainCameraRotate.transform.rotation = rotation;
				MainCameraRotate.transform.position = position;
			}
			if (backValueX != 0) 
			{
				upX = backValueX;
			}
			if (backValueY !=0)
			{
				upY = backValueY;
			}
			startFingerPos = nowFingerPos;
		}
		if (backValueX != 0) 
		{
			upX = backValueX;
		}
		if (backValueY !=0)
		{
			upY = backValueY;
		}
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
	/// 输入结束之后平滑停止
	/// </summary>
	public void InputEnd(Transform MainCameraRotate)
	{
		if (controlMouseUp) {
			//Debug.Log (xSpeed);
			if (xSpeed <= 0)
			{
				xSpeed = 0;
				upX = 0;
			}
			if (ySpeed <= 0)
			{
				ySpeed = 0;
				upY = 0;
			}
			if (xSpeed <= 0 & ySpeed <= 0) {
				controlMouseUp = false;
				return;
			}
			x += upX * xSpeed;
			y -= upY * ySpeed;
			y = ClamAngle (y, yMinLimit, yMaxLimit);

			MainCameraRotate.transform.LookAt (target.position);

			rotation = Quaternion.Euler (y, x, 0.0f);
			position = rotation * (new Vector3 (0.0f, 0.0f, -distance)) + target.position;
			MainCameraRotate.transform.rotation = rotation;
			MainCameraRotate.transform.position = position;

			if (xSpeed > 5f)
			{
				xSpeed -= 1f;
			}
			else
			{
				xSpeed -= 0.2f;
			}
			if (ySpeed > 5f) 
			{
				ySpeed -= 1f;
			} else {
				ySpeed -= 0.2f;
			}
			//xSpeed -= xSpeed / 2;//0.2f;
			Debug.Log(xSpeed);
		}
	}
	/// <summary>
	/// 摄像机移动到目标点的动画
	/// </summary>
	/// <param name="cameraMove">Camera move.</param>
	/// <param name="CameraTarget">Camera target.</param>
	/// <param name="con">If set to <c>true</c> con.</param>
	public bool CameraMoveAnimation (Transform cameraMove, Transform CameraTarget,bool con)
	{
		if (con) {
			//control = false;
//			xSpeed = 0;
//			ySpeed = 0;
			if (Vector3.Distance (cameraMove.position, CameraTarget.position) < 0.1f)
			{
				cameraMove.position = CameraTarget.position;
			}
			if (Vector3.Distance (cameraMove.eulerAngles, CameraTarget.eulerAngles) < 0.1f) 
			{
				cameraMove.rotation = CameraTarget.rotation;
			}
			if (cameraMove.position == CameraTarget.position && cameraMove.rotation == CameraTarget.rotation) 
			{
				//huxingpinjian.enabled = true;
				//Debug.Log("ttt");
				x = cameraMove.eulerAngles.y;
				y = cameraMove.eulerAngles.x;
				con = false;
			}
			cameraMove.position = Vector3.Slerp (cameraMove.position, CameraTarget.position, 0.1f);
			cameraMove.rotation = Quaternion.Slerp (cameraMove.rotation, CameraTarget.rotation, 0.1f);
		}
		return con;
	}
	/// <summary>
	/// 滑轮放大缩小
	/// </summary>
	/// <param name="cameraView">Camera view.</param>
	public void ScrollView(GameObject cameraView)  
	{  
		float offsetView = Input.GetAxis("Mouse ScrollWheel") * speedView;
		float tmpView = Camera.main.fieldOfView - offsetView;
		tmpView = Mathf.Clamp(tmpView, minView, maxView);
		cameraView.GetComponent<Camera>().fieldOfView = tmpView;
	}
	private Vector3 OldVector3 = Vector3.zero;
	private Vector3 NewVector3;
	private Vector3 OldNewDifference = Vector3.zero;//两个向量之间的差
	private Vector3 SpeedOfRotate = Vector3.zero;
	/// <summary>
	/// Vectors the distance.计算两帧间鼠标移动的距离
	/// </summary>
	public Vector3 VectorDistanceX()
	{
		if (Input.GetMouseButton(0)) 
		{
			NewVector3 = Input.mousePosition;
			if (OldVector3 == Vector3.zero)
			{
				//return OldNewDifference;
			} 
			else 
			{
				OldNewDifference = NewVector3 - OldVector3;
			}
			OldVector3 = NewVector3;
		}
		if (Input.GetMouseButtonUp(0))
		{
			OldVector3 = Vector3.zero;
			NewVector3 = Vector3.zero;
		}
		//Debug.Log (OldVector3 + "========" + NewVector3 + "=========" + OldNewDifference);
		return OldNewDifference;
	}
}
