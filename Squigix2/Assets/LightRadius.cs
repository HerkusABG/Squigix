using UnityEngine;

public class LightRadius : MonoBehaviour
{
    int myRadius;
    public void Initialize(int radius)
    {
        myRadius = radius;
    }

    private void Update()
    {
        //int count = 0;
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
        //Debug.Log($"COUNT IS: {count}");
    }

    private float MeasureDistance(Transform other)
    {
        float distance = Vector3.Distance(transform.position, other.position);
        return distance;
    }
}
