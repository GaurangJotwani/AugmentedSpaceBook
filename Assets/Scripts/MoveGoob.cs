using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class MoveGoob : MonoBehaviour
{
    float speed = 0.5f;
    float turnSpeed = 1.0f;
    public bool dead = false;
    Animator anim;
    GameObject home;
    bool lookingForHome = true;
    AddOneToScore addOneToScore;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        InvokeRepeating("FindHome", 0, 1);
    }

    void FindHome() {
        home = GameObject.FindWithTag("home");
        if (home != null) {
            CancelInvoke();
            lookingForHome = true;
            addOneToScore = home.GetComponent<AddOneToScore>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet") {
            //Destroy(other, 0.1f);
            
            Hit();
        } else if  (other.gameObject.tag == "home") {
            Destroy(this.gameObject, 1);
            this.GetComponent<AudioSource>().Play();
        }
    }

    void Hit() {
        
        dead = true;
        anim.SetTrigger("IsDying");
        Destroy(this.GetComponent<Collider>(), 1);
        Destroy(this.GetComponent<Rigidbody>(), 1);
        addOneToScore.AddOne();
        

        Destroy(this.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) {
            return;
        }
        if (home != null)
        {
            Vector3 direction = home.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction),
                turnSpeed * Time.smoothDeltaTime);
        }
        else if (lookingForHome) {
            InvokeRepeating("FindHome", 0, 1);
            lookingForHome = false;
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
