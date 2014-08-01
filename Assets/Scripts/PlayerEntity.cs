using UnityEngine;
using System.Collections;

public class PlayerEntity : MonoBehaviour {
	

	//Variables Start
	public int healthCount = 2;
	public static PlayerEntity Instance;
	//Variables Ends


	void Awake(){

		//Keep the health value for the next round until player's health is finished
		if(Instance)
		{

			DestroyImmediate(gameObject);

		}
		else{

			DontDestroyOnLoad (transform.gameObject);
			Instance = this;
		}

	}

	public void minHealth()
	{
		healthCount--; 
	}

	public void reset()
	{
		healthCount = 2;
	}

	public int getHealth()
	{
		return healthCount;
	}
}
