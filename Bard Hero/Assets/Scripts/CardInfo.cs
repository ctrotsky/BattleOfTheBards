using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour {

    public string cardTitle;
    public CharacterClass characterClass;

    private SpriteRenderer render;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


public enum CharacterClass {
    Warrior,
        Mage,
        Healer
}