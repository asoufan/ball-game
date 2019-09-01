using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float health = 10;
    private Rigidbody2D ball;
    private Vector2 moveVelocity;
    public Text healthdisplay;

    void Start(){
        this.gameObject.tag = "Player";
        ball = GetComponent<Rigidbody2D>();
    }

    void Update(){

        healthdisplay.text = health.ToString();
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //GetAxisRaw and not GetAxis to prevent gradual speed/acceleration and allow snappy stopping
        moveVelocity = input.normalized * speed; //normalized prevents diagonal movement from covering more distance
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void FixedUpdate(){

        ball.MovePosition(ball.position + moveVelocity * Time.fixedDeltaTime);
    }
}