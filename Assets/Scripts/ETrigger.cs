using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETrigger : MonoBehaviour
{
    [SerializeField] private GameObject instruction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            instruction.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            instruction.SetActive(false);
        }
    }

    private void Start()
    {
        instruction.SetActive(false);
    }
}
