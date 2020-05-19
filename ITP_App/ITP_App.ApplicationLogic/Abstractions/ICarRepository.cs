using ITP_App.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITP_App.ApplicationLogic.Abstractions
{
    public interface ICarRepository : IRepository<Car>
    {
        public IEnumerable<Car> GetByCivSeries(string civSeries);
        public IEnumerable<Car> GetByBodySeries(string bodySeries);
        public IEnumerable<Car> GetAllCars();
    }
}
