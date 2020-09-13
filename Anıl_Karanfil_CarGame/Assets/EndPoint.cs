using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))//Collider tag is'Car'?
        {
            other.gameObject.GetComponent<Recorder>().isRecorded=true;//Record is Complete
            other.gameObject.GetComponent<Player>().enabled = false;//Stop Move and Record
        }
    }
}
