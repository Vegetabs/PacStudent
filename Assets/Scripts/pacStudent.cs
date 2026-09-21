using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class pacStudent : MonoBehaviour
{   
    [SerializeField]
    private entityTileset playerSprite;
    private Vector3[] cornerArr = new Vector3[]
    {
        new Vector3(7.5f,7.5f,0.3f),
        new Vector3(12.33f,7.5f,0.3f),
        new Vector3(12.33f,11.5f,0.3f),
        new Vector3(7.5f,11.5f,0.3f)
    };
    private TweenManager tweener;
    private Animator anim;
    private int index;
    private float musicTimer;
    private AudioSource moveSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSound = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        tweener = GetComponentInChildren<TweenManager>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*/
        if (    Input.GetKeyDown(KeyCode.W))
        {
            playerSprite.setDirection(new Vector2(0.0f, 1.0f));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            playerSprite.setDirection(new Vector2(0.0f, -1.0f));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            playerSprite.setDirection(new Vector2(-1.0f, 0.0f));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerSprite.setDirection(new Vector2(1.0f, 0.0f));
        }
        /*/
        tweener.updateTween();

        if (tweener.getActive() == false)
        {
            newTween();
        }

        if (musicTimer >= 1f)
        {
            musicTimer = 0f;
            moveSound.Play();
        }

        musicTimer += Time.deltaTime;
    }

    private void newTween()
    {
        Vector3 from = cornerArr[index];
        if (index >= cornerArr.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        Vector3 to = cornerArr[index];
        float duration = Vector3.Distance(from, to)/4f;
        tweener.newTween(transform, from, to, duration);
        Vector3 dir = (to-from).normalized;
        anim.SetFloat("dirX", dir.x*-1);
        anim.SetFloat("dirY", dir.y);
    }
}
