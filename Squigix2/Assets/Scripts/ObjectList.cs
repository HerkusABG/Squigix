using UnityEngine;
using System.Collections.Generic;

public static class ObjectList
{

    //Information storage class. Managing objects where it is not necessary to have scene access.
    public static List<Sensor> Sensors = new List<Sensor>();

    public static ExitPortal exitPortal;
}
