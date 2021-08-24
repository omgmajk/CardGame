# Welcome to war!

A simple implementation of the card game War in C# with slight adjustments... 

**Needs .NET 5.0 to compile**

**Rules**
1. Players each get 26 cards from a shuffled deck.
2. Each player reveals the top card of the deck, highest card wins.
3. Winning player puts the cards on the bottom of his deck (in this case, in random order).
4. If cards are of equal value, instead reveals four cards and compare them in order like step 1.
5. First player to get to zero cards loses, *if* a player has less than four cards when the war is starting, the other player wins by default.
6. Special case: If by some freak accident all cards in a war are equal, put them back in random order and go back to battle.

**Enjoy**
