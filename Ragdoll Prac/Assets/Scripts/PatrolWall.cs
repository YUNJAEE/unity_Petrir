using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWall : MonoBehaviour
{
    public Animator animator;
    public GameObject objPlayer;

    void Start()
    {
        animator.SetTrigger("WallMove");
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter : " + other.gameObject);
        if (objPlayer.transform.parent == null)
        {
            objPlayer.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit : " + other.gameObject);
    }
}
