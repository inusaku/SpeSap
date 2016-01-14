using UnityEngine;
using System.Collections;

public class PlayerGeneration : MonoBehaviour {
	public GameObject player01;
	public GameObject player02;
	public GameObject player03;
	public GameObject PlayerHP;
	public GameObject menu;
	public GameObject cost;
	public Vector3 kyotenpos;
	private float x;
	private float y;
	public AudioClip select;
	public AudioClip up;
	// Use this for initialization
	void Start () {
//		cost = GameObject.Find ("cost_text");
//		menu = GameObject.Find ("PlayerMenu");
	}
	
	// Update is called once per frame
	void Update () {
		x = UnityEngine.Random.Range (kyotenpos.x -5, kyotenpos.x+5);
		y =UnityEngine.Random.Range (kyotenpos.z - 5, kyotenpos.z+5);

	}
	public void Player01(){
		if (cost.GetComponent<CostSC> ().cost>=player01.gameObject.GetComponent<PlayerStatus>().cost) {
			Vector3 pos = new Vector3 (x, kyotenpos.y, y);
			Instantiate (player01, pos, player01.transform.rotation);
			Instantiate (PlayerHP, new Vector3(10000,0,0), Quaternion.identity);
			this.GetComponent<AudioSource> ().PlayOneShot (up);

			cost.GetComponent<CostSC> ().cost -= player01.gameObject.GetComponent<PlayerStatus>().cost;
		}

	}
	public void Player02(){
		if (cost.GetComponent<CostSC> ().cost>=player02.gameObject.GetComponent<PlayerStatus>().cost) {
			Vector3 pos = new Vector3 (x, kyotenpos.y, y);
			this.GetComponent<AudioSource> ().PlayOneShot (up);

			Instantiate (player02, pos, player02.transform.rotation);
			Instantiate (PlayerHP, new Vector3(10000,0,0), Quaternion.identity);

			cost.GetComponent<CostSC> ().cost -= player02.gameObject.GetComponent<PlayerStatus>().cost;
		}

	}
	public void Player03(){
		if (cost.GetComponent<CostSC> ().cost>=player03.gameObject.GetComponent<PlayerStatus>().cost) {
			Vector3 pos = new Vector3 (x, kyotenpos.y, y);
			this.GetComponent<AudioSource> ().PlayOneShot (up);
			
			Instantiate (player03, pos, player03.transform.rotation);
			Instantiate (PlayerHP, new Vector3(10000,0,0), Quaternion.identity);
			
			cost.GetComponent<CostSC> ().cost -= player03.gameObject.GetComponent<PlayerStatus>().cost;
		}
		
	}
	public void close()
	{
		this.GetComponent<AudioSource> ().PlayOneShot (select);
		menu.SetActive (false);
	}
}
