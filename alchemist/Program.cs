namespace alchemist {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("Welcome to Alchemist!");
            Console.WriteLine("to start new game press 1\nTo load save press 2 \nto quit game press 3");


            do {
                int menuwyb = Int32.Parse(Console.ReadLine());
                switch (menuwyb) {
                    case 1:
                        NewGame();
                        break;
                    case 2:
                        Console.WriteLine("Load Game feature not implemented yet");
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
            int miasma, blood, ardent;
            int gift = 0;
            int gold = 0;
            int[] igri = new int[5]; // 0 health potion, 1 mana potion
            Console.WriteLine("Welcome to your new job acolyte. As your supervisor i hope we will work well togheter.");
            Console.WriteLine("Your job will be making potion, buying supplies and selling potions to our brave paladin.\nLet me show all the fundaments, we have three basic funtaments of alchemy Miasma, Blood and ardent.\nWe also use more comples herbs or alchemist parts. Here are your starting supplies:");
            miasma = 5;
            blood = 5;
            ardent = 5;
            displaystats(miasma, blood, ardent, gold, igri);
            Console.WriteLine("I hope you are ready. Yes/No");
            string Newchoise = Console.ReadLine();
            if (Newchoise == "Yes") {
                Console.WriteLine("Good luck acolyte");
            } else {
                Console.WriteLine("Tough luck acolyte, you are starting now.");
            }
            menu(miasma, blood, ardent, gold, igri, gift);
        }

        static int displaystats(int miasma, int blood, int ardent, int gold, int[] igri) {
            Console.WriteLine("You have:\n" + miasma + " Miasma\n" + blood + " Blood\n" + ardent + " Ardent\n" + gold + " Gold");
            Console.WriteLine("You also have following items:");
            Console.WriteLine(igri[0] + " Health Potions\n" + igri[1] + " Mana Potions\n" + igri[2]);

            return 0;
        }

        static void menu(int miasma, int blood, int ardent, int gold, int[] igri, int gift) {
            do {
                Console.WriteLine("Your station. You see alchemist tools, your window and other construct walking aroud.\nWhat would you like to do?\n1. Make Potion\n2. Buy Supplies\n3. Sell Potions\n4. View Stats\n5. Save Game\n6. Quit Game");
                int menuwyb = Int32.Parse(Console.ReadLine());

                switch (menuwyb) {
                    case 1:
                        (miasma, blood, ardent, gold, igri) = alchemy(miasma, blood, ardent, gold, igri);
                        break;
                    case 2:
                        (miasma, blood, ardent, gold, gift) = shop(miasma, blood, ardent, gold, gift);

                        break;
                    case 3:
                        (miasma, blood, ardent, gold, igri) = sell(miasma, blood, ardent, gold, igri);
                        break;
                    case 4:
                        displaystats(miasma, blood, ardent, gold, igri);
                        break;
                    case 5:
                        Console.WriteLine("Save system not implemented yet");
                        break;
                    case 6:
                        Console.WriteLine("Quitting Game\nThanks for playing!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("[Wrong command]");
                        break;
                }
            } while (true);
        }


        static (int, int, int, int, int[]) alchemy(int miasma, int blood, int ardent, int gold, int[] igri) {
            Console.WriteLine("You approach your alchemist table. What potion would you like to make?\n1. Health Potion (2 Blood, 1 Ardent)\n2. Mana Potion (2 Blood, 1 miasma)\n3. Back to Menu");
            bool continueLoop = true;
            while (continueLoop == true) {
                int alchwyb = Int32.Parse(Console.ReadLine());
                switch (alchwyb) {
                    case 1:
                        if (blood >= 2 && ardent >= 1) {
                            blood -= 2;
                            ardent -= 1;
                            igri[0] += 1;
                            Console.WriteLine("Potion made successfully, you have:" + igri[0]);
                        } else {
                            Console.WriteLine("Not enough resources to make Health Potion");
                        }
                        break;
                    case 2:
                        if (blood >= 2 && miasma >= 1) {
                            blood -= 2;
                            miasma -= 1;
                            igri[1] += 1;
                            Console.WriteLine("Potion made successfully, you have:" + igri[1]);
                        } else {
                            Console.WriteLine("Not enough resources to make Mana Potion");
                        }
                        break;
                    case 3:
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("[Wrong command]");
                        break;
                }
            }
            return (miasma, blood, ardent, gold, igri);
        }

        static (int, int, int, int, int) shop(int miasma, int blood, int ardent, int gold, int gift) {
            Console.WriteLine("You approach the shop. Green eyed contruct looks at you, her eyes are happy. 'Hello, what can i give you?'\n1.Buy miasma(2 gold)\n2.Buy ardent(2 gold)\n3.Buy blood(1 gold)\n4.talk\n5.Get back to lab");
            bool continueLoop = true;
            while (continueLoop == true) {
                int shopwyb = Int32.Parse(Console.ReadLine());
                switch (shopwyb) {
                    case 1:
                        if (gold >= 2) {
                            gold -= 2;
                            miasma += 1;
                        } else {
                            Console.WriteLine("Not enough gold");
                        }
                        break;
                    case 2:
                        if (gold >= 2) {
                            gold -= 2;
                            ardent += 1;
                        } else {
                            Console.WriteLine("Not enough gold");
                        }
                        break;
                    case 3:
                        if (gold >= 1) {
                            gold -= 1;
                            blood += 1;
                        } else {
                            Console.WriteLine("Not enough gold");
                        }
                        break;
                    case 4:
                        (blood, gift) = talk(blood, gift);
                        Console.WriteLine("You approach the shop. Green eyed contruct looks at you, her eyes are happy. 'Hello, what can i give you?'\n1.Buy miasma(2 gold)\n2.Buy ardent(2 gold)\n3.Buy blood(1 gold)\n4.talk\n5.Get back to lab");
                        break;
                    case 5:
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("[Wrong command]");
                        break;
                }
            }
            return (miasma, blood, ardent, gold, gift);
        }
        static (int, int) talk(int blood, int gift) {
            bool continueLoop = true;
            Random rnd = new Random();
            int daymood = rnd.Next(1, 4);
            Console.WriteLine("Hello Miss, I am Clara, i hope we will get along? I see you are new here. Ask me anything you want.\n1.I am new acolyte, i have shop near you\n2.Do you know what happend to previous acolyte?\n3.How is your day?\n4.Goodbye");
            while (continueLoop == true) {
                int talkwyb = Int32.Parse(Console.ReadLine());
                switch (talkwyb) {
                    case 1:
                        if (gift == 0) {
                            Console.WriteLine("Oh, then i hope you will have a great time at here. It got bored seeing all the figting and sacrate units.\nHere, little gift from me");
                            blood += 5;
                            gift++;
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
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("[Wrong command]");
                        break;
                }


            }

            return (blood, gift);
        }

        static (int, int, int, int, int[]) sell(int miasma, int blood, int ardent, int gold, int[] igri) {
            Console.WriteLine("You enter front of your shop, symbol of 3ight goddess is near your table. few of customers get in. Mostly paladins and warriors.\n1.help customer\n2.check your stash\n3.go back into the back of a store.");
            bool continueLoop = true;
            string typepotion = "none";
            Random rnd = new Random();
            while (continueLoop == true) {
                int sellwyb = Int32.Parse(Console.ReadLine());
                switch (sellwyb) {
                    case 1:
                        int type = rnd.Next(1, 4);
                        int ammount = rnd.Next(1, 4);
                        switch (type) {

                            case 1:
                                typepotion = "of healing";
                                break;
                            case 2:
                                typepotion = "of mana regeneration";
                                break;
                            case 3:
                                typepotion = "of mana and health regeneration";
                                break;
                        }
                        if (type == 1 || type == 2) {
                            Console.WriteLine("A customer approaches you. He wants to buy " + ammount + " potions" + typepotion + "\n1.Sell it\n2.say you dont have it");
                            int sellwyb2 = Int32.Parse(Console.ReadLine());
                            if (sellwyb2 == 1) {                            
                            if (ammount <= igri[type - 1]) {
                                gold += ammount * 8;
                                igri[type - 1] -= ammount;
                                Console.WriteLine("You sold " + ammount + " potions " + typepotion + " for " + (ammount * 8) + " gold.");
                            } else {
                                Console.WriteLine("You don't have enough potions to sell.");
                            }
                            } else if (sellwyb2 == 2) {
                            Console.WriteLine("You refuse to sell the potions.");
                            } else {
                                Console.WriteLine("[Wrong command]");
                            }
                            break;

                        } else {
                            Console.WriteLine("A customer approaches you. He wants to buy " + ammount + " potions " + typepotion + "\n1.Sell it\nsay you dont have it");
                            int sellwyb2 = Int32.Parse(Console.ReadLine());
                            if (sellwyb2 == 1) {
                                if (ammount <= igri[type - 3] && ammount <= igri[type - 2]) {
                                    gold += ammount * 16;
                                    igri[type - 3] -= ammount;
                                    igri[type - 2] -= ammount;
                                    Console.WriteLine("You sold " + ammount + " potions " + typepotion + " for " + (ammount * 16) + " gold.");
                                } else {
                                    Console.WriteLine("You don't have enough potions to sell.");
                                } 
                            }else if (sellwyb2 == 2) { 
                              Console.WriteLine("You refuse to sell the potions.");
                            } else {
                                Console.WriteLine("[Wrong command]");
                            }
                        }


                        break;
                    case 2:
                        displaystats(miasma, blood, ardent, gold, igri);
                        break;
                    case 3:
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("[Wrong command]");
                        break;



                        
                }
            }
            return (miasma, blood, ardent, gold, igri);
        }
    }
}
