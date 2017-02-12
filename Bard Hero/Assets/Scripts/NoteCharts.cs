using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoteCharts {

    public static NoteChart getChartByTitle(string songTitle){
		if (songTitle == "Attack")
        {
            return AttackSong();
        }
		if (songTitle == "Defend") 
		{
			return DefendSong ();
		}
		if (songTitle == "Provoke") 
		{
			return ProvokeSong ();
		}
        if (songTitle == "Lightning")
        {
            return LightningSong();
        }
        if (songTitle == "Gust")
        {
            return GustSong();
        }
        if (songTitle == "Explosion")
        {
            return ExplosionSong();
        }
        if (songTitle == "Heal")
        {
            return HealSong();
        }
        if (songTitle == "Healing Ballad")
        {
            return HealingBalladSong();
        }
        if (songTitle == "Power Up")
        {
            return PowerUpSong();
        }

        return null;
    }

    public static NoteChart AttackSong()
    {
        NoteChart chart = new NoteChart();
        chart.Add(Note.Green);
        chart.Add(Note.Green);
        chart.Add(Note.Red);
        chart.Add(Note.Red);
        chart.Add(Note.Yellow);
        chart.Add(Note.Yellow);
        chart.Add(Note.Green | Note.Red | Note.Yellow);
		chart.Add(Note.None);
		chart.Add(Note.None);
		chart.Add(Note.None);
		chart.Add(Note.Yellow);
		chart.Add(Note.Yellow);
		chart.Add(Note.Red);
		chart.Add(Note.Red);
		chart.Add(Note.Green);
		chart.Add(Note.Green);
		chart.Add(Note.Green | Note.Red | Note.Yellow);

        return chart;
    }

	public static NoteChart DefendSong()
	{
		NoteChart chart = new NoteChart();
		chart.Add(Note.Green);
		chart.Add(Note.None);
		chart.Add(Note.Green);
		chart.Add(Note.Green);
		chart.Add(Note.None);
		chart.Add(Note.Green);
		chart.Add(Note.Yellow);
		chart.Add(Note.Red);
		chart.Add(Note.Yellow);
		chart.Add(Note.Blue);
		chart.Add(Note.None);
		chart.Add(Note.None);
		chart.Add(Note.Green);
		chart.Add(Note.Green | Note.Red | Note.Yellow);

		return chart;
	}

	public static NoteChart ProvokeSong()
	{
		NoteChart chart = new NoteChart();
		chart.Add(Note.Green | Note.Yellow);
		chart.Add(Note.Green | Note.Yellow);
		chart.Add(Note.None);
		chart.Add(Note.None);
		chart.Add(Note.Red | Note.Blue);
		chart.Add(Note.Red | Note.Blue);
		chart.Add(Note.None);
		chart.Add(Note.None);
		chart.Add(Note.Red);
		chart.Add(Note.Red);
		chart.Add(Note.Yellow);
		chart.Add(Note.Yellow);
		chart.Add(Note.Red | Note.Yellow);

		return chart;
	}

    public static NoteChart LightningSong()
    {
        NoteChart chart = new NoteChart();
        chart.Add(Note.Orange);
        chart.Add(Note.Yellow);
        chart.Add(Note.Green);
        chart.Add(Note.Orange);
        chart.Add(Note.Yellow);
        chart.Add(Note.Green);
		chart.Add(Note.Orange);
		chart.Add(Note.Yellow);
		chart.Add(Note.Green);
		chart.Add(Note.None);
		chart.Add(Note.None);
		chart.Add(Note.None);
		chart.Add(Note.Orange | Note.Yellow | Note.Green);
		chart.Add(Note.Orange);
		chart.Add(Note.Orange | Note.Yellow | Note.Green);

        return chart;
    }

    public static NoteChart GustSong()
    {
        NoteChart chart = new NoteChart();
		chart.Add(Note.Green | Note.Red);
		chart.Add(Note.Green | Note.Red);
		chart.Add(Note.None);
		chart.Add(Note.Green | Note.Yellow);
		chart.Add(Note.Green | Note.Yellow);
		chart.Add(Note.None);
        chart.Add(Note.None);
		chart.Add(Note.Red);
		chart.Add(Note.Red);
		chart.Add(Note.Green);
		chart.Add(Note.Green);
		chart.Add(Note.Green);
		chart.Add(Note.Red);
		chart.Add(Note.Green | Note.Yellow);


        return chart;
    }

    public static NoteChart ExplosionSong()
    {
        NoteChart chart = new NoteChart();
		chart.Add(Note.Green | Note.Red | Note.Yellow);
		chart.Add(Note.Green | Note.Red | Note.Yellow);
		chart.Add(Note.Green | Note.Red | Note.Yellow);
		chart.Add(Note.Green | Note.Red | Note.Yellow);
		chart.Add(Note.Green | Note.Red);
		chart.Add(Note.Green | Note.Red);
		chart.Add(Note.Green | Note.Red);
		chart.Add(Note.Green | Note.Red);
		chart.Add(Note.Red | Note.Yellow);
		chart.Add(Note.Red | Note.Yellow);
		chart.Add(Note.Red | Note.Yellow);
		chart.Add(Note.Red | Note.Yellow);
		chart.Add(Note.None);
		chart.Add(Note.None);
		chart.Add(Note.Blue);
		chart.Add(Note.Green | Note.Red | Note.Yellow | Note.Blue);

        return chart;
    }

    public static NoteChart HealSong()
    {
        NoteChart chart = new NoteChart();
        chart.Add(Note.Green | Note.Red);
        chart.Add(Note.Red | Note.Yellow);
        chart.Add(Note.None);
        chart.Add(Note.Blue | Note.Orange);
        chart.Add(Note.Blue);
        chart.Add(Note.Blue | Note.Orange);
		chart.Add(Note.None);
		chart.Add(Note.Blue | Note.Orange);
		chart.Add(Note.Blue);
		chart.Add(Note.Blue | Note.Orange);
		chart.Add(Note.None);
		chart.Add(Note.Blue);
		chart.Add(Note.Blue | Note.Orange);
		chart.Add(Note.Blue | Note.Orange | Note.Yellow);

        return chart;
        
    }

    public static NoteChart HealingBalladSong()
    {
        NoteChart chart = new NoteChart();
        chart.Add(Note.Green | Note.Blue);
		chart.Add(Note.Green | Note.Blue);
		chart.Add(Note.Green | Note.Blue);
        chart.Add(Note.None);
        chart.Add(Note.Green);
		chart.Add(Note.Green);
		chart.Add(Note.Green);
		chart.Add(Note.None);
		chart.Add(Note.Red);
		chart.Add(Note.Red);
		chart.Add(Note.Red);
		chart.Add(Note.Red);
		chart.Add(Note.Green);
        chart.Add(Note.Blue);
        chart.Add(Note.Green);

        return chart;

    }

    public static NoteChart PowerUpSong()
    {
        NoteChart chart = new NoteChart();
        chart.Add(Note.Green);
        chart.Add(Note.Red);
        chart.Add(Note.Yellow);
		chart.Add(Note.Red);
		chart.Add(Note.Green);
		chart.Add(Note.None);
		chart.Add(Note.Green);
		chart.Add(Note.None);
		chart.Add(Note.Green);
		chart.Add(Note.Red);
		chart.Add(Note.Yellow);
		chart.Add(Note.Red);
		chart.Add(Note.Green | Note.Yellow | Note.Blue);

        return chart;

    }


}
