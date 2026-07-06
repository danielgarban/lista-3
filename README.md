using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        const int linhas = 20;
        const int colunas = 30;

        char[,] pista = new char[linhas, colunas];

        while (true)
        {
            // Limpa a matriz
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    pista[i, j] = ' ';
                }
            }

            // Desenha o divisor das duas pistas
            for (int i = 0; i < linhas; i++)
            {
                pista[i, colunas / 2] = '│';
            }

            Console.Clear();

            // Título
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                           BRICK RACE                               ║");
            Console.WriteLine("╠══════════════════════════════╦═══════════════════════════════════════╣");

            // Área do jogo + painel lateral
            for (int i = 0; i < linhas; i++)
            {
                Console.Write("║");

                // Desenha a pista
                for (int j = 0; j < colunas; j++)
                {
                    Console.Write(pista[i, j]);
                }

                Console.Write("║");

                // Painel lateral
                switch (i)
                {
                    case 0:
                        Console.Write(" Pontos: 0");
                        break;
                    case 1:
                        Console.Write(" Recorde: 0");
                        break;
                    case 2:
                        Console.Write(" Nível: 1");
                        break;
                    case 3:
                        Console.Write(" Velocidade: 1");
                        break;
                    case 5:
                        Console.Write(" Controles");
                        break;
                    case 6:
                        Console.Write(" A ← Esquerda");
                        break;
                    case 7:
                        Console.Write(" D → Direita");
                        break;
                    case 8:
                        Console.Write(" ESC Sair");
                        break;
                }

                Console.WriteLine();
            }

            // Linha inferior
            Console.WriteLine("╚══════════════════════════════╩═══════════════════════════════════════╝");

            // Atualiza a tela
            Thread.Sleep(100);
        }
    }
}
