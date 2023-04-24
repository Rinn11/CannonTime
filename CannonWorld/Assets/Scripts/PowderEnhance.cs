using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderEnhance : MonoBehaviour
{
    public Animator anim;
    public GameObject door;
    public Vector2 size_;

    public SpriteRenderer m_SpriteRenderer;
    
    public GameObject _interact;
    
    public int doorType;
    private string doorNum;

    BoxCollider2D m_Collider;

    public Charicter2DController player;

    void Start ()
    {
        m_Collider = door.GetComponent<BoxCollider2D>();

        doorNum = " (" + doorType + ")";

        door = GameObject.Find("/Door"+doorNum);

        m_SpriteRenderer = _interact.GetComponent<SpriteRenderer>();

    }

void OnTriggerStay2D(Collider2D collider)
    {
        m_SpriteRenderer.enabled = true;

        if (Input.GetKeyDown(KeyCode.E)) {
            size_ = m_Collider.bounds.size;

            m_Collider.size = new Vector2(-1,2);

            anim.SetBool("doorOpen", true);
            doorType++;
        }
    }
}
