using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {
	public float MAXHP=0;
	public float HP=0;
	public float Atk=0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		HP=Mathf.Clamp (HP,0, MAXHP);
	}
}
