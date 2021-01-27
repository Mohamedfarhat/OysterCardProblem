using OysterCardProblemMF.core;
using OysterCardProblemMF.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCardProblemMF.entity
{
    public  class Journey
    {
        private StationZone startPoint;
        private StationZone endPoint;
        private Transport transport;

        private Card card;
        private Fare fare;

        public Journey(Fare fare)
        {
            this.fare = fare;
        }


        public StationZone GetStartPoint()
        {
            return this.startPoint;
        }

        public void SetStartPoint(Transport transport, StationZone startPoint, Card card)
        {
            try
            {
                this.fare.validate(transport, card);
                this.fare.chargeMax(transport, card);

            }
            catch (FareException ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.transport = transport;
            this.card = card;
            this.startPoint = startPoint;
        }

        public StationZone GetEndPoint()
        {
            return this.endPoint;
        }

        public void SetEndPoint(StationZone endPoint)
        {
            this.endPoint = endPoint;
            this.fare.charge(this.transport, this, this.card);
        }
    }
}
