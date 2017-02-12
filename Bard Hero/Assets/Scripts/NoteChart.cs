using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteChart : MonoBehaviour {

    public List<Note> noteChart = new List<Note>();

    public void Add(Note note)
    {
        noteChart.Add(note);
    }

    public int Count()
    {
        int count = 0;
        foreach (Note note in noteChart)
        {
            if (note != Note.None)
            {
                count++;
            }
        }
        return count;
    }

    public Note Get(int index)
    {
        return noteChart[index];
    }

}
