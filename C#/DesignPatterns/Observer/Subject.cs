using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class WeatherData : ISubject
    {
        public double Temperature
        {
            get
            {
                return m_Temperature;
            }
        }
        public double Humidity
        {
            get
            {
                return m_Humidity;
            }
        }
        public double Pressure
        {
            get
            {
                return m_Pressure;
            }
        }

        private Random m_Random;
        private double m_Temperature;
        private double m_Humidity;
        private double m_Pressure;
        private List<IObserver> m_Observers; 

        public WeatherData()
        {
            m_Random = new Random();
            m_Observers = new List<IObserver>();
        }

        public void NotifyObservers()
        {
            for(int i = 0; i < m_Observers.Count; i++)
            {
                m_Observers[i].Update();
            }
            return;
        }

        public void RegisterObserver(IObserver observer)
        {
            if(!m_Observers.Contains(observer))
            {
                m_Observers.Add(observer);
            }

            return;
        }

        public void RemoveObserver(IObserver observer)
        {
            if (m_Observers.Contains(observer))
            {
                m_Observers.Remove(observer);
            }
            else
            {
                throw new Exception("Observer not current suscribed to updates");
            }
            return;
        }

        public void SetMeasurments(double temperature, double humidity, double pressure)
        {
            m_Temperature = temperature;
            m_Humidity = humidity;
            m_Pressure = pressure;
            MeasurmentsChanged();
        }

        public void MeasurmentsChanged()
        {
            NotifyObservers();
        }
    }
}
