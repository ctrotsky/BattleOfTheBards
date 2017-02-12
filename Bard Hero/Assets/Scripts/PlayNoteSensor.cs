using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNoteSensor : MonoBehaviour {

    public AudioSource audio;
    public AudioClip guitarNote;
    public AudioClip bassNote;
    public AudioClip fluteNote;
    public AudioClip currentSound;

    public NoteGenerator noteGenerator;

    float transpose = -4.0f;
    bool strummed = false;

    private Collider2D collide;

    List<GameObject> touchingNotes = new List<GameObject>();

    private int totalNotes;
    private int remainingNotes = -1;
    private int hitNotes;
    private bool noteCountedInFrame = false;

    public List<GameObject> fretboard;

    public void RecordPercentage(int numNotes)
    {
        totalNotes = numNotes;
        remainingNotes = numNotes;
        hitNotes = 0;
        noteCountedInFrame = false;
    }

    // Update is called once per frame
    void Update () {
        noteCountedInFrame = false;

        List<GameObject> hitNotesInFrame = new List<GameObject>();


        if (Input.GetAxis("StrumGuitar") > 0.5 || Input.GetAxis("StrumGuitar") < -0.5 || Input.GetButtonDown("StrumKey"))
        {
            if (strummed == false)
            {
                strummed = true;
                Debug.Log("strum");

                List<int> pressedFrets = new List<int>();
                List<int> touchingFrets = new List<int>();

                for (int i = 1; i <= 5; i++)
                {
                    if (Input.GetButton("Fret" + i))
                    {
                        pressedFrets.Add(i);
                        Debug.Log("Pressing " + i);
                    }
                }


                foreach (GameObject note in touchingNotes)
                {
                    touchingFrets.Add(note.GetComponent<NoteMover>().fret);
                }

                bool hitAll = true;

                //Make sure every fret thats hit is exactly the ones you are touching
                foreach (int fret in touchingFrets)
                {
                    if (!pressedFrets.Contains(fret))
                    {
                        Debug.Log("Pressed frets doesn't contain " + fret);
                        hitAll = false;
                    }
                }
                foreach (int fret in pressedFrets)
                {
                    if (!touchingFrets.Contains(fret))
                    {
                        Debug.Log("Touching frets doesn't contain " + fret);
                        hitAll = false;
                    }
                }

                if (hitAll)
                {
                    List<GameObject> removeNotes = new List<GameObject>();
                    Debug.Log("Hit All");
                    foreach (GameObject note in touchingNotes)
                    {
                        int fret = note.GetComponent<NoteMover>().fret;
                        PlayNote(fret);

                        ParticleSystem effect = fretboard[fret - 1].GetComponentInChildren<ParticleSystem>();
                        effect.Play();

                        note.SetActive(false);
                        removeNotes.Add(note);
                        
                    }
                    
                    foreach (GameObject note in removeNotes)
                    {
                        touchingNotes.Remove(note);
                        Destroy(note);
                    }


                    hitNotes++;
                }

               
                
            }

        }
        if (Input.GetAxis("StrumGuitar") == 0)
        {
            strummed = false;
        }

        if (remainingNotes == 0)
        {
            StartCoroutine(EndSong());

        }
    }

    IEnumerator EndSong()
    {
        remainingNotes = -1;
        //delay to wait for player to hit last note
        yield return new WaitForSeconds(1);
        noteGenerator.receiveSongPercentage((((float)hitNotes) / ((float)totalNotes)));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (! touchingNotes.Contains(other.gameObject)) {

            if (noteCountedInFrame == false)
            {
                noteCountedInFrame = true;
                remainingNotes--;
                Debug.Log("remaining notes in song: " + remainingNotes);
            }
            
            touchingNotes.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        touchingNotes.Remove(other.gameObject);
    }

    public void PlayNote(int fret)
    {
        int pitch = 0;
        switch (fret)
        {
            case 1:
                pitch = 0;
                break;
            case 2:
                pitch = 2;
                break;
            case 3:
                pitch = 4;
                break;
            case 4:
                pitch = 5;
                break;
            case 5:
                pitch = 7;
                break;
        }

        audio.pitch = Mathf.Pow(2, (pitch + transpose) / 12.0f);
        audio.PlayOneShot(currentSound);
    }


}
