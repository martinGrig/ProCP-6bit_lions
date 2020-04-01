using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Result
    {
        private List<Shop> shops;
        private string _demographic;
        private double _incomePerSimulation;
        private TimeSpan _busyTime;

        public Result(List<Shop> perShopVisitRate, double incomePerSimulation, TimeSpan busyTime)
        {
            //_demographic = demographic;
            shops = new List<Shop>();
            _incomePerSimulation = incomePerSimulation;
            _busyTime = busyTime;
        }
    }
}
