using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneName;
    private Transform player;
    public bool isNext;
    public bool isNull;
    public Coin coinData;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && (player.position - transform.position).magnitude < 0.7f)
        {
            if (isNull)
                return;
            if (isNext)
            {
                coinData.isNext = true;
                coinData.currScene++;
                if (coinData.currScene >=9)
                {
                    coinData.currScene = 0;
                }
            }
            else
            {
                coinData.currScene--;
                coinData.isNext = false;
                if (coinData.currScene <= 0)
                {
                    coinData.currScene = 7;

                }
            }
            SceneManager.LoadScene(coinData.SceneInt[coinData.currScene]);
        }

    }


    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (Input.GetKey(KeyCode.UpArrow)&& collision.transform.tag == "Player")
    //        SceneManager.LoadScene(sceneName);
    //}
}
