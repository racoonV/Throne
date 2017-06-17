using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Living {

    public const int HERO_UP = -2;
    public const int HERO_RIGHT = -1;
    public const int HERO_DOWN = 2;
    public const int HERO_LEFT = 1;
    public float moveSpeed = 0.3f;
    private int times = 0;
    private int dir = 0;
    Vector3 pos;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        if (times >= 60)
        {
            dir = Random.Range(HERO_UP, HERO_DOWN+1);
            times = 0;
        }
        setHeroState(dir);
        times++;
	}
    void setHeroState(int newState)
    {
        Vector2 transformValue = new Vector2();

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

    public override void Damage(float damage)
    {
        Debug.Log("monster attacked");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogFormat("monster collison????" + collision.ToString());
        //setHeroState(-dir);
        //setHeroState(-dir);
        if (collision.gameObject.CompareTag("Brick"))
        {
            dir = -dir;
            pos = transform.position;
            //setHeroState(dir);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            /*dir = -dir;
            pos = transform.position;
            */
            collision.gameObject.GetComponent<Living>().Damage(5f);
            //setHeroState(dir);
        }
    }
}
