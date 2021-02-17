using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using EllipticCurve;

namespace BlockchainLab
{
    class Program
    {
       
        static void Main(string[] args)
        {

            PrivateKey key1  = key1 = new PrivateKey();
            PublicKey wallet1 = key1.publicKey();

            PrivateKey key2 = key2 = new PrivateKey();
            PublicKey wallet2 = key2.publicKey();


            Blockchain neumiecoin = new Blockchain(2, 100);

            Console.WriteLine("Start the Miner.");
            neumiecoin.MinePendingTransactions(wallet1);
            Console.WriteLine("\n Balance of wallet1 is $" + neumiecoin.GetBalanceofWallet(wallet1).ToString());

            Transaction tx1 = new Transaction(wallet1, wallet2, 10);
            tx1.SignTransaction(key1);
            neumiecoin.addPendingTransaction(tx1);
            Console.WriteLine("Start the Miner.");
            neumiecoin.MinePendingTransactions(wallet2);
            Console.WriteLine("\n Balance of wallet1 is $" + neumiecoin.GetBalanceofWallet(wallet1).ToString());
            Console.WriteLine("\n Balance of wallet2 is $" + neumiecoin.GetBalanceofWallet(wallet2).ToString());



            //neumiecoin.AddBlock(new Block(1, DateTime.Now.ToString("yyyMMddHHmmssfffff"), "amount : 50"));
            //neumiecoin.AddBlock(new Block(2, DateTime.Now.ToString("yyyMMddHHmmssfffff"), "amount : 200"));

            string blockJSON = JsonConvert.SerializeObject(neumiecoin, Formatting.Indented);
            Console.WriteLine(blockJSON);


            if (neumiecoin.IsChainValid())
            {
                Console.WriteLine("Blockchain is Valid!");

            }
            else
            {
                Console.WriteLine("Blockchain is NOT valid.");
            }
        }
    }

   
    
}
