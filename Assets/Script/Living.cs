using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : MonoBehaviour {

    public float health = 100f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Damage(float damage)
    {
        Debug.Log("hero attacked");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
