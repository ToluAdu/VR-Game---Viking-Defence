using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyControllerSnow : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;    
    Animator animator;
    public AudioSource swingSword;
    public AudioSource AxeHit;
    public AudioSource dieSound;
    public Vector3 target;
    public AudioSource beingHit;
    private float rotationSpeed = 10f;
    private GameObject playerScript;
    private float health = 10;

    public enum States
    {
        march,
        chasePlayer,
        attack,
        defense,
        die
    }

    States _state = States.march;
    void Start()
    {
        GameObject tt = GameObject.Find("Big Wooden House");
        target = tt.transform.position;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("IsMarching", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsDie", false);
        animator.SetBool("IsDefense", false);
        playerScript = GameObject.Find("OVRPlayerController");
        swingSword.Stop();
        dieSound.Stop();
        beingHit.Stop();
        AxeHit.Stop();
    }
    void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        ChangeStates();

        switch (_state)
        {
            case States.march: Marching(); break;
            case States.chasePlayer: Chase(); break;
            case States.attack: Attacking(); break;
            case States.defense: Defensing(); break;
            case States.die: Die(); break;
        }
        
    }

    void ChangeStates()
    {
        float distance = 0;
        float healthValue = health;
        if (player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
        }
        else
        {
            _state = States.march;
            return;
        }

        if (distance < 20 && distance > 3)    //if player can be seen, chase the player
        {
            switch (_state)
            {
                case States.march:
                    _state = States.chasePlayer;
                    break;
                case States.chasePlayer:
                    break;
                case States.attack:
                    _state = States.chasePlayer;
                    break;
                case States.defense:
                    _state = States.chasePlayer;
                    break;
                case States.die:
                    _state = States.chasePlayer;
                    break;
            }
        }
        else if (distance <= 3)   //if the player is close, attack the player
        {
            switch (_state)
            {
                case States.march:
                    _state = States.attack;
                    break;
                case States.chasePlayer:
                    _state = States.attack;
                    break;
                case States.attack:
                    break;
                case States.defense:
                    _state = States.attack;
                    break;
                case States.die:
                    _state = States.attack;
                    break;
            }
        }
        else
        {                  //if player is too far, goes into the village
            switch (_state)
            {
                case States.march:
                    break;
                case States.chasePlayer:
                    _state = States.march;
                    break;
                case States.attack:
                    _state = States.march;
                    break;
                case States.defense:
                    _state = States.march;
                    break;
                case States.die:
                    _state = States.march;
                    break;
            }
           
        }
        if (healthValue == 0)
        {
            switch (_state)
            {
                case States.march:
                    _state = States.die;
                    break;
                case States.chasePlayer:
                    _state = States.die;
                    break;
                case States.attack:
                    _state = States.die;
                    break;
                case States.defense:
                    _state = States.die;
                    break;
                case States.die:
                    break;
            }
        }

    }

    void Marching()
    {
        agent.SetDestination(target);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsMarching", true);
        animator.SetBool("IsDie", false);
        animator.SetBool("IsDefense", false);
    }

    void Chase()
    {
        if (player)
        {
            agent.SetDestination(player.position);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsMarching", true);
            animator.SetBool("IsDie", false);
            animator.SetBool("IsDefense", false);
        }
        else
        {
            agent.enabled = false;
        }
    }
    void Attacking()
    {
        RotateTowards(player);
        swingSword.Play();
        animator.SetBool("IsMarching", false);
        animator.SetBool("IsAttack", true);
        animator.SetBool("IsDie", false);
        animator.SetBool("IsDefense", false);

    }

    void Die()
    {        
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsMarching", false);
        animator.SetBool("IsDie", true);
        animator.SetBool("IsDefense", false);
        agent.enabled = false;
        
        Destroy(gameObject, 2f);
        
    }

    void Defensing()
    {
        animator.SetBool("IsDefense", true);
    }
    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Axe")
        {
            health = 0;
            AxeHit.Play();
            for (int i = 0; i < 700; i++)/////////////////Working sometimes
            {
                OVRInput.SetControllerVibration(0.05f, 0.6f, OVRInput.Controller.RTouch);
            }
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
        if(other.gameObject.tag == "Sword_Snow")
        {
            health = 0;
            beingHit.Play();

            for (int i = 0; i < 700; i++)/////////////////Working sometimes
            {
                OVRInput.SetControllerVibration(0.05f, 0.6f, OVRInput.Controller.RTouch);
            }
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
        if(other.gameObject.tag == "Shield")
        {
            _state = States.defense;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Axe")
       {
            health = health-10;
            Debug.Log("Enemy Health: " + health);
            
        }
    }

   
    
}

