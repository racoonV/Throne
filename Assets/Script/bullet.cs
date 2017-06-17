using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float damage = 10.0f;
    public float speed = 10f;
    public float DestroyTime = 10.0f;
    private Vector3 velocity;
    // Use this for initialization
    void Start () {
        
    }
	
    public void Shoot(Vector2 dir)
    {
        velocity = dir.normalized * speed;
        Destroy(gameObject, DestroyTime);
    }
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, velocity, speed * Time.deltaTime);
        foreach (RaycastHit2D hit in hits)
        {
            switch (hit.transform.tag)
            {
                case "Brick":
                    Destroy(gameObject);
                    return;
                case "Player":
                    /*hit.collider.gameObject.GetComponent<Living>().Damage(damage);
                    Destroy(gameObject);
                    return;*/
                case "Monster":
                    hit.collider.gameObject.GetComponent<Living>().Damage(damage);
                    Destroy(gameObject);
                    return;
            }
        }
        transform.position += velocity * Time.deltaTime;
        
    }
}
