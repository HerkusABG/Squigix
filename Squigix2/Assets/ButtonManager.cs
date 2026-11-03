using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Audio.GeneratorInstance;

public static class ButtonManager
{
    public static List<NightButton> NightButtons = new List<NightButton>();

    public static List<Unit> UnitList = new List<Unit>();

    public static void AddNightButton(NightButton button)
    {
        NightButtons.Add(button);
        int id = button.id;

        Unit unit = UnitList.Find(x => x.id.Equals(id));
        if(unit == null)
        {
            Unit newUnit = new Unit(id);
            UnitList.Add(newUnit);
            //newUnit.pairStateArray[0] = true;
        }
        else
        {
            //unit.pairStateArray[1] = true;
        }
    }

    public static void ButtonPressed(int inputId)
    {
        Unit unit = UnitList.Find(x => x.id.Equals(inputId));
        if (unit.pairStateArray[0] == false)
        {
            unit.pairStateArray[0] = true;
        }
        else
        {
            unit.pairStateArray[1] = true;
        }
    }

    public static void PrintButtonStatuses()
    {
        foreach (Unit unit in UnitList)
        {
            Debug.Log($"Unit with id {unit.id} is {unit.pairStateArray[0]} and {unit.pairStateArray[1]}");
        }
    }
    
}

public class Unit
{
    public Unit(int setupId)
    {
        id = setupId;
    }
    public int id;
    public bool[] pairStateArray = { false, false };
}