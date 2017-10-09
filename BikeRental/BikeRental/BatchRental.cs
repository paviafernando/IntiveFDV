using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeRental
{
    public class BatchRental
    {
        private readonly int MinPromo;
        private readonly int MaxPromo;

        public List<Rental> rentals { get; set; }

        public BatchRental()
        {
            MinPromo = 3;
            MaxPromo = 5;
            rentals = new List<Rental>();
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public decimal GetTotal()
        {
            decimal result = 0;
            try
            {
                result = rentals.Sum(r=>r.Price);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetPromo()
        {
            decimal result = 0;
            try
            {
                result = rentals.Sum(r => r.Price);
                if (rentals.Count>=MinPromo && rentals.Count<=MaxPromo)
                {
                    result = result * (decimal)0.7;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}