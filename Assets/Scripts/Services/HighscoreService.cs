using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreService {
	private SaveFile file;

	public HighscoreService (SaveFile file) {
		this.file = file;
	}

	public int LoadHighscore () {
		return file.highScore;
	}

	public bool SaveHighscore (int highScore) {
		bool newHigh = false;

		if (file.highScore > highScore) {
			file.highScore = highScore;
			newHigh = true;
		}

		return newHigh;
	}
}
