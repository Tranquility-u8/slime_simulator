using System;

/// <summary>
/// Input => InputMode  
/// </summary>
public enum SSAction
{
    None,           // Invalid action
    
    MoveUp = 1,     // Clockwise from north
    MoveRight,
    MoveDown,
    MoveLeft,
    
    MoveUpLeft,
    MoveUpRight,
    MoveDownLeft,
    MoveDownRight,
    
    Wait = 10,
    Use,            // Use hotItem
    Chat,           // Chat with sbd
    Interact,       // Interact with sth
    Pick,           // Pick up sth
    Fire,           // Shoot on sbd
    Melee,
    
    OpenMainMenu = 20,
    OpenInventory,
    OpenJournal,
    
    Confirm = 30,
    Cancel,
    Next,
    Prev,

    QuickSave = 40,
    QuickLoad,
}