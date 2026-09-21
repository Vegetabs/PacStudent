using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private Vector2[] dirs;
    private entityTileset child;
    private float timer;
    private float elapsedTime;
    private int index;
    private enum State { NORMAL, SCARE, RECOVER, DEAD }
    private State curState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        elapsedTime = 0;
        index = 1;
        curState = State.NORMAL;
        child = GetComponentInChildren<entityTileset>();
        child.setDirection(dirs[0]);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer >= 0.5f)
        {
            child.setDirection(dirs[index]);
            if (index < dirs.Length - 1)
            {
                index++;
            } else
            {
                index = 0;
            }
            elapsedTime += timer;
            timer = 0;
        }
        if (elapsedTime >= 3.0f)
        {
            if (curState == State.NORMAL)
            {
                child.setBool("is_scared", true);
                curState = State.SCARE;
            }
            else if (curState == State.SCARE)
            {
                child.setFloat("scared_timer", 3.1f);
                curState = State.RECOVER;
            }
            else if (curState == State.RECOVER) 
            {
                child.setFloat("scared_timer", 0.0f);
                child.setBool("is_dead", true);
            }
            else if (curState == State.DEAD)
            {
                child.setBool("is_dead",false);
                child.setBool("is_scared", false);
                curState = State.NORMAL;
            }
            elapsedTime = 0;
        }
    }
}
