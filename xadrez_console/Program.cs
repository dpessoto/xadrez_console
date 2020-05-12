using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                PartidadeXadrez partida = new PartidadeXadrez();

                while (!partida.terminada) {

                    try {

                        Console.Clear();
                        Tela.imprimirPartida(partida);
                        /*Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);*/

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigiem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();

                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                        Console.WriteLine();

                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);
                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroExeception e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Tela.imprimirTabuleiro(partida.tab);
            }
            catch (TabuleiroExeception e) {
                Console.WriteLine(e.Message);
            }

        }

    }
}
