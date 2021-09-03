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
        int currentMonsterIndex = 1;


        public void Run()
        {
            Start();
            
            while(!gameOver)
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
            Lompus.defense = 25.0f;
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

        void Update()
        {
            Battle();
            UpdateCurrentMonsters();
            Console.ReadKey(true);
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


            if (monsterIndex == 1)
            {
               monster = caral;
            }
            else if (monsterIndex == 2)
            {
                monster = Lompus;
            }
            else if (monsterIndex == 3)
            {
                monster = Wompus;
            }
            else if (monsterIndex == 4)
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
                Console.WriteLine("Simulation Over :]");
                gameOver = true;
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