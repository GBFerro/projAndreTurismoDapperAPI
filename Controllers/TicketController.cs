﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace Controllers
{
    public class TicketController
    {
        #region Constants
        public readonly static string INSERT = "insert into Ticket (Departure, Arrival, RegisterDate, Value) " +
            "values (@Departure, @Arrival, @RegisterDate, @Value); Select cast(scope_Identity() as int)";

        public readonly static string GETALL = "Select ticket.[Id],ticket.[Value], ticket.[RegisterDate], " + 
            "addressDeparture.[Id], addressDeparture.[Street], addressDeparture.[Number], " + 
            "addressDeparture.[District], addressDeparture.[ZipCode], addressDeparture.[Complement], " + 
            "cityDeparture.[Id], cityDeparture.[Name], cityDeparture.[RegisterDate], " +
            "addressArrival.[Id], addressArrival.[Street], addressArrival.[Number], " +
            "addressArrival.[District], addressArrival.[ZipCode], addressArrival.[Complement], " +
            "cityArrival.[Id], cityArrival.[Name], cityArrival.[RegisterDate] " + 
            "from[Ticket] ticket join[Address] addressArrival on ticket.[Arrival] = addressArrival.[Id] " +
            "join[City] cityArrival on addressArrival.[IdCity] = cityArrival.[Id] " +
            "join[Address] addressDeparture on ticket.[Departure] = addressDeparture.[Id] " +
            "join[City] cityDeparture on addressDeparture.[IdCIty] = cityDeparture.[Id]";

        public readonly static string DELETE = "delete from Ticket where Id = @Id";

        public readonly static string UPDATE = "update Ticket set Value = @Value where Id = @Id";
        #endregion

        private TicketService _ticketService;

        public TicketController()
        {
            _ticketService = new TicketService();
        }

        public int Insert(Ticket ticket)
        {
            ticket.Departure.Id = new AddressController().Insert(ticket.Departure);
            ticket.Arrival.Id = new AddressController().Insert(ticket.Arrival);
            return _ticketService.Insert(ticket, INSERT);
        }

        public bool Update(Ticket ticket)
        {

            new AddressController().Update(ticket.Departure);
            
            new AddressController().Update(ticket.Arrival);

            return _ticketService.Update(ticket, UPDATE);
        }

        public bool Delete(int id)
        {
            return _ticketService.Delete(id, DELETE);
        }

        public List<Ticket> FindAll()
        {
            return _ticketService.FindAll(GETALL);
        }
    }
}
