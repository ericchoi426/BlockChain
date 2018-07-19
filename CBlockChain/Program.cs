using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBlockChain
{
    class Program
    {
        static CBlockChain chain;
        static string currHash = string.Empty;

        static void Main(string[] args)
        {
            // Welcome Screen
            Console.WriteLine("+----------------+");
            Console.WriteLine("| THE BLOCK - V1 |");
            Console.WriteLine("+----------------+");
            Console.WriteLine("Welcome to the Block");
            Console.WriteLine("A simple blockchain app written in c#");
            Console.WriteLine("(c) Tobias Herber for CoreUtils\n");

            // Setup
            setup();

            Console.ReadKey();
        }
        static void setup()
        {
            Console.WriteLine("+-------+");
            Console.WriteLine("| SETUP |");
            Console.WriteLine("+-------+");

            Console.Write("Local(l): ");
            string execType = Console.ReadLine();

            if (execType == "l" || execType == "L")
            {
                local();
            }
            else
            {
                Console.WriteLine("Exiting");
                return;
            }
        }

        static void local()
        {
            Console.Clear();

            chain = new CBlockChain("0", "the genesis block", DateTime.Now);
            currHash = chain.firstHash;
            Console.WriteLine("Initialized Block with default values.");

            bool ok = true;

            while (ok)
            {
                Console.Write("What do you want to do(add(a), list(l), exit(e)): ");
                string execType = Console.ReadLine();

                if (execType == "a" || execType == "A")
                {
                    add();
                }
                else if (execType == "l" || execType == "L")
                {
                    list();
                }
                else if (execType == "e" || execType == "E")
                {
                    Console.WriteLine("Exiting");
                    ok = false;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
        }

        static void list()
        {
            Console.Clear();
            foreach (CBlock<string> c in chain.Chain)
            {
                CBlock<string> ch = c;
                Console.WriteLine($"Block { ch.index }: { ch.data }");
            }

            Console.WriteLine("");
        }

        static void add()
        {
            Console.Clear();
            Console.Write("Data: ");
            string data = Console.ReadLine();

            Console.Clear();

            CBlock<string> c = chain.AddBlock(currHash, data, DateTime.Now);

            Console.WriteLine($"Added Block({ c.data }, { c.date.ToString() }, { c.hash })\n");

            currHash = c.hash;
        }
    }
}
