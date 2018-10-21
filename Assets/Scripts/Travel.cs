using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour 
{
	[SerializeField] float initialTimer;
	[SerializeField] int sizeofArray;
	[SerializeField] string[] stationTypes;
	private float Stoptime;
	public bool isStopped;
	bool isTheEnd;
	private int index;
	
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
		isStopped = true;
		isTheEnd = false;
	}
	
	void Update () 
	{
		
		if(Stoptime > 0 && isStopped == true && index < stationTypes.Length)
		{
			//Is stopped in the station
			Stoptime -= Time.deltaTime;
		}
		else if(Stoptime <= 0 && isStopped == true  && index < stationTypes.Length)
		{
			//the time in the station has ended
			Stoptime = initialTimer;
			isStopped = false;

			if(index + 1 < stationTypes.Length && isTheEnd == false)
			{
				stations[index].distStations = 10 + index;
				stations[index].travelTime = 10 + index;
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
			//is going to the next station
			stations[index].travelTime -= Time.deltaTime;	
			stations[index].distStations -= Time.deltaTime;
		}
		else if(isStopped == false && stations[index].travelTime <= 0 && stations[index].distStations <= 0  && index < stationTypes.Length)
		{
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