using UnityEngine;
using System.Collections;

public class PlayerGeneration : MonoBehaviour {
	public GameObject player01;
	public GameObject player02;
	public GameObject menu;
	public GameObject cost;
	public Vector3 kyotenpos;
	private float x;
	private float y;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		x = UnityEngine.Random.Range (kyotenpos.x - 5, kyotenpos.x + 5);
		y = UnityEngine.Random.Range (kyotenpos.z - 5, kyotenpos.z + 5);

	}
	public void Player01(){
		if (cost.GetComponent<CostSC> ().cost>=player01.gameObject.GetComponent<PlayerStatus>().cost) {
			if(MoveCursor.myname == "P_kyoten_A"){
				pos = new Vector3 (GameObject.Find ("P_kyoten_A").transform.position.x, GameObject.Find ("P_kyoten_A").transform.position.y, GameObject.Find ("P_kyoten_A").transform.position.z - 7.5f);
				Instantiate (player01, pos, player01.transform.rotation);
				menu.SetActive (false);
				cost.GetComponent<CostSC> ().cost -= player01.gameObject.GetComponent<PlayerStatus>().cost;
			}
			if(MoveCursor.myname == "kyoten_C"){
				pos = new Vector3 (GameObject.Find ("kyoten_C").transform.position.x, GameObject.Find ("kyoten_C").transform.position.y, GameObject.Find ("kyoten_C").transform.position.z - 7.5f);
				Instantiate (player01, pos, player01.transform.rotation);
				menu.SetActive (false);
				cost.GetComponent<CostSC> ().cost -= player01.gameObject.GetComponent<PlayerStatus>().cost;
			}
			if(MoveCursor.myname == "kyoten_B"){
				pos = new Vector3 (GameObject.Find ("kyoten_B").transform.position.x, GameObject.Find ("kyoten_B").transform.position.y, GameObject.Find ("kyoten_B").transform.position.z - 7.5f);
				Instantiate (player01, pos, player01.transform.rotation);
				menu.SetActive (false);
				cost.GetComponent<CostSC> ().cost -= player01.gameObject.GetComponent<PlayerStatus>().cost;
			}
			if(MoveCursor.myname == "kyoten_A"){
				pos = new Vector3 (GameObject.Find ("kyoten_A").transform.position.x, GameObject.Find ("kyoten_A").transform.position.y, GameObject.Find ("kyoten_A").transform.position.z - 7.5f);
				Instantiate (player01, pos, player01.transform.rotation);
				menu.SetActive (false);
				cost.GetComponent<CostSC> ().cost -= player01.gameObject.GetComponent<PlayerStatus>().cost;
			}
		}
	}
	public void Player02(){
		if (cost.GetComponent<CostSC> ().cost>=player02.gameObject.GetComponent<PlayerStatus>().cost) {
			Vector3 pos = new Vector3 (-12f, -0.3f, 40.5f);			
			Instantiate (player02, pos, player02.transform.rotation);
			menu.SetActive (false);
			cost.GetComponent<CostSC> ().cost -= player02.gameObject.GetComponent<PlayerStatus>().cost;
		}
	}
}
