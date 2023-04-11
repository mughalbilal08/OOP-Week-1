using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using EZInput;

namespace Game_C_SHARP_
{
    class Program
    {
        static void Main(string[] args)
        {

            //                   ########################### ARRAYS ##############################

           
            int gridX = 0;                               // Grid coordinates
            int gridY = 0;                               // Grid coordinates
            int shipX = 22;                              // player coordinates
            int shipY = 60;                              // player coordinates
            int enemyX = 3;                              // enemy coordinates
            int enemyY = 5;                              // enemy coordinates
            int [] bulletshipX= new int [1000];          // Ship Bullet
            int[] bulletshipY = new int[1000];           // Ship Bullet
            int[] bulletenemyX = new int[1000];          // enemy Bullet
            int[] bulletenemyY = new int[1000];          // enemy Bullet
            bool[] isBulletActive = new bool [1000];
            bool[] isBulletEActive = new bool[1000];

            int bulletCount = 0;
            int bulletECount = 0;
            int score = 0;
            int healthE = 100;
            int healthP = 100;
            int enemy1Shot = 0;
            bool enemy1present = true;            
            string enemyDirection1 = "down";
            
            //    PLAYER COORDINATES;

            char up = (char)94;
            char box = (char)219;
            char[,] ship = new char[2, 5]{
                { ' ', ' ', up, ' ', ' '},
                { '-', box, box, box, '-'}
                };

            //  Enemy  PLAYER COORDINATES;

            char[,] enemy = new char[2, 5]{
             { '-', box, box, box, '-'},
             { ' ', ' ', up, ' ', ' '},
            };

            //    Maze;

            char[,] maze2D = new char[26, 130];

            //                 ########################## Body #########################       

            int option = 0;
            Console.Clear();
            loading();
            Console.Clear();
            header();
            loadmaze(ref maze2D);
            printingMaze1(ref maze2D);
            storemaze(ref  maze2D);
            
//            bool run = true;
            while(option != 3)
            {
                Console.Clear();
                header();
                
                option = login();
                if (option == 1)
                {
                    
                    int choice = gamemenu();
                    if (choice == 1)
                    {
                        
                        startGame(ref enemy1present, ref enemy1Shot, ref enemyDirection1, ref maze2D, ref ship, ref enemy, ref bulletenemyX, ref bulletenemyY, ref shipX, ref shipY, ref enemyX, ref enemyY, ref bulletCount, ref bulletECount, ref bulletshipX, ref bulletshipY, ref isBulletActive, ref isBulletEActive, ref healthP, ref healthE, ref score);
                       // storemaze(ref maze2D);
                    }
                    if (choice == 2)
                    {
                        Console.Write("COMING");
                        
                    }
                }
                if (option == 2)
                {
                    Console.Clear();
                    header();
                    keys();
                    Console.ReadKey();
                    
                }

                if (option == 3)
                {
                    Console.Clear();
                    
                }

            }

        }

        //                            ################### Printing ######################## 
        public static int login()
        {
            int choice;
            Console.WriteLine("Press 1 To Start The Game: ");
            Console.WriteLine("Press 2 to Read Instructions oF the Game: ");
            Console.WriteLine("Press 3 To Exit The Game: ");
            Console.WriteLine("...................................");
            Console.WriteLine("Enter Your Choice ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void header()
        {
            Console.WriteLine();
            Console.WriteLine("         _______   __   __   ___   _______    _     _   _______   ______    ");
            Console.WriteLine("        |       | |  | |  | |   | |       |  | | _ | | |   _   | |    _ |   ");
            Console.WriteLine("        |  _____| |  |_|  | |   | |    _  |  | || || | |  |_|  | |   | ||   ");
            Console.WriteLine("        | |_____  |       | |   | |   |_| |  |       | |       | |   |_||_  ");
            Console.WriteLine("        |_____  | |       | |   | |    ___|  |       | |       | |    __  | ");
            Console.WriteLine("         _____| | |   _   | |   | |   |      |   _   | |   _   | |   |  | | ");
            Console.WriteLine("        |_______| |__| |__| |___| |___|      |__| |__| |__| |__| |___|  |_| ");
            Console.WriteLine();
        }
        public static void clear()
        {
            Console.WriteLine();
            Console.Write("Press Any Key To Continuou");
            Console.Clear();
            Console.WriteLine();
        }
        public static void keys()
        {
            Console.WriteLine("1. UP         GO UP");
            Console.WriteLine("2. DOWN       GO DOWN");
            Console.WriteLine("3. LEFT       GO LEFT");
            Console.WriteLine("4. RIGHT      GO RIGHT");
            Console.WriteLine("5. SPACE      Fire");
        }
        public static int gamemenu()
        {

            int choice = 0;
            Console.Clear();
            header();
            Console.WriteLine("Press 1 To Start The New Game: " );
            Console.WriteLine("Press 2 To Load Old Saved Game: " );
            Console.WriteLine("Press 3 To Exit The Game: " );
            Console.WriteLine("..................................." );
            Console.WriteLine("Enter Your Choice " );
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static void loading()

        {
  
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine( "                                   .                                                 # #  ( )                      .                   .                                            " );
            Console.WriteLine( "                                     ..                                       ___#_#___|__                             .                                                            " );
            Console.WriteLine( "             .        .          .                                        _  |____________|  _                                 .               .                                    " );
            Console.WriteLine( "          .    .        .                                          _=====| | |            | | |====_                               .     .                                          " );
            Console.WriteLine( "               .                                            =====| |.---------------------------. | |====                  . ..         .                                          " );
            Console.WriteLine( "         .        . .                         <--------------------'   .  .  .  .  .  .  .  .   '----------------//                 ..                                               " );
            Console.WriteLine( "                     .                          \\                                                               //                .                                                  " );
            Console.WriteLine( "         .             ..     ..                 \\                                                             //        ..    .. .                                                 " );
            Console.WriteLine( "                ..       .    .                   \\_______________________________________________WWS_________//            .           .                                         " );
            Console.WriteLine( "        .                ..              wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww         . .     . .                                         " );
            Console.WriteLine( "          ..              ..            wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww        .                                               " );
            Console.WriteLine( "                                          wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww                   . .                                    " );

 
            Console.WriteLine( "        ------------------------------------------------------------------------------------------------------------------------------------------- " );
            Console.WriteLine( );
            Console.WriteLine( );
            Console.WriteLine( );
            Console.WriteLine( );

            char box =(char) 219;

           

            Console.WriteLine( "                                                          Your Game Is Loading ");
            for (int i = 0; i < 9; i++)
            {
                Thread.Sleep(300);
            }
            Console.WriteLine( );
        }

        static void printScore(int healthP, int healthE, int score)
        {
            Console.SetCursorPosition(140, 11);
            Console.WriteLine("Score: " + score);
            Console.SetCursorPosition(140, 10);
            Console.WriteLine("Health is: " + healthP);
            Console.SetCursorPosition(140, 12);
            Console.WriteLine("Enemy Health is: " + healthE);
        }

        //                             ############### MAZE PRINTING ######################

        public static void loadmaze(ref char[,] maze)
        {
            
            string line;
            
            string path = "P:\\Game(C_SHARP)\\Game(C_SHARP)\\maze.txt";
            int row = 0;
            StreamReader myFile = new StreamReader(path);
            while ((line = myFile.ReadLine()) != null)
            {
                for (int colom = 0; colom < 130; colom++)
                {
                    maze[row,colom] = line[colom];
                }
                Console.WriteLine();
                row++;
            }
            myFile.Close();
        }
        public static void printingMaze1(ref char[,] maze)
        {
            for (int x = 0; x < 26; x++)
            {
                for (int y = 0; y < 130; y++)
                {

                    if ((x == 0) && (y > -1 && y < 130))

                    {
                        maze[x, y] = '_';
                    }

                    else if ((x == 24) && (y > 2 && y < 127))

                    {
                        maze[x, y] = '_';
                    }

                    else if ((x == 1) && (y > 2 && y < 127))

                    {
                        maze[x, y] = '#';
                    }

                    else if ((x == 25) && (y > -1 && y < 130))

                    {
                        maze[x, y] = '#';
                    }

                     else if ((x == 19) && (y >= 40 && y <= 85))

                     {
                         maze[x,y] = '#';
                     }

                    else if ((y == 0 || y == 129) && (x > 0 && x < 25))

                    {
                        maze[x, y] = '|';
                    }

                    else if ((y == 1 || y == 128) && (x > 0 && x < 25))

                    {
                        maze[x, y] = '@';
                    }

                    else if ((y == 2 || y == 127) && (x > 0 && x < 25))
                    {
                        maze[x, y] = '|';
                    }

                    else
                    {
                        maze[x, y] = ' ';
                    }            
                }             
            }
        }
        public static void storemaze(ref char[,] maze)
        {
            string line;
            string path = "P:\\Game(C_SHARP)\\Game(C_SHARP)\\maze.txt";
            int row = 0;
            StreamWriter myFile = new StreamWriter(path, false);
            {
                for (int x = 0; x < 26; x++)
                {
                    for (int y = 0; y < 130; y++)
                    {
                        myFile.Write(maze[x, y]);
                    }
                    myFile.WriteLine();
                }
            }
            myFile.Close();
        }
        public static void maze12D(ref char[,] maze)
        {

            Console.Clear();
            

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write( maze[x,y]);
                }
                Console.WriteLine();
            }
        }

        //                          ############### Main PLAYER ##########################

        static void player(ref char[,] maze, char[,] ship, ref int shipX, ref int shipY)
        {
            for (int x = 0; x < ship.GetLength(0); x++)
            {           
                for (int y = 0; y < ship.GetLength(1); y++)
                {
                    Console.SetCursorPosition(shipY + y, shipX + x);
                    Console.Write(ship[x, y]);
                    maze[shipX+ x, shipY + y] = ship[x, y];
                }
            }
        }
        static void Eraseplayer( ref char[,] maze, char[,] ship, ref int shipX, ref int shipY)
        {
            for (int x = 0; x < ship.GetLength(0); x++)
            {
               // Console.SetCursorPosition(shipY + x, shipX);
                for (int y = 0; y < ship.GetLength(1); y++)
                {
                    Console.SetCursorPosition(shipY + y, shipX + x);
                    Console.Write(" ");
                    maze[shipX + x, shipY + y] = ' ';
                }
            }
        }
        static void moveShipRight( ref char[,] maze, char[,] ship, ref int shipX, ref int shipY)
        {
            if (maze[shipX , shipY + 5] == ' ' && maze[shipX+1 , shipY + 5] == ' ')
            {

                Eraseplayer( ref maze,  ship,ref shipX, ref shipY);

                shipY = shipY + 1;
                player(ref maze, ship, ref shipX, ref shipY);



            }
        }

        //                        ############### PLAYER Bullets #########################

        static void moveShipLeft(ref char[,] maze, char[,] ship, ref int shipX, ref int shipY)
        {
            if (maze[shipX, shipY - 1] == ' ' && maze[shipX - 1, shipY - 1] == ' ')
            {

                Eraseplayer(ref maze, ship, ref shipX, ref shipY);

                shipY = shipY - 1;
                player(ref maze, ship, ref shipX, ref shipY);
            }
        }
        static void generateBulletPlayer(ref char[,] maze, char[,] ship, ref int shipX, ref int shipY, ref int bulletCount,  ref int[] bulletshipX, ref int []bulletshipY, ref bool [] isBulletActive)
        { 
            
            bulletshipX[bulletCount] = shipX - 1;
            bulletshipY[bulletCount] = shipY + 2;
            char next = maze[bulletshipX[bulletCount], bulletshipY[bulletCount]];
            if (next == ' ')
            {
                printbullet(ref maze, bulletshipX[bulletCount], bulletshipY[bulletCount]);
                bulletCount++;
                isBulletActive[bulletCount] = true ;
            }
        }
        static void printbullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write("*");
            maze[x, y] = '*';
        }
        static void erasebullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            maze[x, y] = ' ';
        }
        static void movebullet(ref char[,] maze,  ref int[] bulletshipX, ref int[] bulletshipY, ref int bulletCount, ref bool [] isBulletActive, ref int enemyX, ref int enemyY)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                 
                    char next = maze[bulletshipX[x] - 1, bulletshipY[x]];
                    if (next == ' ')
                    {
                        erasebullet(ref maze, bulletshipX[x], bulletshipY[x]);
                        bulletshipX[x]--;
                        printbullet(ref maze, bulletshipX[x], bulletshipY[x]);
                    }
                    else if (next != ' ' || (bulletshipY[x] == enemyX && (bulletshipX[x] == enemyY + 3)) || (bulletshipY[x] == enemyX + 1 && (bulletshipX[x] == enemyY + 3)) || (bulletshipY[x] == enemyX + 2 && (bulletshipX[x] == enemyY + 3)) || (bulletshipY[x] == enemyX + 3 && (bulletshipX[x] == enemyY + 3)) || (bulletshipY[x] == enemyX + 4 && (bulletshipX[x] == enemyY + 3)) || (bulletshipY[x] == enemyX + 5 && bulletshipX[x] == enemyY + 3))
                    {
                        erasebullet(ref maze, bulletshipX[x], bulletshipY[x]);
                        isBulletActive[bulletCount] = false;
                        makebulletinactive(ref x, ref bulletshipX, ref bulletshipY, ref bulletCount);
                    }
                
            }
        }
        static void makebulletinactive( ref int index,   ref int []  bulletshipX,  ref int [] bulletshipY,  ref int bulletCount)
        {
            for (int y = index; y < bulletCount; y++)
            {
                bulletshipX[y] = bulletshipX[y + 1];
                bulletshipY[y] = bulletshipY[y + 1];
            }
            bulletCount--;
        }

        //                          ############### ENEMY  PLAYER ##########################

        static void enemyPlayer(ref char[,] maze, ref char[,] enemy, ref int enemyX, ref int enemyY)
        {
            for (int x = 0; x < enemy.GetLength(0); x++)
            {
                
                for (int y = 0; y < enemy.GetLength(1); y++)
                {
                    Console.SetCursorPosition(enemyY + y, enemyX + x);
                    Console.Write(enemy[x, y]);
                    maze[enemyX + x, enemyY + y] = enemy[x, y];
                }
            }
        }
        static void eraseEnemyCharacter1(ref char[,] maze, ref char[,] enemy, ref int enemyX, ref int enemyY)
        {
            for (int x = 0; x < enemy.GetLength(0); x++)
            {
             
                for (int y = 0; y < enemy.GetLength(1); y++)
                {
                    Console.SetCursorPosition(enemyY + y, enemyX + x);
                    Console.Write(" ");
                    maze[enemyX + x, enemyY + y] = ' ' ;
                }
            }
        }
        static void moveenemy1(ref char[,] maze, ref char[,] enemy, ref int enemyX, ref int enemyY, ref string enemyDirection1)
        {
            if (enemyDirection1 == "down")
            {    
                if (maze[enemyX+3, enemyY ] == ' ')
                {
                    eraseEnemyCharacter1(ref  maze, ref enemy, ref enemyX, ref  enemyY);
                    enemyX++;
                    enemyPlayer(ref maze, ref enemy, ref enemyX, ref enemyY);
                }
                if (enemyX == 10)
                {
                    enemyDirection1 = "up";
                                   
                }                
            }
            if (enemyDirection1 == "up")
            {
                if ((maze[enemyX - 1, enemyY] == ' '))
                {
                    eraseEnemyCharacter1(ref maze, ref enemy, ref enemyX, ref enemyY);
                    enemyX--;
                    enemyPlayer(ref maze, ref enemy, ref enemyX, ref enemyY);
                }
                if (maze[enemyX - 1, enemyY] == '#')
                {
                    enemyDirection1 = "down";
                }
            }
        }
      
        //                        ############### Enemy Bullets #########################
        
        static void generateEbullet(ref char[,] maze, ref int[] bulletenemyX, ref int[] bulletenemyY, ref int bulletECount, ref int enemyX, ref int enemyY, ref int enemy1Shot)
        {
            if (enemy1Shot % 4 == 0)
            {
                bulletenemyX[bulletECount] = enemyX + 2;
                bulletenemyY[bulletECount] = enemyY + 2;
                char next = maze[bulletenemyX[bulletECount], bulletenemyY[bulletECount]];
                if (next == ' ')
                {
                    printEbullet(ref maze, bulletenemyX[bulletECount], bulletenemyY[bulletECount]);
                    bulletECount++;
                }
            }
            enemy1Shot++;
        }
        static void printEbullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write("o");
            maze[x, y] = 'o';
        }
        static void eraseEbullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            maze[x, y] = ' ';
        }
        static void moveEbullet(ref char[,] maze, ref int[] bulletenemyX, ref int[] bulletenemyY, ref int bulletECount, ref int enemyX, ref int enemyY, ref int shipY,ref bool[] isBulletEActive)
        {
            for (int x = 0; x < bulletECount; x++)
            {

                    char next = maze[bulletenemyX[x] + 1, bulletenemyY[x] + 1];

                    if (next == ' ')
                    {
                        eraseEbullet(ref maze, bulletenemyX[x], bulletenemyY[x]);
                        bulletenemyX[x]++;
                        if ( (enemyX != shipY))
                        {
                            bulletenemyY[x] = bulletenemyY[x] + 2;
                        }
                        printEbullet(ref maze, bulletenemyX[x], bulletenemyY[x]);
                    }
                    else if (next != ' '|| (maze[enemyX+1, enemyY+2] != ' ') || (maze[enemyX + 2, enemyY+2] != ' ') || (maze[enemyX + 3, enemyY + 2] != ' ') || (maze[enemyX + 4, enemyY + 2] != ' ') || (maze[enemyX + 5, enemyY + 2 ] != ' '))
                    {
                        eraseEbullet(ref maze, bulletenemyX[x], bulletenemyY[x]);
                        makeEbulletinactive(ref x, ref bulletenemyX, ref bulletenemyY, ref bulletECount);                       
                    }
                
            }
        }
        static void makeEbulletinactive(ref int index, ref int[] bulletenemyX, ref int[] bulletenemyY, ref int bulletECount)
        {
            for (int y = index; y < bulletECount; y++)
            {
                bulletenemyX[y] = bulletenemyX[y + 1];
                bulletenemyY[y] = bulletenemyY[y + 1];
            }
            bulletECount--;
        }
       
      
        //                      ################# Bullets Collision ######################
        
        static void enemyBulletCollisionWithPlayer(  ref int shipY, ref int shipX, ref char[,] maze, ref int healthP)
        {
            if ( maze[ shipY + 1, shipX]  == 'o')
            {
                healthP = healthP - 10;
            }
           
            if (maze[shipY - 2, shipX -3 ] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[shipY - 3, shipX - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[shipY - 4, shipX - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[shipY - 5, shipX - 3] == 'o')
            {
                healthP = healthP - 10;
            }
           else if (healthP <= 0)
            {
                healthP = 0;
            }
        }
        static void playerBulletCollisionWithE(ref int enemyY, ref int enemyX, ref char[,] maze, ref int healthE, ref int score)
        {
            if (maze[enemyX + 3, enemyY ] == '*')
            {
                score++;
                healthE = healthE - 10;
            }

            if (maze[enemyX + 3, enemyY + 1] == '*')
            {
                score++;
                healthE = healthE- 10;
            }
            if (maze[enemyX + 3, enemyY +2 ] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[enemyX + 3, enemyY + 3] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[enemyX + 3, enemyY + 4] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[enemyX + 3, enemyY + 5] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            else if (healthE <= 0)
            {
                healthE = 0;
            }
        }

        //                     ################ MOVEMENT OF PlaYer ###########################

        static void movePlayer(ref char[,] maze2D, ref char[,]ship, ref int shipX, ref int shipY, ref int bulletCount, ref int[] bulletshipX, ref int [] bulletshipY, ref bool [] isBulletActive)
        {

            Thread.Sleep(90);

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveShipRight(ref maze2D, ship, ref shipX, ref shipY);
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveShipLeft(ref maze2D, ship, ref shipX, ref shipY);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                generateBulletPlayer(ref maze2D, ship, ref shipX, ref shipY, ref bulletCount, ref bulletshipX, ref bulletshipY, ref isBulletActive);
            }
        }

        //                      ################ GaMe StaRt ###########################
    
        static void startGame(ref bool enemy1present,ref int enemy1Shot ,ref string enemyDirection1, ref char[,] maze2D, ref char[,] ship, ref char[,] enemy, ref int [] bulletenemyX, ref int[] bulletenemyY, ref int shipX, ref int shipY, ref int enemyX, ref int enemyY, ref int bulletCount, ref int bulletECount, ref int[] bulletshipX, ref int[] bulletshipY, ref bool[] isBulletActive, ref bool[] isBulletEActive, ref int healthP, ref int healthE, ref int score)
        {
            Console.Clear();
            enemy1present = true;
            bool gamerunning = true;

            maze12D(ref maze2D);
           
            
            while(gamerunning)
            {
                
                if (enemy1present == true)
                {
                    
                    enemyPlayer(ref maze2D, ref enemy, ref enemyX, ref enemyY);
                    generateEbullet(ref maze2D, ref bulletenemyX, ref bulletenemyY, ref bulletECount, ref enemyX, ref enemyY, ref enemy1Shot);
                    moveenemy1(ref maze2D, ref enemy, ref enemyX, ref enemyY, ref enemyDirection1);
                    printScore( healthP,  healthE, score);
                }
                if (healthP == 0 || healthE == 0)
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine( "Game Ends");
                    Console.WriteLine ("Score:" + score) ;
                    Thread.Sleep(2000);



                    gamerunning = false;
                }

                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    storemaze(ref maze2D);
                    gamerunning = false;
                    break;
                }

                player(ref maze2D, ship, ref shipX, ref shipY);
                movePlayer(ref maze2D, ref ship, ref shipX, ref shipY, ref bulletCount, ref bulletshipX, ref bulletshipY, ref isBulletActive);

                movebullet(ref maze2D, ref bulletshipX, ref bulletshipY, ref bulletCount, ref isBulletActive, ref enemyX, ref enemyY);
                moveEbullet(ref maze2D, ref bulletenemyX, ref bulletenemyY, ref bulletECount, ref enemyX, ref enemyY, ref shipY, ref isBulletEActive);

                playerBulletCollisionWithE(ref enemyY, ref enemyX, ref maze2D, ref healthE, ref score);
                enemyBulletCollisionWithPlayer(ref shipX, ref shipY, ref maze2D, ref healthP);

                

            }

        }
    }

}

