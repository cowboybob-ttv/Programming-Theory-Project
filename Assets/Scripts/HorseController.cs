using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : Animal
{
    public static bool horseRun = false;
    private SpriteRenderer horseSprite;
    private Animator horseAnim;
    
    void Start()
    {
        horseSprite = GetComponent<SpriteRenderer>();
        horseAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorseMovement();
    }

    public void HorseMovement()
    {
        if (horseRun)
        {
        speed = 6;
        horseAnim.SetBool("Interaction", true);
        horseSprite.flipX = false;
        AnimalMovement();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            horseRun = true;
        }
        Debug.Log("Touched Horse");
    }
}
