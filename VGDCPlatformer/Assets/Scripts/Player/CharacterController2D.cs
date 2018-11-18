using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    [SerializeField] private float m_JumpForce = 700f;
    [SerializeField] public int m_AirJumps = 0;
    [SerializeField] public float m_DefaultPounceCharge = 0f;
    [SerializeField] private float m_PounceCharge = 0f;
    [SerializeField] private float m_FallGravity = 4f;
    [SerializeField] private float m_DefaultFallGravity = 4f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private LayerMask m_GroundLayer;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private Transform m_HorizontalCheck;
    [SerializeField] private bool m_AirControl = false;


    [HideInInspector] public Rigidbody2D m_RigidBody2D;
    [HideInInspector] public SpriteRenderer m_SpriteRenderer;
    private bool m_Grounded;
    public bool m_NotPounced;
    private bool m_Charged;
    public bool m_FacingRight = true;
    private bool m_OnJumpPad = false;
    public bool m_Damaged;
    public bool m_Immune = false;
    public int m_AirJumpsLeft;
    private Vector3 m_Velocity = Vector3.zero;


    void Awake()
    {

        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        m_Grounded = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_GroundLayer);
        Debug.DrawLine(transform.position, m_GroundCheck.position, Color.yellow);
        if (m_Grounded)
        {
            JumpadOff();
            m_AirJumpsLeft = m_AirJumps;
            m_NotPounced = true;
            m_PounceCharge = 0;
            Color m_NewColor = new Color(0, 0, 0);
            m_SpriteRenderer.color = m_NewColor;
        }
    }

    public void Move(float move, bool jump, bool pounce)
    {

        //print(pounce);
        if (m_Grounded || m_AirControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, m_RigidBody2D.velocity.y);

            m_RigidBody2D.velocity = Vector3.SmoothDamp(m_RigidBody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }

        }

        JumpGravity(jump, pounce);

        if (m_Grounded && jump)
        {
            m_Grounded = false;
            m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));
        }

        //air Jump
        if (jump && m_AirJumpsLeft > 0)
        {
            m_Grounded = false;
            m_RigidBody2D.AddForce(new Vector2(0f, m_JumpForce));
            m_AirJumpsLeft--;
        }
        if (pounce && m_NotPounced)
        {
            m_Charged = true;
            m_PounceCharge += -0.2f;
            m_FallGravity *= 0.5f;
            Color m_NewColor = new Color(-1f * m_PounceCharge, 0, 0);
            m_SpriteRenderer.color = m_NewColor;

        }
        if (((pounce != true) && m_NotPounced && m_Charged) || (m_PounceCharge < -1f))
        {
            m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_PounceCharge * m_JumpForce - m_JumpForce));
            m_NotPounced = false;

            m_Charged = false;
            m_PounceCharge = m_DefaultPounceCharge;
            m_FallGravity = m_DefaultFallGravity;
        }
    }

    void JumpGravity(bool jump, bool pounce)
    {
        if (!pounce)
        {
            if (jump && m_AirJumpsLeft >= 1)
            {
                m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, 0);
            }

            if (m_RigidBody2D.velocity.y < 0) //we are falling
            {
                m_RigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (m_FallGravity - 1) * Time.deltaTime;
            }
            else if ((m_RigidBody2D.velocity.y > 0 || m_OnJumpPad) && !Input.GetButton("Fire1"))//tab jump
            {
                m_RigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (m_FallGravity - 1) * Time.deltaTime;
            }
            else if ((m_RigidBody2D.velocity.y > 0 || m_OnJumpPad) && Input.GetButton("Fire1") && m_OnJumpPad)
            {
                m_RigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (m_FallGravity - 1) * Time.deltaTime;
            }
        }
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "hurtBox" && this.gameObject.transform.position.y - collide.gameObject.transform.position.y >= 0)
        {
            m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, 25);
        }
        if (collide.gameObject.tag == "ladder")
        {
            m_Grounded = false;
        }

    }

    void OnTriggerStay2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "ladder")
        {

        }
    }

    void OnTriggerExit2D(Collider2D collide)
    {

    }


    //Used by other objects to check Character status
    public bool IsGrounded()
    {
        return m_Grounded;
    }

    public void JumpadOn()
    {
        m_OnJumpPad = true;
    }
    public void JumpadOff()
    {
        m_OnJumpPad = false;
    }
}
