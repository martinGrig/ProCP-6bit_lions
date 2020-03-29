using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Simulation
    {
        private Result result;
        
        private DateTime _date;
        private TimeSpan _duration;
        private Weather _weather;
        private bool _holiday;
        private bool _seasanolSale;
        private DaysOfTheWeek _dayOfTheWeek;

        public Simulation(DateTime date, TimeSpan duration, bool holiday, bool seasonalSale, DaysOfTheWeek dayOfTheWeek)
        {
            _date = date;
            _duration = duration;
            _weather = SetWeather();
            _holiday = holiday;
            _seasanolSale = seasonalSale;
            _dayOfTheWeek = dayOfTheWeek;
        }
        public Result runSimulation()
        {
            switch (_weather)
            {
                case Weather.SUNNY:
                    
                    break;
                case Weather.CLOUDY:
                    break;
                case Weather.RAINY:
                    break;
                case Weather.SNOWY:
                    break;
                default:
                    break;
            }

            return result;
        }
        public int GetPerShopIncome(string ShopName)
        {
            int income = 0;
            return income;
        }

        private Weather SetWeather()
        {
            Random random = new Random();
            double result = random.NextDouble();
            if (result<0.20)
            {
                return Weather.CLOUDY;

            }
            else if (true)
            {

            }

        }
    }

}
