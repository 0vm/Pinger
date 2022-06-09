using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace ConsoleApp2
{
    internal class Program
    {


        public static void Log(string logMessage, TextWriter w)
        {
            w.Write($"{logMessage} at: ");
            w.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine();
        }

        static void Main(string[] args)
        {
            int Timeouts = 0;

            new Thread(() =>
            {

                var s = "        "; // 8 spaces for the titles spacing, looks very messy but who cares.

                fortnite:
                Thread.CurrentThread.IsBackground = true;
                for (int i = 0; i < int.MaxValue; i++)
                //{
                //    Console.Title = $"Rapid IP Pinger | Time open : {i} seconds";
                //    Thread.Sleep(1000);
                //}
                {
                    var random = new Random();
                    var randomNumber = random.Next(1, 5);

                    if (randomNumber == 3)
                    {
                        Console.Title = "Hey bb "+s+" " +s+s+s+s+s+s+s+s+s+s+s+s+$"  Time open: {i} seconds"+s+"|"+s+$"Total Timeouts: {Timeouts}";
                        Thread.Sleep(500);
                        Console.Title = "Hey bb "+s+" "+s+s+s+s+s+s+s+s+s+s+s+s+$"  Time open: {i+1} seconds"+s+"|"+s+$"Total Timeouts: {Timeouts}";
                        Thread.Sleep(500);
                    }
                    else if (randomNumber == 2)
                    {
                        Console.Title = "Rapid IP / Host Pinger "+s+" "+s+s+s+s+s+s+s+s+s+$"Time open: {i} seconds"+s+"|"+s+$"Total Timeouts: {Timeouts}";
                        Thread.Sleep(500);
                        Console.Title = "Rapid IP / Host Pinger "+s+" "+s+s+s+s+s+s+s+s+s+$"Time open: {i+1} seconds"+s+"|"+s+$"Total Timeouts: {Timeouts}";
                        Thread.Sleep(500);
                    }
                    else if (randomNumber == 1)
                    {
                        Console.Title = "Consider Starring The Repo? github.com/0vm/Pinger "+s+" "+s+s+$" Time open: {i} seconds"+s+"|"+s+$"Total Timeouts: {Timeouts}";
                        Thread.Sleep(500);
                        Console.Title = "Consider Starring The Repo? github.com/0vm/Pinger "+s+" "+s+s+$" Time open: {i+1} seconds"+s+"|"+s+$"Total Timeouts: {Timeouts}";
                        Thread.Sleep(500);
                    }
                    else if (randomNumber == 4)
                    {
                        Console.Title = "Pro Tip: Click On The Console To Pause The Pinger   " + s + " " + s + s + $"    Time open: {i} seconds" + s + "|" + s + $"Total Timeouts: {Timeouts}";
                        Thread.Sleep(500);
                        Console.Title = "Pro Tip: Click On The Console To Pause The Pinger   " + s + " " + s + s + $"    Time open: {i + 1} seconds" + s + "|" + s + $"Total Timeouts: {Timeouts}";
                        Thread.Sleep(500);
                    }
                }
            }).Start();

            int? log = 0;

            Console.Write("Want to log the timeouts to a file? (y/n): ");
            ConsoleKey response = Console.ReadKey(false).Key;
            Console.WriteLine();
            if (response == ConsoleKey.Y)
            {
               log = 1;
            }else
            {
                log = 0;
            }
            Console.Clear();
            Console.Write("Enter Host: ");
            string option = Console.ReadLine();



            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    try
                    {
                        int timeout = 1500;
                        Ping ping = new Ping();
                        PingReply pingreply = ping.Send(option, timeout);
                        if (pingreply.Status == IPStatus.Success)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Status: {0}", pingreply.Status);
                            Console.ForegroundColor = ConsoleColor.White; Console.Write(" | ");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("IP: {0}", pingreply.Address);
                            Console.ForegroundColor = ConsoleColor.White; Console.Write(" | ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Latency: {0}ms", pingreply.RoundtripTime);
                            Console.WriteLine();
                        }else
                        { 
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(option + " Timed Out");

                            if (log == 1)
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    Log($"{option} Timed Out", w);
                                }
                            }
                            Timeouts++;
                            continue;
                        }
                    }
                    catch (PingException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }).Start();
        }
    }
}
