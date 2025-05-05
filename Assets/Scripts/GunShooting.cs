using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotSpeed = 1500f;
    [SerializeField] private int shotCount = 30;
    [SerializeField] private TextMeshProUGUI roadCount;
    private float shotInterval;

    private void Start()
    {
        
    }

    void Update()
    {
        

        float xRotation = this.transform.rotation.eulerAngles.x;

        roadCount.text = shotCount.ToString();
        if (Input.GetKey(KeyCode.Mouse0) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) 
        {
            shotInterval += 1;

            if (shotInterval % 5 == 0 && shotCount > 0)
            {
                shotCount -= 1;

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);

                //ŽËŒ‚‚³‚ê‚Ä‚©‚ç3•bŒã‚Ée’e‚ÌƒIƒuƒWƒFƒNƒg‚ð”j‰ó‚·‚é.

                Destroy(bullet, 3.0f);
            }
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 30;

        }

        

        else if (xRotation > 60f)
        {
            if (xRotation < 90f)
            {
                shotCount = 30;
            }
            
        }

    }
}
