using UnityEngine;
using System.Collections;

public class ControlPC : MonoBehaviour {

	public Rigidbody cameraRigidbody;
	private float speedMove = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		ControlMove ();
		JudgeFinger ();	
		RotateCameraX ();
		//RotateCameraY ();
		//Debug.Log (backValueX);
		//Debug.Log(nowFingerPos.y - startFingerPos.y);
	}
	private Vector3 startFingerPos;  
	private Vector3 nowFingerPos; 

	private float xMoveDistance;  
	private float yMoveDistance;

	public int backValueX = 0;

	//public GameObject my_Cube;  

	public void ControlMove()
	{
		if (Input.GetMouseButton (0)) {
			Vector3 LocalPos = transform.position;/*物体所处的世界坐标向量*/


			Vector3 LocalForward = transform.TransformPoint (Vector3.forward * speedMove);/*物体前方距离为speed的位置的世界坐标向量*/


			Vector3 VecSpeed = LocalForward - LocalPos;/*物体自身Vector3.forward * speed的世界坐标向量*/


			cameraRigidbody.velocity = new Vector3 (VecSpeed.x, VecSpeed.y, VecSpeed.z);
		} else
		{
			cameraRigidbody.velocity = new Vector3 (0, 0, 0);
		}
	}
	public void RotateCameraX()
	{
		if (Input.GetMouseButton(0)) 
		{
			
			if (backValueX == 1 || backValueX == -1) 
			{
				transform.Rotate (transform.up,backValueX*xMoveDistance*Time.deltaTime*5,Space.World);
			}
		}
	}

	public void JudgeFinger ()  
	{  
		//没有触摸  
//		if (Input.touchCount <= 0) {  
//			return;  
//		}  

		if (Input.GetMouseButtonDown(0)) {  

			//Debug.Log("======开始触摸=====");  

			startFingerPos = Input.mousePosition;  

		}  

		nowFingerPos = Input.mousePosition;

		if (Input.GetMouseButton(0))
		{
			xMoveDistance = Mathf.Abs (nowFingerPos.x - startFingerPos.x);  

			yMoveDistance = Mathf.Abs (nowFingerPos.y - startFingerPos.y);  
			//RotateY ();//控制绕X旋转的角度

			//transform.Translate(Vector3.forward*Time.deltaTime);
//			Vector3 LocalPos = transform.position;/*物体所处的世界坐标向量*/
//
//
//			Vector3 LocalForward = transform.TransformPoint(Vector3.forward * 5);/*物体前方距离为speed的位置的世界坐标向量*/
//
//
//			Vector3 VecSpeed = LocalForward - LocalPos;/*物体自身Vector3.forward * speed的世界坐标向量*/
//
//
//			cameraRigidbody.velocity = new Vector3 (VecSpeed.x,VecSpeed.y,VecSpeed.z);


			if (xMoveDistance > yMoveDistance) {  

				if (nowFingerPos.x - startFingerPos.x > 0) {  

					//Debug.Log("=======沿着X轴负方向移动=====");  

					backValueX = -1; //沿着X轴负方向移动  

				} else {  

					//Debug.Log("=======沿着X轴正方向移动=====");  

					backValueX = 1; //沿着X轴正方向移动  

				}  

			} 
			else {  

				if (nowFingerPos.y - startFingerPos.y > 0) {  

					//Debug.Log("=======沿着Y轴正方向移动=====");  

					backValueX = 2; //沿着Y轴正方向移动  

				} else if(nowFingerPos.y - startFingerPos.y < 0)
				{  

					//Debug.Log("=======沿着Y轴负方向移动=====");  

					backValueX = -2; //沿着Y轴负方向移动  

				}  

			}
			startFingerPos = nowFingerPos; 

		}

		if (Input.GetMouseButtonUp(0))
		{  

			startFingerPos = nowFingerPos; 
			backValueX = 0;
			//backValueY = 0;
			//RotateEndY ();
			//Debug.Log("======释放触摸=====");  
			return;  
		}  

		if (startFingerPos == nowFingerPos) {  
			return;  
		}    
		//Debug.Log (transform.rotation.eulerAngles.x);
	}
}
