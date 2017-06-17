using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public GameObject brick;
    public List<GameObject> bricks;
    public float oneSize = 0.3f;
    private char[] mapData = null;
    private char WALLBRICK = 'w';
    private char NOTHING = '0';
    private char GUN = 'g';
    private char MONSTER = 'm';
    public GameObject gunObj;
    public GameObject monsterObj;
    private int row;
    private int col;

    void DrawBrick(int x, int y)
    {
        bricks.Add(GameObject.Instantiate(brick, new Vector2(x * oneSize, y * oneSize), Quaternion.identity));
        
    }

    void DrawItem(GameObject obj, int x, int y)
    {
        //bricks.Add(GameObject.Instantiate(GameObject.Find("Assets/Prefabs/Moster"), new Vector2(x * oneSize, y * oneSize), Quaternion.identity));
        bricks.Add(GameObject.Instantiate(obj, new Vector2(x * oneSize, y * oneSize), Quaternion.identity));
    }

    public void GenRandomMap()
    {
        mapData[3 * col + 5] = MONSTER;
        int r = 0, c = 0;
        for (r = 0; r < row; r++)
        {
            mapData[r * col] = WALLBRICK;
            DrawBrick(r, 0);
            for (c = 0; c < col-1; c++)
            {
                if ((r == 0) || (r == row-1))
                {
                    mapData[r * col] = WALLBRICK;
                    DrawBrick(r, c);
                    continue;
                }
                if (mapData[r * col + c] == MONSTER)
                {
                    Debug.Log("monster at "+r+c);
                    DrawItem(monsterObj, r, c);
                    continue;
                }
                if (mapData[r * col + c] == GUN)
                {
                    Debug.Log("gun at " + r + c);
                    DrawItem(gunObj, r, c);
                    continue;
                }
                if (Random.Range(0, 8) == 3) {
                    mapData[r * col + c] = WALLBRICK;
                    DrawBrick(r, c);
                } else
                {
                    mapData[r * col + c] = NOTHING;
                }
            }
            mapData[(r + 1) * col - 1] = WALLBRICK;
            DrawBrick(r, c-1);
        }
        
    }

    public void SetItem(int x, int y, char ob)
    {
        mapData[x * col + y] = ob;
    }

    public void CreateMap(int rows, int cols)
    {
        mapData = new char[rows * cols];
        row = rows;
        col = cols;
    }
	// Use this for initialization
	void Start () {
        //GameObject.Instantiate(gunObj, new Vector2(3f, 3f), Quaternion.identity);
        CreateMap(40, 30);
        SetItem(3, 3, GUN);
        GenRandomMap();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        bricks.ForEach(new System.Action<GameObject>(Destroy));
    }
}
