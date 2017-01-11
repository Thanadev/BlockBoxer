using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove {
	private int score;

	public PlayerMove (int score) {
		this.score = score;
	}

	public int Score {
		get {
			return this.score;
		}
	}
}
