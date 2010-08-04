using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Service.Models
{
    class EventModel
    {
        public static readonly EventModel Instance = new EventModel();

        static EventModel() { }

        //добавляет новое событие
        public void CreateEvent(int userId, string description, int fileId = 0)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            Event newEvent = new Event();
            newEvent.UserId = userId;
            newEvent.FileId = fileId;
            newEvent.Description = description;
            newEvent.Created = DateTime.Now;
            db.Events.InsertOnSubmit(newEvent);
            db.SubmitChanges();
        }
        //----------------------------------------------------------------------------------


        //возвращает все события пользователя
        public List<EventInfo> GetEvents(int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var userEvents = from f in db.Events
                        where f.UserId == userId
                        select f;
            List<EventInfo> changes = new List<EventInfo>();
            foreach (Event userEvent in userEvents)
                changes.Add(new EventInfo { 
                    FileId = userEvent.FileId, 
                    Description=userEvent.Description,
                    Path = DirectoryModel.Instance.GetDirectoryPath(userEvent.File.DirectoryId, userId),
                    FileSize=userEvent.File.Size,
                    Created=userEvent.Created,
                    FileName=userEvent.File.Name
                });
            return changes;
        }
        //----------------------------------------------------------------------------------
    }
}
