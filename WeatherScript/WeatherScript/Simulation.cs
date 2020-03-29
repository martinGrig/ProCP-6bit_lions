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

        public Simulation(DateTime date, TimeSpan duration, Weather weather, bool holiday, bool seasonalSale, DaysOfTheWeek dayOfTheWeek)
        {
            _date = date;
            _duration = duration;
            _weather = weather;
            _holiday = holiday;
            _seasanolSale = seasonalSale;
            _dayOfTheWeek = dayOfTheWeek;
        }
        public Result runSimulation()
        {


            return result;
        }
    }

}
