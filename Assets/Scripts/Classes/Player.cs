using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	protected int score;
	protected string name;
	protected Combo combo;

	public Player (string name) {
		this.score = 0;
		this.name = name;
		this.combo = null;
	}

	public void GainScore (int addedScore) {
		score += addedScore;

		if (addedScore != 0) {
			if (combo == null || addedScore != combo.EnemyValue) {
				combo = new Combo(addedScore);
			} else {
				score += combo.addOneMove();
			}
		}
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
