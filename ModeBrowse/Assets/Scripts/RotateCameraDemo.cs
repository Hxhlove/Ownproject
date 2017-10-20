using UnityEngine;
using System.Collections;

public class RotateCameraDemo: MonoBehaviour 
{
	public Transform target;
	public float distance = 2.0f;
	public float minDistance = 10f;
	public float maxDistance = 20f;

	public float xSpeed = 2.0f;
	public float ySpeed = 2.0f;

	public float yMinLimit = 10.0f;
	public float yMaxLimit = 80.0f;

	private float x = 0.0f;
	private float y = 0.0f;

	private bool control = false;
	//是否漫游
	//private bool isManYou = false;
	// Use this for initialization
	void Start () 
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x; 

		Tools.camaeraPositionNow = this.position;
		Tools.cameraRotationNow = this.rotation;
	}
	Quaternion rotation;
	Vector3 position;

	float upX;
	float upY;
	bool controlMouseUp;
	public GameObject uiTosouth;
	void Update()
	{
		uiTosouth.transform.eulerAngles = new Vector3(0,0 , transform.eulerAngles.y);
		UpdateDriction ();//安卓端
		UpdateDriction2 ();//电脑端
		InputEnd();

		Tools.camaeraPositionNow = this.position;
		Tools.cameraRotationNow = this.rotation;
	}

	public void UpdateDriction2 () 
	{  
		if (Input.GetMouseButtonDown(0)) 
		{  
			//Debug.Log("======开始触摸=====");  
			startFingerPos = Input.mousePosition;  
		}

		if (Input.GetMouseButton(0))
		{
			control = true;
			xSpeed = 2.0f;
			ySpeed = 2.0f;
			nowFingerPos = Input.mousePosition;
		}

		//nowFingerPos = Input.mousePosition;  

		if (Input.GetMouseButtonUp(0)) 
		{  
			startFingerPos = nowFingerPos;  
			controlMouseUp = true;
			//SetPosition ();
			//Debug.Log("======释放触摸=====");  
			return;
		}
		if (startFingerPos == nowFingerPos) 
		{  
			return;  
		}  
		xMoveDistance = Mathf.Abs (nowFingerPos.x - startFingerPos.x);  
		yMoveDistance = Mathf.Abs (nowFingerPos.y - startFingerPos.y);  
		if (xMoveDistance > yMoveDistance) 
		{  
			if (nowFingerPos.x - startFingerPos.x > 0) 
			{ 
				//Debug.Log("=======沿着X轴负方向移动=====");  
				backValueX = 1; //沿着X轴负方向移动  
			}
			else 
			{  
				//Debug.Log("=======沿着X轴正方向移动=====");  
				backValueX = -1; //沿着X轴正方向移动  
			}  
		} 
		else 
		{  
			if (nowFingerPos.y - startFingerPos.y > 0)
			{ 
					//Debug.Log("=======沿着Y轴正方向移动=====");  
				backValueY = 1; //沿着Y轴正方向移动  

			}
			else 
			{ 
				//Debug.Log("=======沿着Y轴负方向移动=====");  
				backValueY = -1; //沿着Y轴负方向移动 
			}  

		}  
		if (control) 
		{
			if (target)
			{
				x += backValueX*xSpeed;
				y -= backValueY*ySpeed;
				y = ClamAngle (y,yMinLimit,yMaxLimit);
				rotation = Quaternion.Euler (y,x,0.0f);
				position = rotation * (new Vector3 (0.0f, 0.0f, -distance)) + target.position;
				//Debug.Log (position);
				transform.rotation = rotation;
				transform.position = position;
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
		
	private Touch oldTouch1;  //上次触摸点1(手指1)  
	private Touch oldTouch2;  //上次触摸点2(手指2)  
	private Vector3 startFingerPos;  
	private Vector3 nowFingerPos;  
	private float xMoveDistance;  
	private float yMoveDistance;  
	private int backValueX = 0;
	private int backValueY = 0;
	//bool isRotate = false;//是否旋转结束
	float angela;//旋转的角度

	public void UpdateDriction () 
	{  
		//没有触摸  
		if ( Input.touchCount <= 0 )
		{  
			return;  
		}  

		//单点触摸， 水平上下旋转  
		if( 1 == Input.touchCount ){  
			if (Input.GetTouch (0).phase == TouchPhase.Began ) {  
				//Debug.Log("=====开始触摸=====");  
				startFingerPos = Input.GetTouch (0).position;  
			}
			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				control = true;
				xSpeed = 2.0f;
				ySpeed = 2.0f;
			}

			nowFingerPos = Input.GetTouch (0).position;  

			if ((Input.GetTouch (0).phase == TouchPhase.Stationary) || (Input.GetTouch(0).phase == TouchPhase.Ended)) 
			{  

				startFingerPos = nowFingerPos;  
				controlMouseUp = true;

				//SetPosition ();
				//Debug.Log("======释放触摸=====");  
				return;

			}
			//          if (Input.GetTouch(0).phase == TouchPhase.Ended) {  
			//                
			//          }  
			if (startFingerPos == nowFingerPos) {  
				return;  
			}  
			xMoveDistance = Mathf.Abs (nowFingerPos.x - startFingerPos.x);  

			yMoveDistance = Mathf.Abs (nowFingerPos.y - startFingerPos.y);  

			if (xMoveDistance > yMoveDistance) {  

				if (nowFingerPos.x - startFingerPos.x > 0)
				{  

					//Debug.Log("=======沿着X轴负方向移动=====");  

					backValueX = 1; //沿着X轴负方向移动  

				} else 
				{  

					//Debug.Log("=======沿着X轴正方向移动=====");  

					backValueX = -1; //沿着X轴正方向移动
				}  

			} else {  

				if (nowFingerPos.y - startFingerPos.y > 0) {  

					//Debug.Log("=======沿着Y轴正方向移动=====");  

					backValueY = 1; //沿着Y轴正方向移动  

				} else {  

					//Debug.Log("=======沿着Y轴负方向移动=====");  

					backValueY = -1; //沿着Y轴负方向移动  

				}  

			}  
		}
		if (control) 
		{
			if (target)
			{
				x += backValueX*xSpeed;
				y -= backValueY*ySpeed;
				y = ClamAngle (y,yMinLimit,yMaxLimit);
				rotation = Quaternion.Euler (y,x,0.0f);
				position = rotation * (new Vector3 (0.0f, 0.0f, -distance)) + target.position;
				transform.rotation = rotation;
				transform.position = position;
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
		//多点触摸, 放大缩小  
		Touch newTouch1 = Input.GetTouch (0);  
		Touch newTouch2 = Input.GetTouch (1);  

		//第2点刚开始接触屏幕, 只记录，不做处理  
		if( newTouch2.phase == TouchPhase.Began ){  
			oldTouch2 = newTouch2;  
			oldTouch1 = newTouch1;  
			return;  
		}  

		//计算老的两点距离和新的两点间距离，变大要放大模型，变小要缩放模型  
		float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);  
		float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);  

		//两个距离之差，为正表示放大手势， 为负表示缩小手势  
		float offset = newDistance - oldDistance;  

		//放大因子， 一个像素按 0.01倍来算(100可调整)  
		float scaleFactor = offset / 200f;  
		//Vector3 localScale = transform.localScale; 
		distance += scaleFactor;
		if (distance<minDistance)
	    {
			distance = minDistance;
		}
		else if(distance > maxDistance)
		{
			distance = maxDistance;
		}

		//记住最新的触摸点，下次使用  
		oldTouch1 = newTouch1;  
		oldTouch2 = newTouch2; 
	}
	/// <summary>
	/// 触摸结束之后 对旋转的速度递减 达到速度渐渐减慢的效果
	/// </summary>
	public void InputEnd()
	{
		if (controlMouseUp)
		{
			x += upX*xSpeed;
			y -= upY*ySpeed;
			y = ClamAngle (y,yMinLimit,yMaxLimit);
			rotation = Quaternion.Euler (y,x,0.0f);
			position = rotation * (new Vector3 (0.0f, 0.0f, -distance)) + target.position;
			transform.rotation = rotation;
			transform.position = position;
			xSpeed -= 0.1f;
			//Debug.Log (xSpeed);
			if (xSpeed < 0)
			{
				xSpeed = 0;
				controlMouseUp = false;
			}
			//transform.Rotate(Vector3.Lerp(transform.eulerAngles,new Vector3(y,x,0.0f),0.1f));
		}
	}
}
