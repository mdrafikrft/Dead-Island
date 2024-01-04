using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    
    Transform player;

    [SerializeField] Transform firingSpot;
    float timeBtwShots;
    [SerializeField] float startTimeBtwShots;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] GameObject scorePlusTextPrefab;
    
    //[SerializeField] AudioSource burstSound;

    //ShakeManager shake;
    Rigidbody2D enemyRb;
    private Score score;
    

    private void Start()
    {
        //shake = GameObject.FindGameObjectWithTag("ShakeManager").GetComponent<ShakeManager>();
        score = GameObject.FindGameObjectWithTag("score").GetComponent<Score>(); 
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyRb = GetComponent<Rigidbody2D>();
        
        timeBtwShots = startTimeBtwShots;

    }

    private void FixedUpdate()
    {
        Vector3 scale = transform.localScale;

        if (player != null)
        {
            //Character_One_Movement Towards The Player
            Vector3 direction = player.position - transform.position;
            enemyRb.velocity = new Vector3(direction.x, direction.y, 0f) * speed * Time.fixedDeltaTime;

            if (player.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1;
                transform.localScale = scale;
            }
            else if (player.position.x < transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }

            //Firing Projectile towards player :
            /*if (timeBtwShots <= 0)
            {
                Instantiate(projectile, firingSpot.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else if (timeBtwShots > 0)
            {
                timeBtwShots -= Time.deltaTime;
            }*/
        }
        else
        {
            enemyRb.velocity = new Vector3(0f, 0f, 0f);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //StartCoroutine(shake.cameraShake(1, 5));
            //shake.CamShake();
            ShakeManager.Instance.CamShake(20.0f, 0.1f);
            //burstSound.Play();
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            score.IncreaseScore(1);

            if(scorePlusTextPrefab != null)
            {
                showScoreText();
            }
            Destroy(gameObject);
        }
    }

    private void showScoreText()
    {
        Instantiate(scorePlusTextPrefab, transform.position, Quaternion.identity);
    }


}
