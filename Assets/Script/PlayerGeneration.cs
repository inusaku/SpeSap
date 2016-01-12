using UnityEngine;
using System.Collections;

public class PlayerGeneration : MonoBehaviour {
	public GameObject player01;
	public GameObject player02;
	public GameObject PlayerHP;
	public GameObject menu;
	public GameObject cost;
	private GameObject _child;
	public Vector3 kyotenpos;
	private float x;
	private float y;
	// Use this for initialization
	void Start () {
<<<<<<< HEAD

=======
//		cost = GameObject.Find ("cost_text");
//		menu = GameObject.Find ("PlayerMenu");
>>>>>>> origin/CHIBA
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
<<<<<<< HEAD
			Instantiate (PlayerHP);
			_child = player01.transform.FindChild ("par3").gameObject;
			_child.GetComponent<ParticleSystem>().startColor=Color.red;
=======
			Instantiate (PlayerHP, new Vector3(10000,0,0), Quaternion.identity);

>>>>>>> origin/CHIBA
			cost.GetComponent<CostSC> ().cost -= player01.gameObject.GetComponent<PlayerStatus>().cost;
		}

	}
	public void Player02(){
		if (cost.GetComponent<CostSC> ().cost>=player02.gameObject.GetComponent<PlayerStatus>().cost) {
			Vector3 pos = new Vector3 (x, kyotenpos.y, y);
			
			Instantiate (player02, pos, player02.transform.rotation);
<<<<<<< HEAD
			Instantiate (PlayerHP);
			_child = player02.transform.FindChild ("par3").gameObject;
			_child.GetComponent<ParticleSystem>().startColor=Color.cyan;
=======
			Instantiate (PlayerHP, new Vector3(10000,0,0), Quaternion.identity);

>>>>>>> origin/CHIBA
			cost.GetComponent<CostSC> ().cost -= player02.gameObject.GetComponent<PlayerStatus>().cost;
		}

	}
	public void close()
	{
		menu.SetActive (false);
	}
}
