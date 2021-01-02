using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class BossController : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    Animator animator;
    public AudioSource beingHit;
    
    public Slider healthBar;
    public Vector3 target;
    private float rotationSpeed = 5f;
    private GameObject playerScript;
    private float health = 100;
    
    public enum States
    {
        march,
        chasePlayer,
        attack,
        die
    }

    States _state = States.march;

    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        
        
    }


    void Start()
    {
        GameObject tt = GameObject.Find("Big Wooden House");
        target = tt.transform.position;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("IsMarching", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsDie", false);
        playerScript = GameObject.Find("OVRPlayerController");
        beingHit.Stop();
        
    }


    void Update()
    {
        ChangeStates();
        healthBar.value = health;
        switch (_state)
        {
            case States.march: Marching(); break;
            case States.chasePlayer: Chase(); break;
            case States.attack: Attacking(); break;
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
                case States.die:
                    _state = States.die;
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
    }

    void Chase()
    {
        if (player)
        {
            agent.SetDestination(player.position);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsMarching", true);
            animator.SetBool("IsDie", false);
        }
        else
        {
            agent.enabled = false;
        }
    }
    void Attacking()
    {
        RotateTowards(player);
        animator.SetBool("IsMarching", false);
        animator.SetBool("IsAttack", true);
        animator.SetBool("IsDie", false);
        
    }

    void Die()
    {
        //agent.enabled = false;
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsMarching", false);
        animator.SetBool("IsDie", true);
        
        StartCoroutine(WinCoroutine());
    }
    private void RotateTowards(Transform target)
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Axe")
        {
            beingHit.Play();
            health = health-10;
            for (int i = 0; i < 700; i++)/////////////////Working sometimes
            {
                OVRInput.SetControllerVibration(0.05f, 0.6f, OVRInput.Controller.RTouch);
            }
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
        if (other.gameObject.tag == "Sword_Snow")
        {
            beingHit.Play();
            health = health - 20;
            for (int i = 0; i < 700; i++)/////////////////Working sometimes
            {
                OVRInput.SetControllerVibration(0.05f, 0.6f, OVRInput.Controller.RTouch);
            }
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }

    }


   

    IEnumerator WinCoroutine()
    {

        yield return new WaitForSeconds(2);
        GameFinish GF = GameObject.Find("GameFinish").GetComponent<GameFinish>();
        GF.Win();
        
    }
}
