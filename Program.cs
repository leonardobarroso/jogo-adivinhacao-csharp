void ExibirLogo()
{
    Console.WriteLine(@"       _                         _                     _       _       _
      | |                       | |           /\      | |     (_)     | |
      | | ___   __ _  ___     __| | __ _     /  \   __| |_   ___ _ __ | |__   __ _  ___ __ _  ___
  _   | |/ _ \ / _` |/ _ \   / _` |/ _` |   / /\ \ / _` \ \ / / | '_ \| '_ \ / _` |/ __/ _` |/ _ \
 | |__| | (_) | (_| | (_) | | (_| | (_| |  / ____ \ (_| |\ V /| | | | | | | | (_| | (_| (_| | (_) |
  \____/ \___/ \__, |\___/   \__,_|\__,_| /_/    \_\__,_| \_/ |_|_| |_|_| |_|\__,_|\___\__,_|\___/
                __/ |
               |___/                                                                               ");

    Console.WriteLine("Bem vindo ao jogo de adivinhação!");
    Console.WriteLine("Tente adivinhar o número secreto entre 1 e 100.");
}

static int Gerador()
{
    // 1. Cria uma nova instância da classe Random
    Random sorteador = new Random();

    // 2. Gera um número inteiro aleatório entre 1 e 100
    int numeroAleatorio = sorteador.Next(1, 101);
    return numeroAleatorio;
}

static int Dificuldade()
{
    while (true)
    {
        Console.Write("Digite o número correspondente à dificuldade desejada:\n");
        Console.WriteLine("1 - Fácil (10 tentativas)");
        Console.WriteLine("2 - Médio (5 tentativas)");
        Console.WriteLine("3 - Difícil (3 tentativas)");

        switch (Console.ReadLine())
        {
            case "1":
                return 10;
            case "2":
                return 5;
            case "3":
                return 3;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma dificuldade válida.");
                break;
        }
    }
}

static void Jogar(int chances)
{
    int tentativas = 0;
    int numeroSecreto = Gerador();
    bool jogar = true;
    if (chances == 10)
    {
        Console.WriteLine("Você escolheu a dificuldade Fácil. Você tem 10 tentativas para adivinhar o número secreto.");
    }
    else if (chances == 5)
    {
        Console.WriteLine("Você escolheu a dificuldade Médio. Você tem 5 tentativas para adivinhar o número secreto.");
    }
    else if (chances == 3)
    {
        Console.WriteLine("Você escolheu a dificuldade Difícil. Você tem 3 tentativas para adivinhar o número secreto.");
    }

    while (jogar)
    {
        Console.Write("Digite seu palpite: ");
        if (!int.TryParse(Console.ReadLine(), out int palpite))
        {
            Console.WriteLine("Digite um número válido!");
            continue;
        }
        tentativas++;


        if (palpite < numeroSecreto)
        {
            Console.WriteLine("O número secreto é maior.");
            if (tentativas >= chances)
            {
                Console.WriteLine($"Você excedeu o número máximo de tentativas ({chances}). O número secreto era {numeroSecreto}.");
                jogar = false;
            } else
            {
                Console.WriteLine($"Tente novamente. Você tem {chances - tentativas} tentativas restantes.\n");
            }
        }
        else if (palpite > numeroSecreto)
        {
            Console.WriteLine("O número secreto é menor. Tente novamente.");
            if (tentativas >= chances)
            {
                Console.WriteLine($"Você excedeu o número máximo de tentativas ({chances}). O número secreto era {numeroSecreto}.");
                jogar = false;
            } else
            {
                Console.WriteLine($"Tente novamente. Você tem {chances - tentativas} tentativas restantes.\n");
            }
        }
        else
        {
            Console.WriteLine($"Parabéns! Você acertou o número secreto em {tentativas} tentativas.");

            string resposta = "";
            while (resposta != "s" && resposta != "n")
            {
                Console.WriteLine("Deseja jogar novamente? (s/n)");
                resposta = (Console.ReadLine() ?? "").ToLower();
                if (resposta != "s" && resposta != "n")
                {
                    Console.WriteLine("Opção inválida. Digite 's' para sim ou 'n' para não.");
                    continue;
                }
                else
                    switch (resposta.ToLower())
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
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                break;
            }
        }

    }
}

ExibirLogo();
int chances = Dificuldade();
Jogar(chances);
