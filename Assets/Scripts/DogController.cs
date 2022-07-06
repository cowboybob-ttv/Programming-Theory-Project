using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : Animal
{
    private SpriteRenderer dogSprite;
    private Animator dogAnim;
    
    void Start()
    {
        dogSprite = GetComponent<SpriteRenderer>();
        dogAnim = GetComponent<Animator>();
    }

    //Polymorphism
    public override void Update()
    {
        DogMovement();
        DestroyOutOfBounds(gameObject);
    }

    //Inheritance
    public void DogMovement()
    {
        if (buttonRun && buttonValue >= 2)
        {
        //speed = 4;
        dogAnim.SetBool("Interaction", true);
        dogSprite.flipX = false;
        AnimalMovement(4);
        }
    }
}
