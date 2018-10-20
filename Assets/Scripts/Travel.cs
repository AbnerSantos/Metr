using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour 
{
	[SerializeField] float initialTimer;
	[SerializeField] string[] stationTypes;
	private float Stoptime;
	bool isStopped;
	[SerializeField] bool isTheEnd;
	private int index;
	[SerializeField] int sizeofArray;
	Stations[] stations;
	void Start () 
	{
		index = 0;
		
		stations = new Stations[sizeofArray];
		Stoptime = initialTimer;
		for(int i = 0; i < stationTypes.Length; i++)
		{
			if(stations[i] == null)
			{
				stations[i] = new Stations();
			}
		
			stations[i].type = stationTypes[i];
			stations[i].distStations = 10 + i;
			stations[i].travelTime = 10 + i;		
		}
		isStopped = false;
		isTheEnd = false;
	}
	
	void Update () 
	{
		Debug.Log("index: " + index);
		Debug.Log("Current travel time: " + stations[index].travelTime + " of index: " + index);
		Debug.Log("Current disStations is: " + stations[index].distStations + " of index: " + index);
		if(Stoptime > 0 && isStopped == true && index < stationTypes.Length)
		{
			Stoptime -= 1;
			Debug.Log("Stop time is: " + Stoptime + " of index: " + index);
		}
		else if(Stoptime <= 0 && isStopped == true  && index < stationTypes.Length)
		{
			Stoptime = initialTimer;
			Debug.Log("Initial stop time is: " + Stoptime);
			isStopped = false;
			if(index + 1 < stationTypes.Length && isTheEnd == false)
			{
				index++;
			}
			else if(index + 1 == stationTypes.Length)
			{
				isTheEnd = true;
			}
			if(index > 0 && isTheEnd == true)
			{
				index--;
			}
		}
		else if(isStopped == false && stations[index].travelTime > 0 && stations[index].distStations > 0  && index < stationTypes.Length)
		{
			stations[index].travelTime -= 1;
			Debug.Log("travel time is: " + stations[index].travelTime + " of index: " + index);
			stations[index].distStations -= 1;
			Debug.Log("disStations is: " + stations[index].distStations + " of index: " + index);
		}
		else if(isStopped == false && stations[index].travelTime <= 0 && stations[index].distStations <= 0  && index < stationTypes.Length)
		{
			stations[index].travelTime = 10 + index;
			stations[index].distStations = 10 + index;
			isStopped = true;
		}
	}
}

public class Stations
{
	public  string type;
	public  float distStations;
	public  float travelTime;
}