using System;

class Program
{
    static char[,] matriz = new char[3, 3];
    static char jogadorAtual = 'X';
    static bool jogoTerminado = false;

    static void Main()
    {
        InicializarMatriz();

        while (!jogoTerminado)
        {
            Mtz();
            Game();
            victorycheck();
            gamers();
            Empate();
        }
    }

    static void InicializarMatriz()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matriz[i, j] = ' ';
            }
        }
    }

    static void Mtz()
    {
        Console.Clear();
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Game()
    {
        Console.WriteLine($"Jogador {jogadorAtual}, é sua vez.");
        Console.Write("Informe a linha (0, 1 ou 2): ");
        int linha = int.Parse(Console.ReadLine());

        Console.Write("Informe a coluna (0, 1 ou 2): ");
        int coluna = int.Parse(Console.ReadLine());

        if (matriz[linha, coluna] == ' ')
        {
            matriz[linha, coluna] = jogadorAtual;
        }
        else
        {
            Console.WriteLine("Posição ocupada. Tente novamente.");
            Game();
        }
    }

    static void victorycheck()
    {
        for (int i = 0; i < 3; i++)
        {
            // Verificar linhas e colunas
            if ((matriz[i, 0] == jogadorAtual && matriz[i, 1] == jogadorAtual && matriz[i, 2] == jogadorAtual) ||
                (matriz[0, i] == jogadorAtual && matriz[1, i] == jogadorAtual && matriz[2, i] == jogadorAtual))
            {
                Console.WriteLine($"Jogador {jogadorAtual} venceu!");
                jogoTerminado = true;
                return;
            }
        }

        // Verificar diagonais
        if ((matriz[0, 0] == jogadorAtual && matriz[1, 1] == jogadorAtual && matriz[2, 2] == jogadorAtual) ||
            (matriz[0, 2] == jogadorAtual && matriz[1, 1] == jogadorAtual && matriz[2, 0] == jogadorAtual))
        {
            Console.WriteLine($"Jogador {jogadorAtual} venceu!");
            jogoTerminado = true;
        }
    }

    static void Empate()
    {
        bool empate = true;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matriz[i, j] == ' ')
                {
                    empate = false;
                    break;
                }
            }

            if (!empate)
            {
                break;
            }
        }

        if (empate)
        {
            Console.WriteLine("O jogo empatou!");
            jogoTerminado = true;
        }
    }

    static void gamers()
    {
        jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
    }
}