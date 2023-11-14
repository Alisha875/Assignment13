using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @"C:\Users\alish\Desktop\Mphasis\Day-7";

        while (true)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Create File");
            Console.WriteLine("2. Read File");
            Console.WriteLine("3. Append to File");
            Console.WriteLine("4. Delete File");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter file name: ");
                        string createFileName = Console.ReadLine();
                        Console.Write("Enter content: ");
                        string createFileContent = Console.ReadLine();
                        CreateFile(path, createFileName, createFileContent);
                        break;

                    case 2:
                        Console.Write("Enter file name to read: ");
                        string readFileName = Console.ReadLine();
                        ReadFile(path, readFileName);
                        break;

                    case 3:
                        Console.Write("Enter file name to append: ");
                        string appendFileName = Console.ReadLine();
                        Console.Write("Enter content to append: ");
                        string appendContent = Console.ReadLine();
                        AppendToFile(path, appendFileName, appendContent);
                        break;

                    case 4:
                        Console.Write("Enter file name to delete: ");
                        string deleteFileName = Console.ReadLine();
                        DeleteFile(path, deleteFileName);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }

    static void CreateFile(string path, string fileName, string content)
    {
        try
        {
            string fullPath = Path.Combine(path, fileName);
            File.WriteAllText(fullPath, content);
            Console.WriteLine($"File '{fullPath}' created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating file: {ex.Message}");
        }
    }

    static void ReadFile(string path, string fileName)
    {
        try
        {
            string fullPath = Path.Combine(path, fileName);
            string content = File.ReadAllText(fullPath);
            Console.WriteLine($"Content of '{fullPath}':\n{content}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{fileName}' not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }

    static void AppendToFile(string path, string fileName, string content)
    {
        try
        {
            string fullPath = Path.Combine(path, fileName);
            File.AppendAllText(fullPath, content);
            Console.WriteLine($"Content appended to '{fullPath}' successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error appending to file: {ex.Message}");
        }
    }

    static void DeleteFile(string path, string fileName)
    {
        try
        {
            string fullPath = Path.Combine(path, fileName);
            File.Delete(fullPath);
            Console.WriteLine($"File '{fullPath}' deleted successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{fileName}' not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting file: {ex.Message}");
        }
    }
}

