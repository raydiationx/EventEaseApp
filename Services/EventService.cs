using EventEaseApp.Models;
using System.Collections.Concurrent;

namespace EventEaseApp
{
    public class EventService
    {
        private readonly ConcurrentDictionary<int, Event> events = new ConcurrentDictionary<int, Event>();

        public EventService()
        {
            // Initialize with some mock data
            AddEvent(new Event { Id = 1, EventName = "Event 1", EventDate = DateTime.Now, Location = "Location 1" });
            AddEvent(new Event { Id = 2, EventName = "Event 2", EventDate = DateTime.Now.AddDays(1), Location = "Location 2" });
            AddEvent(new Event { Id = 3, EventName = "Event 3", EventDate = DateTime.Now.AddDays(2), Location = "Location 3" });
        }

        public List<Event> GetEvents() => events.Values.ToList();

        public void AddEvent(Event newEvent)
        {
            if (newEvent == null)
                throw new ArgumentNullException(nameof(newEvent));

            if (string.IsNullOrWhiteSpace(newEvent.EventName))
                throw new ArgumentException("Event name is required.", nameof(newEvent.EventName));

            if (string.IsNullOrWhiteSpace(newEvent.Location))
                throw new ArgumentException("Location is required.", nameof(newEvent.Location));

            newEvent.Id = events.Count > 0 ? events.Keys.Max() + 1 : 1;
            events[newEvent.Id] = newEvent;
        }

        public Event? GetEventById(int id)
        {
            events.TryGetValue(id, out var eventItem);
            return eventItem;
        }
    }
}