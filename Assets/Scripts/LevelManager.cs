using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int _levelCount;

    [SerializeField] private TMP_Text levelCountTextField;
    [SerializeField] private GameObject restartLevelButton;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject loseTextField;
  
    // singlton + dont destroy on load

    public static LevelManager instance;

    public bool _shouldRestart;
    public bool _shouldStartNextlevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _levelCount = 1;
        levelCountTextField.SetText("LVL: "+_levelCount.ToString());
    }

    private void Update()
    {
        if (_shouldRestart)
        {
            restartLevelButton.SetActive(true);
            loseTextField.SetActive(true);
        }
        else if (_shouldStartNextlevel)
        {
            nextLevelButton.SetActive(true);
        }
        else
        {
            restartLevelButton.SetActive(false);
            loseTextField.SetActive(false);
            nextLevelButton.SetActive(false);
        }
       
    }
    public void NexttLevel()
    {
        _levelCount++;
        levelCountTextField.SetText("LVL: " + _levelCount.ToString());
        _shouldRestart = false;
        _shouldStartNextlevel = false;
        SceneManager.LoadScene("Game"); //Load scene called Game
 
    }
    public void RestartLevel()
    {
           _shouldRestart = false;
        _shouldStartNextlevel = false;
        SceneManager.LoadScene("Game"); //Load scene called Game
     
    }
}
