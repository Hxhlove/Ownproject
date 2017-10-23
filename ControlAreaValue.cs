using UnityEngine;
using System.Collections;

/*---------------------------------------------------------------- 
* 版权所有：北京阿尔法视觉科技有限公司  
 
* 文件名：AreaValuesScript 
* 文件功能描述：区域价值模块动画及显示控制 
* author：hxh
* 时间：2017/10/23
* 创建标识：G 

* 修改标识： 
 
* 修改描述：
----------------------------------------------------------------*/
public class ControlAreaValue : MonoBehaviour 
{
	public GameObject roadLight;//路上的发光线条
	public GameObject[] allUI;//在开场动画结束之后需要出现的东西
	public Animator logoAnimator;//开场动画
	private float contronRoadLight = 0f;//控制发光线条间隔出现
	private float roadLightIntervals = 6f;//发光线条出现的间隔时间
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartPlay ();
		ControlRoadLight ();
	}
	/// <summary>
	/// 控制道路发光线条出现
	/// </summary>
	public void ControlRoadLight()
	{
		contronRoadLight += Time.deltaTime;
		if (contronRoadLight >= 3f) 
		{
			roadLight.SetActive (false);
		}
		if (contronRoadLight >= roadLightIntervals)
		{
			roadLight.SetActive (true);
			contronRoadLight = 0f;
		}
	}
	public void StartPlay()
	{
		AnimatorStateInfo info = logoAnimator.GetCurrentAnimatorStateInfo(0);
		// 判断动画是否播放完成
		if (info.normalizedTime >= 1.0f)
		{
			foreach (var item in allUI) 
			{
				item.SetActive (true);
			}
		}
	}
}
