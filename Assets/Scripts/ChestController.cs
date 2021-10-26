using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private GameObject particles;

    public static bool isOpened;

    //Action allowed if player is within the collider
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            isOpened = true;
            anim.SetBool("isOpening", isOpened);
            particles.SetActive(true);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
}
