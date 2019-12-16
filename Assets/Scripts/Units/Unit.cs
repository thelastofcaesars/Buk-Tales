using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    public enum eMode { idle, wait, move, fight, chase, stopChase, defend, death};

    [Header("Inscribed")]
    // public bool drawGizmos;
    // public List<Waypoint> waypoints;
    public float speed = 4;
    public float range = 4;
    public int costGold = 100;
    //public float distanceToChase = 2; // as we use mathf we just need single float to decide when to chase player

    [Header("Dynamic")]
    [SerializeField]
    private eMode _mode = eMode.wait;

    public virtual void DestroyUnit()
    {
        // init animations of death, disable all skills
        Debug.Log("Destroyed!");
        TreeManager.RemoveUnit(this.gameObject);
        
        Destroy(this);
    }
    public virtual void Fight()
    {
        Debug.Log("Fight!");
    }
    public virtual void Move()
    {
        Debug.Log("Moving!");
    }

    public virtual void Defend()
    {
        Debug.Log("Defend!");
    }

    public virtual void Wait()
    {
        Debug.Log("Wait!");
    }

    private int health = 100;
    private int energy = 100;
    private int mana = 100;
    private int cost = 100; // how many types of cash? minerals, energy, sun power?
    
    private Sprite characterSprite;
    private Rigidbody rb;
    private Animator anim;

    public eMode mode
    {
        get
        {
            return _mode;
        }

        set
        {
            _mode = value;
        }
    }

    private void Start()
    {
        characterSprite = GetComponent<Sprite>();
        if(characterSprite == null)
        {
            Debug.LogWarning("There is no sprite attached to unit!");
        }
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("There is no rigidbody attached to unit!");
            rb = new Rigidbody();
        }
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogWarning("There is no animator attached to unit!");
        }
        MoveToWaypoint(0);
    }

    void MoveToWaypoint(int num)
    {
        //wpNum = num;
        //nav.SetDestination(waypoints[wpNum].pos);
        //nav.isStopped = true;
        //nav.updatePosition = false;

        mode = eMode.move;
    }

    /*void MoveToNextWaypoint()
    {
        int wpNum1 = wpNum + 1;
        if (wpNum1 >= waypoints.Count)
        {
            wpNum1 = 0;
        }

        MoveToWaypoint(wpNum1);
    }*/

    void GetHit(int damage)
    {
        health -= damage;
        CheckHealth();
    }
    void CheckHealth()
    {
        if(health <= 0)
        {
            DestroyUnit();
        }
    }

    void FixedUpdate()
    {
        switch (mode)
        {
            case eMode.fight:
                //Vector3 goalPos = waypoints[wpNum].pos;// nav.nextPosition;
                //if (RotateTowards(goalPos, angularSpeed * Time.fixedDeltaTime))
                //{
                //  nav.isStopped = false;
                //nav.updatePosition = true;
                // mode = eMode.move;
                //}
                Fight();
                break;

            case eMode.move:
                // Navigate towards the waypoint
                //if (!nav.pathPending && nav.remainingDistance <= nav.stoppingDistance)
                //{
                // We've reached the destination waypoint
                //  mode = eMode.wait;
                //}
                Move();
                break;

            case eMode.defend:
                Defend();
                break;

            case eMode.death:
                DestroyUnit();
                break;

            case eMode.wait:
                Wait();
                // Are we still waiting?
                //if (pathTime < waitUntil)
                //{
                //    break;
                //}
                // We've waited long enough, Move on to the next Waypoint
                //MoveToNextWaypoint();
                break;
                /*
            case eMode.chase:
                nav.SetDestination(InteractingPlayer.S.transform.position);
                nav.isStopped = false;
                nav.updatePosition = true;
                // Eventually, we'll check to see if the player is caught
                if (Mathf.Sqrt(Mathf.Pow(Mathf.Abs(transform.position.x - InteractingPlayer.S.transform.position.x), 2)
                    + Mathf.Pow(Mathf.Abs(transform.position.z - InteractingPlayer.S.transform.position.z), 2)) <= distanceToChasePlayer)
                {
                    playerCaught = true;        // yep, good-looking function ;)
                    GameManager.LevelFailure(); // idk what to do with events without possibility to call them from here lol 
                                                // maybe shot mode in future here
                }
                break;

            case eMode.stopChase:
                nav.SetDestination(waypoints[wpNum].pos);
                nav.isStopped = false;
                nav.updatePosition = true;
                playerCaught = false;
                mode = eMode.move;
                break;
                */
        }

    }
}