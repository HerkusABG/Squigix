using UnityEngine;

public class LightRadius : MonoBehaviour
{

    //Radius in which objects are affected.
    int myRadius;
    public void Initialize(int radius)
    {
        myRadius = radius;
    }

    private void Update()
    {
        //int count = 0;

        //Going through each sensor in the scene and setting it
        //to AWAKE or ASLEEP based on the range to the lightRadius object.
        foreach(Sensor sensor in ObjectList.Sensors)
        {
            if (sensor == null) continue;
            
            if(MeasureDistance(sensor.transform) <= myRadius)
            {
                //count++;
                if (sensor.GetSensorStatus() == false)
                {
                    sensor.SetSensorStatus(true);
                }
            }
            else if(sensor.GetSensorStatus())
            {
                sensor.SetSensorStatus(false);
            }
        }
    }

    //If light is turned off, we want to turn off all the interactables, no matter the distance.
    public void TurnOffOutOfDistanceInteractables()
    {
        foreach(Sensor sensor in ObjectList.Sensors)
        {
            //if (MeasureDistance(sensor.transform) > myRadius)
            //{
                sensor.SetSensorStatus(false);
            //}
        }
    }


    //Measure distance between the light and a set interactable object.
    private float MeasureDistance(Transform other)
    {
        float distance = Vector3.Distance(transform.position, other.position);
        return distance;
    }
}
