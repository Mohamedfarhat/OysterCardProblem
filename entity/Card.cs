using OysterCardProblemMF.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCardProblemMF.entity
{
    public class Card
    {
        private float balance;

        public Card()
        {
            this.balance = 0;
        }

        public Card(float balance)
        {
            this.balance = balance;
        }

        public float Balance { get => balance; set => balance = value; }

        public void addBalance(float money)
        {
            this.balance += money;
        }

        public void payOut(float fare)
        {
            checkBalance(fare);
            this.balance -= fare;

        }

        public void checkBalance(float fare)
        {
            if (balance < fare)
                throw new FareException($"Not Enough Money In Your Balance: Balance is £{this.balance} and the fare is £{fare} ");
        }
        /*public Boolean checkBalance(float fare)
        {
            if (balance < fare)
                return false;
            return true; 
        }
        */
        public void cashBack(float cashBack)
        {
            this.balance += cashBack;
        }
    }
}
