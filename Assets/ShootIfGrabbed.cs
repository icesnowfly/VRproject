using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootIfGrabbed : MonoBehaviour
{
    private SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
    public Text bulletText;
    public int numOfBullet = 10;
    // Start is called before the first frame update
    void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        bulletText.text = numOfBullet.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed &&
            OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController())
            && numOfBullet > 0) 
        {
            //Shoot
            simpleShoot.TriggerShoot();
            numOfBullet--;
            bulletText.text = numOfBullet.ToString();
        }
    }
}
