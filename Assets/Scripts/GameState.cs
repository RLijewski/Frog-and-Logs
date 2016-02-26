using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	private bool gameStarted = false;

	[SerializeField]
	private Text gameStateText;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private BirdMovement birdMovement;

	[SerializeField]
	private FollowCamera followCamera;

	private float restartDelay = 3f;
	private float restartTimer;
	private PlayerMovement playerMovement;
	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;

		playerMovement = player.GetComponent<PlayerMovement> ();
		playerHealth = player.GetComponent<PlayerHealth> ();

		// prevent the player from moving at the start of the game
		playerMovement.enabled = false;

		// prevent the bird from moving at the start of the game
		birdMovement.enabled = false;

		// prevent the follow camera from moving into its game position
		followCamera.enabled = false;

	}	
	
	// Update is called once per frame
	void Update () {

		// if the game is not started and the player presses the space bar...
		if (gameStarted == false && Input.GetKeyUp(KeyCode.Space)) {

			// ...start the game
			StartGame();
		}

		// if the player is no longer alive...
		if (playerHealth.alive == false) {

			// ... end the game...
			EndGame();

			// ...increment a timer to count up to restarting...
			restartTimer = restartTimer + Time.deltaTime;

			// ...and if it reaches the restart delay...
			if (restartTimer >= restartDelay) {

				// ...then reload the currently loaded level...
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	private void StartGame() {

		// set the game state
		gameStarted = true;

		// removing the start text
		gameStateText.color = Color.clear;

		// allow the player the move
		playerMovement.enabled = true;

		// allow the bird to move
		birdMovement.enabled = true;

		// allow the camera to move
		followCamera.enabled = true;
		
	}

	private void EndGame() {
	
		// set the game state
		gameStarted = false;

		// show the game over text
		gameStateText.color = Color.white;
		gameStateText.text = "Game Over";

		// remove the player from the game
		player.SetActive (false);
	}













}
