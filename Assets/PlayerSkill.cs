using UnityEngine;
using System.Collections;

public class PlayerSkill : MonoBehaviour {
	public GameObject normalhitpar;
	public GameObject skillPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Skill01(){
		Instantiate(normalhitpar,skillPoint.transform.position,normalhitpar.transform.rotation);
	}
}
