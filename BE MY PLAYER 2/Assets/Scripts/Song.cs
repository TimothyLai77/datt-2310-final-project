using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song
{
	public string title;
	public string composer;
	public GameObject audioTrack;
	public float bpm;
	public float subdivisions;
	public float startDelay;

	public List<int> easyChart = new List<int>();
	public List<int> mediumChart = new List<int>();
	public List<int> hardChart = new List<int>();

	public Song()
    {

    }

	public Song(string title, string composer, GameObject audioTrack, float bpm, float subdivisions, float startDelay, List<int> easyChart, List<int> mediumChart, List<int> hardChart)
    {
		this.title = title;
		this.composer = composer;
		this.audioTrack = audioTrack;
		this.bpm = bpm;
		this.subdivisions = subdivisions;
		this.easyChart = easyChart;
		this.mediumChart = mediumChart;
		this.hardChart = hardChart;
    }
}
