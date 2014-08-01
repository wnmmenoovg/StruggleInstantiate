using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private float score = 0f;
	public static GameController Instance;
	
	// Update is called once per frame
	void Awake(){
		if(Instance)
			DestroyImmediate(gameObject);
		else{
			DontDestroyOnLoad (transform.gameObject);
			Instance = this;
		}
	}

	

	public void addScore(){
		score+=100.0f;
	}

	public float getScore(){
		return score;
	}
	public void  reset(){
		score = 0;
	}
}
