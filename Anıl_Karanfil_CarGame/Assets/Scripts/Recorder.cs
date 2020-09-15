using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Recorder : MonoBehaviour
{
    public List<TransformData> dataList = new List<TransformData>();
    public bool isRecording = false;

    public bool stopCoroutine = false;

    private void Update()
    {
        if (isRecording)
        {

            dataList.Add(new TransformData() { position = transform.position, rotation = transform.rotation, time = Time.time });
        }

    }

    public void ClearList()//Clear all dataList data
    {
        dataList.Clear();
    }

    public IEnumerator Replay()
    {

        for (int i = 0; i < dataList.Count; i++)
        {
            yield return new WaitForEndOfFrame();
            transform.position = dataList[i].position;
            transform.rotation = dataList[i].rotation;

            if (stopCoroutine)
            {
                break;
            }

        }
    }

    public void PlayReplay()
    {
        stopCoroutine = false;
        StartCoroutine(Replay());
    }

    public void StopReplay()
    {
        stopCoroutine = true;

    }


}

[Serializable]
public class TransformData
{
    public Vector3 position;
    public Quaternion rotation;
    public float time;

}
