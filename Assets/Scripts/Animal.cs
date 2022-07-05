using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float speed { set; get; }

    public void AnimalMovement()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed * -1);
    }
}
