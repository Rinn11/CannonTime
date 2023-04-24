using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Charicter2DController : MonoBehaviour
{
    Animator anim;

    private float shotTime = 60;
    private bool hasShot = false;

    public ProjectileBehaviour ProjectilePrefab;
    public PowderEnhance PowderPrefab;    
    public Transform LanchOffset;

    public Rigidbody2D _rigidbody;

    private Vector2 whereMouse;

    private Vector3 mouse_pos;

    //public Transform target;
    private Vector3 object_pos;
    private float angle;

    public float forceScalar = 5f;
    private Vector2 forceDirection;

    // Start is called before the first frame update
    void Start()
    {
         //This gets the Animator, which should be attached to the GameObject you are intending to animate.
        anim = GetComponent<Animator> ();
         Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        forceDirection = mousePosInWorld - (Vector2)transform.position;

        Debug.DrawLine(transform.position, -forceDirection);
        
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -20;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;

        whereMouse.x = mouse_pos.x - object_pos.x;
        whereMouse.y = mouse_pos.y - object_pos.y;

        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);        

         if (Input.GetButtonDown("Fire1") && shotTime > 15)
        {
            Instantiate(ProjectilePrefab, LanchOffset.position, transform.rotation);
            CannonMove();  
            hasShot = true;
            
        } 
    
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
        shotTime = 0;
        
        hasShot = true;
    } 
    else if (shotTime > 20) {
        hasShot = false;
    }
    
    
    shotTime++;
    anim.SetBool("CannonShot", hasShot);
    }


    void CannonMove() 
    {
        _rigidbody.AddForce(-forceDirection.normalized * forceScalar, ForceMode2D.Impulse);
    }
}
    
