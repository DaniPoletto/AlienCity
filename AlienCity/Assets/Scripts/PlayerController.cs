using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
	public float RotationSpeed;
	CharacterController cc;
	private Animator anim;
	protected Vector3 gravidade = Vector3.zero;
	protected Vector3 move = Vector3.zero;
	private bool jump = false;
    public int key = 0;
    public int pode_abrir = 0;
    public int estag_cai = 0;

    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    int vezes = 2;
    public Image vida1;
    public Image vida2;
    public Image vida3;
    public Image chave1;
    public Image chave2;
    //Texto para pontuação
    private int score;
    public Text ScoreText;

    void Start()
	{
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator>();
		anim.SetTrigger("Parado");

        // Set the initial health of the player.
        currentHealth = startingHealth;
        chave1.enabled = false;
        chave2.enabled = false;
        ScoreText.text = "0";
    }

	void Update()
	{
		Vector3 move = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * MoveSpeed;
		transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * RotationSpeed * Time.deltaTime, 0));
		
		if (!cc.isGrounded) {
			gravidade += Physics.gravity * Time.deltaTime;
		} 
		else 
		{
			gravidade = Vector3.zero;
			if(jump)
			{
				gravidade.y = 6f;
				jump = false;
			}
		}
		move += gravidade;
		cc.Move (move* Time.deltaTime);
		Anima ();

        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }
	 
	void Anima()
	{
		if (!Input.anyKey)
		{
			anim.SetTrigger("Parado");
		} 
		else 
		{
			if(Input.GetKeyDown("space"))
			{
				anim.SetTrigger("Pula");
				jump = true;
			}
			else
			{
				anim.SetTrigger("Corre");
			}
		}
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            key = key + 1;
            if(chave1.enabled == false)
            {
                chave1.enabled=true;
            }
            else
            {
                chave2.enabled = true;
            }
        }
        if (other.gameObject.CompareTag("abrir_porta"))
        {
            pode_abrir = 1;
        }
        if (other.gameObject.CompareTag("estag"))
        {
            estag_cai = 1;
        }
        if (other.gameObject.CompareTag("estag2"))
        {
            estag_cai = 2;
        }
    }
    public int Key()
    {
        return key;
    }
    public int PodeAbrir()
    {
        return pode_abrir;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("Tocando "+hit.collider.tag);
        hit.collider.gameObject.GetComponent<Animator>().SetTrigger("abre_plat");
    }

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead && vezes==0)
        {
            // ... it should die.
            Death();
        }else if (currentHealth <= 0)
        {
            // Set the initial health of the player.
            currentHealth = startingHealth;
            vezes = vezes - 1;
            if (vida3.enabled==true)
            {
                vida3.enabled = false;
            }
            else if(vida2.enabled==true)
            {
                vida2.enabled = false;
            }
            else
            {
                vida1.enabled = false;
            }
            
            
        }

    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
        //playerShooting.DisableEffects();

        // Tell the animator that the player is dead.
        //anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        // Turn off the movement and shooting scripts.
        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
        Debug.Log("Morreu");
        Application.LoadLevel("Jogo");
    }

    //faz calculo da pontuação (tiro no alien)
    public void AddScore(int newScore)
    {
        score += newScore;
        ScoreText.text = score.ToString();
    }

}
