using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField]private bool isAttack = true;
    // Start is called before the first frame update
    public void OnEnable()
    {
        isAttack = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Box")
        {
            collision.GetComponent<Box>().Open();
        }
        if (collision.transform.tag == "Enemy" &&isAttack)
        {
            isAttack = false;
            collision.GetComponent<EnemyManager>().Damage(PlayerControl.Instance.attackHurt);
        }
    }
}
