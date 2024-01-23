using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    [SerializeField] private float _velocity = 1.5f;
    public int Score = 0;
    public Text scoreText;
    private Rigidbody _rb;
    private Animation thisAnimation;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            _rb.velocity = Vector2.up * _velocity;
            thisAnimation.Play();


        }
            


    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == ("Score"))
        {
            Score += 1;
            scoreText.text = "Score: " + Score.ToString();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameLose");
        }
    }

}
