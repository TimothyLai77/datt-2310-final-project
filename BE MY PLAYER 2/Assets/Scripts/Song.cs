using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song
{
	public string title;
	public string composer;
	public AudioClip audioClip;
	public float bpm;
	public float subdivisions;
	public float startDelay;

	public List<int> easyChart = new List<int>();
	public List<int> normalChart = new List<int>();
	public List<int> hardChart = new List<int>();

	public Song()
    {

    }

	public Song(string title, string composer, AudioClip audioClip, float bpm, float subdivisions, float startDelay, List<int> easyChart, List<int> normalChart, List<int> hardChart)
    {
		this.title = title;
		this.composer = composer;
		this.audioClip = audioClip;
		this.bpm = bpm;
		this.subdivisions = subdivisions;
		this.startDelay = startDelay;
		this.easyChart = easyChart;
		this.normalChart = normalChart;
		this.hardChart = hardChart;
    }
}
