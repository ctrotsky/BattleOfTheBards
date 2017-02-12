using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

    public AudioSource audio;
    float transpose = -4.0f;
	
	// Update is called once per frame
	void Update () {
        int pitch = -1;

		if (Input.GetButtonDown("Fret1"))
        {
            Debug.Log("Green");
            pitch = 0;
        }
        if (Input.GetButtonDown("Fret2"))
        {
            Debug.Log("Red");
            pitch = 2;
        }
        if (Input.GetButtonDown("Fret3"))
        {
            Debug.Log("Yellow");
            pitch = 4;
        }
        if (Input.GetButtonDown("Fret4"))
        {
            Debug.Log("Blue");
            pitch = 5;
        }
        if (Input.GetButtonDown("Fret5"))
        {
            Debug.Log("Orange");
            pitch = 7;
        }
        if (Input.GetAxis("StrumGuitar") > 0.5)
        {
            Debug.Log("Upstrum");
        }
        if (Input.GetAxis("StrumGuitar") < -0.5 || Input.GetButtonDown("StrumKey"))
        {
            Debug.Log("Downstrum");
        }

        if (pitch >= 0)
        {
            audio.pitch = Mathf.Pow(2, (pitch + transpose) / 12.0f);
            audio.Play();
            pitch = -1;
        }
    }

}
