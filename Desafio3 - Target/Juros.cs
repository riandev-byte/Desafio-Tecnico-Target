Console.WriteLine("Calculo de Juros");


Console.Write("Digite o valor da conta: R$ ");

if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
{
    Console.WriteLine("Valor inválido.");
    return;
}


Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");

if (!DateTime.TryParse(Console.ReadLine(), out DateTime vencimento))
{
    Console.WriteLine("Data inválida.");
    return;
}


DateTime hoje = DateTime.Today;


if (vencimento >= hoje)
{
    Console.WriteLine();
    Console.WriteLine("A conta não está vencida.");

    Console.WriteLine(
        $"Valor a pagar: R$ {valor:F2}"
    );

    return;
}


TimeSpan diferenca = hoje - vencimento;

int diasAtraso = diferenca.Days;


decimal taxaJuros = 0.025m;


decimal juros =
    valor * taxaJuros * diasAtraso;


decimal valorFinal =
    valor + juros;


Console.WriteLine();
Console.WriteLine("Resultado:");

Console.WriteLine(
    $"Valor original: R$ {valor:F2}"
);

Console.WriteLine(
    $"Data de vencimento: {vencimento:dd/MM/yyyy}"
);

Console.WriteLine(
    $"Dias de atraso: {diasAtraso}"
);

Console.WriteLine(
    $"Juros: R$ {juros:F2}"
);

Console.WriteLine(
    $"Valor final: R$ {valorFinal:F2}"
);