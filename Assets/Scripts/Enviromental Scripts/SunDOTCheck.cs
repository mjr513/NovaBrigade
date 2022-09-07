using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDOTCheck : MonoBehaviour
{
    public float tickDelay = 1f;
    public Vector3 skyDirection = new Vector3(0,1,0);
    public Transform skylight;

    private float tickCountdown;

    // Start is called before the first frame update
    void Start()
    {
        tickCountdown = tickDelay;
        skyDirection = skylight.forward * -1f;
    }

    // Update is called once per frame
    void Update()
    {
        tickCountdown -= Time.deltaTime;
        if (tickCountdown <= 0f)
        {
            tickCountdown = tickDelay;
            if (!Physics.Raycast(transform.position, skyDirection))
            {
                print("Sun Hot");
            }
                //Raycast(Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);
        }
    }
}
