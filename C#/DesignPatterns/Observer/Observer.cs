using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    public interface IObserver
    {
        void Update(ISubject weatherData);
    }

    public interface IDisplayElement
    {
        void Display();
    }

    public class CurrentConditionsDisplay : IObserver,IDisplayElement
    {

        private double m_Temperature;
        private double m_Humidity;
        private ISubject m_WeatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.m_WeatherData = weatherData;
            this.m_WeatherData.RegisterObserver(this);
        }

        void IObserver.Update(ISubject weatherData)
        {
        }

        void IDisplayElement.Display()
        {

        }

    }

    public class ForcastDisplay : IObserver, IDisplayElement
    {
        void IObserver.Update(ISubject weatherData)
        {

        }

        void IDisplayElement.Display()
        {

        }

    }

    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        void IObserver.Update(ISubject weatherData)
        {

        }

        void IDisplayElement.Display()
        {

        }

    }
}
