using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Audio.GeneratorInstance;

public static class ButtonManager
{
    //NOT IN A FULLY FUNCTIONAL STATE RIGHT NOW !!!!



    //This class is responsible for managing all the main puzzle of level 1.
    //This means that all the information in regards to the puzzle execution is handled mostly here.
    //Additional code is included in the NightButton class itself, of course.
    //IMPORTANT: below the UNIT class is also defined, used for storing the information about the puzzle's completion.

    //List for storing the night buttons. The night buttons add themselves when initialized.
    public static List<NightButton> NightButtons = new List<NightButton>();

    //List of Units which store information about what sets of buttons have been pressed.
    //Basically just tracking the puzzle completion.
    public static List<Unit> UnitList = new List<Unit>();

    //The puzzle manager's communication to the outside world.
    public static LevelManager levelManager;

    //integer used for remembering the last id of the button pressed.
    //using this we can tell whether two buttons with the same ID have been pressed one after another.
    private static int previousId = 100;
    

    //Method that gets called from NightButton.cs
    public static void AddNightButton(NightButton button)
    {
        NightButtons.Add(button);
        //Grabbing button's id. At first they get set in the inspector.
        int id = button.id;

        //Searching through the unit list to see if this Id already exists.
        Unit unit = UnitList.Find(x => x.id.Equals(id));
        if(unit == null)
        {
            //If an unit with this ID does not exist, we create it and give it the
            //appropriate ID.
            Unit newUnit = new Unit(id);
            UnitList.Add(newUnit);
        }
    }

    public static void ResetUnlockedButtons()
    {
        //Resetting all unlocked buttons if the wrong button was pressed.
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
        //Checking the logic of the buttons once one is pressed.
        //Finding an unit with the ID of the button pressed.
        Unit unit = UnitList.Find(x => x.id.Equals(inputId));

        //If input ID of this button is equal to the one pressed previously...
        if (inputId == previousId)
        {
            //... it means that they have been pressed in the right order.
            unit.pairStateArray[1] = true;

            //Grabbing both of the buttons with this ID.
            List<NightButton> NightButtonListTemp = new List<NightButton>();
            NightButtonListTemp = NightButtons.FindAll(x => x.id == inputId);

            //Locking them, so they cannot be pressed again.
            foreach(NightButton loopButton in NightButtonListTemp)
            {
                loopButton.isLocked = true;
            }

            //Checking in case this was the last set of unpressed buttons,
            //in which case the puzzle is complete.
            CheckWinCondition();
            //Resetting previous button ID to ensure no nonsense.
            previousId = 100;
        }
        else
        {

            //... , but it turns out it wasn't, reset the puzzle memory accordingly.
            Unit oldUnit = UnitList.Find(x => x.id.Equals(previousId));
            unit.pairStateArray[0] = true;

            previousId = inputId;

            //Fail early
            if (oldUnit == null) return;
            oldUnit.pairStateArray[0] = false;

            //Reset all buttons which weren't pressed in the correct order.
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
    // A tracker class used for tracking which units of buttons have been pressed.

    //each unit is made up of an id and two booleans, each referring to the pressed state of the button.
    public Unit(int setupId)
    {
        id = setupId;
    }
    public int id;
    public bool[] pairStateArray = { false, false };
}