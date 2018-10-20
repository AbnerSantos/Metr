using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTile : BaseSeatTile{
    [SerializeField] GameObject putometro;
    private Putometro putometroScript;
    [SerializeField] IndividualPutometro passengerPutometro;

    void Update(){
        if(passenger != null){
            putometro = GameObject.FindGameObjectWithTag("Putometro");
            passengerPutometro = putometro.GetComponent<IndividualPutometro>();
            putometroScript = putometro.GetComponent<Putometro>();

            putometroScript.UpdatePutometer(passenger.GetComponent<IndividualPutometro>());
            Destroy(passenger);
        }   
    }
}