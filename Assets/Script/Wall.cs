using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public EdgeCollider2D wallCollider;
    public Sprite wallPic;
    // Use this for initialization
    void Start () {
        wallCollider = this.GetComponent<EdgeCollider2D>();
        Sprite s = (Sprite)GameObject.Instantiate(wallPic, new Vector2(1,1),  Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void setWall(Vector2 start, Vector2 end)
    {
        wallCollider.points[0] = start;
        wallCollider.points[1] = end;
        
    }
}
