namespace alchemist {
    using System.IO;
    class GameState {
        public int Miasma { get; set; } = 5;
        public int Blood { get; set; } = 5;
        public int Ardent { get; set; } = 5;
        public int Gold { get; set; } = 0;
        public int Gift { get; set; } = 0;
        public int Daymood { get; set; } = 2;
        public int Day { get; set; } = 0;
        public int[] Inve { get; set; } = new int[5];
        public int[] Potionval = {8,8,8,35};
        public string[] Potionname = {"Health Potion", "Mana Potion", "Explosive Potion", "Resurrection Potion" };
        public string[] Potionrec = { "2 Blood and 1 Ardent", "2 Blood and 1 Miasma", "1 ardent and 1 Miasma", "4 of all" };
    }



    internal class Program {
        static void Main(string[] args) {
            GameState g = null;
            Console.WriteLine("Welcome to Alchemist!");
            Console.WriteLine("to start new game press 1\nTo load save press 2 \nto quit game press 3");


            do {
                int menuwyb = Int32.Parse(Console.ReadLine());
                switch (menuwyb) {
                    case 1:
                        NewGame();
                        break;
                    case 2:
                        g = LoadGame();
                        menu(g);
                        break;
                    case 3:
                        Console.WriteLine("Quitting Game\nThanks for playing!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("[Wrong command]");
                        break;
                }

            } while (true);
        }

        static void NewGame() {
            GameState g = new GameState();
            Console.WriteLine("Welcome to your new job acolyte. As your supervisor i hope we will work well togheter.");
            Console.WriteLine("Your job will be making potion, buying supplies and selling potions to our brave paladin.\nLet me show all the fundaments, we have three basic funtaments of alchemy Miasma, Blood and ardent.\nWe also use more comples herbs or alchemist parts. Here are your starting supplies:");
            displaystats(g);
            Console.WriteLine("I hope you are ready. Yes/No");
            string Newchoise = Console.ReadLine();
            if (Newchoise == "Yes") {
                Console.WriteLine("Good luck acolyte");
            } else {
                Console.WriteLine("Tough luck acolyte, you are starting now.");
            }
            menu(g);
        }

        static void displaystats(GameState g) {
            Console.WriteLine("You have:\n" + g.Miasma + " Miasma\n" + g.Blood + " Blood\n" + g.Ardent + " Ardent\n" + g.Gold + " Gold");
            Console.WriteLine("You also have following items:");
            for (int i = 0; i < g.Potionname.Length; i++) {
                Console.WriteLine($"{g.Inve[i]} {g.Potionname[i]}");
            }



        }

        static void menu(GameState g) {
            do {
                Console.WriteLine("Your station. You see alchemist tools, your window and other construct walking aroud.\nWhat would you like to do?\n1. Make Potion\n2. Buy Supplies\n3. Sell Potions\n4. View Stats\n5. Save Game\n6. Quit Game");
                int menuwyb = Int32.Parse(Console.ReadLine());
                switch (menuwyb) {
                    case 1:
                        alchemy(g);
                        break;
                    case 2:
                        shop(g);

                        break;
                    case 3:
                        sell(g);
                        break;
                    case 4:
                        displaystats(g);
                        break;
                    case 5:
                        SaveGame(g);
                        break;
                    case 6:
                        Console.WriteLine("Quitting Game\nThanks for playing!");
                        Environment.Exit(0);
                        break;
                    case 88:
                        g.Miasma += 50;
                        g.Ardent += 50;
                        g.Blood += 50;
                        g.Gold += 50;
                        g.Inve[0] += 20;
                        g.Inve[1] += 20;
                        g.Inve[2] += 20;
                        g.Inve[3] += 20;
                        Console.WriteLine("Cheat activated");
                        break;
                    default:
                        Console.WriteLine("[Wrong command]");
                        break;
                }
            } while (true);
        }


        static void alchemy(GameState g) {
            displaystats(g);
            Console.WriteLine("You approach your alchemist table. What potion would you like to make?");
            Console.WriteLine("1. View Recipes\n2. Make Health Potion\n3. Make Mana Potion\n4. Make Explosive Potion\n5. Go back to station");
            for (int i = 1; i < g.Potionname.Length; i++) {
                Console.WriteLine($"{i}. {g.Potionname[i-1]}\n");
            }

            while (true) {
                int alchwyb = Int32.Parse(Console.ReadLine());
                switch (alchwyb) {
                    case 1:
                        for (int i = 0; i < g.Potionname.Length; i++) {
                            Console.WriteLine($"{g.Inve[i]} {g.Potionrec[i]}");
                        }
                    break;
                    case 2:
                        if (g.Blood >= 2 && g.Ardent >= 1) {
                            g.Blood -= 2;
                            g.Ardent -= 1;
                            g.Inve[0] += 1;
                            Console.WriteLine("Potion made successfully, you have:" + g.Inve[0]);
                        } else {
                            Console.WriteLine("Not enough resources");
                        }
                        break;
                    case 3:
                        if (g.Blood >= 2 && g.Miasma >= 1) {
                            g.Blood -= 2;
                            g.Miasma -= 1;
                            g.Inve[1] += 1;
                            Console.WriteLine("Potion made successfully, you have:" + g.Inve[1]);
                        } else {
                            Console.WriteLine("Not enough resources");
                        }
                        break;
                    case 4:
                        if (g.Ardent >= 1 && g.Miasma >= 1) {
                            g.Ardent -= 1;
                            g.Miasma -= 1;
                            g.Inve[2] += 1;
                            Console.WriteLine("Potion made successfully, you have:" + g.Inve[2]);
                        } else {
                            Console.WriteLine("Not enough resources");
                        }
                        break;
                    case 5:
                        if (g.Blood >= 4 && g.Miasma >= 4 && g.Ardent >= 4) {
                            g.Ardent -= 4;
                            g.Miasma -= 4;
                            g.Blood -= 4;
                            g.Inve[3] += 1;
                            Console.WriteLine("Potion made successfully, you have:" + g.Inve[3]);
                        } else {
                            Console.WriteLine("Not enough resources");
                        }
                        break;
                    case 6:
                    return;
                    default:
                        Console.WriteLine("[Wrong command]");
                        break;
                }
            }

        }

        static void shop(GameState g) {
            Console.WriteLine("You approach the shop. Green eyed contruct looks at you, her eyes are happy. 'Hello Sister'");

            while (true) {
                Console.WriteLine("'what can i give you?'\n1.Buy miasma(2 gold)\n2.Buy ardent(2 gold)\n3.Buy blood(1 gold)\n4.talk\n5.Get back to lab");
                int shopwyb = Int32.Parse(Console.ReadLine());
                switch (shopwyb) {
                    case 1:
                        if (g.Gold >= 2) {
                            g.Gold -= 2;
                            g.Miasma += 1;
                        } else {
                            Console.WriteLine("Not enough gold");
                        }                        
                        break;
                    case 2:
                        if (g.Gold >= 2) {
                            g.Gold -= 2;
                            g.Ardent += 1;
                        } else {
                            Console.WriteLine("Not enough gold");
                        }                       
                        break;
                    case 3:
                        if (g.Gold >= 1) {
                            g.Gold -= 1;
                            g.Blood += 1;
                        } else {
                            Console.WriteLine("Not enough gold");
                        }                      
                        break;
                    case 4:
                        talk(g);
                       
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("[Wrong command]");      
                        break;
                }
            }

        }
        static void talk(GameState g) {


            Console.WriteLine("Hello Miss, I am Clara, i hope we will get along? I see you are new here. Ask me anything you want.");
            while (true) {
                Console.WriteLine("\n1.I am new acolyte, i have shop near you\n2.Do you know what happend to previous acolyte?\n3.How is your day?\n4.Goodbye");
                int talkwyb = Int32.Parse(Console.ReadLine());
                switch (talkwyb) {
                    case 1:
                        if (g.Gift == 0) {
                            Console.WriteLine("Oh, then i hope you will have a great time at here. It got bored seeing all the figting and sacrate units.\nHere, little gift from me");
                            g.Blood += 5;
                            g.Gift++;
                        } else {
                            Console.WriteLine("I hope you are enjoying your job here.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("I heard she had an accident. Maybe she was moved. But also she didnt get alonmg well with one guy. ");
                        break;
                    case 3:
                        if (daymood == 1) {
                            Console.WriteLine("Oh, today is great day! I sold a lot of alchemy elements");
                        } else if (daymood == 2) {
                            Console.WriteLine("Oh, today is normal day. Nothing special, buiznsess as usual");
                        } else {
                            Console.WriteLine("Oh, today is bad day. I cant sell anything... maybe you can buy something");
                        }
                        break;
                    case 4:
                        return;

                    default:
                        Console.WriteLine("[Wrong command]");
                        break;
                }


            }


        }

        static void sleep(GameState g) {
            Random rnd = new Random();
            g.Daymood = rnd.Next(1, 4);
            g.Day += 1;

            Console.WriteLine("You go to sleep, taking off your mask you lay into your resting coffin. Day " + (g.Day + 1) + " begins.");


        }

        static void sell(GameState g) {
            Console.WriteLine("You enter front of your shop, symbol of eight goddess is near your table. few of customers get in. Mostly paladins and warriors.\n1.help customer\n2.check your stash\n3.go back into the back of a store.");
            bool continueLoop = true;
            Stack<int> buylist = new Stack<int>();
            Random rnd = new Random();
            while (continueLoop == true) {
                int sellwyb = Int32.Parse(Console.ReadLine());
                switch (sellwyb) {
                    case 1:
                        int type;
                        int ammount;
                        int buymany = rnd.Next(1, 7);
                        bool sellingloop = true;
                        if (buymany <= 5) {
                            while (sellingloop == true) {
                                 type = rnd.Next(1, 5);
                                 ammount = rnd.Next(1, 3);
                                 buymany = rnd.Next(1, 7);
                                Console.WriteLine("A customer approaches you. He wants to buy " + ammount + " potions " + g.Potionname[type - 1] + "\n1.Sell it\n2.say you dont have it");
                                int sellwyb2 = Int32.Parse(Console.ReadLine());
                                if (sellwyb2 == 1) {
                                    if (ammount <= g.Inve[type - 1]) {
                                        g.Gold += ammount * g.Potionval[type - 1];
                                        g.Inve[type - 1] -= ammount;
                                        int val = g.Potionval[type - 1];
                                        Console.WriteLine("You sold " + ammount + " potions " + g.Potionname[type - 1] + " for " + (ammount * val) + " gold. You now have " + g.Gold + " gold.");
                                        sellingloop = false;
                                    } else {
                                        Console.WriteLine("You don't have enough potions to sell.");
                                        sellingloop = false;
                                    }
                                } else if (sellwyb2 == 2) {
                                    Console.WriteLine("You refuse to sell the potions.");
                                    sellingloop = false;
                                } else {
                                    Console.WriteLine("[Wrong command]");
                                }
                            }
                        } else {
                            int tries = 0;
                            while (sellingloop == true) {
                                for (int i = 0; i < buymany; i++) {
                                    type = rnd.Next(1, 5);
                                    ammount = rnd.Next(1, 3);
                                    buymany = rnd.Next(1, 7);
                                    tries++;
                                    while (buylist.Contains(type - 1)) { type = rnd.Next(1, 5); }
                                    buylist.Push(type - 1);
                                    Console.WriteLine("And also he wants to buy " + ammount + " potions " + g.Potionname[type - 1] + "\n1.Sell it\n2.say you dont have it");
                                    int sellwyb2 = Int32.Parse(Console.ReadLine());
                                    if (sellwyb2 == 1) {
                                        if (ammount <= g.Inve[type - 1]) {
                                            g.Gold += ammount * g.Potionval[type - 1];
                                            g.Inve[type - 1] -= ammount;
                                            int val = g.Potionval[type - 1];
                                            Console.WriteLine("You sold " + ammount + " potions " + g.Potionname[type - 1] + " for " + (ammount * 8) + " gold. You now have " + g.Gold + " gold.");
                                        } else {
                                            Console.WriteLine("You don't have enough potions to sell.");
                                            sellingloop = false;
                                            buylist.Clear();
                                        }
                                    } else if (sellwyb2 == 2) {
                                        Console.WriteLine("You refuse to sell the potions.");
                                        sellingloop = false;
                                        buylist.Clear();
                                    } else {
                                        Console.WriteLine("[Wrong command]");
                                    }
                                }
                                buylist.Clear();
                            }
                        }
                        break;
                    case 2:
                                displaystats(g);
                                break;
                            case 3:
                                continueLoop = false;
                                break;
                            default:
                                Console.WriteLine("[Wrong command]");
                                break;
                            }
                        }

                }

                static void SaveGame(GameState g) {
                    string data = $"{g.Miasma}\n{g.Blood}\n{g.Ardent}\n{g.Gold}\n{g.Gift}\n{string.Join(";", g.Inve)}";
                    File.WriteAllText("savegame.txt", data);
                    Console.WriteLine("Game saved successfully.");
                }

                static GameState LoadGame() {
                    if (!File.Exists("savegame.txt")) {
                        Console.WriteLine("No save game found. Starting a new game.");
                        return new GameState();
                    }

                    string[] data = File.ReadAllLines("savegame.txt");
                    GameState g = new GameState {
                        Miasma = int.Parse(data[0]),
                        Blood = int.Parse(data[1]),
                        Ardent = int.Parse(data[2]),
                        Gold = int.Parse(data[3]),
                        Gift = int.Parse(data[4]),
                        Inve = Array.ConvertAll(data[5].Split(';'), int.Parse)
                    };


                    Console.WriteLine("Game loaded successfully.");
                    return g;
                }

            }
        } 
