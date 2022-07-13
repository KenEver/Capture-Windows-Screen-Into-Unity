using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresece : MonoBehaviour
{
    /*public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice targetDevice;
    public List<GameObject> controllerPrefabs;
    public GameObject spawnedController;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0) { 
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                
                spawnedController = Instantiate(prefab,transform);

            }
            else {
                Debug.Log("Did not find corresponding controller model:" + targetDevice.name);
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton,out bool primaryButtonValue);

        if(primaryButtonValue)
            Debug.Log("Pressing the primary button");
    }*/
}
