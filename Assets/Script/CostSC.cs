using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CostSC : MonoBehaviour {
	public Text costtext;
	public int cost=0;
	static public float limit;
	private float timer;
	// Use this for initialization
	void Start () {
		limit = 0.5f;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		costtext.text = "Cost:" + cost.ToString ();
		timer += Time.deltaTime;
		if(limit < timer){
			if(cost < 100){
				cost ++;
			}
			timer = 0f;
		}
	}
}
