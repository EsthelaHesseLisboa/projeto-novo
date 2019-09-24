﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    [SerializeField]

    private Vector3 TapeSpeed = new Vector3(-2f, 0f, 0f);

    [SerializeField]

    private Transform Tape = null;

    public UIComponetes uiComponetes;

    SceneData sceneData = new SceneData();

    void Awake(){
        Assert.IsNotNull(Tape);
        if (instance == null){
            instance = this;
        }
       
    }

    
    void Update()
    {
        Tape.position = Tape.position + TapeSpeed * Time.deltaTime;
        DisplayHudData();
    }

    public void IncrementCoinCount(){
        sceneData.coinCount++;
    }

     public void DecrementLifeCount() {
        sceneData.lifeCount--;
    }

    public int GetLifeCount() {
        return sceneData.lifeCount;
    }

    void DisplayHudData(){
       uiComponetes.hud.txtCoinCount.text = "x" + sceneData.coinCount;
       uiComponetes.hud.txtLifeCount.text = "x" + sceneData.lifeCount; 
    }

    public void SetTapeSpeed(float value){
        TapeSpeed = new Vector3(value, TapeSpeed.y, TapeSpeed.z);
    }

    public void ShowLevelCompletePanel() {
        uiComponetes.levelCompletePanel.panel.SetActive(true);
        uiComponetes.levelCompletePanel.txtScore.text = "" + sceneData.coinCount;
    }

     public void ShowGameOverPanel() {
        uiComponetes.gameOverPanel.panel.SetActive(true);
        uiComponetes.gameOverPanel.txtScore.text = "" + sceneData.coinCount;
    }
}
