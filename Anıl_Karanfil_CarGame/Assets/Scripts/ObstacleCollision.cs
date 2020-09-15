
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))//Collider tag is'Car'?
        {
            other.GetComponent<Recorder>().isRecording = false; //Stop the record
            SceneManager.instance.CrushedCar(other.gameObject, other.GetComponent<Recorder>().dataList[0].position, other.GetComponent<Recorder>().dataList[0].rotation);//Reset Wave
            other.GetComponent<Recorder>().ClearList();//All recorded data is clear now.
        }
    }
}
