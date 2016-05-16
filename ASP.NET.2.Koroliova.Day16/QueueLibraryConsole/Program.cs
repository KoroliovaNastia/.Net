using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueLibrary;

namespace QueueLibraryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListQueue<char> ll = new LinkedListQueue<char>();

            Console.WriteLine("Исходное количество элементов в списке: " + ll.Count);

        Console.WriteLine();

        Console.WriteLine("Добавить в список 5 элементов");

        // Добавить элементы в связный список.
        ll.Enqueue('А');
        ll.Enqueue('В');
        ll.Enqueue('С');
        ll.Enqueue('D');
        ll.Enqueue('Е');

        Console.WriteLine("Количество элементов в списке: " + ll.Count);

        // Отобразить связный список, обойдя его вручную.
        LListNode<char> node;

        Console.Write("Отобразить содержимое списка по ссылкам: ");
        for(node = ll.Head; node != null; node = node.Next)
            Console.Write(node.Value + " ");

        Console.WriteLine("\n");

        // Отобразить связный список, обойдя его в цикле foreach.
        Console.Write("Отобразить содержимое списка в цикле foreach: ");
        foreach(char ch in ll)
            Console.Write(ch + " ");

        Console.WriteLine("\n");

        Console.WriteLine("Удалить 2 элемента из списка");

        ll.Dequeue();
        ll.Dequeue();

        Console.WriteLine("Количество элементов в списке: " + ll.Count);

        Console.Write("Содержимое списка после удаления элементов: ");
        foreach(char ch in ll)
            Console.Write(ch + " ");

        Console.WriteLine("\n");

        // Добавить три элемента в конец списка.
        ll.Enqueue('X');
        ll.Enqueue('Y');
        ll.Enqueue('Z');

        Console.Write("Содержимое списка после ввода элементов: ");
        foreach(char ch in ll)
            Console.Write(ch + " ");

        Console.WriteLine("\n");

        MassQueue<double> q = new MassQueue<double>();

        q.Enqueue(98.6);
        q.Enqueue(212.0);
        q.Enqueue(32.0);
        q.Enqueue(3.1416);

        double sum = 0.0;
        Console.Write("Очередь содержит: ");
        while (q.Count > 0)
        {
            double val = q.Dequeue();
            Console.Write(val + " ");
            sum += val;
        }

        Console.WriteLine("\nИтоговая сумма равна " + sum);
            Console.Read();
        }
    }
}
