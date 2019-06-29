using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootIfGrabbed : MonoBehaviour
{
    private SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    private XMLReader reader;
    public OVRInput.Button shootingButton;
    public Text bulletText;
    public Text testText;
    public int numOfBullet = 10;
    // Start is called before the first frame update
    void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        bulletText.text = numOfBullet.ToString();
        reader = GetComponent<XMLReader>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((ovrGrabbable.isGrabbed &&
            OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController())
            && numOfBullet > 0) || Input.GetKeyDown(KeyCode.E)) 
        {
            //Shoot
            if (reader != null) Debug.Log("Yes");
            simpleShoot.TriggerShoot();
            numOfBullet--;
            bulletText.text = numOfBullet.ToString();
            testText.text = reader.GetAnimalName("1");
        }
    }
}
