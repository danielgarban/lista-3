using System;
using System.Text;
using System.Threading;

namespace BrickRaceTela
{
    class Program
    {
        // ---------- Configurações do layout ----------
        const int LarguraPista = 30;   // largura da área da pista
        const int LarguraPainel = 39;  // largura do painel lateral
        const int AlturaPista = 16;    // quantidade de linhas da pista

        static void Main()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "BRICK RACE";

            // ---------- Variáveis mostradas no painel ----------
            int pontos = 0;
            int recorde = 0;
            int nivel = 1;
            int velocidade = 1;

            bool rodando = true;

            Console.Clear(); // limpa a tela antes de começar a desenhar

            // ---------- Loop principal: atualiza a tela continuamente ----------
            while (rodando)
            {
                // Entrada do usuário (não bloqueante) — só para sair com ESC
                if (Console.KeyAvailable)
                {
                    var tecla = Console.ReadKey(true).Key;
                    if (tecla == ConsoleKey.Escape) rodando = false;
                }

                DesenharTela(pontos, recorde, nivel, velocidade);

                Thread.Sleep(200); // controla a taxa de atualização da tela
            }

            Console.Clear();
            Console.WriteLine("Saindo do Brick Race...");
        }

        // ------------------------- Desenho da tela ----------------------------
        static void DesenharTela(int pontos, int recorde, int nivel, int velocidade)
        {
            // ---------- Matriz que representa a pista (linhas x colunas) ----------
            char[,] pista = new char[AlturaPista, LarguraPista];
            for (int l = 0; l < AlturaPista; l++)
                for (int c = 0; c < LarguraPista; c++)
                    pista[l, c] = ' ';

            // Divisória central: separa a pista em duas faixas
            int colDivisoria = LarguraPista / 2;
            for (int l = 0; l < AlturaPista; l++)
                pista[l, colDivisoria] = '│';

            // ---------- Texto do painel lateral ----------
            string[] painel = new string[AlturaPista];
            for (int i = 0; i < AlturaPista; i++) painel[i] = "";
            painel[0] = $" Pontos: {pontos}";
            painel[1] = $" Recorde: {recorde}";
            painel[2] = $" Nível: {nivel}";
            painel[3] = $" Velocidade: {velocidade}";
            painel[4] = "";
            painel[5] = " Controles";
            painel[6] = " A ← Esquerda";
            painel[7] = " D → Direita";
            painel[8] = " ESC Sair";

            // ---------- Monta o frame completo ----------
            var sb = new StringBuilder();

            sb.Append('╔').Append('═', LarguraPista + 1 + LarguraPainel).Append('╗').Append('\n');

            string titulo = "BRICK RACE";
            int espacoTotal = LarguraPista + 1 + LarguraPainel;
            int espacoEsq = (espacoTotal - titulo.Length) / 2;
            int espacoDir = espacoTotal - titulo.Length - espacoEsq;
            sb.Append('║').Append(' ', espacoEsq).Append(titulo).Append(' ', espacoDir).Append('║').Append('\n');

            sb.Append('╠').Append('═', LarguraPista).Append('╦').Append('═', LarguraPainel).Append('╣').Append('\n');

            for (int l = 0; l < AlturaPista; l++)
            {
                sb.Append('║');
                for (int c = 0; c < LarguraPista; c++) sb.Append(pista[l, c]);
                sb.Append('║');
                sb.Append(painel[l].PadRight(LarguraPainel));
                sb.Append('║').Append('\n');
            }

            sb.Append('╚').Append('═', LarguraPista).Append('╩').Append('═', LarguraPainel).Append('╝');

            // Atualiza a tela: posiciona o cursor no topo e reescreve o frame
            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());
        }
    }
}
