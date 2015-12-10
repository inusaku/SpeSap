using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {
	public float MAXHP=0;
	public float HP=0;
	public float Atk=0;
	private Slider playerSlider;
	float playerSliVal;
	// Use this for initialization
	void Start () {
		playerSlider = GameObject.Find("playerHP").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		HP=Mathf.Clamp (HP,0, MAXHP);
		playerSliVal = HP;
		playerSlider.value = playerSliVal;
	}
}
