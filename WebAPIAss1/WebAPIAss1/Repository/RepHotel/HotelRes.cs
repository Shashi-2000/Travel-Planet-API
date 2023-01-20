using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIAss1.Models;

namespace WebAPIAss1.Repository.RepHotel
{

    public class HotelRes : IHotelRes
    {
        Student_AssigEntities dbContext = new Student_AssigEntities();
        List<HotelModel> IHotelRes.getAll()
        {
            var dataList = dbContext.HotelReservations.Select(e => new HotelModel()
            {
                ReservationID = e.ReservationID,
                Hotel = e.Hotel,
                Arrival = e.Arrival,
                Departure = e.Departure,
                TYPE = e.TYPE,
                Price = e.Price,
                Guests = e.Guests
            }).ToList<HotelModel>();
            dbContext.Dispose();
            return dataList;
        }

        bool IHotelRes.PostData(HotelModel newEntry)
        {
            if(newEntry != null)
            {
                dbContext.HotelReservations.Add(new HotelReservation
                {
                    ReservationID = newEntry.ReservationID,
                    Hotel = newEntry.Hotel,
                    Arrival = newEntry.Arrival,
                    Departure = newEntry.Departure,
                    TYPE = newEntry.TYPE,
                    Price = newEntry.Price,
                    Guests = newEntry.Guests
                });
                dbContext.SaveChanges();
                dbContext.Dispose();
                return true;
            }
            return false;    
        }

        bool IHotelRes.DeleteData(int reservID)
        {
            var exists = dbContext.HotelReservations.FirstOrDefault(e => e.ReservationID == reservID);
            try
            {
                if (exists != null)
                {
                    dbContext.HotelReservations.Remove(exists);
                }    
            } catch(Exception ex)
            {
                throw ex;
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return true;  
        }

        bool IHotelRes.UpdatedData(HotelModel updateEntry)
        {
            var exists = dbContext.HotelReservations.FirstOrDefault(e => e.ReservationID == updateEntry.ReservationID);
            if(exists != null)
            {
                exists.Hotel = updateEntry.Hotel;
                exists.Arrival = updateEntry.Arrival;
                exists.Departure = updateEntry.Departure;
                exists.TYPE = updateEntry.TYPE;
                exists.Price = updateEntry.Price;
                exists.Guests = updateEntry.Guests;

                dbContext.SaveChanges();
                dbContext.Dispose();
                return true;
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return false;
        }
    }
}