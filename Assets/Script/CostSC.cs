using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CostSC : MonoBehaviour {
	public Text costtext;
	public int cost=0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		costtext.text = "Cost:" + cost.ToString ();
	}
}
