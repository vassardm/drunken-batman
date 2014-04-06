using UnityEngine;
using System.Collections;
using System; // Allows us to use the IComparable Interface.

// To use a collection's sort() method, we need to use the IComparable interface.
public class WarningLevel : IComparable<WarningLevel> {

	// A warning level has a color and an effect to the system.
	public string color;
	public int valueEffect;
	public float endGameModifier;

	public WarningLevel (string newColor, int newValueEffect, float newEndGameModifier) {
		color = newColor;
		valueEffect = newValueEffect;
		endGameModifier = newEndGameModifier;
	}

	public string getColor() {
		return color;
	}

	public int getValueEffect() {
		return valueEffect;
	}

	public float getEndGameModifer() {
		return endGameModifier;
	}

	public string setColor(string newColor) {
		color = newColor;
		return color;
	}
	
	public int setValueEffect(int newValueEffect) {
		valueEffect = newValueEffect;
		return valueEffect;
	}
	
	public float setEndGameModifier(float newEndGameModifier) {
		endGameModifier = newEndGameModifier;
		return endGameModifier;
	}

	public int CompareTo(WarningLevel other) {
		if (other == null) {
			return 1;
		}

		// Return the difference in modifiers
		return valueEffect + (other.valueEffect);

	}

}