using UnityEngine;
using System.Collections;

public class Attack_E : MonoBehaviour {

    Collider[] attackAreaColliders;
    public BoxCollider BC;
    Enemy enemy;
    public GameObject AttackArea;
	// Use this for initialization
	void Start () {
        enemy = GetComponent<Enemy>();
        BC = AttackArea.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
