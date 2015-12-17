using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour {
	//skill01
	public GameObject Rangehitpar;
	public GameObject skillPoint;
	private float skillrecast01;
	public float Maxskillrecast01;
	public GameObject skillbutton;
	//slill02
	public GameObject FRangehitpar;
	public GameObject FskillPoint;
	private float skillrecast02;
	public float Maxskillrecast02;
	public GameObject Frontskillbutton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		skillrecast01-=1*Time.deltaTime;
		skillrecast02-=1*Time.deltaTime;
		if (skillrecast01 < 0) {
			skillbutton.GetComponent<Button>().enabled=true;
		}
		if (skillrecast02 < 0) {
			Frontskillbutton.GetComponent<Button>().enabled=true;
		}
	
	}
	public void Skill01(){
		Instantiate(Rangehitpar,skillPoint.transform.position,Rangehitpar.transform.rotation);
		skillrecast01 = Maxskillrecast01;
		skillbutton.GetComponent<Button>().enabled=false;
	}
	public void Skill02(){
		Instantiate(FRangehitpar,FskillPoint.transform.position,FRangehitpar.transform.rotation);
		skillrecast02 = Maxskillrecast02;
		Frontskillbutton.GetComponent<Button>().enabled=false;
	}
}
