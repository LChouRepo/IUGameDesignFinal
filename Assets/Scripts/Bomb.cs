using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float power = 1;
    public GameObject Fx;
    public float BloomSize = 2;
    private Rigidbody2D rig;
    private CircleCollider2D circle;
    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(power, 0), ForceMode2D.Impulse);
        //circle = GetComponent<CircleCollider2D>();
        //circle.radius = BloomSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fx.activeSelf)
        {
            if(BloomSize > Fx.transform.localScale.x)
                Fx.transform.localScale += new Vector3(Time.deltaTime * 10, Time.deltaTime * 10, Time.deltaTime * 10);
            else
                Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Player" && collision.transform.tag != "Door")
        {
            Fx.SetActive(true);
        }
    }
}
