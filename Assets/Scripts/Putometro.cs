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
    void Update () {
        percentage = (stress * 100) / stressLimit;
        rotationAngle = (percentage / (100f/270)) - 45;
        pointer.transform.rotation = Quaternion.Lerp(pointer.transform.rotation, Quaternion.Euler(0f, 0f, -rotationAngle), pointerSpeed);
    }       

    public void UpdatePutometer(IndividualPutometro passenger){
        stress += passenger.stress / 5;
        if(stress > stressLimit){
            stress = stressLimit;
            SceneManager.LoadScene(2); //Score Scene
        }
    }
}
