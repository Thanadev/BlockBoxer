using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	protected int score;
	protected string name;

	public Player (string name) {
		this.score = 0;
		this.name = name;
	}

	public void GainScore (int addedScore) {
		score += addedScore;
	}

	public int Score {
		get {
			return this.score;
		}
		set {
			if (this.score > value) {
				this.score = value;
			} else {
				Debug.LogError("A score cannot be set at a value lower than its actual value.");
			}
		}
	}

	public string Name {
		get {
			return this.name;
		}
	}
}
