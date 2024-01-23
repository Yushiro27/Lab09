using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody RB;
    public float hight;
    private Animation thisAnimation;
    public GameManager Gamemanager;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            RB.velocity = new Vector3(RB.velocity.x, hight, RB.velocity.z);
        }

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -8, 4));
        if (transform.position.y <= -7)
        {
            SceneManager.LoadScene("GameLose");
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreIncrease"))
        {
            Gamemanager.UpdateScore(1);
        }
    }
}
