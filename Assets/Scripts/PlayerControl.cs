using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CharacterEnum
{
    Sword,
    Master,
    Axe
}

public class PlayerControl : MonoBehaviour
{
    public CharacterEnum characterEnum;
    private Rigidbody2D rig;
    public float speed = 1;
    public float jumpPower = 10;
    private float maxY = 1;
    [SerializeField] private float minY = 1;
    private float currY = 1;
    [SerializeField] private Animator animator;
    public GameObject Weapon;
    private bool isAttack = true;
    private Vector3 initWeaponPlace;
    private Vector3 initWeaponRota;
    public Transform UpAttackPlace;
    public Transform DownAttackPlace;

    public Transform shootPlace;
    public GameObject bullet;
    public GameObject Axe;
    private AudioSource music;
    private float Jumpcd = 0.2f;
    private Coin coinData;

    // Start is called before the first frame update
    void Start()
    {
        coinData = (Coin)Resources.Load("Data/Coin");
        music = GetComponent<AudioSource>();
        initWeaponPlace = Weapon.transform.localPosition;
        initWeaponRota = Weapon.transform.eulerAngles;
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
        Jumpcd -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.D))
        {
            currY = minY;
            if (Jumpcd <= 0)
            {
                Jumpcd = 0.2f;
                rig.velocity = Vector2.zero;
                rig.AddForce(transform.up.normalized * jumpPower, ForceMode2D.Impulse);
            }
        }
        if (currY < maxY)
        {
            currY += Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, currY, transform.localScale.z);
        }
        else if (currY > maxY)
        {
            currY = maxY;
            transform.localScale = new Vector3(transform.localScale.x, currY, transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.F) && isAttack)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Weapon.transform.position = UpAttackPlace.position;
                Weapon.transform.rotation = UpAttackPlace.rotation;

            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Weapon.transform.position = DownAttackPlace.position;
                Weapon.transform.rotation = DownAttackPlace.rotation;
            }
            else
            {
                Weapon.transform.localPosition = initWeaponPlace;
                Weapon.transform.eulerAngles = initWeaponRota;
            }
            Weapon.SetActive(true);
            isAttack = false;
            Invoke("ReadyAttack", 0.2f);
            switch (characterEnum)
            {
                case CharacterEnum.Sword:
                    break;
                case CharacterEnum.Master:
                    Bullet bulletScript = Instantiate(bullet, shootPlace.position, shootPlace.rotation).GetComponent<Bullet>();
                    if (transform.localScale.x < 0)
                        bulletScript.isLeft = true;
                    break;
                case CharacterEnum.Axe:
                    if (FlyAxe.Instance == null)
                    {
                        Instantiate(Axe, shootPlace.position, shootPlace.rotation).GetComponent<FlyAxe>();
                        if (transform.localScale.x < 0)
                            FlyAxe.Instance.isLeft = true;
                    }   
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Coins")
        {
            coinData.coin += 10;
            UIManager.Instance.UpdateCoinsText(coinData.coin);
            Destroy(collision.gameObject);
        }
      
    }

}
