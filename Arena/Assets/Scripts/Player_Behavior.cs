using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public GameObject bullet;
    public float bulletSpeed = 45f;
    public LayerMask groundLayer;
    private float vInput;
    private float hInput;
    private bool jump = false;
    private bool shoot = false;
    private Rigidbody _rb; //capsule rigid body info
    private bool hasGun = false;
    private CapsuleCollider _col;
    private Game_Behavior _gameManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody>(); //check if RigidBody component exists
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<Game_Behavior>();
    }
    void Update()
    {
        
        vInput = Input.GetAxis("Vertical") * moveSpeed; //detects if up (W) or down (S) is pressed
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;//detects if up left (L) or right(D) is pressed

        if(IsGrounded () && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            shoot = true;
        }

        /* We comment out Transform & Rotate so we don't run two different kinds of player control 
            Translate takes in a Vector3 parameter to move the Player's TRANSFORM component
            Time.deltaTime supplies direction & speed Player needs to move
            forward/back along the z axis at the speed we calculated
        
            this.transform.Translate(Vector3.back * vInput * Time.deltaTime);
            this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */
    }

    void FixedUpdate()
    {
        if(jump)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse); //make player jump
            jump = false;
        }
        
        Vector3 rotation = Vector3.up * hInput; //left & right rotation
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime); //Vector3 retrun angle --> Euler angle

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if(shoot && hasGun)
        {
            shoot = false;
            GameObject newBullet = Instantiate(bullet, this.transform.position - //always shoot from the right side of capsule
                transform.right, this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
    }

    bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, 
            _col.bounds.min.y, _col.bounds.center.z);
        
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
            capsuleBottom, distanceToGround, groundLayer,
                QueryTriggerInteraction.Ignore);
        
        return grounded;
    }

    public void OnGun()
    {
        hasGun = true;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            _gameManager.Health -= 5;
        }
    }
}
