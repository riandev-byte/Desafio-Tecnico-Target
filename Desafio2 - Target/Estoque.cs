using System.Text.Json;

string json = """
{
    "estoque": [
        {
            "codigoProduto": 101,
            "descricaoProduto": "Caneta Azul",
            "estoque": 150
        },
        {
            "codigoProduto": 102,
            "descricaoProduto": "Caderno Universitário",
            "estoque": 75
        },
        {
            "codigoProduto": 103,
            "descricaoProduto": "Borracha Branca",
            "estoque": 200
        },
        {
            "codigoProduto": 104,
            "descricaoProduto": "Lápis Preto HB",
            "estoque": 320
        },
        {
            "codigoProduto": 105,
            "descricaoProduto": "Marcador de Texto Amarelo",
            "estoque": 90
        }
    ]
}
""";

Dictionary<int, int> estoques = new();

Dictionary<int, string> produtos = new();

JsonDocument documento = JsonDocument.Parse(json);

foreach (JsonElement produto in documento.RootElement
                                              .GetProperty("estoque")
                                              .EnumerateArray())
{
    int codigo = produto.GetProperty("codigoProduto").GetInt32();

    string descricao = produto
        .GetProperty("descricaoProduto")
        .GetString()!;

    int quantidade = produto
        .GetProperty("estoque")
        .GetInt32();

    produtos[codigo] = descricao;
    estoques[codigo] = quantidade;
}


int idMovimentacao = 1;


while (true)
{
    Console.WriteLine();
    Console.WriteLine("Controle de Estoque:");

    foreach (var produto in produtos)
    {
        Console.WriteLine(
            $"{produto.Key} - {produto.Value} - Estoque: {estoques[produto.Key]}"
        );
    }

    Console.WriteLine();
    Console.WriteLine("1 - Entrada");
    Console.WriteLine("2 - Saída");
    Console.WriteLine("0 - Sair");

    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine() ?? "";


    if (opcao == "0")
    {
        Console.WriteLine("Programa encerrado.");
        break;
    }


    if (opcao != "1" && opcao != "2")
    {
        Console.WriteLine("Opção inválida.");
        continue;
    }


    Console.Write("Digite o código do produto: ");

    if (!int.TryParse(Console.ReadLine(), out int codigoProduto))
    {
        Console.WriteLine("Código inválido.");
        continue;
    }


    if (!produtos.ContainsKey(codigoProduto))
    {
        Console.WriteLine("Produto não encontrado.");
        continue;
    }


    Console.Write("Digite a quantidade: ");

    if (!int.TryParse(Console.ReadLine(), out int quantidade))
    {
        Console.WriteLine("Quantidade inválida.");
        continue;
    }


    if (quantidade <= 0)
    {
        Console.WriteLine("A quantidade deve ser maior que zero.");
        continue;
    }


    Console.Write("Descrição da movimentação: ");

    string descricaoMovimentacao =
        Console.ReadLine() ?? "";


    if (opcao == "1")
    {
        estoques[codigoProduto] =
            estoques[codigoProduto] + quantidade;

        Console.WriteLine();
        Console.WriteLine("Movimentação Realizada Com Sucesso!");

        Console.WriteLine(
            $"ID da movimentação: {idMovimentacao}"
        );

        Console.WriteLine("Tipo: Entrada");
    }


    else
    {
        if (quantidade > estoques[codigoProduto])
        {
            Console.WriteLine("Estoque insuficiente.");
            continue;
        }

        estoques[codigoProduto] =
            estoques[codigoProduto] - quantidade;

        Console.WriteLine();
        Console.WriteLine("Movimentação Realizada Com Sucesso!");

        Console.WriteLine(
            $"ID da movimentação: {idMovimentacao}"
        );

        Console.WriteLine("Tipo: Saída");
    }


    Console.WriteLine(
        $"Produto: {produtos[codigoProduto]}"
    );

    Console.WriteLine(
        $"Descrição: {descricaoMovimentacao}"
    );

    Console.WriteLine(
        $"Quantidade movimentada: {quantidade}"
    );

    Console.WriteLine(
        $"Estoque final: {estoques[codigoProduto]}"
    );

    idMovimentacao++;
}