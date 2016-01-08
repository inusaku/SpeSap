using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ui_HPSystem: MonoBehaviour {
	public Camera camera;
	public Transform target;
	public GameObject targetOb;
	private int enemyCount;
	void Start () {
		if (this.gameObject.name == "ui_playerHP" || this.gameObject.name == "ui_enemyHP") {
		} else {
			this.GetComponent<Slider> ().value = 1f;
		}
	}
	
	void Update () {
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
		if(this.gameObject.name == "ui_playerHP"){
			target = GameObject.Find ("Player").transform;
			targetOb = GameObject.Find ("Player");
			var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(target.position);
			var localPos = Vector2.zero;
			this.transform.position = new Vector3(screenPos.x, screenPos.y + 20f, screenPos.z);
			if(GameObject.Find ("Player").GetComponent<PlayerStatus> ().HP < this.GetComponent<Slider>().value){
				this.GetComponent<Slider>().value -= 10f * Time.deltaTime;
				GameObject.Find("ui_playerHP_under").GetComponent<Slider>().value -= 10f * Time.deltaTime;
			}
		}
		if(this.gameObject.name == "ui_enemyHP" && enemyCount >= 1){
			target = GameObject.Find ("Enemy_ED(Clone)").transform;
			targetOb = GameObject.Find ("Enemy_ED(Clone)");
			var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(target.position);
			var localPos = Vector2.zero;
			this.transform.position = new Vector3(screenPos.x, screenPos.y + 12.5f, screenPos.z);
			if(GameObject.Find ("Enemy_ED(Clone)").GetComponent<Enemy> ().life < this.GetComponent<Slider>().value * 2f){
				this.GetComponent<Slider>().value -= 10f * Time.deltaTime;
			}
		}
		if(this.gameObject.name == "ui_P_kyoten_A"){
			target = GameObject.Find ("P_kyoten_A").transform;
			targetOb = GameObject.Find ("P_kyoten_A");
			var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(target.position);
			var localPos = Vector2.zero;
			this.transform.position = new Vector3(screenPos.x, screenPos.y + 50f, screenPos.z);
			if(GameObject.Find ("P_kyoten_A").GetComponent<SpaceLife> ().Life / 100 < this.GetComponent<Slider>().value){
				this.GetComponent<Slider>().value -= 0.5f * Time.deltaTime;
			}
		}
		if(this.gameObject.name == "ui_P_kyoten_B"){
			target = GameObject.Find ("P_kyoten_B").transform;
			targetOb = GameObject.Find ("P_kyoten_B");
			var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(target.position);
			var localPos = Vector2.zero;
			this.transform.position = new Vector3(screenPos.x, screenPos.y + 50f, screenPos.z);
			if(GameObject.Find ("P_kyoten_B").GetComponent<SpaceLife> ().Life / 100 < this.GetComponent<Slider>().value){
				this.GetComponent<Slider>().value -= 0.5f * Time.deltaTime;
			}
		}
		if(this.gameObject.name == "ui_E_kyoten_A"){
			target = GameObject.Find ("E_kyoten_A").transform;
			targetOb = GameObject.Find ("E_kyoten_A");
			var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(target.position);
			var localPos = Vector2.zero;
			this.transform.position = new Vector3(screenPos.x, screenPos.y + 50f, screenPos.z);
			if(GameObject.Find ("E_kyoten_A").GetComponent<SpaceLife> ().Life / 100 < this.GetComponent<Slider>().value){
				this.GetComponent<Slider>().value -= 0.5f * Time.deltaTime;
			}
		}
		if(this.gameObject.name == "ui_E_kyoten_B"){
			target = GameObject.Find ("E_kyoten_B").transform;
			targetOb = GameObject.Find ("E_kyoten_B");
			var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(target.position);
			var localPos = Vector2.zero;
			this.transform.position = new Vector3(screenPos.x, screenPos.y + 50f, screenPos.z);
			if(GameObject.Find ("E_kyoten_B").GetComponent<SpaceLife> ().Life / 100 < this.GetComponent<Slider>().value){
				this.GetComponent<Slider>().value -=0.5f * Time.deltaTime;
			}
		}
		if(target == null){
			this.GetComponent<Slider> ().value = 0f;
			this.transform.position = new Vector3(10000f,0,0); 
		}
	}
}