using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAxe : MonoBehaviour
{
    public float speed = 2;
    public float timer = 1;
    public bool isLeft;
    private bool isBack;
    private Transform player;
    public static FlyAxe Instance;
    private Transform childAxe;
    public void Awake()
    {
        Instance = this;
        childAxe = transform.GetChild(0);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, 1.5f);
    }


    void Update()
    {
        childAxe.Rotate(0, 0, -720* Time.deltaTime);
        if (timer <= 0&& !isBack)
        {
            isBack = true;
            isLeft = !isLeft;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (isLeft)
            transform.position -= transform.right * speed * Time.deltaTime;
        if (!isLeft)
            transform.position += transform.right * speed * Time.deltaTime;
        if (isBack && (transform.position - player.position).magnitude < 0.5f)
        {
            Destroy(gameObject);
        }
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

        else if(collision.transform.tag != "Player"&& collision.transform.tag != "Door" && collision.transform.tag != "Coins")
        {
            isBack = true;
            isLeft = !isLeft;
        }
    }
}
