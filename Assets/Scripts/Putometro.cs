using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Putometro : MonoBehaviour {
    [SerializeField] float stressLimit;
    [SerializeField] float stress;
    private float percentage;
    private float rotationAngle;
    [SerializeField][Range(0f, 0.1f)] float pointerSpeed;
    [SerializeField] GameObject pointer;

	[SerializeField] Travel underground;
    [SerializeField] float recover;

    void Awake(){
        InvokeRepeating("RecoverPutomoter", 0, 1);
    }
    void Update () {
        percentage = (stress * 100) / stressLimit;
        rotationAngle = (percentage / (100f/270)) - 135;
        pointer.transform.rotation = Quaternion.Lerp(pointer.transform.rotation, Quaternion.Euler(0f, 0f, -rotationAngle), pointerSpeed);
    }       

    public void UpdatePutometer(IndividualPutometro passenger){
        stress += passenger.stress / 5;
        if(stress > stressLimit){
            stress = stressLimit;
            SceneManager.LoadScene(2); //Score Scene
        }
    }

    private void RecoverPutometer(){
        stress -= recover;
        if(stress < 0)
            stress = 0;
    }
}