void ExibirLogo(){
    Console.WriteLine(@"       _                         _                     _       _       _
      | |                       | |           /\      | |     (_)     | |
      | | ___   __ _  ___     __| | __ _     /  \   __| |_   ___ _ __ | |__   __ _  ___ __ _  ___
  _   | |/ _ \ / _` |/ _ \   / _` |/ _` |   / /\ \ / _` \ \ / / | '_ \| '_ \ / _` |/ __/ _` |/ _ \
 | |__| | (_) | (_| | (_) | | (_| | (_| |  / ____ \ (_| |\ V /| | | | | | | | (_| | (_| (_| | (_) |
  \____/ \___/ \__, |\___/   \__,_|\__,_| /_/    \_\__,_| \_/ |_|_| |_|_| |_|\__,_|\___\__,_|\___/
                __/ |
               |___/                                                                               ");
}

static int Gerador()
{
    // O limite superior é exclusivo: 101 permite sortear até 100.
    return Random.Shared.Next(1, 101);
}

static void Jogar()
{
    Console.WriteLine("Bem-vindo ao jogo de adivinhação!");
    Console.WriteLine("Tente adivinhar o número secreto entre 1 e 100.");
    int tentativas = 0;
    int numeroSecreto = Gerador();
    bool jogar = true;

    while (jogar)
    {
        Console.Write("Digite seu palpite: ");
        string? entrada = Console.ReadLine();
        if (entrada is null)
        {
            Console.WriteLine("Entrada encerrada. Obrigado por jogar!");
            return;
        }

        if (!int.TryParse(entrada, out int palpite) || palpite < 1 || palpite > 100)
        {
            Console.WriteLine("Digite um número inteiro entre 1 e 100!");
            continue;
        }

        // Apenas palpites válidos contam como tentativas.
        tentativas++;
        if (palpite < numeroSecreto)
        {
            Console.WriteLine("O número secreto é maior. Tente novamente.");
        }
        else if (palpite > numeroSecreto)
        {
            Console.WriteLine("O número secreto é menor. Tente novamente.");
        }
        else
        {
            Console.WriteLine($"Parabéns! Você acertou o número secreto em {tentativas} tentativas.");
            string resposta = "";
            while (resposta != "s" && resposta != "n")
            {
                Console.Write("Deseja jogar novamente? (s/n): ");
                // Sem mais entrada, encerra o jogo; espaços e maiúsculas são aceitos.
                resposta = (Console.ReadLine() ?? "n").Trim().ToLowerInvariant();
                switch (resposta)
                {
                    case "s":
                        tentativas = 0;
                        numeroSecreto = Gerador();
                        Console.WriteLine("Novo jogo iniciado! Tente adivinhar o novo número secreto.");
                        break;
                    case "n":
                        jogar = false;
                        Console.WriteLine("Obrigado por jogar! Até a próxima.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Digite 's' para sim ou 'n' para não.");
                        break;
                }
            }
        }
    }
}

ExibirLogo();
Jogar();
