using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesEventMakerIC.Models;

namespace RazorPagesEventMakerIC.Interfaces
{
    public interface IRepository
    {
        List<Event> GetAllEvents();
        Event GetEvents(int id);
        void AddEvent(Event ev);
        void UpdateEvent(Event evt);

        List<Event> FilteredEvents(string criteria, DateTime dateFrom, DateTime dateTo);
        List<Event> SearchEventsByCode(string code);
    }
}
