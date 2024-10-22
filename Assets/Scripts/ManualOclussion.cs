using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;
public class ManualOclussion : MonoBehaviour
{
    private IAvatar localAvatar;
    private Vector3 avatar;
    public List<GameObject> objectsToCheck;
    public float distanceToOcclude;
    public float checkInterval = 0.2f;
    void Start()
    {
        localAvatar = SpatialBridge.actorService.localActor.avatar;
        avatar = localAvatar.position;
        StartCoroutine(CheckDistanceRoutine());
    }

    private IEnumerator CheckDistanceRoutine()
    {
        while (true)
        {
            avatar = localAvatar.position;

            foreach (GameObject obj in objectsToCheck)
            {
                if (obj != null)
                {
                    Vector3 positionB = obj.transform.position;
                    float distance = Vector3.Distance(avatar, positionB);

                    if (distance > distanceToOcclude)
                    {
                        obj.SetActive(false);
                    }
                    else
                    {
                        obj.SetActive(true);
                    }
                }
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }
}
