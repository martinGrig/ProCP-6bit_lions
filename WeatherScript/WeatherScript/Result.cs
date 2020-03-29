using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Result
    {
        private string _perShopStatisctic;
        private string _demographic;
        private double _incomePerSimulation;
        private TimeSpan _busyTime;

        public Result(string perShopStatistic, string demographic, double incomePerSimulation, TimeSpan busyTime)
        {
            _perShopStatisctic = perShopStatistic;
            _demographic = demographic;
            _incomePerSimulation = incomePerSimulation;
            _busyTime = busyTime;
        }
    }
}
