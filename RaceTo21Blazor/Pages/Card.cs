using System;
namespace RaceTo21Blazor.Pages
{
    public class Card
    {
        public string id { get; private set; }//hz
        public string displayName { get; private set; }//hz



        public Card(string shortCardName, string longCardName)
        {
            id = shortCardName;
            displayName = longCardName;
        }
    }
}
