using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Target;
    private Vector3 agentSpeed;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agentSpeed = agent.velocity;
            //print(agent.velocity);
            var pos = GameObject.FindGameObjectWithTag("Player");
            agent.destination = pos.transform.position;
            float distance = Vector3.Distance(gameObject.transform.position, pos.transform.position);
            //print(distance);
            if (distance < 2f)
            {
                gameObject.GetComponent<Animator>().SetTrigger("attack");
                agent.velocity = Vector3.zero;
            }
            else
                gameObject.GetComponent<Animator>().ResetTrigger("attack");
            //agent.velocity = agentSpeed;
        }
    }

    void Attack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<player>().health -= 1;
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<sfxController>().Attack();
    }

    void Destroyed()
    {
        Destroy(gameObject, 0.2f);
        gameObject.GetComponent<Animator>().ResetTrigger("died");
    }
}
