using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float YMin = -3.9f;
    private float YMax = 3.9f;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);
        transform.position = new Vector3(-5.81f, Mathf.Clamp(transform.position.y, YMin, YMax), -0.04771193f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Obstacle")
        {
            gm.Loser();
        }
        if (collision.gameObject.tag=="Score")
        {
            gm.ScoreIncrement();
        }
    }
}
