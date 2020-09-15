using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))//Collider tag is'Car'?
        {
            other.GetComponent<Recorder>().isRecording = false; //Stop the record
            other.gameObject.GetComponent<PlayerController>().enabled=false;//Player Stop Move
            SceneManager.instance.carRecords.Add(other.gameObject);//Add completed car records
            SceneManager.instance.NewWave();//Set the new wave
            SceneManager.instance.isPlaying = false;
            SceneManager.instance.ResetCarParameters();
            SceneManager.instance.Confetti();
            Destroy(gameObject, .5f);//Destroy gameobject
        }
    }
}
