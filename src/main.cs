/******************************************************************************
*                     Multi-Use System Command-Line Tool                      *
*                               (AKA. MUSCL)                                  *
*                                                                             *
*                       Written by Siri - 2020-2021                           *
*                       Licensed under Gnu GPL v3.0                           *
*******************************************************************************/
using System;
using System.IO;
using System.IO.Compression;


namespace muscl
{
    class main
    {
        public static main m = new main();
        static void Main(string[] args)
        {
            // Add void to get installdir before handling args
            int exitCode = 0;
            if(args.Length == 0 || args == null) {
                Console.Write("No arguments. \nUse -h or --help for more information.");
            }
            for (int a = 0; a < args.Length; a++) {
                if(args[a] == "-h" || args[a] == "--help"){
                    if(args.Length == 1){
                        exitCode = m.HelpMSG();
                    } else {
                        exitCode = m.ArgHelp(args[a + 1]);
                    }
                    return;
                }
                else if(args[a] == "-v" || args[a] == "--version"){
                    exitCode = m.Version();
                }
                else if(args[a] == "-r" || args[a] == "--read"){
                    exitCode = m.Read(args[a + 1]);
                    a++;
                }
                /*
                else if (args[a] == "-z" || args[a] == "--zip")
                {
                    exitCode = m.Zip(args[a + 1], args[a + 2]);
                    a++;
                    a++;
                }
                else if (args[a] == "-uz" || args[a] == "--unzip")
                {
                    exitCode = m.UnZip(args[a + 1], args[a + 2]);
                    a++;
                    a++;
                }
                */
                else {
                    Console.Write("\nArgument \"{0}\" not recognised.", args[a]);
                }
            }
            /*
            if(false){
            // Exit Codes: 0 - Success; 1 - Unknown Failure;
            Console.Write("\nExited with exit code " + exitCode + ". \n Press Any Key to Close.");
            }
            */
        }
        int HelpMSG(){
            Console.Write("                  Broken, but reserved keywords:");
            Console.Write("\n-z <dir> <output> | --zip <dir> <output>: Zips up <dir> to <output>.zip.");
            Console.Write("\n-uz <input> <dir> | --unzip <input> <dir>: Unzips <input>.zip to <dir>.");
            Console.Write("\n ---------------------------------------------------------------------------");
            Console.Write("\n           Working Arguments:");
            Console.Write("\n-h | --help: Prints this help message.");
            Console.Write("\n-v | --version: Prints the version.");
            Console.Write("\n-r <path> | --read <path>: Reads the file at <path>.");
            Console.Write("\n");
            Console.Write("\n Use muscl -h <arg> for more information on a specific argument.");
            return 0;
        }
        int ArgHelp(string x) {
            switch (x) {
                case "--help":
                    Console.Write("/---------------------------------------------------------------------\\");
                    Console.Write("\n|                              Help                                   |");
                    Console.Write("\n|---------------------------------------------------------------------|");
                    Console.Write("\n|Arguments:          --help <?arg> | -h <?arg>                        |");
                    Console.Write("\n|Desc:    Displays information about the available arguments          |");
                    Console.Write("\n|                     or a specific argument.                         |");
                    Console.Write("\n\\---------------------------------------------------------------------/");
                    break;
                case "-h":
                    Console.Write("/---------------------------------------------------------------------\\");
                    Console.Write("\n|                              Help                                   |");
                    Console.Write("\n|---------------------------------------------------------------------|");
                    Console.Write("\n|Arguments:          --help <?arg> | -h <?arg>                        |");
                    Console.Write("\n|Desc:   Displays information about the available arguments           |");
                    Console.Write("\n|                     or a specific argument.                         |");
                    Console.Write("\n\\---------------------------------------------------------------------/");
                break;
                case "--version":
                    Console.Write("/---------------------------------------------------------------------\\");
                    Console.Write("\n|                              Version                                |");
                    Console.Write("\n|---------------------------------------------------------------------|");
                    Console.Write("\n|Arguments:                --version | -v                             |");
                    Console.Write("\n|Desc:  Displays information about the current version of muscl       |");
                    Console.Write("\n\\---------------------------------------------------------------------/");
                break;
                case "-v":
                    Console.Write("/---------------------------------------------------------------------\\");
                    Console.Write("\n|                              Version                                |");
                    Console.Write("\n|---------------------------------------------------------------------|");
                    Console.Write("\n|Arguments:                --version | -v                             |");
                    Console.Write("\n|Desc:  Displays information about the current version of muscl       |");
                    Console.Write("\n\\---------------------------------------------------------------------/");
                break;
                case "--read":
                break;
                case "-r":
                break;
                /*
                case "-z":
                break;
                case "--zip":
                break;
                case "-uz":
                break;
                case "--unzip":
                break;
                */
                default:
                    Console.WriteLine("Argument not recognized.");
                    Console.WriteLine("Any Key to View Generic Help Message");
                    Console.ReadKey();
                    m.HelpMSG();
                break;
            }
            return 0;
        }
        int Version(){
            Console.Write("MUSCL Tool, written by Siri \n Version [0.1]");
            return 0;
        }
        int Read(string path){
            if (File.Exists(path))
            {
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            return 0;
            }
            else{
                Console.Write("\n File at Path not Found");
                return 1;
            }
        }
        int Zip(string input, string output) {
            string newOutput = output + ".zip";
            if(Directory.Exists(input)){
                //if(!File.Exists(newOutput)){
                ZipFile.CreateFromDirectory(input, output);
                return 0;
                //}
            }
            else{ Console.Write("\n Cannot create zip from non existing " + input + " directory."); }
            return 1;
        }
        int UnZip(string input, string output) {
            string newInput = input + ".zip";
            if (File.Exists(newInput)){
                ZipFile.ExtractToDirectory(input, output);
                return 0;
            }
            Console.Write(newInput + " does not exist.");
            return 1;
        }
    }
}
