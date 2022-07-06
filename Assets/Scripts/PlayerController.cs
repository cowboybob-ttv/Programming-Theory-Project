using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public GameObject finishedPopUp;
    private float xPopUp = 20f;
    private Animator playerAnim;
    private SpriteRenderer playerSprite;
    private float xBound = -13f;


    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        PlayerMovement();
        ConstrainPlayer();
        GameFinished();
    }

    public void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerAnim.SetFloat("speed", Mathf.Abs(horizontalInput));

        transform.Translate(Vector2.left * Time.deltaTime * speed * horizontalInput);
        if (horizontalInput < 0)
        {
            playerSprite.flipX = false;
        }

        else if (horizontalInput > 0)
        {
            playerSprite.flipX = true;
        }
    }

    public void ConstrainPlayer()
    {
        if (transform.position.x < xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        } 
    }

    public void GameFinished()
    {
        if (transform.position.x > xPopUp)
        {
            finishedPopUp.SetActive(true);
            Time.timeScale = 0;
        }
    }    
}
