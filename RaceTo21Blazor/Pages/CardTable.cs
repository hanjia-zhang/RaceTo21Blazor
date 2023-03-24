﻿using System;
using System.Collections.Generic;

namespace RaceTo21Blazor.Pages
{
    public class CardTable
    {
        public CardTable()
        {
            Console.WriteLine("Setting Up Table...");
        }

        /* Shows the name of each player and introduces them by table position.
         * Is called by Game object.
         * Game object provides list of players.
         * Calls Introduce method on each player object.
         */
        public void ShowPlayers(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Introduce(i+1); // List is 0-indexed but user-friendly player positions would start with 1...
            }
        }

        /* Gets the user input for number of players.
         * Is called by Game object.
         * Returns number of players to Game object.
         */
        public int GetNumberOfPlayers()
        {
            Console.Write("How many players? ");
            string response = Console.ReadLine();
            int numberOfPlayers;
            while (int.TryParse(response, out numberOfPlayers) == false
                || numberOfPlayers < 2 || numberOfPlayers > 8)
            {
                Console.WriteLine("Invalid number of players.");
                Console.Write("How many players?");
                response = Console.ReadLine();
            }
            return numberOfPlayers;
        }

        /* Gets the name of a player
         * Is called by Game object
         * Game object provides player number
         * Returns name of a player to Game object
         */
        public string GetPlayerName(int playerNum)
        {
            Console.Write("What is the name of player# " + playerNum + "? ");
            string response = Console.ReadLine();
            while (response.Length < 1)
            {
                Console.WriteLine("Invalid name.");
                Console.Write("What is the name of player# " + playerNum + "? ");
                response = Console.ReadLine();
            }
            return response;
        }

        public bool OfferACard(Player player)
        {
            while (true)
            {
                Console.Write(player.name + ", do you want a card? (Y/N)");
                string response = Console.ReadLine();
                if (response.ToUpper().StartsWith("Y"))
                {
                    return true;
                }
                else if (response.ToUpper().StartsWith("N"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please answer Y(es) or N(o)!");
                }
            }
        }

        public void ShowHand(Player player)
        {
            if (player.cards.Count > 0)
            {
                string output = player.name + " has: ";
             
                foreach (Card card in player.cards)//hz Enable the " number of cards types"
                {
                    string[] divid = card.displayName.Split(" ");//Using Split cut the put into pieces
                    

                    string cardName = divid[0];
                    string cardLongName = divid[0];
                    switch(cardName)
                    {
                        case "2":                       //when the case is 2 out put "Two" instead   
                            cardLongName = "Two";
                            break;

                        case "3":
                            cardLongName = "Three";    //when the case is 3 out put "Three" instead 
                            break;

                        case "4":
                            cardLongName = "Four";
                            break;

                        case "5":
                            cardLongName = "Five";
                            break;

                        case "6":
                            cardLongName = "Six";
                            break;

                        case "7":
                            cardLongName = "Seven";
                            break;

                        case "8":
                            cardLongName = "Eight";
                            break;

                        case "9":
                            cardLongName = "Nine";
                            break;

                        case "10":
                            cardLongName = "Ten";
                            break;

                        default:
                           
                            break;
                    }
                    
                    output += cardLongName + " " + divid[1] + " " + divid[2] + ", ";// edit output
                }
                
                output = output.Remove(output.Length - 2);//hz

                Console.WriteLine(output);

                Console.Write("=" + player.score + "/21 ");
                if (player.status != PlayerStatus.active)
                {
                    Console.Write("(" + player.status.ToString().ToUpper() + ")");
                }
                Console.WriteLine();
            }
        }

        public void ShowHands(List<Player> players)
        {
            foreach (Player player in players)
            {
                ShowHand(player);
            }
        }


        public void AnnounceWinner(Player player)
        {
            if (player != null)
            {
                Console.WriteLine(player.name + " wins!");
            }
            else
            {
                Console.WriteLine("Everyone busted!");
            }
            
        }
    }
}