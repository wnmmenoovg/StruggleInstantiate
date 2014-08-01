using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Classes Start!!
	Animator anim;
	PlayerEntity enty;
	//Classes Ends

	//Values Start
	bool facingRight = true;
	public float maxSpeed = 1f;
	Vector3 weaponpoint;
	public bool fired = false;
	float weaponSpawnHeight = 2.9f;
	float weaponSpeed = 0.05f;
	float healthCount;
	//Values End
	
	//Game Objects Starts!!
	GameObject player;
	public GameObject weapon;
	GameObject playerStat;
	GameObject[] health;
	//Game Objects Ends

	void Start () {
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		weapon = GameObject.FindGameObjectWithTag("Weapon");
		playerStat = GameObject.FindGameObjectWithTag("PlayerStats");

		health = GameObject.FindGameObjectsWithTag("Health");
		enty = playerStat.GetComponent<PlayerEntity>();
		healthCount = enty.getHealth();

		//Draw the "Health" sprites
		for(int i = 0 ; i <= healthCount; i++)
		{
			health[i].GetComponent<SpriteRenderer>().enabled = true;
		}

	}
	
	// Update is called once per frame


	void FixedUpdate () {

		float move = Input.GetAxis("Horizontal");	//Player Direction
		anim.SetFloat("Speed", Mathf.Abs(move));	//Trigger the "Run" animation
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y); //Player speed

		//Flip the Animation && Player
		if(move > 0 && !facingRight)
			flip ();

		else if(move < 0 && facingRight)
			flip ();
	

		if(Input.GetKeyDown(KeyCode.Space) && !fired) //Fire the weapon if it is not fired
		{

			weaponpoint = player.transform.position;
			//WeaponSpawnHeigt determine the start point of the weapon
			weapon.transform.position = new Vector3(weaponpoint.x,weaponpoint.y-weaponSpawnHeight,weaponpoint.z);
			fired = true;
		}
	
		//Fire the weapon from with "weaponspeed"
		if(fired)
			weapon.transform.position = new Vector3(weapon.transform.position.x,weapon.transform.position.y+weaponSpeed,weaponpoint.z);


	}

	//Turn the Player
	void flip(){
		
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		
	}





}
