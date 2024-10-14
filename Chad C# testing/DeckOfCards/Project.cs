using System;

namespace DeckOfCards {

    

    class Deck {

        static void Main(string[] args){

            //create deck
            Deck theseCards = new Deck();
            Console.WriteLine("Greetings!  You see before you a deck of cards.");
            int choice = -1;

            while (choice != 3)
            {
                Console.WriteLine("Do you:");
                Console.WriteLine("1. Pick a card\n2. Replenish Deck\n3. Leave");
                Console.WriteLine("\nThere are " + theseCards.getRemaining() + " cards remaining");

                choice =  Convert.ToInt32(Console.ReadLine());

                if(choice == 1){
                    String card = theseCards.getCard();
                    Console.WriteLine("Your card is a " + card);
                }
                else if(choice == 2){
                    theseCards.getNewDeck();
                    Console.WriteLine("Shuffling the deck...");
                }
                else if (choice == 3){
                    Console.WriteLine("See you later!");
                }

            };

        }

        private Dictionary<int,bool> cards;
        private String[] suits;
        private String[] value;
        private int remainingCards;
        private int deckSize;
        
        public Deck(){
            this.cards = this.getNewDeck();
            this.suits = ["Clubs", "Diamonds", "Hearts", "Spades"];
            this.value = ["Ace", "2", "3","4","5","6","7","8","9","10","Jack","Queen","King"];
            this.remainingCards = 52;
            this.deckSize = 52;
        }

        public int getRemaining(){
            return this.remainingCards;
        }
        
        

        public String getCard(){

            Random rando = new Random();
            int cardNumber = -1;
            bool stillLooking = true;

            //finding a card that hasn't been picked yet
            while(stillLooking){
                cardNumber = (int)rando.NextInt64(0,52);
                if(this.cards.ContainsKey(cardNumber)){
                    if(this.cards[cardNumber] == true){
                        stillLooking = false;
                    }
                }
            }

            // Console.WriteLine("Cardnumber is " + cardNumber);
            // Console.WriteLine("cardnumber mod 4 is " + (cardNumber % 4));

            //determining suit
            String suit = this.suits[cardNumber % 4];
            
            //determing value
            String value = this.value[cardNumber % 13];

            //remove card from deck
            cards[cardNumber] = false;
            this.remainingCards--;

            return value + " of " + suit;


        }

        private Dictionary<int, bool> getNewDeck(){
            Console.WriteLine("Shuffling Deck...");
            Dictionary<int, bool> cardDeck = new Dictionary<int, bool>();

            for(int i = 0; i < 52; i++){
                cardDeck.Add(i, true);
            }
            this.remainingCards = 52;
            return cardDeck;
        }
    }
}
