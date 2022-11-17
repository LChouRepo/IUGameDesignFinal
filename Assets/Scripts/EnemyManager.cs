using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    CloseRange,
    LongRange
}

public class EnemyManager : MonoBehaviour
{
    public EnemyType enemyType;
    public int hp = 2;
    public Transform leftPoint;
    public Transform rightPoint;
    public float speed = 1;
    private bool isBack;
    [SerializeField]private float WalkCD= 3;
    [SerializeField]private float AttackCD= 1;
    [SerializeField] private int AttackHurt = 1;
    private float attackCD;
    private float timer = 0;
    private bool isAttack=true;
    public GameObject Bullet;
    private Transform player;
    public float attackRange=5;
    public Transform shootPlace;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (!isBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPoint.position, Time.deltaTime * speed);
            if (Mathf.Abs( transform.position.x - leftPoint.position.x )< 0.1f|| timer<=0)
            {
                timer = WalkCD;
                isBack = true;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPoint.position, Time.deltaTime * speed);
            if (Mathf.Abs(transform.position.x - rightPoint.position.x) < 0.1f || timer <= 0)
            {
                timer = WalkCD;
                isBack = false;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        if ((transform.position - player.transform.position).magnitude < attackRange&& isAttack&&enemyType==EnemyType.LongRange)
        {
            isAttack = false;
            attackCD = AttackCD;
           Instantiate(Bullet, shootPlace.position, shootPlace.rotation).GetComponent<EnemyBullet>().AttackHurt=AttackHurt;
        }
        attackCD -= Time.deltaTime;
        if (attackCD <= 0)
        {
            isAttack = true;
        }
    }

    public void Damage(int value)
    {
        hp -= value;
        if (hp <= 0)
            Died();
    }

    public void Died() 
    {
        ScoreShowUI.Instance.AddLevel();
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player"&& isAttack)
        {
            attackCD = AttackCD;
            isAttack = false;
            collision.transform.GetComponent<PlayerControl>().Damage(AttackHurt);
        }
    }

}
