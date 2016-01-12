using UnityEngine;
using System.Collections;

public class system : MonoBehaviour
{
	public int stageNum;
	public int stageID;
	
	public bool clear1;
	public bool clear2;
	public bool clear3;
	
	int clearNum;
	void Start()
	{
		stageNum = PlayerPrefs.GetInt("stageNum");
		clearNum = PlayerPrefs.GetInt("clearNum");
	}
	
	void Update()
	{
		DontDestroyOnLoad(this);
		PlayerPrefs.SetInt("stageNum", stageNum);
		PlayerPrefs.SetInt("clearNum", clearNum);
		PlayerPrefs.Save();
	}
}