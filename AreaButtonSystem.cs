using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*---------------------------------------------------------------- 
* 版权所有：北京阿尔法视觉科技有限公司  
 
* 文件名：AreaValuesScript 
* 文件功能描述：区域价值模块按钮功能 
* author：hxh
* 时间：2017/10/23
* 创建标识：G 

* 修改标识： 
 
* 修改描述：
----------------------------------------------------------------*/

public class AreaButtonSystem : MonoBehaviour
{
	public GameObject MedicalEducation;//医疗教育
	public GameObject MunicipalSupport;//市政配套
	public GameObject BusinessMatching;//商业配套
	private bool isHideMedicalEducation = true;//医疗配套的显示与隐藏
	private bool isHideMunicipalSupport = true;//市政配套的显示与隐藏
	private bool isHideBusinessMatching = true;//商业配套的显示与隐藏
	private string sceneNameOfLoad = "";//点返回要进入的场景
	/// <summary>
	/// Clicks the medical education button.
	/// 点击教育医疗按钮,教育医疗隐藏或者显示之间切换,并恢复市政与商业的显示初始值
	/// </summary>
	public void ClickMedicalEducation()
	{
		SetHideAndDisplay (MunicipalSupport,BusinessMatching,MedicalEducation,isHideMedicalEducation,isHideMunicipalSupport,isHideBusinessMatching);
	}
	/// <summary>
	/// Clicks the municipal support.
	/// 点击市政配套按钮,教育医疗隐藏或者显示之间切换,并恢复教育与商业的显示初始值
	/// </summary>
	public void ClickMunicipalSupport()
	{
		SetHideAndDisplay (MedicalEducation,BusinessMatching,MunicipalSupport,isHideMunicipalSupport,isHideMedicalEducation,isHideBusinessMatching);
	}
	/// <summary>
	/// Clicks the business matching.
	/// 点击商业配套按钮,教育医疗隐藏或者显示之间切换,并恢复市政与教育医疗的显示初始值
	/// </summary>
	public void ClickBusinessMatching()
	{
		SetHideAndDisplay (MedicalEducation,MunicipalSupport,BusinessMatching,isHideBusinessMatching,isHideMedicalEducation,isHideMunicipalSupport);
	}
	/// <summary>
	/// Clicks the back.
	/// </summary>
	public void ClickBack()
	{
		SceneManager.LoadScene (sceneNameOfLoad);
	}
	/// <summary>
	/// Sets the hide and display.
	/// 根据ishide值判断显示其中一个或者显示所有
	/// </summary>
	public void SetHideAndDisplay(GameObject display1,GameObject display2,GameObject hide,bool isHide,bool restore1,bool restore2)
	{
		isHide = !isHide;
		if (!isHide) 
		{
			display1.SetActive (false);
			display2.SetActive (false);
			hide.SetActive (true);
		} 
		else 
		{
			SetHideAll (display1,display2,hide);
		}
		restore1 = true;
		restore2 = true;
	}
	/// <summary>
	/// Sets the hide all.
	/// </summary>
	public void SetHideAll(GameObject hide1,GameObject hide2,GameObject hide3)
	{
		hide1.SetActive (true);
		hide2.SetActive (true);
		hide3.SetActive (true);
	}

}
                                                  