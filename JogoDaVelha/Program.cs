using System;

class Program
{
    static char[,] tabuleiro = new char[3, 3];
    static char  jogadorAtual = 'X';

    static void Main()
    {
        IniciarTabuleiro();

        while (true)
        {
            Console.Clear();
            MostrarTabuleiro();
            FazerJogada();

            if (VerificarVitoria())
            {
                Console.Clear();
                MostrarTabuleiro();
                Console.WriteLine($"\nJogador '{jogadorAtual}' Venceu!");
                break;
            }

            if(VerificarEmpate())
            {
                Console.Clear();
                MostrarTabuleiro();
                Console.WriteLine("\nEmpate!");
                break;
            }

            AlterarJogador();
        }
        Console.WriteLine("\nFim de Jogo! Pressione ENTER para sair");
        Console.ReadLine();
    }

    static void IniciarTabuleiro()
    {
        for (int linha = 0; linha < 3; linha++)
            for (int col = 0; col < 3; col++)
                tabuleiro[linha, col] = ' ';

    }

    static void MostrarTabuleiro()
    {
        Console.WriteLine("  0 1 2");
        for (int linha = 0; linha < 3; linha++)
        {
            Console.Write(linha + " ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(tabuleiro[linha, col]);
                if (col < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (linha < 2) Console.WriteLine("  -+-+-");
        }
    }


    static void FazerJogada()
    {
        int linha, col;
        do
        {
            Console.WriteLine($"\nJogador '{jogadorAtual}', digite a linha (0-2): ");
            linha = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a coluna (0-2): ");
            col = int.Parse(Console.ReadLine());

            if (linha < 0 ||  linha > 2 || col < 0 || col > 2 || tabuleiro[linha, col] != ' ')
            {
                Console.WriteLine("Jogada Invalida, tente novamente.");
            }
            else
            {
                break;
            }
        }while (true);

        tabuleiro[linha, col] = jogadorAtual;
    }

    static void AlterarJogador()
    {
        jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
    }

    static bool VerificarVitoria()
    {
        for (int i = 0; i < 3 ; i++)
        {
            if (tabuleiro[i, 0] == jogadorAtual && tabuleiro[i, 1] == jogadorAtual && tabuleiro[i, 2] == jogadorAtual) 
                return true;

        }

        for (int i = 0; i < 3 ; i++)
        {
            if (tabuleiro[0, i] == jogadorAtual && tabuleiro[1, i] == jogadorAtual && tabuleiro[2, i] == jogadorAtual)
                return true;
        }

        if (tabuleiro[0, 0] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 2] == jogadorAtual)
            return true;

        if (tabuleiro[0, 2] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 0] == jogadorAtual)
            return true;

        return false;
    }

    static bool VerificarEmpate()
    {
        foreach (char c in tabuleiro)
        {
            if (c == ' ') return false;
        }
        return true;
    }
}