public enum InputMode
{
    Waiting,    // Waiting for animation: stop control of pc action
 
    OnTitle,    // Browsing the title: stop control of any action, prepare for game loading
    
    OnMainMenu, // Browsing the mainMenu: stop control of pc action , interact with mainMenu and options 
    
    OnInventory,// Browsing the inventory: stop control of pc action, interact with inventory widgets
    
    OnJournal,  // Browsing the Journal: stop control of pc action, interact with journey
    
}