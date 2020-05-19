using ITP_App.ApplicationLogic.Abstractions;
using ITP_App.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace ITP_App.DataAccess
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(ITP_AppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Car> GetByCivSeries(string civSeries)
        {
            return dbContext.Car.Where(x => x.CivSeries == civSeries || civSeries == null)
                .Include(car => car.Owner)
                .Include(car => car.Admin)
                .AsEnumerable();
        }

        public IEnumerable<Car> GetByBodySeries(string bodySeries)
        {
            return dbContext.Car.Where(x => x.BodySeries == bodySeries || bodySeries == null)
                .Include(car => car.Owner)
                .Include(car => car.Admin)
                .AsEnumerable();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return dbContext.Car
                             .Include(car => car.Owner)
                             .Include(car => car.Admin)
                             .AsEnumerable();
        }
    }
}