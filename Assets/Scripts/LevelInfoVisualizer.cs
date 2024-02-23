using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoVisualizer : MonoBehaviour
{
    [SerializeField] private int levelID;
    
    [Space]
    [SerializeField] private Text levelInfoText;
    [SerializeField] private GameObject[] starsIndicators;
    [SerializeField] private Image enabledImage;
    [SerializeField] private Button button;
    
    
    [Space]
    [SerializeField] private Sprite enabledSprite;
    [SerializeField] private Sprite disabledSprite;

    private int score;
    private void Start()
    {
        score = GameData.GetScoreByLevelID(levelID);
        FillLevelInfoText();
        UpdateAccesToButton();
        ShowLevelStars();
    }

    
    void FillLevelInfoText()
    {
        levelInfoText.text = $"LEVEL {levelID}";
        if(score == 0) return;
        levelInfoText.text += $"\n{score}";
    }

    void UpdateAccesToButton()
    {
        button.enabled = false;
        enabledImage.sprite = disabledSprite;
        if (levelID == 1 || score > 0 || GameData.GetScoreByLevelID(levelID - 1) > 0)
        {
            enabledImage.sprite = enabledSprite;
            button.enabled = true;
        }
    }
    void ShowLevelStars()
    {
        if (score > 200)
        {
            starsIndicators[0].SetActive(true);
        }if (score > 300)
        {
            starsIndicators[1].SetActive(true);
        }if (score > 400)
        {
            starsIndicators[2].SetActive(true);
        }
    }
}