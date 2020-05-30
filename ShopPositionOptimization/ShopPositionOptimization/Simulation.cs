﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Simulation
    {
        private Result result;
        private MiniMall miniMall; // represents one floor of the mall. it can be a List when multiple floors are needed
        private List<Customer> customers; // represents the spwan rate of customers, youll change to the unity thingy
        private DateTime _date;
        private TimeSpan _duration;
        private Weather _weather;
        private Holidays _holiday;
        private bool _seasanolSale;
        private DaysOfTheWeek _dayOfTheWeek;

        
        public Simulation(DateTime date, TimeSpan duration, Holidays holiday, bool seasonalSale,Weather weather, DaysOfTheWeek dayOfTheWeek)
        {
            TimeSpan s = new TimeSpan(10, 30, 00); //starting hour
            TimeSpan e = new TimeSpan(20, 30, 00); //ending hour
            miniMall = new MiniMall("ozobi", s, e, 700, 4);
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
            double amountOfPeople = customers.Count; //this is supposed to be the amount of people spawned in the mini mall
            TimeSpan busyTime = _duration;

            switch (_holiday)
            {
                case Holidays.CHRISTMAS:
                    amountOfPeople += amountOfPeople * 0.50;
                    break;
                case Holidays.VALENTINESDAY:
                    amountOfPeople += amountOfPeople * 0.33;
                    break;
                case Holidays.EASTER:
                    amountOfPeople += amountOfPeople * 0.25;
                    break;
                case Holidays.BLACKFRIDAY:
                    amountOfPeople += amountOfPeople * 0.90;
                    break;
                default:
                    break;
            }
            if (_seasanolSale)
            {
                amountOfPeople += amountOfPeople * 0.30;
            }

            //TimeSpan duration = default;
            switch (_weather)
            {
                case Weather.SUNNY:
                    amountOfPeople -= amountOfPeople * 0.25;
                    break;
                case Weather.CLOUDY:
                    amountOfPeople += amountOfPeople * 0.17;
                    break;
                case Weather.RAINY:
                    amountOfPeople += amountOfPeople * 0.25;
                    break;
                case Weather.SNOWY:
                    amountOfPeople += amountOfPeople * 0.20;
                    break;
                default:
                    break;
            }
           result = new Result(miniMall.GetShops(), miniMall.GetAllIncome(), _duration);


            return result;
        }

        

        
    }

}
