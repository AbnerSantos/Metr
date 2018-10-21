using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour 
{
	[SerializeField] float timeInStation;
	[SerializeField] int minRange;
	[SerializeField] int maxRange;
	[SerializeField] string[] stationTypes;
	private float Stoptime;
	public bool isStopped;
	public bool isTheEnd;
	private int index;
	
	Stations[] stations;
	public string currentStation;
	void Start () 
	{
		index = 0;
		stations = new Stations[stationTypes.Length];
		Stoptime = timeInStation;
		for(int i = 0; i < stationTypes.Length; i++)
		{
			if(stations[i] == null)
			{
				stations[i] = new Stations();
			}
		
			stations[i].type = stationTypes[i];
			stations[i].distStations = Random.Range(minRange, maxRange);
			stations[i].travelTime = stations[index].distStations;	
		}
		isStopped = true;
		isTheEnd = false;
	}
	
	void FixedUpdate () 
	{

		if(Stoptime > 0 && isStopped == true && index < stationTypes.Length)
		{
			//Is stopped in the station
			Stoptime -= Time.deltaTime;
			currentStation = stations[index].type;
		}
		else if(Stoptime <= 0 && isStopped == true  && index < stationTypes.Length)
		{
			//the time in the station has ended
			Stoptime = timeInStation;
			isStopped = false;

			if(index + 1 < stationTypes.Length && isTheEnd == false)
			{
				stations[index].distStations = Random.Range(minRange, maxRange);
				stations[index].travelTime = stations[index].distStations;
				index++;
			}
			else if(index + 1 == stationTypes.Length)
			{	
				isTheEnd = true;
			}
			if(index > 0 && isTheEnd == true)
			{
				stations[index].distStations = Random.Range(minRange, maxRange);
				stations[index].travelTime = stations[index].distStations;
				index--;
			}
			else if(index <= 0 && isTheEnd == true)
			{
				isTheEnd = false;
				index++;
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