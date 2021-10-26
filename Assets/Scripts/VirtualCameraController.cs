using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCameraController : MonoBehaviour
{
    public List<GameObject> virtualCameras;

    // Start is called before the first frame update
    void Start()
    {
        virtualCameras.Clear();
        for (int counter = 0; counter < transform.childCount; counter++)
            virtualCameras.Add(transform.GetChild(counter).gameObject);
    }

    public void TransitionTo(GameObject cameraToTransitionTo)
    {
        foreach (GameObject g in virtualCameras)
            if (g == cameraToTransitionTo)
                g.GetComponent<CinemachineVirtualCamera>().Priority = 10;
            else
                g.GetComponent<CinemachineVirtualCamera>().Priority = 5;
    }
}
