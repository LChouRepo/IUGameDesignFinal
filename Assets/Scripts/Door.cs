using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneName;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)&&(player.position - transform.position).magnitude < 0.7f)
        { 
            SceneManager.LoadScene(sceneName);
        }

    }


    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (Input.GetKey(KeyCode.UpArrow)&& collision.transform.tag == "Player")
    //        SceneManager.LoadScene(sceneName);
    //}
}
