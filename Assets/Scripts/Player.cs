using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerFlapForce;
    private Animation thisAnimation;
    Rigidbody p_rb;
    Vector3 TopBorder, BottomBorder;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        p_rb = GetComponent<Rigidbody>();
        TopBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
        BottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        
    }
    float timer;
    float floatTimer;
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer = -1;
        }
        if (Input.GetKey(KeyCode.Space) && timer < 0 && Time.timeScale!=0)
        {
            floatTimer = 0;
            timer = 0.2f;
            thisAnimation.Play();
            p_rb.AddForce(Vector3.up * PlayerFlapForce, ForceMode.Impulse);
        }
        transform.position = new Vector3(transform.position.x, 
            Mathf.Clamp(transform.position.y, -10, TopBorder.y - 0.5f), transform.position.z);
        if(transform.position.y > TopBorder.y - 0.51f)
        {
            p_rb.velocity = Vector3.down*0.6f;
        }
        if (transform.position.y < BottomBorder.y)
        {
            GameManager.instance.GameOver();

        }
        p_rb.AddForce(Vector3.down * floatTimer*2, ForceMode.Acceleration);
        floatTimer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (ObstacleSpawner.instance.obstacles.Contains(collision.gameObject))
        {
            GameManager.instance.GameOver();
        }
    }
}
