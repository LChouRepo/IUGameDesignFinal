using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] character;
    public Transform createPlace;
    private Coin coin;
    // Start is called before the first frame update
    void Awake()
    {
        coin = (Coin)Resources.Load("Data/Coin");
        Instantiate(character[SelectCharacter.currCharacter], createPlace.position,createPlace.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
