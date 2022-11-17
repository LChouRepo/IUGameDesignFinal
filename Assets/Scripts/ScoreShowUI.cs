using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ScoreShowUI : MonoBehaviour
{
    public PlayerMessage playerMessage;
    public TMP_Text sceneText;
    public TMP_Text HPText;
    public TMP_Text LevelText;
    public static int Level = 1;
    public static ScoreShowUI Instance;
    private int currScene = 0;
    // Start is called before the first frame update
    public void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (currScene != SceneManager.GetActiveScene().buildIndex)
        {
            sceneText.text = "Scene:" + SceneManager.GetActiveScene().buildIndex;
            currScene = SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void AddLevel() 
    {
        Level++;
        LevelText.text = "Level:" + Level;
        
    }



}
