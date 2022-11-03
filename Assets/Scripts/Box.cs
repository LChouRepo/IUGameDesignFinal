using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite open_Image;
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Open() 
    {
        sr.sprite = open_Image;
        Instantiate(coin,transform.position,transform.rotation);
        GetComponent<BoxCollider2D>().enabled = false;
    }
    
}
