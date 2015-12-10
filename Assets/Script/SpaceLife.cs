using UnityEngine;
using System.Collections;

public class SpaceLife : MonoBehaviour {
	public Animator animator;
	public string BoolName;
	[SerializeField]
	public float Life = 10;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Life <= 0.0){
			StartCoroutine(del(1.4f));
		}
	}
	IEnumerator del(float wait){
		animator.SetBool(BoolName,true);
		yield return new WaitForSeconds(wait);//"Coroutine"Toyara Ga Hituyou Rashii Nanisore
		//System.Threading.Thread.Sleep(1000);//Syori Ga Zenbu Tomaru. Kouiu Syori No Tameni Coroutine Ha Arurashii
		Destroy(this.gameObject);
		Debug.Log("Break out!");
		//return null;
	}
}
//This developed by Hyryu Hachino.