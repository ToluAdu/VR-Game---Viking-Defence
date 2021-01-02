using UnityEngine.AI;
using UnityEngine;

public class EnemyControllerIslandWanimation: MonoBehaviour
{


    
    NavMeshAgent agent;
    Transform player;
    public Vector3 target;
    

    bool enemydead;

    public float rotationSpeed = 10f;


    //^&^&^^&^&^&^&^^&^&^
    public Animator anim;
    

    //^&^&^^&^&^&^&^^&^&^

    public enum States
    {
        march,
        chasePlayer,
        attack,
        death
    }

    States _state = States.march;
    void Start()
    {
        
        //GameObject tt = GameObject.Find("Castle");
        GameObject tt = GameObject.FindGameObjectWithTag("city");
        target = tt.transform.position;

        //^&^&^^&^&^&^&^^&^&^
       
        anim.SetInteger("State", 0); // idle 0
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
        enemydead = GetComponent<targetpractice>().enemydown;
        Die();

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

        if (distance < 20 && distance > 4)    //if player can be seen, chase the player
        {
           
            switch (_state)
            {
                case States.march:
                    _state = States.chasePlayer;
                    break;
                case States.chasePlayer:
                    break;
                case States.attack:
                    _state = States.chasePlayer; //}{}{}}{{}{}{{}{
                    break;
            }
        }
        else if (distance < 4)   //if the player is close, attack the player
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
       // agent.isStopped = false;
        agent.SetDestination(target);
        anim.SetInteger("State", 1); // run

    }

    void Chase()
    {
        if (player)
        {
            //agent.isStopped = false;
            agent.SetDestination(player.position);
            anim.SetInteger("State", 1); // run
        }
        else
        {
            agent.enabled = false;
        }
    }
    void Attacking()
    {
      
        agent.SetDestination(player.position);
        anim.SetInteger("State", 2); // attack
        RotateTowards(player);

    }

    void Die()
    {
        if (enemydead)
        {
            anim.SetInteger("State", 3); //Die animation}
            agent.isStopped = true;
            
            enemydead = false;
        }
    }

    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }







}

