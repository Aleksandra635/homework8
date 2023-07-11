// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


int rows1 = Prompt("Введите количество строк для первой матрицы: ");
int columns1 = Prompt("Введите количество столбцов для первой матрицы: ");
int rows2 = Prompt("Введите количество строк для второй матрицы: ");
int columns2 = Prompt("Введите количество столбцов для второй матрицы: ");

int[,] matrix1 = GetMatrix(rows1, columns1);
Console.WriteLine("Первая матрица:");
PrintMatrix(matrix1);

int[,] matrix2 = GetMatrix(rows2, columns2);
Console.WriteLine("Вторая матрица:");
PrintMatrix(matrix2);

if (columns1 != rows2)
{
    Console.WriteLine("Невозможно умножить матрицы с данными размерами.");
    return;
}

int[,] result = MultiplyMatrices(matrix1, matrix2);
Console.WriteLine("Результат умножения матриц:");
PrintMatrix(result);


int Prompt(string message)
{
    Console.WriteLine(message);
    int number = int.Parse(Console.ReadLine());
    return number;
}


int[,] GetMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    Random random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = random.Next(1, 10);
        }
    }
    return matrix;
}

int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
{
    int rows1 = matrix1.GetLength(0);
    int columns1 = matrix1.GetLength(1);
    int rows2 = matrix2.GetLength(0);
    int columns2 = matrix2.GetLength(1);

    int[,] result = new int[rows1, columns2];

    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < columns2; j++)
        {
            for (int k = 0; k < columns1; k++)
            {
                result[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return result;
}

void PrintMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}
