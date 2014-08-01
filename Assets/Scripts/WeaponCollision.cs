using UnityEngine;
using System.Collections;

public class WeaponCollision : MonoBehaviour {

	//Gameobjects start
	GameObject player;
	GameObject main;
	//Gameobject ends

	//Classes Start
	PlayerController ply;
	GameController gamecontroller;
	//Classes Ends

	//Variables Start
	Vector3 weaponpoint;

	float groundHeight = 3.5f;
	float weaponMaxHeight = 0.08f;
	//Variable Ends


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		ply = player.GetComponent<PlayerController>();
		main = GameObject.FindGameObjectWithTag("PlayerStats");
		gamecontroller = main.GetComponent<GameController>();
	}

	void Update(){
		if(transform.position.y > weaponMaxHeight)
		{
			weaponpoint = player.transform.position;
			transform.position = new Vector3(weaponpoint.x,weaponpoint.y-groundHeight,weaponpoint.z);
			ply.fired = false;
		}
		
	}
		

	/*void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("SmallBall")) {	
			weaponpoint = player.transform.position;
			Destroy(col.gameObject);
			transform.position = new Vector3(weaponpoint.x,weaponpoint.y-groundHeight,weaponpoint.z);		
			ply.fired = false;
			//gamecontroller.addScore();
		}


		
	}*/
}
