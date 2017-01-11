using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

	private Vector2 coordinates;
	private Placeable occupant;
	private GameObject occupantAvatar;

	void Awake () {
		// Init vars
		occupant = null;
		occupantAvatar = null;
	}

	public int EnterPlayer (ref PlayerController boxer) {
		int value = 0;

		// If an enemy is on the cell...
		if (occupant != null && occupant != boxer.model) {
			// Killing the occupant
			value = ((Enemy) occupant).value;
			Destroy(occupantAvatar);

			// Getting player as occupant
			occupantAvatar = FindObjectOfType<PlayerController>().gameObject;
			occupantAvatar.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
			occupant = (Placeable) boxer.model;
			boxer.Coordinates = this.coordinates;
			Debug.Log(coordinates + " / " + boxer.Coordinates);
		}

		return value;
	}

	/**
	 * 	Instantiate a placeable on the cell
	 * 	If the placeable is the player, make the GameController register it
	 */
	public bool SpawnPlaceable (Placeable toSpawn) {
		bool isValid = false;

		// Simple check to avoid memory loss due to multiple spawning on one cell
		if (occupant == null) {
			occupant = toSpawn;

			// Spawning the prefab
			Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
			occupantAvatar = GameObject.Instantiate(toSpawn.avatar, newPos, toSpawn.avatar.transform.rotation);
			PlayerController playerC = occupantAvatar.GetComponent<PlayerController>();

			if (playerC != null) {
				playerC.Coordinates = this.coordinates;
				GameController.GetInstance().RegisterBoxer(playerC);
			}

			isValid = true;
		}

		return isValid;
	}

	public Vector2 Coordinates {
		get {
			return this.coordinates;
		}
		set {
			coordinates = value;
		}
	}

	public GameObject OccupantAvatar {
		get {
			return this.occupantAvatar;
		}
		set {
			occupantAvatar = value;
		}
	}
}
