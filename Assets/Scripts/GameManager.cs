using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] character;
    public Transform createPlace;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(character[SelectCharacter.currCharacter], createPlace.position,createPlace.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
