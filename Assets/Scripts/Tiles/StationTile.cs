using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTile : BaseSeatTile{
    [SerializeField] GameObject putometro;
    private Putometro putometroScript;
    [SerializeField] IndividualPutometro passengerPutometro;
    [SerializeField] Passenger passengerScript;
    [SerializeField] PassengerState.station station;

    void Update(){
        if(passenger != null && passenger.GetComponent<Passenger>().state != PassengerState.passengerState.waitingForUnderground){
            putometro = GameObject.FindGameObjectWithTag("Putometro");
            passengerPutometro = passenger.GetComponent<IndividualPutometro>();
            putometroScript = putometro.GetComponent<Putometro>();
            passengerScript = passenger.GetComponent<Passenger>();
            
            if(passengerScript.state == PassengerState.passengerState.lostUnderground|| passengerScript.station != station){
                passengerPutometro.stress = passengerPutometro.maxStress;
            }

            putometroScript.UpdatePutometer(passengerPutometro);
            Destroy(passenger);
        }   
    }
}