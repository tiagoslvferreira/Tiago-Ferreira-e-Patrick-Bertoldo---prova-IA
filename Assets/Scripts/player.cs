using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    public float speed2 = 9f;
    public float speed3 = 2f;
    private SpriteRenderer vira;
    public Rigidbody2D rb;
    public float forcaPulo;
    private bool pisouChao;
    private bool pisouChao2;
    public LayerMask chao;
    private Animator anima;
    private PolygonCollider2D polygonCollider;

     private float currentSpeed;
    

    float horizontalInput = 0f;


    private bool isJumping = false;
    private bool isWalking = false;
    private bool isRuning = false;


    public enum estadoPerso 
    { Idle,  Walk, Jump, Slide, Agachar, Correr, Corrarde4, AndarAgachado, AtaqueLateral, AtaqueBaixo, AtaqueCima, Rolar, WallSlider, Climb, IdleClimb }


    private estadoPerso estadoAnima;


    void Start()
    {
        vira = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        estadoAnima = estadoPerso.Idle;
        
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");


       if (horizontalInput < 0f && pisouChao)
        {
            vira.flipX = false;
            transform.position -= new Vector3(1 * speed * Time.deltaTime, 0, 0);
            estadoAnima = estadoPerso.Walk;

        // CORRER
        if (Input.GetKeyDown(KeyCode.LeftShift) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.Correr;
            pisouChao = false;
            rb.velocity -= new Vector2(speed * 4, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.LeftShift) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity += new Vector2(speed, rb.velocity.y);
        }

        // CORRER DE 4
        if (Input.GetKeyDown(KeyCode.LeftControl) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.Corrarde4;
            pisouChao = false;
            rb.velocity -= new Vector2(speed * 4, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.LeftControl) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity += new Vector2(speed, rb.velocity.y);
        }

        // DESLIZAR - SLIDE
        if (Input.GetKeyDown(KeyCode.V) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.Slide;
            pisouChao = false;
            rb.velocity -= new Vector2(speed * 4, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.V) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity += new Vector2(speed, rb.velocity.y);
        }

        // ROLAR
        if (Input.GetKeyDown(KeyCode.R) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.Rolar;
            pisouChao = false;
            rb.velocity -= new Vector2(speed * 4, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.R) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity += new Vector2(speed, rb.velocity.y);
        }

        // SNEAK
        if (Input.GetKeyDown(KeyCode.F) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.AndarAgachado;
            pisouChao = false;
            rb.velocity -= new Vector2(speed * 2, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.F) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity += new Vector2(speed, rb.velocity.y);
        }

        }
        else if (horizontalInput > 0f && pisouChao)
        {
            vira.flipX = true;
            transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
            estadoAnima = estadoPerso.Walk;

        //CORRER
        if (Input.GetKeyDown(KeyCode.LeftShift) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.Correr;
            pisouChao = false;
            rb.velocity += new Vector2(speed * 4, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.LeftShift) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity -= new Vector2(speed, rb.velocity.y);
        }

        // CORRER DE 4
        if (Input.GetKeyDown(KeyCode.LeftControl) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.Corrarde4;
            pisouChao = false;
            rb.velocity += new Vector2(speed * 4, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.LeftControl) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity -= new Vector2(speed, rb.velocity.y);
        }

        // DESLIZAR - SLIDE
        if (Input.GetKeyDown(KeyCode.V) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.Slide;
            pisouChao = false;
            rb.velocity += new Vector2(speed * 4, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.V) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity -= new Vector2(speed, rb.velocity.y);
        }

        // ROLAR 
        if (Input.GetKeyDown(KeyCode.R) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.Rolar;
            pisouChao = false;
            rb.velocity += new Vector2(speed * 4, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.R) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity -= new Vector2(speed, rb.velocity.y);
        }

         // SNEAK
        if (Input.GetKeyDown(KeyCode.F) && pisouChao)
        {
            isRuning = true;
            estadoAnima = estadoPerso.AndarAgachado;
            pisouChao = false;
            rb.velocity += new Vector2(speed * 2, rb.velocity.y);
        }

        else if(Input.GetKeyDown(KeyCode.F) && pisouChao)
        {
            isRuning = false;
            estadoAnima = estadoPerso.Walk;
            pisouChao = true;
            rb.velocity -= new Vector2(speed, rb.velocity.y);
        }

        }


        if (pisouChao && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode2D.Impulse);
            rb.AddForce(horizontalInput * Vector3.right, ForceMode2D.Impulse);
            pisouChao = false;
            estadoAnima = estadoPerso.Jump;
        }
        else if (pisouChao && horizontalInput == 0)
        {
            estadoAnima = estadoPerso.Idle;
        }

        if (Input.GetKeyDown(KeyCode.E) && pisouChao)
        {
            estadoAnima = estadoPerso.Agachar;
            pisouChao = false;
        }
        

         if (Input.GetKeyDown(KeyCode.Z) && pisouChao)
        {
            ChangeTag();
            Invoke("ResetTag", 1f);
            estadoAnima = estadoPerso.AtaqueCima;
            pisouChao = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && pisouChao)
        {
            ChangeTag();
            Invoke("ResetTag", 1f);
            estadoAnima = estadoPerso.AtaqueBaixo;
            pisouChao = false;
        }

        if (Input.GetKeyDown(KeyCode.C) && pisouChao)
        {
            ChangeTag();
            Invoke("ResetTag", 1f);
            estadoAnima = estadoPerso.AtaqueLateral;
            pisouChao = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && pisouChao)
        {
            estadoAnima = estadoPerso.Rolar;
            pisouChao = false;
        }
     
        if (Input.GetKeyDown(KeyCode.Q))
        {
            estadoAnima = estadoPerso.WallSlider;
            pisouChao = false;
        }

        if (Input.GetKeyDown(KeyCode.Y) && pisouChao)
        {
            estadoAnima = estadoPerso.IdleClimb;
            pisouChao = false;
        }

        if (Input.GetKeyDown(KeyCode.U) && pisouChao)
        {
            estadoAnima = estadoPerso.Climb;
            pisouChao = false;
        }


        Atualiza();
    }

    
    void Atualiza()
    {
        switch (estadoAnima)
        {
            case estadoPerso.Idle:
                anima.Play("idle");
                break;


            case estadoPerso.Walk:
                anima.Play("walk");
                break;


            case estadoPerso.Jump:
                anima.Play("jump");
                break;


            case estadoPerso.Slide:
                StartCoroutine(SlideAnimation());
                break;


             case estadoPerso.Agachar:
                StartCoroutine(AgacharAnimation());
                break;


            case estadoPerso.Correr:
                StartCoroutine(CorrerAnimation());
                break;


             case estadoPerso.AndarAgachado:
                StartCoroutine(AndarAgachadoAnimation());
                break;

            case estadoPerso.AtaqueCima:
                StartCoroutine(AtaqueCimaAnimation());
                break;
            
             case estadoPerso.AtaqueBaixo:
                StartCoroutine(AtaqueBaixoAnimation());
                break;

             case estadoPerso.AtaqueLateral:
                StartCoroutine(AtaqueLateralAnimation());
                break;

            case estadoPerso.Rolar:
                StartCoroutine(RolarAnimation());
                break;

            case estadoPerso.Corrarde4:
                StartCoroutine(Correrde4Animation());
                break;

            case estadoPerso.WallSlider:
                StartCoroutine(WallSliderAnimation());
                break;
            
            case estadoPerso.IdleClimb:
                StartCoroutine(IdleClimbAnimation());
                break;

            case estadoPerso.Climb:
                StartCoroutine(ClimbAnimation());
                break;

        }
    }

    
    IEnumerator SlideAnimation()
    {
        anima.Play("slide em pé"); // Substitua "slide_em_pe" pelo nome da animação de deslize em pé
        yield return new WaitForSeconds(1.0f); // Ajuste esse valor conforme necessário
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;


    }


    IEnumerator AgacharAnimation()
    {
        anima.Play("idle agachado");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }


    IEnumerator CorrerAnimation()
    {
        anima.Play("run de pé");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }
    IEnumerator AndarAgachadoAnimation()
    {
        anima.Play("andar agachando");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }

     IEnumerator AtaqueCimaAnimation()
    {
        anima.Play("attack cima");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }

     IEnumerator AtaqueBaixoAnimation()
    {
        anima.Play("attack baixo");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }

     IEnumerator AtaqueLateralAnimation()
    {
        anima.Play("attack lateral");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }

    IEnumerator Correrde4Animation()
    {
        anima.Play("run on four");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }

    IEnumerator RolarAnimation()
    {
        anima.Play("rolar");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }

    IEnumerator IdleClimbAnimation()
    {
        anima.Play("idle escalando");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }

    IEnumerator ClimbAnimation()
    {
        anima.Play("escalando");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }

    IEnumerator WallSliderAnimation()
    {
        anima.Play("slide parede");
        yield return new WaitForSeconds(1.0f);
        estadoAnima = estadoPerso.Idle;
        pisouChao = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("pedra"))
        {
            Destroy(this.gameObject);
        }
    
        if (col.gameObject.layer == 6)
        {
            pisouChao = true;
        }

        if (col.gameObject.layer == 7)
        {
            pisouChao2 = true;
        }
    }

    private void ChangeTag()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (player != null)
        {
            player.tag = "playerATT";
            Debug.Log("Player tag changed to 'PlayerATT'.");
        }
        else
        {
            Debug.LogError("Player GameObject not found in the scene.");
        }
    }

     private void ResetTag()
    {
        GameObject player = GameObject.FindGameObjectWithTag("playerATT");
        if (player != null)
        {
            player.tag = "player";
            Debug.Log("Player tag reset to 'Player'.");
        }
        else
        {
            Debug.LogError("PlayerATT GameObject not found in the scene.");
        }
    }

    //aiai 
}