using System;
using System.IO;

namespace DeleteGrab
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\0.0.309\\modules\\discord_desktop_core\\index.js";
            if(File.Exists(path))
            {
                if(File.ReadAllText(path) == @"module.exports = require('./core.asar');")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Aucun token grabber trouvé !");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(-1);
                } else
                {
                    try
                    {
                        File.WriteAllText(path, @"module.exports = require('./core.asar');");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Token grabber trouvé et patché avec succès!");
                        System.Threading.Thread.Sleep(-1);
                    } catch
                    {
                        Console.WriteLine("Token grabber trouvé (veuillez lancer l'application en administrateur pour patcher le token grab)!");
                        System.Threading.Thread.Sleep(-1);
                    }
                }
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je ne peux pas trouver le fichier index.js de discord.");
                System.Threading.Thread.Sleep(-1);
            }
         }
    }
}
