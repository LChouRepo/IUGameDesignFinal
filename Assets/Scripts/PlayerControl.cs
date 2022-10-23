using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterEnum
{ 
    Sword,
    Master
}

public class PlayerControl : MonoBehaviour
{
    public CharacterEnum characterEnum;
    private Rigidbody2D rig;
    public float speed = 1;
    public float jumpPower= 10;
    private float maxY = 1;
    [SerializeField]private float minY = 1;
    private float currY = 1;
    [SerializeField]private Animator animator;
    public GameObject Weapon;
    private bool isAttack = true;
    private Vector3 initWeaponPlace;
    private Vector3 initWeaponRota;
    public Transform UpAttackPlace;
    public Transform DownAttackPlace;

    public Transform shootPlace;
    public GameObject bullet;
    private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music=GetComponent<AudioSource>();
        initWeaponPlace = Weapon.transform.localPosition;
        initWeaponRota= Weapon.transform.eulerAngles;
        animator = GetComponentInChildren<Animator>();
        maxY = transform.localScale.y;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("walk", true);
            transform.position += transform.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            if (!music.isPlaying)
                music.Play();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            animator.SetBool("walk", true);
            transform.position -= transform.right * speed * Time.deltaTime;
            if (!music.isPlaying)
                music.Play();
        }
        else
            animator.SetBool("walk", false);

        if (Input.GetKeyDown(KeyCode.D))
        {
            currY = minY;
            rig.AddForce(transform.up * jumpPower, ForceMode2D.Force);
        }
        if (currY < maxY)
        {
            currY += Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, currY, transform.localScale.z);
        }
        else if(currY>maxY)
        {
            currY = maxY;
            transform.localScale = new Vector3(transform.localScale.x, currY, transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.F)&& isAttack)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Weapon.transform.position = UpAttackPlace.position;
                Weapon.transform.rotation= UpAttackPlace.rotation;
                
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Weapon.transform.position = DownAttackPlace.position;
                Weapon.transform.rotation= DownAttackPlace.rotation;
            }
            else
            {
                Weapon.transform.localPosition = initWeaponPlace;
                Weapon.transform.eulerAngles= initWeaponRota;
            }
            Weapon.SetActive(true);
            isAttack = false;
            Invoke("ReadyAttack", 0.2f);
            switch (characterEnum)
            {
                case CharacterEnum.Sword:
                    break;
                case CharacterEnum.Master:
                    Bullet bulletScript=  Instantiate(bullet, shootPlace.position,shootPlace.rotation).GetComponent<Bullet>();
                    if (transform.localScale.x < 0)
                        bulletScript.isLeft = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void ReadyAttack() 
    {
        Weapon.SetActive(false);
        isAttack = true;
    }

}
