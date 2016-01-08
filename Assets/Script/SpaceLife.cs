using UnityEngine;
using System.Collections;

public class SpaceLife : MonoBehaviour {
	public Animator animator;
	public string BoolName;
	[SerializeField]
	public float Life;
	// Use this for initialization
	void Start () {
		Life = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (Life <= 0.0){
			StartCoroutine(del(1.4f));
		}
	}
	IEnumerator del(float wait){
//		animator.SetBool(BoolName,true);
		yield return new WaitForSeconds(wait);//"Coroutine"Toyara Ga Hituyou Rashii Nanisore
		//System.Threading.Thread.Sleep(1000);//Syori Ga Zenbu Tomaru. Kouiu Syori No Tameni Coroutine Ha Arurashii
		Destroy(this.gameObject);

		if(this.gameObject.name == "P_kyoten_A"){
			Destroy (GameObject.Find("ui_P_kyoten_A"));
		}
		if(this.gameObject.name == "P_kyoten_B"){
			Destroy (GameObject.Find("ui_P_kyoten_B"));
		}
		if(this.gameObject.name == "E_kyoten_A"){
			gameManager.isClear = true;
			Destroy (GameObject.Find("ui_E_kyoten_A"));
		}
		if(this.gameObject.name == "E_kyoten_B"){
			Destroy (GameObject.Find("ui_E_kyoten_B"));
		}
	}
}
//This developed by Hyryu Hachino.