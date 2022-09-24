// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3

// Создание массива
int LineTwoDimensionalArray()
{
    Console.Write("Введите колличество строк массива: ");
    bool parseNIsOk = int.TryParse(Console.ReadLine(), out int line);
    if (!parseNIsOk)
    {
        Console.WriteLine("Введено значение некорректного формата, введите заново");
        return LineTwoDimensionalArray();
    }
    else
    {
        return line;
    }
}
int ColumnTwoDimensionalArray()
{
    Console.Write("Введите колличество столбцов массива: ");
    bool parseNIsOk = int.TryParse(Console.ReadLine(), out int column);
    if (!parseNIsOk)
    {
        Console.WriteLine("Введено значение некорректного формата, введите заново");
        return ColumnTwoDimensionalArray();
    }
    else
    {
        return column;
    }
}

int[,] MakeTwoDimensionalArray()
{
    int line = LineTwoDimensionalArray();
    int column = ColumnTwoDimensionalArray();
    int[,] array = new int[line, column];
    return array;
}

// Ввода начального и конечного чисел массива.
int RandomNumbersStart()
{
    Console.Write("Введите первое число массива: ");
    bool parseNIsOk = int.TryParse(Console.ReadLine(), out int start);
    if (!parseNIsOk)
    {
        Console.WriteLine("Введено некорректное значение. Введите число заново");
        return RandomNumbersStart();
    }
    else
    {
        return start;
    }
}
int RandomNumbersEnd()
{
    Console.Write("Введите последнее число: ");
    bool parseMIsOk = int.TryParse(Console.ReadLine(), out int finish);
    if (!parseMIsOk)
    {
        Console.WriteLine("Введено некорректное значение. Введите число заново");
        return RandomNumbersEnd();
    }
    else
    {
        return finish;
    }
}
int[,] FillTwoDimensionalArray(int[,] array, int startRandom, int finishRandom)
{
    Random random = new Random();
    int startValue = startRandom;
    int endValue = finishRandom;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)

        {
            array[i, j] = random.Next(startValue, endValue);
        }
    }
    return array;
}
void WriteTwoDimensionalArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)

        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

//Среднее арифметическое каждого столбца:
string ArithmeticMeanOfElements(int[,] array)
{
    string result = string.Empty;
    double count = 0;

    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)

        {
            count = count + array[j, i];
        }

        count = count / array.GetLength(0);
        if (i == (array.GetLength(1) - 1)) result = result + count + ".";
        else result = result + count + "; ";
        count = 0;
    }
    return result;
}

int[,] array = MakeTwoDimensionalArray();
int startRandom = RandomNumbersStart();
int finishtRandom = RandomNumbersEnd();
array = FillTwoDimensionalArray(array, startRandom, finishtRandom);
WriteTwoDimensionalArray(array);
Console.WriteLine();
string result = ArithmeticMeanOfElements(array);
Console.WriteLine($"Среднее арифметическое каждого столбца : {result}");