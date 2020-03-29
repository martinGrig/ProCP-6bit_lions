using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Result
    {
        private int _perShopVisitRate;
        private double _perShopIncome;
        private string _demographic;
        private double _incomePerSimulation;
        private TimeSpan _busyTime;

        public Result(int perShopVisitRate, int perShopIncome, string demographic, double incomePerSimulation, TimeSpan busyTime)
        {
            _perShopVisitRate = perShopVisitRate;
            _perShopIncome = perShopIncome;
            _demographic = demographic;
            _incomePerSimulation = incomePerSimulation;
            _busyTime = busyTime;
        }
    }
}
