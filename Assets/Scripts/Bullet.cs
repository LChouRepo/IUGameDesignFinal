using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2;
    public bool isLeft;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft)
            transform.position -= transform.right * speed * Time.deltaTime;
        if (!isLeft)
            transform.position += transform.right * speed * Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Box")
        {
            collision.GetComponent<Box>().Open();
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Enemy")
        {
            collision.GetComponent<EnemyManager>().Damage(PlayerControl.Instance.attackHurt);
            Destroy(gameObject);
        }
    }
}
