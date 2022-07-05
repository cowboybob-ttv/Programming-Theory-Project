using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : Animal
{
    public static bool catRun = false;
    private SpriteRenderer catSprite;
    private Animator catAnim;
    
    void Start()
    {
        catSprite = GetComponent<SpriteRenderer>();
        catAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CatMovement();
    }

    public void CatMovement()
    {
        if (catRun)
        {
        speed = 2;
        catAnim.SetBool("Interaction", true);
        catSprite.flipX = false;
        AnimalMovement();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            catRun = true;
        }
        Debug.Log("Touched Cat");
    }
}
