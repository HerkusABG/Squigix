using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Audio.GeneratorInstance;

public static class ButtonManager
{
    public static List<NightButton> NightButtons = new List<NightButton>();

    public static List<Unit> UnitList = new List<Unit>();

    public static LevelManager levelManager;

    private static int previousId = 100;



    

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

    public static void ResetUnlockedButtons()
    {
        Debug.Log("RESETING BUTTONS");
        foreach (NightButton button in NightButtons)
        {
            if(!button.isLocked)
            {
                button.ResetButton();
            }
        }
    }

    public static void ButtonPressed(int inputId)
    {
        Unit unit = UnitList.Find(x => x.id.Equals(inputId));
        if (inputId == previousId)
        {
            Debug.Log("good");
            unit.pairStateArray[1] = true;

            List<NightButton> NightButtonListTemp = new List<NightButton>();
            NightButtonListTemp = NightButtons.FindAll(x => x.id == inputId);

            foreach(NightButton loopButton in NightButtonListTemp)
            {
                loopButton.isLocked = true;
            }

            Debug.Log("Locking buttons");
            CheckWinCondition();
            previousId = 100;
        }
        else
        {
            Unit oldUnit = UnitList.Find(x => x.id.Equals(previousId));
            unit.pairStateArray[0] = true;

            previousId = inputId;
            if (oldUnit == null) return;
            //oldUnit.pairStateArray[0] = false;

            ResetUnlockedButtons();
        }
    }

    public static void PrintButtonStatuses()
    {
        foreach (Unit unit in UnitList)
        {
            Debug.Log($"Unit with id {unit.id} is {unit.pairStateArray[0]} and {unit.pairStateArray[1]}");
        }
    }

    public static void CheckWinCondition()
    {
        foreach(NightButton button in NightButtons)
        {
            Debug.Log($"button with id {button.id} is {button.isLocked}");
            if (!button.isLocked) return;
        }
        Debug.Log("Puzzle solved!");
        levelManager.RemoveBlockage();
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