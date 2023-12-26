using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    public float speed;

	private Animator anim;

	public int health;
	public TextMeshProUGUI healthDisplay;
	private float safeTime;
	public float startSafeTime;

	public int score;
	public TextMeshProUGUI scoreDisplay;

	public Animator hurtPanel;
	public GameObject damPopUp;

	public Animator cam;

	public GameObject losePanel;
	public bool isDead;

	public float dashBoost;
	private float dashTime;
	public float startDashTime;
	private bool once;

	private AudioSource source;

	private void Start()
	{
		source = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		healthDisplay.text = health.ToString();
	}

	private void Update()
	{

		if(Input.GetMouseButtonDown(1) && once == false){ 
			source.Play();
			speed += dashBoost;
			once = true;
			dashTime = startDashTime;
		}

		if (dashTime < 0 && once == true)
		{			
			speed -= dashBoost;
			once = false;
		} else{ 
			dashTime -= Time.deltaTime;
		}

		Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
		transform.position += moveInput.normalized * speed * Time.deltaTime;

		if(moveInput == Vector3.zero){ 
			anim.SetBool("isRunning", false);
		}else{
			anim.SetBool("isRunning", true);
		}

		if(safeTime > 0){ 
			safeTime -= Time.deltaTime;
		}

		scoreDisplay.text = score.ToString();

		if(health <= 0){ 
			losePanel.SetActive(true);
			speed = 0;
			isDead = true;
		}

	}

	public void TakeDam(int dam){ 
		if(safeTime <= 0){

			cam.SetTrigger("shake");

			GameObject instance = Instantiate(damPopUp, transform.position, Quaternion.identity);
			instance.GetComponentInChildren<TextMeshProUGUI>().text = "-" + dam;
			hurtPanel.SetTrigger("hurt");
			health -= dam;
			healthDisplay.text = health.ToString();
			safeTime = startSafeTime;
		}
		
	}
}
