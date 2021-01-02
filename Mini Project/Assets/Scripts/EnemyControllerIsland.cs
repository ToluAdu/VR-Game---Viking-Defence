using UnityEngine.AI;
using UnityEngine;

public class EnemyControllerIsland: MonoBehaviour
{


    
    NavMeshAgent agent;
    Transform player;
    public Vector3 target;


    //^&^&^^&^&^&^&^^&^&^
    //public Animator anim;
    

    //^&^&^^&^&^&^&^^&^&^

    public enum States
    {
        march,
        chasePlayer,
        attack
    }

    States _state = States.march;
    void Start()
    {
        
        //GameObject tt = GameObject.Find("Castle");
        GameObject tt = GameObject.FindGameObjectWithTag("city");
        target = tt.transform.position;

        //^&^&^^&^&^&^&^^&^&^
       
        //anim.SetInteger("State", 0); // idle 0
        //^&^&^^&^&^&^&^^&^&^

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
        }


     
    }

    void ChangeStates()
    {
        float distance = 0;

        if (player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
        }
        else
        {
            _state = States.march;
            return;
        }

        if (distance < 20)    //if player can be seen, chase the player
        {
           
            switch (_state)
            {
                case States.march:
                    _state = States.chasePlayer;
                    break;
                case States.chasePlayer:
                    break;
                case States.attack:
                    break;
            }
        }
        else if (distance < 1)   //if the player is close, attack the player
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
            }
        }
        else
        {
            //if player is too far, goes into the village
       
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
            }
           
        }

    }

    void Marching()
    {
        //anim.SetInteger("State", 1); // idle 0
        agent.SetDestination(target);
       
    }

    void Chase()
    {
        if (player)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.enabled = false;
        }
    }
    void Attacking()
    {
       
        
    }
}

