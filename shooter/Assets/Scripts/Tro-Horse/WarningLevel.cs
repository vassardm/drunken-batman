using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System; // Allows us to use the IComparable Interface.

// To use a collection's sort() method, we need to use the IComparable interface.
public class WarningLevel : IComparable<WarningLevel> {

	// A warning level has a color and an effect to the system.
	public string color;
	public List<float> valueEffects;
	public float endGameModifier;

	public WarningLevel (string newColor, List<float> newValueEffects, float newEndGameModifier) {
		color = newColor;
		valueEffects = newValueEffects;
		endGameModifier = newEndGameModifier;
	}

	public string getColor() {
		return color;
	}

	public List<float> getValueEffects() {
		return valueEffects;
	}

	public float getEndGameModifer() {
		return endGameModifier;
	}

	public string setColor(string newColor) {
		color = newColor;
		return color;
	}
	
	public void setValueEffect(List<float> newValueEffect) {
		valueEffects = newValueEffect;
	}

    public float setEndGameModifier(float newEndGameModifier)
    {
        endGameModifier = newEndGameModifier;
        return endGameModifier;
    }

    public int CompareTo(WarningLevel other) { return 0; }
}