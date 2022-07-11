using System.Diagnostics;
using HLC17.BinaryTreeExample;


BinaryTree binaryTree = new BinaryTree();

var random = new Random(); 

var randomList = new List<int>();

var findNumber = 0;

// Заповнення дерева 10000000 значень

Parallel.For(1, 10000000, i =>
{
    var current = NewNumber();

    if (i == 50000)
    {
        findNumber = current;
    }

    binaryTree.Insert(current);
});

// Замір видалення
// Результат - 1мс
// Також перевіряв пошук та інсерт - той ж результат
var stopWatch = new Stopwatch();
stopWatch.Start();

binaryTree.SoftDelete(findNumber);

stopWatch.Stop();

Console.WriteLine($"Elapsed time - {stopWatch.ElapsedMilliseconds}");

Console.ReadLine();

int NewNumber()
{
    var n = random.Next(0, 999999999);
    while (randomList.Contains(n))
        n = random.Next(0, 999999999);

    return n;
}