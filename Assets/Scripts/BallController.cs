using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {


	//Game Objects Starts!!
	GameObject weapon;
	GameObject player;
	GameObject[] spawnBall;
	GameObject ball;
	GameObject playerStats;
	GameObject smallball;
	GameObject smallball2;
	//Game Objects Ends

	//Classes Starts!!
	PlayerEntity stats;
	PlayerController ply;
	GameController scoreController;
	//Classes Ends

	//Boundries Starts !!
	Vector3 weaponPoint;	//Weapon spawn position
	Vector3 spawnpoint;		//Small Balls spawn position			
	float ballForce = 0.1f;
	float groundHeight = 3.5f; 
	float maxSpeed = 1.5f;
	float ballDirection = 1.0f;
	float maxHeight = 10.0f;

	//Boundries Ends

	//Initilization
	void Start () {
		ball = GameObject.FindGameObjectWithTag("Ball");
		spawnBall = GameObject.FindGameObjectsWithTag("SmallBall");
		player = GameObject.FindGameObjectWithTag("Player");
		ply = player.GetComponent<PlayerController>();
		playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
		stats = playerStats.GetComponent<PlayerEntity>();
		scoreController = playerStats.GetComponent<GameController>();

		//Determine the speed of the ball
		if(gameObject.tag.Equals("Ball"))
			rigidbody2D.velocity = new Vector2(1.5f*ballDirection,rigidbody2D.velocity.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log(this.rigidbody2D.velocity);
		//Ball Movement
		//if(Mathf.Abs(this.rigidbody2D.velocity.x) < maxSpeed)	
		//	rigidbody2D.AddForce(new Vector2(ballForce,0));
	}

	void OnCollisionEnter2D(Collision2D collision) {
		//Debug.Log (collision.gameObject.tag);

		//This determines max height of the ball can reach
		//maxHeight is the value to determine the max height after the bounce
		rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity,maxHeight);

		//Ball collide with Wall
		if(collision.gameObject.tag.Equals("Wall")) {
			//Change Ball Direction
			ballForce *=-1;
	   	}

		//Ball collide with player
		if(collision.gameObject.tag.Equals("Player")) {

			if(stats.getHealth() >= -1)
			{
				//Player losses health 
				stats.minHealth();
				Application.LoadLevel (Application.loadedLevel);
			}

			if(stats.getHealth() < -1)
			{
				//Player losses the game 
				stats.reset();
				scoreController.reset();
				Application.LoadLevel (Application.loadedLevel);
			}

		}


			


	}

	void OnTriggerEnter2D(Collider2D col){


		//Ball Collide with Weapon
		if(col.gameObject.tag.Equals("Weapon")) {

			if(gameObject.tag == "Ball" || gameObject.tag == "SmallBall")
			{
				//ball = GameObject.FindGameObjectWithTag("Ball");
				spawnpoint = this.transform.position;	//Spawnpoint of the new balls 

				/*ball.transform.position = new Vector3(0,0,11); 
				Destroy(ball.GetComponent<BallController>());
				Destroy(ball.GetComponent<CircleCollider2D>());
				Destroy(ball.GetComponent<Rigidbody2D>());*/  //Another way to destoy the Ball 
				Destroy(gameObject);
			

				scoreController.addScore();
				weaponPoint = player.transform.position;
				ply.weapon.transform.position = new Vector3(weaponPoint.x,weaponPoint.y-groundHeight,weaponPoint.z);
				ply.fired = false;


				Vector2 scaleRecent = this.transform.localScale;
				smallball = (GameObject)Instantiate(Resources.Load("BallPrefab"));
				smallball.transform.position = new Vector2(spawnpoint.x+0.1f*ballDirection,spawnpoint.y);
				smallball.rigidbody2D.AddForce(new Vector2(50*ballDirection,200));
				smallball.rigidbody2D.velocity = new Vector2(0.1f*ballDirection,0);
				smallball.transform.localScale = scaleRecent/2;
				smallball.tag = "SmallBall";
				ballDirection *= -1;
				smallball2 = (GameObject)Instantiate(Resources.Load("BallPrefab"));
				smallball2.transform.position = new Vector2(spawnpoint.x+0.1f*ballDirection,spawnpoint.y);
				smallball2.rigidbody2D.AddForce(new Vector2(50*ballDirection,200));
				smallball2.rigidbody2D.velocity = new Vector2(0.1f*ballDirection,0);
				smallball2.transform.localScale = new Vector2(0.5f,0.5f);
				smallball2.transform.localScale = scaleRecent/2;
				smallball2.tag = "SmallBall";


				//Spawning the new Balls
				/*
				for(int i = 0;i < spawnBall.Length;i++)
				{

					ballDirection *= -1;
					spawnBall[i].transform.position = new Vector2(spawnpoint.x+0.1f*ballDirection,spawnpoint.y);
					spawnBall[i].GetComponent<Rigidbody2D>().isKinematic = false;
					//spawnBall[i].GetComponent<BallController>().ballForce *= ballDirection ;

					//First Spawn Force for gaining height
					spawnBall[i].rigidbody2D.AddForce(new Vector2(50*ballDirection,200));
					//Determine the speed of the small balls
					spawnBall[i].rigidbody2D.velocity = new Vector2(0.1f*ballDirection,0);

				}*/

			}
		
		}


	}
}
