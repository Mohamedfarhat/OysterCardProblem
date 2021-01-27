using OysterCardProblemMF.core;
using OysterCardProblemMF.entity;
using OysterCardProblemMF.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCardProblemMF
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Card card = new Card();
            card.Balance = 2;
            try { 
            card.payOut(5);
            }
            catch (FareException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }
            Console.WriteLine(card.Balance + "");
            Console.ReadLine();*/
            Card card = new Card();
            Console.WriteLine("Loading a card with £30 \n");
            card.addBalance(30);

            Journey journeyHolbornToCourt = new Journey(new Fare());
            journeyHolbornToCourt.SetStartPoint(Transport.TUBE, new StationZone(Station.HOLBORN), card);
            journeyHolbornToCourt.SetEndPoint(new StationZone(Station.EARLS_COURT));

            Console.WriteLine($"Card Balance after first journey (Tube Holborn to Earl’s Court)  is £{card.Balance} \n");

            Journey journeyBusEarlToChelsea = new Journey(new Fare());
            journeyBusEarlToChelsea.SetStartPoint(Transport.BUS, null, card);
            journeyBusEarlToChelsea.SetEndPoint(null);

            Console.WriteLine($"Card Balance after second journey (328 bus from Earl’s Court to Chelsea) is £{card.Balance} \n");

            Journey journeyEarlsToHammersmith = new Journey(new Fare());
            journeyEarlsToHammersmith.SetStartPoint(Transport.TUBE, new StationZone(Station.EARLS_COURT), card);
            journeyEarlsToHammersmith.SetEndPoint(new StationZone(Station.HAMMERSMITH));

            Console.WriteLine($"Card Balance after third journey (Tube Earl’s court to Hammersmith) is £{card.Balance} \n");
            Console.ReadLine();
        }
    }
}
