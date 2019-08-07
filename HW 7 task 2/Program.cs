using System;
using System.Threading;

namespace HW_7_task_2
{
    class Mine
    {
        public int gold = 1000;
        public int Take()
        {
            lock (this)
            {
                if (gold >= 3)
                {
                    gold -= 3;
                    return 3;
                }
                if (gold == 2)
                {
                    gold -= 2;
                    return 2;
                }

                if (gold == 1)
                {
                    gold -= 1;
                    return 1;
                }
                return 0;
            }
            
        }
    }
   
    class Worker
    {
        public string name;
        public int taken_gold = 0;
        public Mine mine;
        public Worker(string name,Mine mine)
        {
            this.mine = mine;
            this.name = name;
            new Thread(Take_gold).Start();
        }
        public void Take_gold()
        {
            
                while (mine.gold > 0)
                {
                    //lock (mine)
                    
                        Thread.Sleep(3000);
                        
                        taken_gold += mine.Take();
                        Console.WriteLine(name + " gold: " + taken_gold + "; Gold Mine: " + mine.gold);
                    
                }
            Thread.Sleep(5000);
            Console.WriteLine(name + " his gold: " + taken_gold);
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mine mine = new Mine();
            string worker = "new worker";
            int number = 1;
            new Worker("A", mine);
            new Worker("B", mine);
            new Worker("C", mine);
            while (mine.gold > 0)
            {
                Thread.Sleep(10000);
                
                new Worker(worker+"_"+number++, mine);
               
            }

            Console.ReadKey();
        }
    }
}
