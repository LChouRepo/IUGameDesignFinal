using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
[System.Serializable]
public struct CharacterMessage
{
    public GameObject character;
    public int gold;
    public TMP_Text _Text;
}

public class SelectCharacter : MonoBehaviour
{
    public CharacterMessage[] characterMessages;
    public CharacterData CharacterData;
    private Vector3[] v3;
    public static int currCharacter = 0;
    public Transform Arrow;
    public Coin coinData;
    // Start is called before the first frame update
    void Start()
    {
        v3 = new Vector3[characterMessages.Length];
        int i = 0;
        foreach (var item in characterMessages)
        {
            v3[i] = item.character.transform.position;
            v3[i].y += 1.6f;
            i++;
        }
        Arrow.position = v3[currCharacter];
        UIManager.Instance.UpdateCoinsText(coinData.coin);
        if (!coinData.isHave[currCharacter])
            characterMessages[currCharacter]._Text.text = characterMessages[currCharacter].gold + "G";
        else
            characterMessages[currCharacter]._Text.text = "ready";
        coinData.SceneInt = new int[8];
        for (int j = 0; j < 8; j++)
        {
            coinData.SceneInt[j] = CreateScene();

        }
    }

    private int CreateScene()
    {
        int range = Random.Range(1, 9);
        foreach (var item in coinData.SceneInt)
        {
            if (item == range)
            {
                CreateScene();
            }
        }
        return range;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            characterMessages[currCharacter]._Text.text = "";
            if (currCharacter == 0)
                currCharacter = characterMessages.Length - 1;
            else
                currCharacter--;
            Arrow.position = v3[currCharacter];
            if (!coinData.isHave[currCharacter])
                characterMessages[currCharacter]._Text.text = characterMessages[currCharacter].gold + "G";
            else
                characterMessages[currCharacter]._Text.text = "ready";
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            characterMessages[currCharacter]._Text.text = "";
            if (currCharacter == characterMessages.Length - 1)
                currCharacter = 0;
            else
                currCharacter++;
            Arrow.position = v3[currCharacter];
            if (!coinData.isHave[currCharacter])
                characterMessages[currCharacter]._Text.text = characterMessages[currCharacter].gold + "G";
            else
                characterMessages[currCharacter]._Text.text = "ready";
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!coinData.isHave[currCharacter])
            {
                if (characterMessages[currCharacter].gold <= coinData.coin)
                {
                    coinData.coin -= characterMessages[currCharacter].gold;
                    coinData.isHave[currCharacter] = true;
                    UIManager.Instance.UpdateCoinsText(coinData.coin);
                    characterMessages[currCharacter]._Text.text = "ready";
                }
                else
                {
                    characterMessages[currCharacter]._Text.text = "Not enough";
                }
            }
            else
            {
                coinData.currScene = 1;
                SceneManager.LoadScene(coinData.SceneInt[coinData.currScene]);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
