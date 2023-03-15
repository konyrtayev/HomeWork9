Main m = new Main();

m.MainProject();

internal class Main
{
  public void MainProject()
  {
    Console.Clear();

    Tasks t = new Tasks();
    Methods m = new Methods();

    bool isWork = true;
    string mainMenuText = $"Если хотите вызвать справку, напишите - /help.{Environment.NewLine}"
                        + $"Если хотите завершить работу программы, напишите - exit.{Environment.NewLine}"
                        + $"Если хотите очистить терминал, напишите clear.{Environment.NewLine}{Environment.NewLine}"
                        + $"Какую задачу хотите проверить?{Environment.NewLine}Напишите номер задачи от 1 до 3: ";

    while (isWork)
    {
      Console.Write(mainMenuText);
      string word = Console.ReadLine();
      Console.WriteLine();

      if (m.CheckNumberOfTask(word))
      {
        t.RunProgram(word);
        m.ToEndTask();
      }
      else if (word.ToLower() == "e" || word.ToLower() == "exit" || word.ToLower() == "у")
      {
        isWork = false;
      }
      else if (word.ToLower() == "c" || word.ToLower() == "clear" || word.ToLower() == "с")
      {
        Console.Clear();
      }
      else if (word.ToLower() == "/help" || word.ToLower() == "h" || word.ToLower() == "р")
      {
        m.ToHelp();
      }
      else
      {
        m.CantFindTask();
      }
    }
  }
}
public class Methods
{
  #region MethodsForTasks

  public int ReadInt(string arg)
  {
    Console.Write($"Введите {arg}: ");
    int num;

    while (!int.TryParse(Console.ReadLine(), out num))
    {
      Console.Write("Значение не подходит, повторите: ");
    }

    return num;
  }

  public void PrintFromNToOneRecursion(int n)
  {
    if (n > 0)
    {
      Console.Write($"{n} ");
      PrintFromNToOneRecursion(--n);
    }
  }

  public bool CheckPositive(int n)
  {
    if (n > 0) return true;
    else return false;
  }

  public int CalculateSumOfNaturalFromMToNRecursion(int m, int n)
  {
    if (m > n - 1)
    {
      return m + CalculateSumOfNaturalFromMToNRecursion(m - 1, n);
    }

    return 0;
  }

  public bool CheckNumbers(int m, int n)
  {
    if (m < 1 || n < 1)
    {
      return false;
    }

    return true;
  }

  public int CalculateAckermanRecursion(int m, int n)
  {
    if (m == 0)
    {
      return n + 1;
    }
    else if (m > 0 && n == 0)
    {
      return CalculateAckermanRecursion(m - 1, 1);
    }
    else if (m > 0 && n > 0)
    {
      return CalculateAckermanRecursion(m - 1, CalculateAckermanRecursion(m, n - 1));
    }

    return 0;
  }

  #endregion

  #region MethodsForWork

  public bool CheckNumberOfTask(string number)
  {
    return (number == "1" || number == "2" || number == "3" || number == "4" || number == "5");
  }

  public void ToEndTask()
  {
    Console.WriteLine($"Для возврата в главное меню, нажмите любую кнопку{Environment.NewLine}");
    Console.ReadKey();
  }

  public void ToHelp()
  {
    Console.Clear();
    string text = $"Справка:{Environment.NewLine}1. Вывести все натуральные числа от N до 1.{Environment.NewLine}"
                + $"2. Вывести сумму всех натуральных элементов в промежутке от M до N.{Environment.NewLine}"
                + $"3. Вычисление функции Аккермана.{Environment.NewLine}"
                + $"/help или /h. Справка{Environment.NewLine}Exit или E. Завершение работы программы";

    Console.WriteLine(text);
    ToEndTask();
    Console.Clear();
  }

  public void CantFindTask()
  {
    Console.WriteLine($"Команда не была распознана, повторите ввод{Environment.NewLine}");
  }

  #endregion
}
internal class Tasks
{
  Methods m = new Methods();

  public void RunProgram(string word)
  {
    switch (word)
    {
      case "1":
        {
          Task64_FromNToOne();
          break;
        }
      case "2":
        {
          Task66_SumOfNaturalFromMToN();
          break;
        }
      case "3":
        {
          Task68_AckermanFunction();
          break;
        }
    }
  }

  public void Task64_FromNToOne()
  {
    string text = $"Вы выбрали задачу номер 1{Environment.NewLine}"
                + $"Вывести все натуральные числа от N до 1.{Environment.NewLine}";
    Console.WriteLine(text);

    int n = m.ReadInt("число N");

    if (m.CheckPositive(n))
    {
      m.PrintFromNToOneRecursion(n);
      Console.WriteLine();
    }
    else
    {
      Console.WriteLine("Число меньше 1");
    }
  }

  public void Task66_SumOfNaturalFromMToN()
  {
    string text = $"Вы выбрали задачу номер 2{Environment.NewLine}"
                + $"Вывести сумму всех натуральных элементов в промежутке от M до N.{Environment.NewLine}";
    Console.WriteLine(text);

    int n1 = m.ReadInt("число М");
    int n2 = m.ReadInt("число N");
    int sum = 0;

    if (n1 == n2)
    {
      Console.WriteLine("Числа равны");
    }
    else if (m.CheckNumbers(n1, n2))
    {
      if (n1 > n2)
      {
        sum = m.CalculateSumOfNaturalFromMToNRecursion(n1, n2);
        Console.WriteLine($"Сумма всех элементов от {n1} до {n2} равна {sum}");
      }
      else if (n2 > n1)
      {
        sum = m.CalculateSumOfNaturalFromMToNRecursion(n2, n1);
        Console.WriteLine($"Сумма всех элементов от {n2} до {n1} равна {sum}");
      }
    }
  }

  public void Task68_AckermanFunction()
  {
    string text = $"Вы выбрали задачу номер 3{Environment.NewLine}"
                + $"Вычисление функции Аккермана.{Environment.NewLine}";
    Console.WriteLine(text);

    int n1 = m.ReadInt("число М");
    int n2 = m.ReadInt("число N");
    int result = m.CalculateAckermanRecursion(n1, n2);

    Console.WriteLine($"A({n1}, {n2}) = {result}");
  }
}