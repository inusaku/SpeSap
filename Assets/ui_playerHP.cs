using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ui_playerHP: MonoBehaviour {
	public Camera camera;
	public Transform target;
	Vector2 viewPos;
	RectTransform myRectTrans;
	RectTransform parentRectTrans;
	
	void Awake(){
		myRectTrans = GetComponent<RectTransform>();
		parentRectTrans = (RectTransform)myRectTrans.parent;
	}
	
	void Start () {
		viewPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.Find ("Player").transform;
		var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(new Vector3(target.position.x -3, target.position.y, target.position.z));
		var localPos = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTrans, screenPos, GameObject.Find("Main Camera").GetComponent<Camera>(), out localPos);
		myRectTrans.localPosition = localPos;
	}
}