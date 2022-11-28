using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgnet;

    public int KD;

    void Start()
    {
        myAgnet = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgnet.SetDestination(hitInfo.point); 
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy^^"))
        { 
            if (Vector3.Distance(other.transform.position,transform.position) > 1)
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
        if (other.gameObject.CompareTag("Enemy^^"))
        {
            other.gameObject.GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
        }
    }

    IEnumerator Attack()
    {
        print("Attack1");
        yield return new WaitForSeconds(1.0f);
    }


}