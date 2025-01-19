using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 20;
    float rotation_speed = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.forward * speed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -rotation_speed * Time.deltaTime, 0));
        }
        else if  (Input.GetKey(KeyCode.RightArrow))
            {
            transform.Rotate(new Vector3(0, rotation_speed * Time.deltaTime, 0));
        }
    }
}
