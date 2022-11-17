using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 2;
    public int AttackHurt;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        transform.Rotate(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * Time.deltaTime * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerControl>().Damage(AttackHurt);
        }

        if (collision.transform.tag != "Enemy")
            Destroy(gameObject);

    }
}
