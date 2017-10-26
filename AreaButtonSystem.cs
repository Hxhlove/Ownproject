using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

	private bool isHideMedicalEducation = false;//医疗配套的显示与隐藏
	private bool isHideMunicipalSupport = false;//市政配套的显示与隐藏
	private bool isHideBusinessMatching = false;//商业配套的显示与隐藏
	public GameObject MedicalEducationUI;//教育医疗按钮
	public GameObject MunicipalSupportUI;//市政配套按钮
	public GameObject BusinessMatchingUI;//商业配套按钮
	public GameObject backSceneUI;//返回按钮

	public Sprite medicalEducationDeafult;//教育医疗默认图片
	public Sprite medicalEducationClick;//教育医疗点击之后的图片
	public Sprite municipalSupportDeafult;//市政配套默认图片
	public Sprite municipalSupportClick;//市政配套按钮点击图片
	public Sprite businessMatchingDeafult;//商业配套按钮默认图片
	public Sprite businessMatchingClick;//商业配套按钮点击图片
	public Sprite backDeafult;//返回按钮图片
	public Sprite backClick;//返回按钮点击图片
	public GameObject maskImage;
	void Update()
	{
		//Debug.Log (isHideMedicalEducation);
		//Debug.Log(isHideMedicalEducation.ToString() + isHideMunicipalSupport.ToString() + isHideBusinessMatching.ToString());
	}
	private string sceneNameOfLoad = "";//点返回要进入的场景
	/// <summary>
	/// Clicks the medical education button.
	/// 点击教育医疗按钮,教育医疗隐藏或者显示之间切换,并恢复市政与商业的显示初始值
	/// </summary>
	public void ClickMedicalEducation()
	{
		//Debug.Log (maskImage.transform.GetSiblingIndex ());
		//MedicalEducation.transform.SetSiblingIndex (maskImage.transform.GetSiblingIndex ()+1);
		isHideMedicalEducation = !isHideMedicalEducation;
		maskImage.SetActive (isHideMedicalEducation);
		//改变图片
		SetButtonImageTexture(MedicalEducationUI.GetComponent<Image>(),medicalEducationDeafult,medicalEducationClick,isHideMedicalEducation);
		SetImageDefaultOfNoClick (MunicipalSupportUI.GetComponent<Image>(),municipalSupportDeafult,BusinessMatchingUI.GetComponent<Image>(),businessMatchingDeafult,backSceneUI.GetComponent<Image>(),backDeafult,isHideMedicalEducation);
		//改变层级
		if (isHideMedicalEducation) {
			SetLeveUp (MedicalEducation,MunicipalSupport,BusinessMatching);
		} 
		else 
		{
			SetLevelDown (MedicalEducation);
		}
		//SetHideAndDisplay (MunicipalSupport,BusinessMatching,MedicalEducation,isHideMedicalEducation,isHideMunicipalSupport,isHideBusinessMatching);
		isHideMunicipalSupport = false;
		isHideBusinessMatching = false;
	}
	/// <summary>
	/// Clicks the municipal support.
	/// 点击市政配套按钮,教育医疗隐藏或者显示之间切换,并恢复教育与商业的显示初始值
	/// </summary>
	public void ClickMunicipalSupport()
	{
		isHideMunicipalSupport = !isHideMunicipalSupport;
		maskImage.SetActive (isHideMunicipalSupport);
		//改变图片
		SetButtonImageTexture(MunicipalSupportUI.GetComponent<Image>(),municipalSupportDeafult,municipalSupportClick,isHideMunicipalSupport);
		SetImageDefaultOfNoClick (MedicalEducationUI.GetComponent<Image>(),medicalEducationDeafult,BusinessMatchingUI.GetComponent<Image>(),businessMatchingDeafult,backSceneUI.GetComponent<Image>(),backDeafult,isHideMunicipalSupport);
		//改变层级
		if (isHideMunicipalSupport) {
			SetLeveUp (MunicipalSupport,MedicalEducation,BusinessMatching);//)MedicalEducation,MunicipalSupport,BusinessMatching);
		} 
		else 
		{
			SetLevelDown (MunicipalSupport);
		}
//		SetButtonImageTexture (MunicipalSupportUI.GetComponent<Image>(),municipalSupportDeafult,municipalSupportClick,isHideMunicipalSupport);
//		SetImageDefaultOfNoClick (MedicalEducationUI.GetComponent<Image>(),medicalEducationDeafult,BusinessMatchingUI.GetComponent<Image>(),businessMatchingDeafult,backSceneUI.GetComponent<Image>(),backDeafult,isHideMunicipalSupport);
//		SetHideAndDisplay (MedicalEducation,BusinessMatching,MunicipalSupport,isHideMunicipalSupport,isHideMedicalEducation,isHideBusinessMatching);
		isHideMedicalEducation = false;
		isHideBusinessMatching = false;
	}
	/// <summary>
	/// Clicks the business matching.
	/// 点击商业配套按钮,教育医疗隐藏或者显示之间切换,并恢复市政与教育医疗的显示初始值
	/// </summary>
	public void ClickBusinessMatching()
	{
		isHideBusinessMatching = !isHideBusinessMatching;
		maskImage.SetActive (isHideBusinessMatching);
		//改变图片
		SetButtonImageTexture(BusinessMatchingUI.GetComponent<Image>(),businessMatchingDeafult,businessMatchingClick,isHideBusinessMatching);
		SetImageDefaultOfNoClick (MedicalEducationUI.GetComponent<Image>(),medicalEducationDeafult,MunicipalSupportUI.GetComponent<Image>(),municipalSupportDeafult,backSceneUI.GetComponent<Image>(),backDeafult,isHideBusinessMatching);
		//改变层级
		if (isHideBusinessMatching) {
			SetLeveUp (BusinessMatching,MunicipalSupport,MedicalEducation);
		} 
		else 
		{
			SetLevelDown (BusinessMatching);
		}
//		SetButtonImageTexture (BusinessMatchingUI.GetComponent<Image>(),businessMatchingDeafult,businessMatchingClick,isHideBusinessMatching);
//		SetImageDefaultOfNoClick (MedicalEducationUI.GetComponent<Image>(),medicalEducationDeafult,MunicipalSupportUI.GetComponent<Image>(),municipalSupportDeafult,backSceneUI.GetComponent<Image>(),backDeafult,isHideBusinessMatching);
//		SetHideAndDisplay (MedicalEducation,MunicipalSupport,BusinessMatching,isHideBusinessMatching,isHideMedicalEducation,isHideMunicipalSupport);
		isHideMunicipalSupport = false;
		isHideMedicalEducation = false;
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
	private void SetHideAndDisplay(GameObject display1,GameObject display2,GameObject hide,bool isHide,bool restore1,bool restore2)
	{
		if (isHide == true) 
		{
			display1.SetActive (false);
			display2.SetActive (false);
			hide.SetActive (true);
		} 
		else 
		{
			SetHideAll (display1,display2,hide);
		}
		restore1 = false;
		Debug.Log (restore1);
		restore2 = false;
	}
	/// <summary>
	/// Sets the button image texture.
	/// </summary>
	/// <param name="image">Image.</param>
	/// <param name="defaultTexture">Default texture.</param>
	/// <param name="clickTexture">Click texture.</param>
	/// <param name="isClick">If set to <c>true</c> is click.</param>
	private void SetButtonImageTexture(Image image,Sprite defaultTexture,Sprite clickTexture,bool isClick)
	{
		if (isClick == true) 
		{
			image.sprite = clickTexture;
		}
		else
		{
			image.sprite = defaultTexture;
		}
	}
	/// <summary>
	/// Sets the image default of no click.
	/// </summary>
	/// <param name="image1">Image1.</param>
	/// <param name="texture1">Texture1.</param>
	/// <param name="image2">Image2.</param>
	/// <param name="texture2">Texture2.</param>
	/// <param name="image3">Image3.</param>
	/// <param name="texture3">Texture3.</param>
	/// <param name="isDefault">If set to <c>true</c> is default.</param>
	private void SetImageDefaultOfNoClick(Image image1,Sprite texture1,Image image2,Sprite texture2,Image image3,Sprite texture3,bool isDefault)
	{
		if (isDefault == true) 
		{
			image1.sprite = texture1;
			image2.sprite = texture2;
			image3.sprite = texture3;
			//Debug.Log ("chushi");
		}
	}
	/// <summary>
	/// Sets the hide all.
	/// </summary>
	private void SetHideAll(GameObject hide1,GameObject hide2,GameObject hide3)
	{
		hide1.SetActive (true);
		hide2.SetActive (true);
		hide3.SetActive (true);
	}
	private void SetLeveUp(GameObject levelUp,GameObject levelDown1,GameObject levelDown2)
	{
		levelUp.transform.SetSiblingIndex (maskImage.transform.GetSiblingIndex ()+1);
		levelDown1.transform.SetSiblingIndex (maskImage.transform.GetSiblingIndex ()-1);
		levelDown2.transform.SetSiblingIndex (maskImage.transform.GetSiblingIndex ()-1);
	}
	private void SetLevelDown(GameObject levelDown)
	{
		levelDown.transform.SetSiblingIndex (maskImage.transform.GetSiblingIndex ()-1);
	}
}
                                                  