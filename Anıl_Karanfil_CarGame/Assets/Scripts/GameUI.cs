using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Inputs")]
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI ResetLevelText;


    public static GameUI instance;


    private void Awake()
    {
        instance = this;
    }

    public void SetLevelText(string textL)
    {
        levelText.text = "Level : " + textL;
    }

    public void SetWaveText(string textW)
    {
        waveText.text = "Wave : " + textW;
    }

    public void SetGameOverText(string textGO)
    {
        ResetLevelText.text = "Reset Level : " + textGO;
    }


}
