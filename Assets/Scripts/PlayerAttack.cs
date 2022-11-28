using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerAttack : MonoBehaviour
{
    private NavMeshAgent myAgnet;

    public int KD;

    // Start is called before the first frame update
    void Start()
    {
        myAgnet = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Vector3.Distance(other.transform.position, transform.position) > 1)
            {
                other.gameObject.GetComponent<NavMeshAgent>().SetDestination(transform.position);
            }
            else
            {
                other.gameObject.GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
                KD++;
                if (KD == 70)
                {
                    StartCoroutine(Attack());
                    KD = KD - KD;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
        }
    }

    IEnumerator Attack()
    {
        print("Attack2");
        yield return new WaitForSeconds(1.0f);
    }

}
