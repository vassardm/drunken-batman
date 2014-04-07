/*
* Energy Bar Toolkit by Mad Pixel Machine
* http://www.madpixelmachine.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergyBar : MonoBehaviour {

    // ===========================================================
    // Constants
    // ===========================================================

    // ===========================================================
    // Fields
    // ===========================================================
    
	public GameObject bar;
	public GameBehavior globals;
	public PlayerInteraction shieldBar;
	public THorseSystemMechanics difficultyGlobals;
    public int valueCurrent = 50;
    public int valueMin = 0;
    public int valueMax = 100;

	void Start() { 
		if (bar.tag == "bomb_bar") {
			valueCurrent = globals.bombCounter;
				}
		if (bar.tag == "life_bar") {
			valueCurrent = globals.numOfLives;
		}
		if (bar.tag == "graze_bar") {
			valueCurrent = globals.grazeCounter;
		}
		if (bar.tag == "firepower_bar") {
			valueCurrent = (int) globals.firePower;
		}
		if (bar.tag == "shield_bar") {
			valueCurrent = (int) shieldBar.invunTime;
		}
		if (bar.tag == "t_horse_bar") {
			valueCurrent = (difficultyGlobals.fragmentCounter);
		}

	}

    
    public float ValueF {
        get {
            if (!animationEnabled) {
                return Mathf.Clamp((valueCurrent - valueMin) / (float) (valueMax - valueMin), 0, 1);
            } else {
                return Mathf.Clamp(animValueF, 0, 1);
            }
        }
        
        set {
            valueCurrent = Mathf.RoundToInt(value * (valueMax - valueMin) + valueMin);
        }
    }
    
    [HideInInspector]
    public bool animationEnabled;
    [HideInInspector]
    public float animValueF;

    // ===========================================================
    // Constructors (Including Static Constructors)
    // ===========================================================

    // ===========================================================
    // Getters / Setters
    // ===========================================================

    // ===========================================================
    // Methods for/from SuperClass/Interfaces
    // ===========================================================

    protected void Update() {
		if (bar.tag == "bomb_bar") {
			valueCurrent = Mathf.Clamp(globals.bombCounter, valueMin, valueMax);
		}
		if (bar.tag == "life_bar") {
			valueCurrent = Mathf.Clamp(globals.numOfLives, valueMin, valueMax);
		}
		if (bar.tag == "graze_bar") {
			valueCurrent = Mathf.Clamp(globals.grazeCounter, valueMin, valueMax);
		}
		if (bar.tag == "firepower_bar") {
			valueCurrent = Mathf.Clamp((int) globals.firePower, valueMin, valueMax);
		}
		if (bar.tag == "shield_bar") {
			valueCurrent = Mathf.Clamp((int) shieldBar.invunTime, valueMin, valueMax);
		}
		if (bar.tag == "t_horse_bar") {
			valueCurrent = Mathf.Clamp(difficultyGlobals.fragmentCounter, valueMin, valueMax);
		}
	
        
        if (animationEnabled) {
            valueCurrent = valueMin + (int) (animValueF * (valueMax - valueMin));
        }
    }

    // ===========================================================
    // Methods
    // ===========================================================
    
    public void SetValueCurrent(int valueCurrent) {
        this.valueCurrent = valueCurrent;
    }
    
    public void SetValueMin(int valueMin) {
        this.valueMin = valueMin;
    }
    
    public void SetValueMax(int valueMax) {
        this.valueMax = valueMax;
    }
    
    public void SetValueF(float valueF) {
        ValueF = valueF;
    }
    
    // ===========================================================
    // Static Methods
    // ===========================================================

    // ===========================================================
    // Inner and Anonymous Classes
    // ===========================================================

}