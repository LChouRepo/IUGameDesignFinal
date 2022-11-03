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
    public  CharacterMessage[] characterMessages;
    public CharacterData CharacterData;
    private Vector3[] v3;
    public static int currCharacter=0;
    public Transform Arrow;
    private Coin coinData;
    // Start is called before the first frame update
    void Start()
    {
        coinData = (Coin)Resources.Load("Data/Coin");
        CharacterData= (CharacterData)Resources.Load("Data/CharactersData");
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
        if (!CharacterData.isHave[currCharacter])
            characterMessages[currCharacter]._Text.text = characterMessages[currCharacter].gold + "G";
        else
            characterMessages[currCharacter]._Text.text = "ready";
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
            if (!CharacterData.isHave[currCharacter])
                characterMessages[currCharacter]._Text.text = characterMessages[currCharacter].gold + "G";
            else
                characterMessages[currCharacter]._Text.text = "ready";
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            characterMessages[currCharacter]._Text.text = "";
            if (currCharacter == characterMessages.Length-1)
                currCharacter = 0;
            else
                currCharacter++;
            Arrow.position = v3[currCharacter];
            if (!CharacterData.isHave[currCharacter])
            characterMessages[currCharacter]._Text.text = characterMessages[currCharacter].gold + "G";
            else
                characterMessages[currCharacter]._Text.text = "ready";
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!CharacterData.isHave[currCharacter])
            {
                if (characterMessages[currCharacter].gold <= coinData.coin)
                {
                    coinData.coin -= characterMessages[currCharacter].gold;
                    CharacterData.isHave[currCharacter]= true;
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
                SceneManager.LoadScene("Level01");
            }
        }

    }
}
