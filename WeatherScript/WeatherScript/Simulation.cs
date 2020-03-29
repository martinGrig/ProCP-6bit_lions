using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Simulation
    {
        private Result result;
        private MiniMall miniMall;
        private Shop shop;
        //private List<Shop> shops;
        private List<Customer> customers;
        private DateTime _date;
        private TimeSpan _duration;
        private Weather _weather;
        private bool _holiday;
        private bool _seasanolSale;
        private DaysOfTheWeek _dayOfTheWeek;

        
        public Simulation(DateTime date, TimeSpan duration, bool holiday, bool seasonalSale,Weather weather, DaysOfTheWeek dayOfTheWeek)
        {
            //customers = new List<Customer>();
            _date = date;
            _duration = duration;
            _weather = weather;
            _holiday = holiday;
            _seasanolSale = seasonalSale;
            _dayOfTheWeek = dayOfTheWeek;
        }
        public Result RunSimulation()
        {
            int increase = 0;
            //all the numbers you see below are based on a BIG research ;D
            double amountOfPeople = customers.Count;
            double perShopVisitRate = 0;
            double perShopIncome = 0;
            double incomePerSimulation = miniMall.GetAllIncome();
            TimeSpan busyTime = _duration;

            if (_holiday)
            {
                increase++;
            }
            if (_seasanolSale)
            {
                increase++;
                
            }
            if (increase == 1)
            {
                amountOfPeople += amountOfPeople * 0.30;
                perShopVisitRate += perShopVisitRate * 0.30;
            }
            else if (increase == 2)
            {
                amountOfPeople += amountOfPeople * 0.60;
                perShopVisitRate += perShopVisitRate * 30;
            }

            if (perShopVisitRate > 200 ) //temporary
            {
                perShopIncome += perShopIncome * 0.25;
            }

            TimeSpan duration = default;
            switch (_weather)
            {
                case Weather.SUNNY:
                    amountOfPeople -= amountOfPeople * 0.25;
                    break;
                case Weather.CLOUDY:
                    amountOfPeople += amountOfPeople * 0.17;
                    break;
                case Weather.RAINY:
                    amountOfPeople += amountOfPeople * 0.33;
                    break;
                case Weather.SNOWY:
                    amountOfPeople += amountOfPeople * 0.40;
                    break;
                default:
                    break;
            }
           result = new Result(miniMall.GetShops(), miniMall.GetAllIncome(), duration);


            return result;
        }
        public int GetPerShopIncome(string ShopName)
        {
            int income = 0;
            //implement after the script for  shop is ready
            return income;
        }

        

        
    }

}
