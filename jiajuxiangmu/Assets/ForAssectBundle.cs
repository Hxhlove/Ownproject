using UnityEngine;
using System.Collections;
using UnityEditor;

public class ForAssectBundle : MonoBehaviour 
{
	[MenuItem("Assets/AssectBundle/Build_IOS")]
	public static void CreateAssetBunldesALL ()
	{

		Caching.CleanCache ();

		string Path = Application.dataPath + "/StreamingAssets/ALL.assetbundle";

		Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);

		foreach (Object obj in SelectedAsset) 
		{
			Debug.Log ("Create AssetBunldes name :" + obj);
		}

		//这里注意第二个参数就行
		if (BuildPipeline.BuildAssetBundle (null, SelectedAsset, Path, BuildAssetBundleOptions.CollectDependencies,BuildTarget.iOS)) 
		{
			AssetDatabase.Refresh ();
		} 
		else {

		}
	}
}
