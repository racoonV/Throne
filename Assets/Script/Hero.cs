using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : Living {
    public const int HERO_UP = -2;
    public const int HERO_RIGHT = -1;
    public const int HERO_DOWN = 2;
    public const int HERO_LEFT = 1;
    public GameObject gunObj;
    public GameObject weapon;
    public Text heroHp;

    public int state = 0;
    //人物移动速度  
    public float moveSpeed = 0.3f;
    float times = 0f;
    Vector3 pos;

    //public float mKeyStrokeMoveStep = 0.07f;    //metre  
    //private CharacterController controller;
    //private Vector3 mMoveDir;
    //bool turna = false;
    // Use this for initialization
    void Start () {
        //controller = GetComponent<CharacterController>();
        //ArmWeapon(GameObject.Instantiate(gunObj, new Vector2(0f, 0f), Quaternion.identity));
    }
	
	// Update is called once per frame
	void Update () {
        /*
        Vector3 vDir = Vector3.zero;
        if (Input.GetKey(KeyCode.S))
        {
            vDir.y -= mKeyStrokeMoveStep;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vDir.y += mKeyStrokeMoveStep;
        }

        if (Input.GetKey(KeyCode.D))
        {
            vDir.x += mKeyStrokeMoveStep;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vDir.x -= mKeyStrokeMoveStep;
        }
        mMoveDir = transform.rotation * vDir;
        CollisionFlags flag = controller.Move(mMoveDir);
        Debug.Log(flag.ToString());*/
        
        if (Input.GetKey(KeyCode.W)) {
            setHeroState(HERO_UP);
        }
        if (Input.GetKey(KeyCode.S))
        {
            setHeroState(HERO_DOWN);
        }
        if (Input.GetKey(KeyCode.A))
        {
            setHeroState(HERO_LEFT);
            /*if (turna == false)
            {
                transform.Rotate(0f, 180f, 0);
                turna = true;
            }*/
        }
        if (Input.GetKey(KeyCode.D))
        {
            setHeroState(HERO_RIGHT);
            //if (turna == true)
            //{
            //    transform.Rotate(0f, 180f, 0);
            //    turna = false;
            //}
        }
        Vector2 mouseDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        if (Input.GetMouseButtonUp(0))
        {
            if (weapon != null)
            {
                weapon.GetComponent<Weapon>().Attack(mouseDir);
            }
        }
        transform.up = mouseDir;
        //Debug.DrawRay(transform.position, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position), Color.red);
    }

    void setHeroState(int newState)
    {
        Vector2 transformValue = new Vector2();
        state = newState;
        //播放行走动画  
        //animation.Play("walk");

        //模型移动的位置数值  
        switch (newState)
        {
            case HERO_UP:
                transformValue = Vector2.up * Time.deltaTime;
                break;
            case HERO_DOWN:
                transformValue = Vector2.down * Time.deltaTime;
                break;
            case HERO_LEFT:
                transformValue = Vector2.left * Time.deltaTime;
                break;
            case HERO_RIGHT:
                transformValue = Vector2.right * Time.deltaTime;
                break;
        }
        pos = transform.position;
        //移动人物  
        transform.Translate(transformValue * moveSpeed, Space.World);

    }

    public void PickUpItem(GameObject obj)
    {

    }

    public void ArmWeapon(GameObject wep)
    {
        weapon = wep;
        weapon.GetComponent<Weapon>().Hold(this.gameObject);
        Destroy(weapon.GetComponent<BoxCollider2D>());
    }

    private void FixedUpdate()
    {
        heroHp.text = "Hp:" + health;
    }

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.LogFormat("pick up gun????" + collision.gameObject.ToString());
        if (Input.GetKey(KeyCode.Space))
        {
            ArmWeapon(collision.gameObject);
        }
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.LogFormat("pick up gun????"+collision.name);
        if (Input.GetKey(KeyCode.Space))
        {
            ArmWeapon(collision.gameObject);
        }
    }
    
}
