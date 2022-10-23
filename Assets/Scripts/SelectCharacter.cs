using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public GameObject[] characters;
    private Vector3[] v3;
    public static int currCharacter=0;
    public Transform Arrow;
    // Start is called before the first frame update
    void Start()
    {
        v3 = new Vector3[characters.Length];
        int i = 0;
        foreach (var item in characters)
        {
            v3[i] = item.transform.position;
            v3[i].y += 1.1f;
            i++;
        }
        Arrow.position = v3[currCharacter];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currCharacter == 0)
                currCharacter = characters.Length - 1;
            else
                currCharacter--;
            Arrow.position = v3[currCharacter];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currCharacter == characters.Length-1)
                currCharacter = 0;
            else
                currCharacter++;
            Arrow.position = v3[currCharacter];
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Level01");
        }

    }
}
