using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTrackr.Domain;

namespace CarTrackr.Repository
{
    public interface ICostsRepository
    {
        ICarRepository CarRepository { get; set; }
        IRefuellingRepository RefuellingRepository { get; set; }

        decimal CalculateTotalKilometers(Car car);
        decimal CalculateAverageUsage(Car car);
        decimal CalculateTotalCosts(Car car);
        decimal CalculateAverageCostsPerKilometer(Car car);
    }
}
