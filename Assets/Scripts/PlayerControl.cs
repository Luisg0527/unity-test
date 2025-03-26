using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Variables para el movimiento, la "física" del sprite, el sr para que se voltee el sprite, 
    // para detectar si está en el piso y para las animaciones
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rig;
    public SpriteRenderer sr;
    public bool isGrounded;
    Animator animatorController;

    // Inicia el controlador de animaciones al iniciar el juego
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    // En cada frame se checan estas condicionales para poder mover el sprite
    void Update()
    {
        // Se agrega el "&& isGrounded" para que solo salte si esta tocando una plataforma
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
            rig.AddForce(UnityEngine.Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
        if(rig.linearVelocity.y != 0) {
            UpdateAnimation(PlayerAnimation.jump);
        }
        if(rig.linearVelocity.x > 0) {
            transform.localScale = new Vector2(1,1);
        }
        else if (rig.linearVelocity.x < 0){
            transform.localScale = new Vector2(-1,1);
        }
    }

    // OnCollisionEnter2D y OnCollisionExit2D verifican si el sprite está tocando una plataforma para evitar el doble salto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground")) {
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground")) {
            isGrounded = false;
        }
    }

    // Similar al update, pero más rápido para poder mover y animar al sprite de manera fluida
    private void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        rig.linearVelocity = new Vector2(xInput*moveSpeed, rig.linearVelocity.y);
        if(xInput != 0 && rig.linearVelocity.y == 0) {
            UpdateAnimation(PlayerAnimation.walk);
        }
        else {
            UpdateAnimation(PlayerAnimation.idle);
        }
    }

    // Se definen las tres animaciones
    public enum PlayerAnimation {
        idle, walk, jump
    }

    // Se definen los booleanos para cada situación de cada animación
    void UpdateAnimation(PlayerAnimation nameAnimation) {
        switch(nameAnimation) {
            case PlayerAnimation.idle:
                animatorController.SetBool("IsWalking", false);
                animatorController.SetBool("IsJumping", false);
                break;
            case PlayerAnimation.walk:
                animatorController.SetBool("IsWalking", true);
                animatorController.SetBool("IsJumping", false);
                break;
            case PlayerAnimation.jump:
                animatorController.SetBool("IsWalking", false);
                animatorController.SetBool("IsJumping", true);
                break;
        }
    }
}
