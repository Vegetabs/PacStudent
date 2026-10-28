using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class pacStudent : MonoBehaviour
{   
    [SerializeField]
    private entityTileset playerSprite;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Vector2Int topLeftPos;
    private string[] level = LevelMap.getMap();
    private TweenManager tweener;
    private Animator anim;
    private int index;
    private float musicTimer;
    private AudioSource moveSound;
    private KeyCode lastInput = KeyCode.None;
    private KeyCode currentInput = KeyCode.None;
    private Vector2Int startPos = new Vector2Int(1,1);
    private Vector2Int curPos;

    void Start()
    {
        moveSound = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        tweener = GetComponentInChildren<TweenManager>();
        index = 0;
        curPos = startPos;
        transform.position = tileToWorld(curPos);
        Debug.Log(grid.WorldToCell(transform.position));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = KeyCode.W;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = KeyCode.S;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = KeyCode.A;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = KeyCode.D;
        }

        if (tweener.getActive())
        {
            tweener.updateTween();
            if (tweener.getActive()) 
            {
                return;
            }
        }

        if (tryMove(lastInput))
        {
            currentInput = lastInput;
        }
        else
        {
            tryMove(currentInput);
        }

        if (musicTimer >= 1f)
        {
            musicTimer = 0f;
            moveSound.Play();
        }

        musicTimer += Time.deltaTime;
    }
    private bool tryMove(KeyCode moveKey)
    {
        if (moveKey == KeyCode.None)
        {
            return false;
        }
        Vector2Int dir = getDirFromKey(moveKey);
        Vector2Int target = new Vector2Int(curPos.x + dir.x, curPos.y - dir.y);
        if (target.x < 0 || target.x >= level[0].Length || target.y < 0 || target.y >= level.Length)
        {
            return false;
        }
        if (level[target.y][target.x] == '1')
        {
            return false;
        }
        Vector3 from = tileToWorld(curPos);
        Vector3 to = tileToWorld(target);
        float duration = Vector2.Distance(from, to) / 5f;
        curPos = target;
        tweener.newTween(transform, from, to, duration);
        return true;
    }

    private static Vector2Int getDirFromKey(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W:
                return new Vector2Int(0, 1);
            case KeyCode.S:
                return new Vector2Int(0, -1);
            case KeyCode.A:
                return new Vector2Int(-1, 0);
            case KeyCode.D:
                return new Vector2Int(1, 0);
            default:
                return new Vector2Int(0, 0);
        }
    }

    private Vector3 tileToWorld(Vector2Int tile)
    {
        return grid.GetCellCenterWorld(new Vector3Int(topLeftPos.x + tile.x, topLeftPos.y - tile.y, 0));
    }
}
