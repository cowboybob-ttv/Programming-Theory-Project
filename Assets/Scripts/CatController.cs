using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : Animal
{
    private SpriteRenderer catSprite;
    private Animator catAnim;
    
    void Start()
    {
        catSprite = GetComponent<SpriteRenderer>();
        catAnim = GetComponent<Animator>();
    }

    //Polymorphism
    public override void Update()
    {
        CatMovement();
        DestroyOutOfBounds(gameObject);
    }

    //Inheritance
    public void CatMovement()
    {
        if (buttonRun && buttonValue >= 3)
        {
        //speed = 3;
        catAnim.SetBool("Interaction", true);
        catSprite.flipX = false;
        AnimalMovement(3);
        }
    }
}
