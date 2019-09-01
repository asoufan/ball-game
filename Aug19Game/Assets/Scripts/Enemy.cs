using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    private  int speed = 4;
    public GameObject effect;
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            c.GetComponent<PlayerController>().health -= damage;

            if (c.GetComponent<PlayerController>().health > 10)
            {
                c.GetComponent<PlayerController>().health = 10;
            }

            Debug.Log(c.GetComponent<PlayerController>().health);

            Instantiate(effect, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
