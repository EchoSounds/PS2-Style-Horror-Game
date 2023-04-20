using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{
    private StarterAssetsInputs starterAssetsInputs;


    [Header("GameObject References")]
    [SerializeField] private GameObject gunAim;
    [SerializeField] private GameObject firePoint;

    [Header("Adjustable Gun Stats")]
    [SerializeField] private float damage, timeBetweenShots, reloadSpeed;
    [SerializeField] private int maxMagazineSize;

    [Header("Particle References")]
    [SerializeField] private GameObject impact;


    //Ints
    private int ammoCount;

    //Floats

    //Bools

    //Vectors

    //Other

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>(); 
    }

    private void Update()
    {

        Vector3 hitNormal = new Vector3();
        Transform hitTransform = null;

        if (Physics.Raycast(firePoint.gameObject.transform.position, firePoint.gameObject.transform.forward, out RaycastHit raycastHit, 999f))
        {
            hitNormal = raycastHit.normal;
            hitTransform = raycastHit.transform;
        }

        if (starterAssetsInputs.aim)
        {
            gunAim.gameObject.SetActive(true);

            if (starterAssetsInputs.shoot)
            {
                if (hitTransform != null)
                {
                    //if (hitTransform.tag == "Target")
                    //{
                    Instantiate(impact, hitTransform.position, Quaternion.LookRotation(hitNormal, Vector3.up));
                    //}
                    
                }

                Debug.Log(hitTransform);
            }
        }
        else
        {
            gunAim.gameObject.SetActive(false);
        }


    }   

    private void FireWeapon()
    {




    }

}
