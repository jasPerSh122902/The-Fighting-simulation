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


            Wompus.name = " Wompus ";
            Wompus.attack = 20.0f;
            Wompus.defense = 15.0f;
            Wompus.health = 20.0f;


            clompus.name = " clompus ";
            clompus.attack = 19.0f;
            clompus.defense = 10.0f;
            clompus.health = 40.0f;


            Lompus.name = " Lompus ";
            Lompus.attack = 21.0f;
            Lompus.defense = 24.0f;
            Lompus.health = 17.0f;


            caral.name = " caral ";
            caral.attack = 26.0f;
            caral.defense = 14.0f;
            caral.health = 10.0f;

            
        }

        void Update()
        {
            Battle();

        }

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
                monster = clompus;
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

        void UpdateCurrentMonsters()
        {
            if()
        }
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