using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NPCsAndTimeManager : MonoBehaviour
{
    [SerializeField] private int timeToBoss;
    [SerializeField] private int currentTime;

    public delegate void OnSecondPassed(int time);
    public static event OnSecondPassed onSecondPassed;

    //Temporario
    public GameObject panelToLoadBoss;

    [Header("Mover barra do dia")]
    public bool sceneHasDayBar = true;
    public Slider dayBar;

    void Start()
    {
        //InvokeRepeating("CheckNPCsAndTimer", 0, 1);
    }

    public void StartTimer()
    {
        InvokeRepeating("CheckNPCsAndTimer", 0, 1);
    }

    public void CheckNPCsAndTimer()
    {
        currentTime += 1;

        onSecondPassed?.Invoke(currentTime);

        if(currentTime >= timeToBoss)
        {
            if (CursorController.Instance != null)
            {
                CursorController.Instance.CursorToNormal();
            }
            panelToLoadBoss.SetActive(true);
            GameStates.Instance.SetStateTransitioning();
        }

        if(sceneHasDayBar)
        {
            UpdateDayBar();
        }
    }

    public void UpdateDayBar()
    {
        dayBar.value = currentTime;
    }
}
