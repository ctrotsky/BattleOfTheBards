using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FretHighlighter : MonoBehaviour {

    public List<GameObject> frets;

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform){
            frets.Add(child.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 1; i <= 5; i++)
        {
            if (Input.GetButton("Fret" + i))
            {
                ((Behaviour)frets[i - 1].GetComponent("Halo")).enabled = true;
            }
            else
            {
                ((Behaviour)frets[i - 1].GetComponent("Halo")).enabled = false;
            }
        }      
    }
}
