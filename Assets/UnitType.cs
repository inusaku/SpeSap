using UnityEngine;
using System.Collections;

public class UnitType : MonoBehaviour {
	public enum enumType{
		Atk,
		DEF,
		SPEED,
	}
	public enumType TYPE;
	public string name;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (TYPE) {
		case enumType.Atk:
			name="ATK";
			break;
		case enumType.DEF:
			name="DEF";
			break;
		case enumType.SPEED:
			name="SPEED";
			break;
		}
	
	}
}
