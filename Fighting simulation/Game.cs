using System;
using System.Collections.Generic;
using System.Text;

namespace FightSimulation
{
    struct Monster
    {
        public string name;
        public float health;
        public float attack;
        public float defense;
    }

    class Game
    {

        bool gameOver = false;
        Monster currentMonster1;
        Monster currentMonster2;

        //Monster 
        Monster Wompus;
        Monster clompus;
        Monster Lompus;
        Monster caral;

        //global varabels that are for scene and monster count.
        int currentMonsterIndex = 0;
        int currentScence = 0;

        public void Run()
        {
            Start();

            while (!gameOver)
            {
                Update();
            }
        }

        /// <summary>
        /// The start is to start it makes the current monster be set and the stats for monster.
        /// </summary>
        void Start()
        {
            //initilizing Monsters
            Wompus.name = " Wompus ";
            Wompus.attack = 20.0f;
            Wompus.defense = 15.0f;
            Wompus.health = 20.0f;


            clompus.name = " clompus ";
            clompus.attack = 19.0f;
            clompus.defense = 10.0f;
            clompus.health = 40.0f;

            //do not spawn in current situation "Lompu"
            Lompus.name = " Lompus ";
            Lompus.attack = 18.0f;
            Lompus.defense = 20.0f;
            Lompus.health = 8.0f;


            caral.name = " caral ";
            caral.attack = 26.0f;
            caral.defense = 14.0f;
            caral.health = 10.0f;

            //getting the initilazation of the monsters to fight and the order of monster fight
            currentMonster1 = GetMonster(currentMonsterIndex);
            currentMonsterIndex++;
            currentMonster2 = GetMonster(currentMonsterIndex);
        }

        void UpdateCurrentScene()
        {
            if (currentScence == 0)
            {
                DisplayStartMenu();

            }
            else if (currentScence == 1)
            {
                Battle();
                UpdateCurrentMonsters();
                Console.ReadKey(true);
            }
            else if (currentScence == 2)
            {
                DisplayRestartMenu();
            }
        }

        /// <summary>
        /// This function is meant to get the input of the player and has a option that if input is invalid then pause.
        /// </summary>
        /// <param name="description">The situation or reason for the choices or story.</param>
        /// <param name="option1">first choice for the player</param>
        /// <param name="option2">second choice for the player</param>
        /// <param name="pauseInvalid">if true, the player must press a key to continue after inputting an invald input</param>
        /// <returns>returns the number in which the player has choosne, Returns 0 if an inbalid input was recieved</returns>
        int GetInput(string description, string option1, string option2, bool pauseInvalid = false)
        {
            //printing the context of the situation "story"
            Console.WriteLine(description);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);

            //player input
            string input = Console.ReadLine();
            //the choice is a choice its a place holder to have a simpaler way of seeing the choices the play can make
            int choice = 0;
            //if 1 
            if (input == "1")
            {   
                //set the return variable to be 1
                choice = 1;
            }
            //if 2
            else if (input == "2")
            {
                //set return variable to be 2
                choice = 2;
            }
            //if nether of the choices
            else
            {
                //invalid input resieved aka "error"
                Console.WriteLine("Not valid Input try again!");

                //Then the read key to be optional
                if (pauseInvalid)
                {
                    //... make the player press a key to continue.
                    Console.ReadKey();
                }
            }

            //the return varable "choice"
            return choice;
        }

        /// <summary>
        /// This is the start menu that comes up to allow player to start or leave.
        /// </summary>
        void DisplayStartMenu()
        {
            int choice = GetInput("Hellow this is the monster fight simulation", "To begain", "To leave");

            //the looping of the game it self
            if (choice == 1)
            {
                currentScence = 1;
            }
            //the game over
            else if (choice == 2)
            {
                gameOver = true;
            }
        }

        /// <summary>
        /// This is meant to be the ending of the simulation. And is a display
        /// </summary>
        void DisplayRestartMenu()
        {
            //the ending of the game // discription of what the player is seeing when the simulation is ending
            int choice = GetInput("Simulation is endding. Would you like to play again?", "Yes", "No");
                
            if (choice ==1)
            {
                //the looping of the game it self for the ending
                currentScence = 0;
            }
            else if (choice == 2)
            {
                //the game over
                gameOver = true;
            }
        }


        void DisplayMainMenu()
        {

        }

        /// <summary>
        /// Called every loop in a game loop 
        /// </summary>
        void Update()
        {
            UpdateCurrentScene();
            Console.Clear();
        }

        /// <summary>
        /// This cataloges the monster in play and makes it so each monster is put on the battle. Also simpliyies the process of the monster fight.
        /// </summary>
        /// <param name="monsterIndex"></param>
        /// <returns></returns>
        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.attack = 1;
            monster.defense = 1;
            monster.health = 1;


            if (monsterIndex == 0)
            {
               monster = caral;
            }
            else if (monsterIndex == 1)
            {
                monster = Lompus;
            }
            else if (monsterIndex == 2)
            {
                monster = Wompus;
            }
            else if (monsterIndex == 3)
            {
                monster = clompus;
            }

            return monster;
        }


        /// <summary>
        /// Simulates one turn in the current monster fight
        /// </summary>
        void Battle()
        {
            //Print currentMonster1
            PrintStats(currentMonster1);
            //Print currentMonster2
            PrintStats(currentMonster2);

            //Monster 1 attacks monster 2
            float damageTaken = Fight(currentMonster1, ref currentMonster2);
            Console.WriteLine(currentMonster2.name + "has taken " + damageTaken);

            //Monster 2 attacks monster 1
            damageTaken = Fight(currentMonster2, ref currentMonster1);
            currentMonster1.health -= damageTaken;
            Console.WriteLine(currentMonster1.name + "has taken " + damageTaken);

        }

        /// <summary>
        /// Changes the current monster if it dies and increases counter by one if needed.
        /// If all monsters are died then end the game.
        /// </summary>
        void UpdateCurrentMonsters()
        {

            //if monster1 or 2 dies they will get replaced
            //this is monster1
            if (currentMonster1.health <= 0 )
            {

                //increases counter by one if monster 1 dies.
                currentMonsterIndex++;
                currentMonster1 = GetMonster(currentMonsterIndex);

            }

            //then this is monster 2 replace
            if (currentMonster2.health <= 0)
            {

                //increases counter by one if monster 2 dies
                currentMonsterIndex++;
                currentMonster2 = GetMonster(currentMonsterIndex);

            }

            //if either monster is set or initilized by "None" and the last monster has been put out
            if (currentMonster2.name == "None" || currentMonster1.name == "None" && currentMonsterIndex >= 4)
            {

                //... game is ending
                currentScence = 2;
            }
        } 

        /// <summary>
        /// Starts the battle by with current monsters.
        /// </summary>
        /// <param name="Wompus"></param>
        /// <param name="clompus"></param>
        /// <returns></returns>
        string StartBattle( ref Monster Wompus, ref Monster clompus )
        {

            string matchResult = "No contest";

            while (Wompus.health > 0 && clompus.health > 0)
            {
                //Print Wompus stats
                PrintStats(Wompus);
                //Print clompus stats
                PrintStats(clompus);

                //Monster 1 attacks monster 2
                float damageTaken = Fight(Wompus, ref clompus);
                Console.WriteLine(clompus.name + "has taken " + damageTaken);

                //Monster 2 attacks monster 1
                damageTaken = Fight(clompus, ref Wompus);
                Wompus.health -= damageTaken;
                Console.WriteLine(Wompus.name + "has taken " + damageTaken);

                //clear and make sure every thing is good to continue the loop
                Console.ReadKey(true);
                Console.Clear();
            }

            if(Wompus.health <= 0 && clompus.health <= 0)
            {
                matchResult = "Draw";
            }
            if (Wompus.health > 0)
            {
                matchResult = Wompus.name;
            }
            else if (clompus.health > 0)
            {
                matchResult = clompus.name;
            }
 
            return matchResult;
        }




        float Fight(Monster attacker, ref Monster defender)
        {
            float damageTaken = CalculateDamage(attacker, defender);
            defender.health -= damageTaken;
            return damageTaken;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name " + monster.name);
            Console.WriteLine("Health " + monster.health);
            Console.WriteLine("Attack " + monster.attack);
            Console.WriteLine("Defense " + monster.defense);
        }

        float CalculateDamage(float attack, float defense)
        {
            float damage = attack - defense;

            if (damage <= 0)
            {
                damage = 0;
            }

            return damage;
        }

        float CalculateDamage(Monster attacker, Monster defender)
        {
            return attacker.attack - defender.defense;
        }
    }
}