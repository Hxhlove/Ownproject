using UnityEngine;
using System.Collections;

public class SmallMapClick : MonoBehaviour 
{
	public GameObject terrainMode;//地形
	public GameObject player;//角色
	public GameObject MapBG;//小地图
	//public GameObject smallMap;//小地图图标

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
		mapwidth = MapBG.GetComponent<RectTransform>().rect.width;//小地图的宽
		//Debug.Log (mapwidth);
		mapheight = MapBG.GetComponent<RectTransform>().rect.height;//小地图的高
		widthScal =(mapwidth) /Twidth;//宽度缩放
		heightScal =(mapheight) /Theight;//高度缩放
		//Debug.Log (widthScal);
		//Debug.Log (heightScal);
		smallMapStartPoint = new Vector3 (Screen.width - mapwidth,Screen.height - mapheight,0);//小地图左下角为0.0点
		//Debug.Log (smallMapStartPoint);
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if (Input.GetMouseButtonDown(0))
//		{
//			Debug.Log (Input.mousePosition - smallMapStartPoint);
//		}
	}
	public void setPlayerPosition()
	{
//		if (Input.GetMouseButtonDown(0))
//		{
			//Debug.Log (Input.mousePosition - smallMapStartPoint);
		Vector3 smallMapPosition = Input.mousePosition - smallMapStartPoint;
		//小地图宽除以缩放比即在地形中的位置,大地形的0.0在模型中心 所以要 -宽度的二分之一 将0.0移动到左下角
		Vector3 playerPosition = new Vector3 ((smallMapPosition.x/widthScal)-(Twidth/2),player.transform.position.y,(smallMapPosition.y/heightScal)-(Theight/2));
		//Debug.Log (playerPosition);
		player.transform.position = playerPosition;
		//}
	}
}
