using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    float diag = Mathf.Sqrt(2);
    bool movingX = false;
    bool movingY = false;
    bool moving = false;
    float cos = 0f;
    Vector2 direction = new Vector2(0, 0);
    int directionInt = 0;

    public int moveForce = 80;
    public int moveSpeed = 5;
    public int sprintSpeed = 10;
    public int rotationSpeed = 15;
    public float friction = .9f;

    //references
    public GameObject model;
    Rigidbody rigidbody;


    //private
    private bool sprinting = false;
    private float speed;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        speed = moveSpeed;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //controls();
        
	}

    void FixedUpdate()
    {
        moving = false;
        controls();
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, speed);
        if (!moving)
        {
            rigidbody.velocity *= friction;
        }
        print(rigidbody.velocity);
    }

    void controls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(0, 0, moveForce);
            moving = true;
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(0, 0, -moveForce);
            moving = true;

        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(-moveForce, 0, 0);
            moving = true;

        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(moveForce, 0, 0);
            moving = true;

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = true;
            speed = sprintSpeed;
        }
        else { 
            sprinting = false;
            speed = moveSpeed;
        }
    }
}
