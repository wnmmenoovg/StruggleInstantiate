using UnityEngine;
using System.Collections;

public class ResizeText : MonoBehaviour {

	//Variables start
	//float originalWidth = 1920.0f;
	//float originalHeight =1080.0f;
	//private Vector3 scale;
	public GUIText Score;
	//Variables end
	
	GameController game;
	GameObject main;

	void Start () {

		main = GameObject.FindGameObjectWithTag("PlayerStats");
		game = main.GetComponent<GameController>();
		Score.text = game.getScore().ToString();
	}


	void OnGUI(){
		/*scale.x = Screen.width/originalWidth; 
		scale.y = Screen.height/originalHeight; 
		scale.z = 1;
		Matrix4x4 svmat = GUI.matrix;

		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
	
		Score.transform.position = new Vector2(0.9f,0.94f);
*/
		Score.text = game.getScore().ToString();
		//GUI.matrix = svmat; 

	}
}
