using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : Animal
{
    public static bool dogRun = false;
    private SpriteRenderer dogSprite;
    private Animator dogAnim;
    
    void Start()
    {
        dogSprite = GetComponent<SpriteRenderer>();
        dogAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DogMovement();
    }

    public void DogMovement()
    {
        if (dogRun)
        {
        speed = 4;
        dogAnim.SetBool("Interaction", true);
        dogSprite.flipX = false;
        AnimalMovement();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dogRun = true;
        }
        Debug.Log("Touched Dog");
    }
}
