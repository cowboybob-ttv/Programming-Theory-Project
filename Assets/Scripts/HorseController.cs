using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : Animal
{    
    private SpriteRenderer horseSprite;
    private Animator horseAnim;
    
    void Start()
    {
        horseSprite = GetComponent<SpriteRenderer>();
        horseAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        HorseMovement();
        DestroyOutOfBounds(gameObject);
    }

    public void HorseMovement()
    {
        if (buttonRun && buttonValue >= 1)
        {
        //speed = 6;
        horseAnim.SetBool("Interaction", true);
        horseSprite.flipX = false;
        AnimalMovement(6);
        }
    }
}
