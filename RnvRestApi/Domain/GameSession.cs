using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestAdapter.Ids;

namespace RnvRestApi.Domain
{
    public class GameSession
    {
        public GameSessionId GameSessionId { get; }
        public MrX MrX { get; private set; }
        public ICollection<PoliceOfficer> PoliceOfficers { get; } = new Collection<PoliceOfficer>();

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