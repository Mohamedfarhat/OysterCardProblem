using OysterCardProblemMF.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCardProblemMF.entity
{
    public class Fare
    {
        public const float ZONE_ONE_FARE = 2.50f;

        public const float ANY_ZONE_OUTSIDE_ZONE_ONE_FARE = 2.00f;

        public const float TWO_ZONES_INC_ZONE_ONE_FARE = 3.00f;

        public const float TWO_ZONES_EXC_ZONE_ONE_FARE = 2.25f;

        public const float THREE_ZONES_FAIR = 3.20f;

        public const float BUS_FARE = 1.80f;

        public const float BASIC_TUBE_FARE = 3.20f;


        public void validate(Transport transport, Card card)
        {
            if (transport.Equals(Transport.BUS))
                card.checkBalance(BUS_FARE);

            if (transport.Equals(Transport.TUBE))
                card.checkBalance(BASIC_TUBE_FARE);
        }

        public void chargeMax(Transport transport, Card card)
        {
            if (transport.Equals(Transport.BUS))
                card.payOut(BUS_FARE);

            if (transport.Equals(Transport.TUBE))
                card.payOut(BASIC_TUBE_FARE);
        }

        public void charge(Transport transport, Journey journey, Card card)
        {
            if (transport.Equals(Transport.TUBE))
            {
                int count = countZones(journey);

                if (isOneZones(count) && isZoneTwo(journey))
                {
                    card.cashBack(BASIC_TUBE_FARE - ANY_ZONE_OUTSIDE_ZONE_ONE_FARE);
                }
                else if (haveZoneOne(journey) && isOneZones(count))
                {
                    card.cashBack(BASIC_TUBE_FARE - ZONE_ONE_FARE);
                }
                else if (!haveZoneOne(journey) && isOneZones(count))
                {
                    card.cashBack(BASIC_TUBE_FARE - ANY_ZONE_OUTSIDE_ZONE_ONE_FARE);
                }
                else if (haveZoneOne(journey) && isTwoZones(count))
                {
                    card.cashBack(BASIC_TUBE_FARE - TWO_ZONES_INC_ZONE_ONE_FARE);
                }
                else if (!haveZoneOne(journey) && isTwoZones(count))
                {
                    card.cashBack(BASIC_TUBE_FARE - TWO_ZONES_EXC_ZONE_ONE_FARE);
                }
                else if (isThreeZones(count))
                {
                    card.cashBack(BASIC_TUBE_FARE - THREE_ZONES_FAIR);
                }
            }
            else if (transport.Equals(Transport.BUS))
            {
                card.cashBack(0f);
            }
        }

        private bool isZoneTwo(Journey journey)
        {
            return journey.GetEndPoint().GetZone().Contains("2") && journey.GetStartPoint().GetZone().Contains("2");
        }

        private int countZones(Journey journey)
        {
            var zonesStart = journey.GetStartPoint().GetZone().Split(',');
            var zonesEnd = journey.GetEndPoint().GetZone().Split(',');

            int x = 10;

            for (int i = 0; i < zonesStart.Length; i++)
            {
                for (int j = 0; j < zonesEnd.Length; j++)
                {
                    int z = int.Parse(zonesStart[i]);
                    int y = int.Parse(zonesEnd[j]);
                    z = Math.Abs(z - y);
                    if (z < x)
                        x = z;
                }
            }

            return Math.Abs(x);
        }

        private bool isThreeZones(int count)
        {
            return count == 2;
        }

        private bool isTwoZones(int count)
        {
            return count == 1;
        }

        private bool isOneZones(int count)
        {
            return count == 0;
        }

        private bool haveZoneOne(Journey journey)
        {
            return journey.GetEndPoint().GetZone().Contains("1") || journey.GetStartPoint().GetZone().Contains("1");
        }
    }
}
