using ITP_App.ApplicationLogic.Abstractions;
using ITP_App.ApplicationLogic.DataModel;
using ITP_App.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITP_App.ApplicationLogic.Services
{
    public class AdminsService
    {
        private readonly IAdminRepository adminRepository;
        private readonly ICarRepository carRepository;
        private readonly IOwnerRepository ownerRepository;
        private readonly IRuleRepository ruleRepository;

        public AdminsService(IAdminRepository adminRepository, ICarRepository carRepository,
                             IOwnerRepository ownerRepository,
                             IRuleRepository ruleRepository)
        {
            this.adminRepository = adminRepository;
            this.carRepository = carRepository;
            this.ownerRepository = ownerRepository;
            this.ruleRepository = ruleRepository;
        }
        public Admin CreateAdmin(string userId, string firstName, string lastName, string email)
        {
            var admin = new Admin
            {
                UserId = Guid.Parse(userId),
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
            adminRepository.Add(admin);
            return admin;
        }
        
        public Admin GetAdminById(string adminId)
        {
            Guid adminIdGuid = Guid.Empty;
            if (!Guid.TryParse(adminId, out adminIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var admin = adminRepository.GetAdminByUserId(adminIdGuid);
            if (admin == null)
            {
                throw new EntityNotFoundException(adminIdGuid);
            }

            return admin;

        }
        
        public void AddCar(string carType, string civSeries, string bodySeries,
                               int carMileage, int yearOfManufacture, string itpValability,
                               string ownerFirstName, string ownerLastName,
                               string cNP)
        {

            var owner = ownerRepository.Add(new Owner()
            {
                Id = Guid.NewGuid(),
                FirstName = ownerFirstName,
                LastName = ownerLastName,
                CNP = cNP
            });

            var car = carRepository.Add(new Car()
            {
                Id = Guid.NewGuid(),
                CarType = carType,
                CivSeries = civSeries,
                BodySeries = bodySeries,
                CarMileage = carMileage,
                YearOfManufacture = yearOfManufacture,
                ItpValability = itpValability,
                Owner = owner,
            });

        }

        public void AddRule(string name, string text)
        {

            var rule = ruleRepository.Add(new Rules()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Text = text
            });
        }

        public IEnumerable<Car> GetCars()
        {
            return carRepository.GetAllCars()
                            .AsEnumerable();
        }

        public IEnumerable<Rules> GetRules()
        {

            return ruleRepository.GetAll()
                            .AsEnumerable();
        }

        public IEnumerable<Car> GetCarByCivSeries(string civSeries)
        {
            return carRepository.GetByCivSeries(civSeries);
        }

        public IEnumerable<Car> GetCarByBodySeries(string bodySeries)
        {
            return carRepository.GetByBodySeries(bodySeries);
        }

        
    }
}