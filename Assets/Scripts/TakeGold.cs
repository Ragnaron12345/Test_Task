using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class TakeGold : MonoBehaviour
{
    private GameObject CurrentGold;
    private int GoldCountCount = 0;
    public LayerMask whatCanBeClickedOn;
    public Text GoldCount;
    private NavMeshAgent myAgnet;
    public GameObject Hub;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoldTriger"))
        {
            MoveToPosition(Hub.transform);
            GoldCountCount++;
            GoldCount.GetComponent<Text>().text = GoldCountCount.ToString();
            CurrentGold = other.gameObject;

        }
        if (other.gameObject.CompareTag("Hub"))
        {
            print("hello");
            if (CurrentGold.gameObject.GetComponentInParent<GoldResistance>().GoldResist > 0)
            {
                MoveToPosition(CurrentGold.transform);
            }
        }
    }



    public void MoveToPosition(Transform? Pos = null)
    {
        if (Pos == null)
        {
            Pos = Hub.transform;
        }
        myAgnet.SetDestination(Pos.position);

    }
}
