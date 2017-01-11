using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Boxer model;
	private Vector2 coordinates;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector2 Coordinates {
		get {
			return this.coordinates;
		}
		set {
			coordinates = value;
		}
	}
}
