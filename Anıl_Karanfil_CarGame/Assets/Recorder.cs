using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{

    public List<RecordData> recordDataList = new List<RecordData>();

    public Vector3 startingPos;
    public bool isRecorded;
    Player player;

    //Compare with recorded values 
    public float playingTime;
    public int counter;
    void Start()
    {
        player = GetComponent<Player>();
        counter = 0;
        transform.position = StartPos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playingTime += Time.deltaTime;

        if (isRecorded)//We have Records?
        {
            if(counter != recordDataList.Count)
            {


                if (recordDataList[counter].recordTime == playingTime)//Is Record Time and Playing Time is Equal
                {
                    Debug.Log("-1");

                    StartCoroutine(PressKey(recordDataList[counter].turnDirect, recordDataList[counter].recordLength));
                    counter++;

                }
            }
            else
            {
                Debug.Log("done");
            }
            player.MoveVertical();

        }

    }


    IEnumerator PressKey(int keyCode, float Ptime)
    {

        while  (Ptime >= 0f)
        {
            Debug.Log("  aaa  "+Time.deltaTime);

            if (keyCode == 1)//Did you press the right side
            {
                
                player.MoveHorizontal(1);
            }
            if(keyCode == -1)//Did you press the left side
            {
                player.MoveHorizontal(-1);

            }
            Ptime -= Time.deltaTime;


        }


        yield return new WaitForSeconds(Ptime);

    }

    public Vector3 StartPos()
    {
        return startingPos;
    }
}
