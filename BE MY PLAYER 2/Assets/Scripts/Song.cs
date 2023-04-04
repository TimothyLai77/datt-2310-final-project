using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Song
{
	public string title;
	public string composer;
	public string audioClip;
	public float bpm;
	public float subdivisions;
	public float startDelay;

	public List<int> easyChart = new List<int>();
	public List<int> normalChart = new List<int>();
	public List<int> hardChart = new List<int>();

	public static Song CreateFromJSON(string jsonString)
    {
		return JsonUtility.FromJson<Song>(jsonString);
    }
}
