using System.Collections.Generic;
using UnityEngine;

public class pacStudent : MonoBehaviour
{   
    [SerializeField]
    private entityTileset playerSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
