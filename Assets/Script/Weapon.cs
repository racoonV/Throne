using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    protected GameObject holder = null;
	// Use this for initialization
	void Start () {
		
	}
	
    public virtual void Attack(Vector2 dir)
    {
        Debug.LogFormat("weapon attack");
    }

    public virtual void Hold(GameObject obj)
    {
        transform.position = new Vector2(obj.transform.position.x + 0.1f, obj.transform.position.y + 0.1f);
        transform.parent = obj.transform;
        holder = obj;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
