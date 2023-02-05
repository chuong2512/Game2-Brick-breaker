using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementPanelSortingLayer : MonoBehaviour {


	public string SortingLayerName = "UI";
	public int SortingOrder = 0;

	void Awake ()
	{
		gameObject.GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
	}
}
