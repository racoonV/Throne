using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon {
    private float nextFire = 0.0f;
    public float fireRate = 1f;
    public GameObject bulletobj;
    // Use this for initialization
    void Start () {
        nextFire = Time.time;
    }

    public override void Attack(Vector2 dir)
    {
        if (Time.time > nextFire)
        {
            nextFire += fireRate;
            Debug.LogFormat("gun aimed {0}", dir.ToString());
            Vector2 pos = transform.parent.position;
            pos += dir.normalized * 0.32f;
            GameObject bullets = (GameObject)Instantiate(bulletobj, pos, this.transform.rotation);
            bullets.GetComponent<bullet>().Shoot(dir);
        }
    }

	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
