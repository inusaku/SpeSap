using UnityEngine;
using System.Collections;

public class Attack_EO : MonoBehaviour {
    Collider[] attackAreaColliders;
    public BoxCollider BC;
    EnemyO enemyO;
    public GameObject AttackArea;

    // Use this for initialization
    void Start () {
        enemyO = GetComponent<EnemyO>();
        BC = AttackArea.GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
