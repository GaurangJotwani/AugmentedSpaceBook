using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawnPos;
    public GameObject goob;
    float turnSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("ShootBullet", 1, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "goober" && goob == null) {
            goob = other.gameObject;
            InvokeRepeating("ShootBullet", 0, 3.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == goob) {
            goob = null;
            CancelInvoke("ShootBullet");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goob) {
            Vector3 direction = goob.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction),
                turnSpeed * Time.smoothDeltaTime);
        }
    }

    void ShootBullet() {
        this.GetComponent<AudioSource>().Play();
        if (goob.GetComponent<MoveGoob>().dead) {
            goob = null;
            CancelInvoke("ShootBullet");
        }
        Instantiate(bullet, spawnPos.transform.position, spawnPos.transform.rotation);

    }
}
