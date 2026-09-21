using UnityEngine;

public class entityTileset : MonoBehaviour
{
    private Vector2 dir = new Vector2(1.0f,0.0f);
    private Animator anim;

    public void setDirection(Vector2 newDir)
    {
        if (dir == newDir)
        {
            return;
        }
        dir = newDir;
        anim.SetFloat("dirX", dir.x);
        anim.SetFloat("dirY", dir.y);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
