using UnityEngine;
using System.Collections;

/*---------------------------------------------------------------- 
* 版权所有：北京阿尔法视觉科技有限公司  
 
* 文件名：smallMapScript
* 文件功能描述： 点击小地图 摄像机到对应的场景位置
* author：hxh
* 时间：2017/10/25
* 创建标识：C 

* 修改标识： 
 
* 修改描述：
----------------------------------------------------------------*/
public class SmallMapClick : MonoBehaviour 
{
	[Header("地形")]
	public GameObject terrainMode;//地形
	[Header("角色")]
	public GameObject player;//角色
	[Header("小地图")]
	public GameObject mapBG;//小地图
	[Header("小图标")]
	public GameObject smallPicture;//小图标
	//public GameObject smallMap;//小地图图标
	private Vector3 smallPicturePosition;//小图标的位置
	private Vector3 smallPictureRotation;//小图标的旋转
	//山地的大小
	private float Twidth;//地形宽
	private float Theight;//地形长（Z方向）
	//地图大小
	private float mapwidth;//小地图宽
	private float mapheight;//小地图高
	//缩放比例
	private float widthScal;//X方向的缩放
	private float heightScal;//Y方向的缩放
	private Vector3 smallMapStartPoint;//小地图（0.0）点
	// Use this for initialization
	void Start () 
	{
		Twidth=terrainMode.GetComponent<MeshFilter>().mesh.bounds.size.x;;//模型的宽
		Theight =terrainMode.GetComponent<MeshFilter>().mesh.bounds.size.z;//模型的长
		mapwidth = mapBG.GetComponent<RectTransform>().rect.width;//小地图的宽
		//Debug.Log (mapwidth);
		mapheight = mapBG.GetComponent<RectTransform>().rect.height;//小地图的高
		widthScal =(mapwidth) /Twidth;//宽度缩放
		heightScal =(mapheight) /Theight;//高度缩放
		//Debug.Log (widthScal);
		//Debug.Log (heightScal);
		smallPicturePosition = new Vector3(0,0,0);
		smallPictureRotation = new Vector3 (0,0,0);
		smallMapStartPoint = new Vector3 (Screen.width - mapwidth,Screen.height - mapheight,0);//小地图左下角为0.0点
		//Debug.Log (smallMapStartPoint);
	}
	
//	// Update is called once per frame
	void Update () 
	{
		setSmallPicturePositionAndRotation ();
	}
	/// <summary>
	/// Sets the player position.
	/// </summary>
	public void setPlayerPosition()
	{
		Vector3 smallMapPosition = Input.mousePosition - smallMapStartPoint;
		//小地图宽除以缩放比即在地形中的位置,大地形的0.0在模型中心 所以要 -宽度的二分之一 将0.0移动到左下角
		Vector3 playerPosition = new Vector3 ((smallMapPosition.x/widthScal)-(Twidth/2),player.transform.position.y,(smallMapPosition.y/heightScal)-(Theight/2));
		//Debug.Log (playerPosition);
		player.transform.position = playerPosition;
	}
	/// <summary>
	/// Sets the small picture position and rotation.
	/// </summary>
	private void setSmallPicturePositionAndRotation()
	{
		smallPicturePosition.x = (player.transform.position.x + (Twidth/2)) * widthScal+smallMapStartPoint.x;
		smallPicturePosition.y = (player.transform.position.z + (Theight/2)) * heightScal+smallMapStartPoint.y;
		smallPicture.transform.position = smallPicturePosition;
		smallPictureRotation.z = -player.transform.eulerAngles.y;
		smallPicture.transform.eulerAngles = smallPictureRotation;
	}
}
