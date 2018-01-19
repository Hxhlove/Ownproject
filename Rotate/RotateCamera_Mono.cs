using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RotateCamera_Mono : MonoBehaviour 
{
	public Transform targetCube;//一开始围绕旋转的目标.默认
	public Transform targetSphere;//点击围绕旋转的目标
	public Transform moveTargetHuxing;//点击移动到的目标

	private RotateCameraMain rotateCameraMain;//旋转主摄像机的类

//	private MainSceneCameraTransform mainSceneCameraTransForm;
	// Use this for initialization
	void Start ()
	{
		rotateCameraMain = new RotateCameraMain ();
		//mainSceneCameraTransForm = MainSceneCameraTransform.GetInstance ();
		RotateCameraMain.target = targetCube;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//MainSceneCameraTransform.SetCurrentTransAndTarget (this.transform,RotateCameraMain.moveTarget);
		rotateCameraMain.ScrollView (this.gameObject);//滑动摄像机视角拉近拉远
		//Debug.Log (this.transform.position);
		rotateCameraMain.UpdateDriction (this.transform);//摄像机围绕目标点旋转
		rotateCameraMain.InputEnd(this.transform);//输入完毕之后慢慢停
		RotateCameraMain.controlMoveAnimation = rotateCameraMain.CameraMoveAnimation (this.transform,RotateCameraMain.moveTarget,RotateCameraMain.controlMoveAnimation);//移动的动画
	}
	/// <summary>
	/// Dians ji hu xing ti yan.
	/// </summary>
	public void DianJiHuXingTiYan()
	{
		RotateCameraMain.target = targetSphere;//改变围绕旋转的目标点
		RotateCameraMain.moveTarget = moveTargetHuxing;//给移动到的目标点赋值
		RotateCameraMain.controlMoveAnimation = true;//开始移动
	}
	public void ChangeSceneHuXing()
	{
		//MainSceneCameraTransform.GetInstance (this.transform,RotateCameraMain.moveTarget);
		SceneManager.LoadScene ("HuXingXuanZhe");
	}
}
