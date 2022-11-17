using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] character;
    public Transform createPlace;
    public Transform createPlace02;


    public Coin coin;

    // Start is called before the first frame update
    void Awake()
    {
        if (coin.isNext)
            Instantiate(character[SelectCharacter.currCharacter], createPlace.position, createPlace.rotation);
        else
            Instantiate(character[SelectCharacter.currCharacter], createPlace02.position, createPlace02.rotation);
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
