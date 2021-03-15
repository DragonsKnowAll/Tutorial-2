using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    private int scoreValue = 0;
    public Text winText;
    public Text livesText;
    private int livesValue = 3;

    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.text = "";
        livesText.text = livesValue.ToString();  // why do i have this? how do i life count?

          musicSource.clip = musicClipOne;
          musicSource.Play();

        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed)); 
        


        if (scoreValue == 8)
        {
            
            musicSource.clip = musicClipTwo;
            musicSource.Play();

            winText.text = "You Win!  Game created by Diana Studstill.";
            Destroy(this); 
        }

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
            // Enemy
        if (collision.collider.tag == "Enemy")
            {
            livesValue -= 1;
            livesText.text = livesValue.ToString();
            Destroy(collision.collider.gameObject);
      // Collide enemy/ changes lives then destroys enemy? 

        if (livesValue == 0)

            { // Lose text
                winText.text = "You Lose! Game created by Diana Studstill.";
                Destroy(this); 
                
            }
        } 

        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);

            if (scoreValue == 4) 
                {
            transform.position = new Vector3(57.0f, 3f, 0.0f);  
            livesText.text = livesValue.ToString();
            livesValue = 3;
                }
        }  

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}
