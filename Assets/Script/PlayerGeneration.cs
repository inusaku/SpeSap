using UnityEngine;
using System.Collections;

public class PlayerGeneration : MonoBehaviour {
	public GameObject player01;
	public GameObject player02;
	public GameObject menu;
	public GameObject cost;
	private float x;
	private float y;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		x = UnityEngine.Random.Range (transform.position.x - 5, transform.position.x + 5);
		y =UnityEngine.Random.Range (transform.position.z - 5, transform.position.z + 5);

	}
	public void Player01(){
		if (cost.GetComponent<CostSC> ().cost>=player01.gameObject.GetComponent<PlayerStatus>().cost) {
			Vector3 pos = new Vector3 (x, transform.position.y, y);

			Instantiate (player01, pos, player01.transform.rotation);
			menu.SetActive (false);
			cost.GetComponent<CostSC> ().cost -= player01.gameObject.GetComponent<PlayerStatus>().cost;
		}
	}
	public void Player02(){
		if (cost.GetComponent<CostSC> ().cost>=player02.gameObject.GetComponent<PlayerStatus>().cost) {
			Vector3 pos = new Vector3 (x, transform.position.y, y);
			
			Instantiate (player02, pos, player02.transform.rotation);
			menu.SetActive (false);
			cost.GetComponent<CostSC> ().cost -= player02.gameObject.GetComponent<PlayerStatus>().cost;
		}
	}
}
