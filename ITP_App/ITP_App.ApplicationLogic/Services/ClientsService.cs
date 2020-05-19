using ITP_App.ApplicationLogic.Abstractions;
using ITP_App.ApplicationLogic.DataModel;
using ITP_App.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP_App.ApplicationLogic.Services
{
    public class ClientsService
    {

        private readonly IClientRepository clientRepository;
        private readonly IReviewRepository reviewRepository;

        public ClientsService(IClientRepository clientRepository, IReviewRepository reviewRepository)
        {
            this.clientRepository = clientRepository;
            this.reviewRepository = reviewRepository;
        }

        public Client CreateClient(string userId, string firstName, string lastName, string email)
        {
            var client = new Client
            {
                UserId = Guid.Parse(userId),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
            };
            clientRepository.Add(client);
            return client;
        }

        public Client GetClientById(string clientId)
        {
            Guid clientIdGuid = Guid.Empty;
            if (!Guid.TryParse(clientId, out clientIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var client = clientRepository.GetClientByUserId(clientIdGuid);
            if (client == null)
            {
                throw new EntityNotFoundException(clientIdGuid);
            }

            return client;
        }

        public IEnumerable<Review> GetReviews()
        {

            return reviewRepository.GetAll()
                            .AsEnumerable();
        }

        public void AddReview(string rating, string title, string text)
        {

            reviewRepository.Add(new Review()
            {
                Id = Guid.NewGuid(),
                Rating = rating,
                Title = title,
                Text = text
            });
        }
    }
}
