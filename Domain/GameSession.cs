using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class GameSession
    {
        public GameSession(string name)
        {
            Name = name;
            PoliceOfficers = new Collection<PoliceOfficer>();
            GameSessionId = new GameSessionId(0);
            StartTime = DateTimeOffset.Now;
            MrX = MrX.NullValue();
        }

        public GameSession(string name, GameSessionId id, DateTimeOffset startTime, MrX mrX, ICollection<PoliceOfficer> policeOfficers)
        {
            Name = name;
            GameSessionId = id;
            StartTime = startTime;
            MrX = mrX;
            PoliceOfficers = policeOfficers;
        }

        public GameSessionId GameSessionId { get; }
        public string Name { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public MrX MrX { get; private set; }
        public ICollection<PoliceOfficer> PoliceOfficers { get; }

        public void OnMrXDriven(VehicelType type, Station stationHto, Player player)
        {
            //speichern der bewegungen
        }

        public void OnPoliceOfficerDriven(VehicelType type, Station stationHto, Player player)
        {
            //speichern der bewegungen
            MrX.Tickets.Add(type);
            SaveGameSession();
        }

        public void OnPlayerEmpty(VehicelType type, Player player)
        {
            //error im client
        }

        public void AddMrX(MrX mrX)
        {
            if (MrX == null)
            {
                MrX = mrX;
                MrX.VehicleDrivenEvent += OnMrXDriven;
                MrX.VehicleEmpty += OnPlayerEmpty;
            }
            else
            {
                //error im client
            }
            SaveGameSession();
        }

        public void RemoveMrX()
        {
            if (MrX != null)
            {
                MrX.VehicleDrivenEvent -= OnMrXDriven;
                MrX.VehicleEmpty -= OnPlayerEmpty;
                MrX = null;
            }
            SaveGameSession();
        }

        private void SaveGameSession()
        {
            //Todo
        }

        public void AddPoliceOfficer(PoliceOfficer policeOfficer)
        {
            PoliceOfficers.Add(policeOfficer);
            policeOfficer.VehicleDrivenEvent += OnPoliceOfficerDriven;
            policeOfficer.VehicleEmpty += OnPlayerEmpty;
            SaveGameSession();
        }

        public void RemovePoliceOfficer(PoliceOfficer policeOfficer)
        {
            var officer = PoliceOfficers.SingleOrDefault(p => p.PoliceOfficerId == policeOfficer.PoliceOfficerId);
            if (officer != null)
            {
                officer.VehicleDrivenEvent -= OnPoliceOfficerDriven;
                officer.VehicleEmpty -= OnPlayerEmpty;

                PoliceOfficers.Remove(officer);
            }
            SaveGameSession();
        }
    }
}