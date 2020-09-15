using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    int wave = -1;
    int maxWave = 6;
    int level = 0;

    [Header("Game Levels")]
    public GameObject[] levels;

    [Header("Level Waves")]
    public List<GameObject> waves = new List<GameObject>();

    public List<GameObject> carRecords = new List<GameObject>();

    public GameObject confetti;

    private GameObject curLevelGameObject;


    public bool isPlaying;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetLevel(level);//Start the first level
    }


    public void StartWithTouch(PlayerController player)//Player touch the screen do these
    {
        isPlaying = true;
        player.GetComponent<Recorder>().isRecording = true; //Start the record

        for (int i = 0; i < carRecords.Count; i++)//Start Playback
        {
            carRecords[i].GetComponent<Recorder>().PlayReplay();

        }
    }
    public void ResetWave()
    {
        ResetCarParameters();
        SetWave(wave);
    }
    public void NewWave()
    {
        WaveCounter();
        SetWave(wave);
    }
    int WaveCounter()
    {
        return wave++;

    }
    public void SetWave(int curWave)//Set the wave
    {
        if (curWave > maxWave)//Is the maximum of wave
        {
            wave = -1;
            level++;
            SetLevel(level);
            return;
        }

        for (int i = 0; i < carRecords.Count; i++)//Start Playback
        {
            carRecords[i].GetComponent<Recorder>().enabled = true;
            carRecords[i].GetComponent<Recorder>().StopReplay();
            carRecords[i].transform.position = carRecords[i].GetComponent<Recorder>().dataList[0].position;
            carRecords[i].transform.rotation = carRecords[i].GetComponent<Recorder>().dataList[0].rotation;
            carRecords[i].transform.Find("Selection").gameObject.SetActive(false);
        }

        waves[wave].SetActive(true);
        GameUI.instance.SetWaveText((wave + 1).ToString());
    }
    void SetLevel(int curLevel)//Set the level
    {
        if (curLevel > levels.Length)//Is the maximum of level
        {
            Debug.Log("Sorry, We have a only " + levels.Length + " levels");
            return;
        }
        if(curLevelGameObject != null)
        {
            Destroy(curLevelGameObject);

        }
        curLevelGameObject = Instantiate(levels[curLevel], new Vector3(0, 0, 0), Quaternion.identity);//Instantiate new gameobject
        GetChildObject(curLevelGameObject.transform, "Wave");
        NewWave();
        GameUI.instance.SetLevelText((level + 1).ToString());
    }

    public void GetChildObject(Transform parent, string waveTag)//Count of waves
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == waveTag)
            {
                waves.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                GetChildObject(child, waveTag);
            }
        }
    }


public void Confetti()
    {
        //Confetti fx Instantiate with diffrent positions
        Instantiate(confetti, new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(confetti, new Vector3(10, 1, -10), Quaternion.identity);
        Instantiate(confetti, new Vector3(-10, 1, -10), Quaternion.identity);

    }



    public void ResetCarParameters()
    {
        for (int i = 0; i < carRecords.Count; i++)
        {
            Debug.Log("Allah123");
            carRecords[i].GetComponent<Recorder>().StopReplay();

            carRecords[i].transform.position = carRecords[i].GetComponent<Recorder>().dataList[0].position;
            carRecords[i].transform.rotation = carRecords[i].GetComponent<Recorder>().dataList[0].rotation;
            carRecords[i].transform.Find("Selection").gameObject.SetActive(false);


        }
    }
    public void CrushedCar(GameObject player,Vector3 carTransform,Quaternion carRotation)
    {
        player.transform.position = carTransform;
        player.transform.rotation = carRotation;
        ResetCarParameters();
        player.GetComponent<PlayerController>().firstTouch = false;
        player.GetComponent<PlayerController>().enabled = true;
        isPlaying = false;

    }



}
