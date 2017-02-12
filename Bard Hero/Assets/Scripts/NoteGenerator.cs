using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour {

    public GameObject hitbar;
    public GameObject notePrefab;
    public Transform spawnPoint;
    public CardManager cardManager;
    public ActionManager actionManager;
    public PlayNoteSensor playNoteSensor;

    private int totalNotes = 0;
    public bool songPlaying;
    private float percentHit = 0.0f;

    public List<Transform> fretPositions;

    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void GenerateNoteFret(int fret, float speed)
    {
        float xPos = fretPositions[fret - 1].position.x + (fretPositions[fret - 1].transform.localScale.x / 1.27f);

        GameObject newNote = (GameObject)Instantiate(notePrefab, spawnPoint.position + new Vector3(xPos, 0, 0), spawnPoint.rotation);
        newNote.GetComponent<NoteMover>().fret = fret;
        newNote.GetComponent<NoteMover>().speed = speed;
        newNote.transform.parent = transform;
        newNote.GetComponent<SpriteRenderer>().color = fretPositions[fret - 1].gameObject.GetComponent<SpriteRenderer>().color;
    }

    void GenerateNote(Note note, float speed)
    {
        if ((note & Note.Green) != 0)
        {
            GenerateNoteFret(1, speed);
        }
        if ((note & Note.Red) != 0)
        {
            GenerateNoteFret(2, speed);
        }
        if ((note & Note.Yellow) != 0)
        {
            GenerateNoteFret(3, speed);
        }
        if ((note & Note.Blue) != 0)
        {
            GenerateNoteFret(4, speed);
        }
        if ((note & Note.Orange) != 0)
        {
            GenerateNoteFret(5, speed);
        }
    }

    public void playSong(string cardTitle, float waitBetweenNotes, float speed)
    {
        StartCoroutine(playSongCoroutine(cardTitle, waitBetweenNotes, speed));
    }

    public IEnumerator playSongCoroutine(string cardTitle, float waitBetweenNotes, float speed)
    {
        songPlaying = true;

        NoteChart noteChart = NoteCharts.getChartByTitle(cardTitle);

        Debug.Log("Song Length: " + noteChart.Count());

        playNoteSensor.RecordPercentage(noteChart.Count());

        foreach (Note n in noteChart.noteChart)
        {
            GenerateNote(n, speed);
            yield return new WaitForSeconds(waitBetweenNotes);

        }

        while (songPlaying) {
            yield return new WaitForSeconds(0.1f);
        }

        //Do card action
        actionManager.doAction(cardTitle, percentHit);

        //cardManager.gameObject.SetActive(true);

    }

    public void receiveSongPercentage(float percentage)
    {
        songPlaying = false;
        percentHit = percentage;
    }

}
