using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public GameObject runButton;
    //Encapsulation
    public float speed { set; get; }
    //Encapsulation
    public int buttonValue {get; set;}
    protected bool buttonRun = false;
    public static float xDestroy = 20f;

    public virtual void Update()
    {
        DestroyOutOfBounds(gameObject);
    }

    //Abstraction
    public void AnimalMovement(float speed)
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed * -1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            runButton.SetActive(true);
        }
        Debug.Log("Touched Animal");
    }

    //Abstraction
    public void Button1Bool()
    {
        buttonRun = true;
        buttonValue++;
        runButton.SetActive(false);
    }

    //Abstraction    
    public void DestroyOutOfBounds(GameObject gameObject)
    {
        if (transform.position.x > xDestroy)
        {
            Destroy(gameObject);
            buttonRun = false;
        }
    }
}
