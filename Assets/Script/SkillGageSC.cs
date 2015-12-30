using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SkillGageSC : MonoBehaviour {
	public Image gage; 
	public float SkillPoint;
	public float MaxPoint=100;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		SkillPoint = Mathf.Clamp (SkillPoint,0,MaxPoint);
		gage.fillAmount=SkillPoint/MaxPoint ;
	}
}
