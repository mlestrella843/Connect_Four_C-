using System;
using System.Collections.Generic;

namespace Connect_Four
{
    //------------Class Player--------------
    class Player
    {
        public string Name { get; set; } //set the name of player.
        public string Symbol { get; set; } //set the symbol to use for a player.
        public bool Turn { get; set; } //set the turn for the player.
        public int Jugadas { get; set; } //para contar las jugadas de los jugadores.

        /*
        public Player(string name)
        {
            Name = name;
        }
        */

        public virtual void showPlayer()
        {
            Console.WriteLine("Este es el jugador " + Name + "Con el simbolo " + Symbol);
        }

        
        public virtual void Imprime_Matriz(string[,] Matriz_par)
        {
            int filas = 6;
            int columnas = 7;

            //imprime la matriz despues de jugar para ver donde jugaste.

            for (int p = 0; p < columnas; p++)
            {
                Console.Write(p + 1 + " ");
            }
            Console.WriteLine(" ");

            for (int l = 0; l < filas; l++)
            {
                for (int m = 0; m < columnas; m++)
                {
                    Console.Write(Matriz_par[l, m] + "|"); Console.Write(" ");
                }
                Console.WriteLine(" ");
            }

        }

        // JUGAR, Entra el simbolo ('X' o 'O') en la matriz

        public virtual void Jugar(int posicion_x, int posicion_y, string[,] Matriz_par)
        {         
            Matriz_par[posicion_x, posicion_y] = Symbol;      
        }


        //Busca en la matriz 4 veces el mismo simbolo, a la derecha
        //------LINEA RECTA-------

        public virtual void Buscar_matriz_derecha(string[,] Matriz_par)
        {          
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (Matriz_par[i, j] == Matriz_par[i, j + i])
                    {
                        Jugadas = 0;
                    }
                }
            }
            Console.WriteLine("El jugador: " + Name + " ,Ha ganado! ");
            
        }


        public virtual void Buscar_matriz_izquierda(string[,] Matriz_par)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 3; j <= 0; j--)
                {
                    if (Matriz_par[i, j] == Matriz_par[i, j + i])
                    {
                        Jugadas = 0;
                    }
                }                
            }
            Console.WriteLine("El jugador: " + Name + " ,Ha ganado! ");
            
        }

        public virtual void Buscar_matriz_Arriba(string[,] Matriz_par)
        {
            for (int j = 0; j < 1; j++)
            {
                for (int i = 3; i <= 0; i--)
                {
                    if (Matriz_par[i, j] == Matriz_par[i - 1, j])
                    {
                        Jugadas = 0;
                    }
                }
            }
            Console.WriteLine("El jugador: " + Name + " ,Ha ganado! ");

        }

        public virtual void Buscar_matriz_Abajo(string[,] Matriz_par)
        {
            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i >= 0; i++)
                {
                    if (Matriz_par[i, j] == Matriz_par[i + 1, j])
                    {
                        Jugadas = 0;
                    }
                }
            }
            Console.WriteLine("El jugador: " + Name + " ,Ha ganado! ");

        }



        //Busca en la matriz 4 veces el mismo simbolo, a la derecha
        //------LINEA DIAGONAL-------












    }



    //----------Class Human Player----------------------

    class Human_Player : Player
    {
        public bool Player_Human { get; set; }

        public Human_Player(string name)
        {
            Name = name;
            //   Matriz = new [,]  Matriz;
        }

        public override void showPlayer()
        {
            Console.WriteLine("Este es el jugador es humano " + Name + " Con el simbolo " + Symbol + " status de humano " + Player_Human);
        }

    }

    //------------Class CPU Player --------------------------

    class CPU : Player   //Como funciona un jugador como CPU??????
    {
        public bool Player_CPU { get; set; }

        public CPU(string name)
        {
            Name = name;
        }

        public override void showPlayer()
        {
            Console.WriteLine("Este es el jugador es humano " + Name + " Con el simbolo " + Symbol + " status de CPU " + Player_CPU);
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            //CREACION DE UN HUMAN_PLAYER
            Player player1 = new Human_Player("Juana Maria");
            Player player2 = new Human_Player("Jose Ramon");

            //Atributo de jugadas para cada jugador.
              player1.Jugadas = 0;
              player2.Jugadas = 0;
            
            //contador de 42 jugadas maximo para la matriz 6X7
            int contador_jugadas = 0;

            //Se instancia una matriz
            string[,] Matriz_Main = new string[6, 7];

            //VARIABLES PARA RECIBIR POSICION EN X Y Y.
             int posicion_x;
             int posicion_y;

            Console.WriteLine("-----------BIENVENIDO AL JUEGO CONECTA 4-------------");
            Console.WriteLine(" ");

            Console.WriteLine("Enter option 1.Human vs Human or Enter option 2.Human vs CPU");
            int option_type_game = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");


            //--------------JUEGO HUMANO VS HUMANO------------------------------------
            //para imprimir la matriz primero

            if (option_type_game == 1) //SI ES HUMANO VS HUMANO EJECUTA LO SIGUIENTE.
            {
                Console.WriteLine("Has escogido juego de Humano vs Humano");
                Console.WriteLine("Eres el primer jugado Player1 y tu simbolo es 'X' ");
                Console.WriteLine(" ");

                Console.WriteLine("Eres el primer jugado Player2 y tu simbolo es 'O' ");
                Console.WriteLine(" ");

                Console.WriteLine("PLAYER 1, Enter symbol option 'X' ");
                player1.Symbol = Console.ReadLine();
                Console.WriteLine(" ");

                Console.WriteLine("PLAYER 2, Enter symbol option 'O' ");
                player2.Symbol = Console.ReadLine();
                Console.WriteLine(" ");


                do
                {
                    //Si el jugado 1 no ha jugado, jugasdas == 0, puede jugar
                    if (player1.Jugadas == 0)
                    {
                        //Pido posicion X y Y para jugar
                        Console.WriteLine("Entre la posicion en x ");
                        posicion_x = int.Parse(Console.ReadLine());

                        Console.WriteLine("Entre la posicion en y ");
                        posicion_y = int.Parse(Console.ReadLine());

                        //Modulo que juega, pone el simbolo dentro de las posicion que entro el jugador
                        player1.Jugar(posicion_x, posicion_y, Matriz_Main);

                        //Contador que cuenta las 4 jugadas, para ver si gano.
                        contador_jugadas++;

                        if (contador_jugadas == 4)
                        {
                            //Trata de buscar 4 lugares con el mismo simbolo, ganaste.
                            player1.Buscar_matriz_derecha(Matriz_Main);
                            player1.Buscar_matriz_izquierda(Matriz_Main);
                            player1.Buscar_matriz_Arriba(Matriz_Main);
                            player1.Buscar_matriz_Abajo(Matriz_Main);
                        }
                    

                    //Imprimir matriz sin que se repita
                    player1.Imprime_Matriz(Matriz_Main);


                    //cuenta las jugadas de jugador 1, si es igual a uno no puede jugar
                    player1.Jugadas++;

                    //Aqui resetea al jugador 2 para que pueda jugar despues de este jugador 1.
                    player2.Jugadas = 0;
                }

                    
                    else if (player2.Jugadas == 0)
                    {
                        //Pido posicion X y Y para jugar
                        Console.WriteLine("Entre la posicion en x ");
                        posicion_x = int.Parse(Console.ReadLine());

                        Console.WriteLine("Entre la posicion en y ");
                        posicion_y = int.Parse(Console.ReadLine());

                        player2.Jugar(posicion_x, posicion_y, Matriz_Main);

                        //Imprimir matriz sin que se repita
                        player1.Imprime_Matriz(Matriz_Main);

                        //cuenta las jugadas de jugador 2, si es igual a uno no puede jugar
                        player2.Jugadas++;

                        //Aqui resetea al jugador 1 para que pueda jugar despues de este jugador 2.
                        player1.Jugadas = 0;


                    }


                } while (contador_jugadas < 42) ;


            }


        }


    }


}









































/*

                //--------------TABLERO------------------------------------
                //para imprimir la matriz primero

                //aqui empieza el controlsobre si el jugador 1 jugo.
                //sino ha jugado entre en el bucle. Si ha jugado
                //le toca al jugador 2.


                while (contador_jugadas < 42)
                {

                    
                     if (player1.Turn == false && player2.Turn == true)
                     {
                        //Inmediatamente seteo el player1.Turn=true;
                        
                    //El jugador 1 puede jugar

                    //for que imprime solo numero de columnas.
                        for (int p = 0; p < columnas; p++)
                        {
                            Console.Write(p + 1 + " ");
                        }
                        Console.WriteLine(" ");
                        for (int l = 0; l < filas; l++)
                        {
                            // Console.Write(l + 1);
                            for (int m = 0; m < columnas; m++)
                            {
                                Console.Write(Matriz[l, m] + "|"); Console.Write(" ");
                            }
                            Console.WriteLine(" ");
                        }

                    //for para dar entrada a la matriz
                    //
                    Console.WriteLine(" ");

                //    for (int i = 0; i < filas; i++)
                 //   {
                    //    for (int j = 0; j < columnas; j++)
                    //    {
                            Console.WriteLine("Entre la posicion en x ");
                            posicion_x = int.Parse(Console.ReadLine());

                            Console.WriteLine("Entre la posicion en y ");
                            posicion_y = int.Parse(Console.ReadLine());

                            Matriz[posicion_x, posicion_y] = player1.Symbol;

                            //imprime la matriz despues de jugar para ver donde jugaste.

                            for (int p = 0; p < columnas; p++)
                            {
                                Console.Write(p + 1 + " ");
                            }
                            Console.WriteLine(" ");

                            for (int l = 0; l < filas; l++)
                            {
                                for (int m = 0; m < columnas; m++)
                                {
                                    Console.Write(Matriz[l, m] + "|"); Console.Write(" ");
                                }
                                Console.WriteLine(" ");
                            }
                        //  }
                        //    }
                        contador_jugadas++;
                        player1.Change_Turn();
                        

                }

                    

                else if (player2.Turn == true)
                {
                        //le toca jugar al jugador 2
                        //Inmediatamente seteo el player1.Turn=true;

                       

                        //------NO TENGO QUE PEDIR EL SIMBOLO DE NUEVO----
                        // Console.WriteLine("Enter symbol option 'O' ");
                        // player2.Symbol = Console.ReadLine();
                        // Console.WriteLine(" ");


                        //for que imprime solo numero de columnas.
                        for (int p = 0; p < columnas; p++)
                    {
                        Console.Write(p + 1 + " ");
                    }
                    Console.WriteLine(" ");
                    for (int l = 0; l < filas; l++)
                    {
                        // Console.Write(l + 1);
                        for (int m = 0; m < columnas; m++)
                        {
                            Console.Write(Matriz[l, m] + "|"); Console.Write(" ");
                        }
                        Console.WriteLine(" ");
                    }

                    //for para dar entrada a la matriz
                    //
                    Console.WriteLine(" ");

                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            Console.WriteLine("Entre la posicion en x ");
                            posicion_x = int.Parse(Console.ReadLine());

                            Console.WriteLine("Entre la posicion en y ");
                            posicion_y = int.Parse(Console.ReadLine());

                            Matriz[posicion_x, posicion_y] = player2.Symbol;

                            //imprime la matriz despues de jugar para ver donde jugaste.

                            for (int p = 0; p < columnas; p++)
                            {
                                Console.Write(p + 1 + " ");
                            }
                            Console.WriteLine(" ");

                            for (int l = 0; l < filas; l++)
                            {
                                for (int m = 0; m < columnas; m++)
                                {
                                    Console.Write(Matriz[l, m] + "|"); Console.Write(" ");
                                }
                                Console.WriteLine(" ");
                            }
                        }
                    }
                        contador_jugadas++;
                         player1.Change_Turn();


                    }



                } //Aqui termina el if para preguntar si es un juego entre humano vs humano.


         }

   }




        class Position
    {
        public int Position_x { get; set; }
        public int Position_y { get; set; }

        public int Return_Position_x(int position_x)
        {
            Position_x = position_x;
            return Position_x;
        }

        public int Return_Position_y(int position_y)
        {
            Position_y = position_y;
            return Position_y;
        }

        public void showPosition()
        {
            Console.WriteLine("La posicion donde cayo o caera la pieza es: " + Position_x + " , " + Position_y);
        }

    }

    class Matrix
    {

        public List<Position> position;

        public Matrix()
        {
            position = new List<Position>();

        }




    public virtual void Change_Turn()
        {
            if (Turn == true)
            {
                Turn = false;
            }
            else if (Turn == false)
            {
                Turn = true;
            }
        }






    }



}


}

                */




