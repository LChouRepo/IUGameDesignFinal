using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Box")
        {
            collision.GetComponent<Box>().Open();
        }

        if (collision.transform.tag == "Enemy")
        {
            collision.GetComponent<EnemyManager>().Damage(PlayerControl.Instance.attackHurt);
        }
    }
}
