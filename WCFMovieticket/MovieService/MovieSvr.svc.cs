using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using MovieDataLayer;
using MovieService.Model;

namespace MovieService
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MovieSvr : ISoapService, IRestService
    {
        //SOAP Service
        //Movie Model
        private mtb_dbEntities db = new mtb_dbEntities();
        public List<MovieModel> GetMovieS()
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                return (from m in db.movies
                        join s in db.screens on m.screenID equals s.screenID
                        join t in db.timeslots on m.timeslotID equals t.timeslotID
                        select new MovieModel { movieName = m.movieName, language = m.language, status = m.status, screenName = s.screenName, timeslotDisc = t.timeslotDisc }).ToList();
            }
        }
        public List<MovieModel> GetMovieByIdS(string id)
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                int mId = Convert.ToInt32(id);
                return (from m in db.movies
                        join s in db.screens on m.screenID equals s.screenID
                        join t in db.timeslots on m.timeslotID equals t.timeslotID
                        where m.movieID == mId
                        select new MovieModel { movieName = m.movieName, language = m.language, status = m.status, screenName = s.screenName, timeslotDisc = t.timeslotDisc }).ToList();

            }
        }
        public string PostMovieS(movie oMovie)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {

                    movieE.movies.Add(oMovie);
                    movieE.SaveChanges();
                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
        public bool UpdateMovieS(movie oMovie, string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int mId = Convert.ToInt32(id);
                    var movie = movieE.movies.FirstOrDefault(m => m.movieID == mId);
                    if (movie == null)
                    {
                        return false;
                    }
                    else
                    {
                        movie.movieName = oMovie.movieName != null ? oMovie.movieName : movie.movieName;
                        movie.language = oMovie.language != null ? oMovie.language : movie.language;
                        movie.date = oMovie.date != null ? oMovie.date : movie.date;
                        movie.status = oMovie.status != null ? oMovie.status : movie.status;
                        movie.screenID = oMovie.screenID != null ? oMovie.screenID : movie.screenID;
                        movie.timeslotID = oMovie.timeslotID != null ? oMovie.timeslotID : movie.timeslotID;

                        movieE.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteMovieByIdS(string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int mId = Convert.ToInt32(id);
                    movie mO = new movie();
                    var c = (from m in db.movies
                             where m.movieID == mId
                             select m).First();
                    db.movies.Remove(c);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Screen Model
        public List<ScreenModel> GetScreenS()
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {

                return (from scr in db.screens
                        select new ScreenModel { screenID = scr.screenID, screenName = scr.screenName }).ToList();
            }
        }
        public List<ScreenModel> GetScreenByIDS(string id)
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                int mId = Convert.ToInt32(id);
                return (from scr in db.screens
                        where scr.screenID == mId
                        select new ScreenModel { screenID = scr.screenID, screenName = scr.screenName }).ToList();
            }
        }
        public bool PostScreenS(screen oScreen)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {

                    movieE.screens.Add(oScreen);
                    movieE.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateScreenS(screen oScreen, string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int mId = Convert.ToInt32(id);
                    var screen = movieE.screens.FirstOrDefault(m => m.screenID == mId);
                    if (screen == null)
                    {
                        return false;
                    }
                    else
                    {
                        screen.screenName = oScreen.screenName != null ? oScreen.screenName : screen.screenName;
                        movieE.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteScreenByIdS(string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int sId = Convert.ToInt32(id);
                    screen sO = new screen();
                    var c = (from s in db.screens
                             where s.screenID == sId
                             select s).First();
                    db.screens.Remove(c);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Seats
        public List<SeatModel> GetSeatS()
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                return (from a in db.seats
                        select new SeatModel { seatID = a.seatID, seatNumber = a.seatNumber, Row = a.Row, status = a.status, price = a.price, screenID = a.screenID }).ToList();

            }
        }

        public List<SeatModel> GetSeatByIdS(string id)
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                int mId = Convert.ToInt32(id);
                return (from a in db.seats
                        where a.seatID == mId
                        select new SeatModel { seatID = a.seatID, seatNumber = a.seatNumber, Row = a.Row, status = a.status, price = a.price, screenID = a.screenID }).ToList();
            }
        }
        public bool PostSeatS(seat oSeat)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    movieE.seats.Add(oSeat);
                    movieE.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateSeatS(seat oSeat, string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {

                    int mId = Convert.ToInt32(id);
                    var seat = movieE.seats.FirstOrDefault(m => m.seatID == mId);
                    if (seat == null)
                    {
                        return false;
                    }
                    else
                    {
                        seat.seatNumber = oSeat.seatNumber != 0 ? oSeat.seatNumber : seat.seatNumber;
                        seat.Row = oSeat.Row != null ? oSeat.Row : seat.Row;
                        seat.screenID = oSeat.screenID != 0 ? oSeat.screenID : seat.screenID;
                        seat.status = oSeat.status != null ? oSeat.status : seat.status;
                        seat.price = oSeat.price != 0 ? oSeat.price : seat.price;
                        movieE.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteSeatByIdS(string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int sId = Convert.ToInt32(id);
                    seat sO = new seat();
                    var c = (from s in db.seats
                             where s.seatID == sId
                             select s).First();
                    db.seats.Remove(c);
                    db.SaveChanges();
                    return true;


                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Timeslot Model
        public List<TimeslotModel> GetTimeS()
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                return (from t in db.timeslots
                        select new TimeslotModel { timeslotID = t.timeslotID, timeslotDisc = t.timeslotDisc }).ToList();
            }
        }
        public List<TimeslotModel> GetTimeByIDS(string id)
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                int mId = Convert.ToInt32(id);
                return (from t in db.timeslots
                        where t.timeslotID == mId
                        select new TimeslotModel { timeslotID = t.timeslotID, timeslotDisc = t.timeslotDisc }).ToList();
            }
        }
        public bool PostTimeS(timeslot oTime)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    movieE.timeslots.Add(oTime);
                    movieE.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateTimeS(timeslot oTime, string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {

                    int mId = Convert.ToInt32(id);
                    var time = movieE.timeslots.FirstOrDefault(m => m.timeslotID == mId);
                    if (time == null)
                    {
                        return false;
                    }
                    else
                    {
                        time.timeslotDisc = oTime.timeslotDisc != null ? oTime.timeslotDisc : oTime.timeslotDisc;
                        movieE.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteTimeByIdS(string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int sId = Convert.ToInt32(id);
                    timeslot sO = new timeslot();
                    var c = (from t in db.timeslots
                             where t.timeslotID == sId
                             select t).First();
                    db.timeslots.Remove(c);
                    db.SaveChanges();
                    return true;


                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Rest Service 

        // Movie Model
        public List<MovieModel> GetMovie()
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                return (from m in db.movies
                        join s in db.screens on m.screenID equals s.screenID
                        join t in db.timeslots on m.timeslotID equals t.timeslotID
                        select new MovieModel { movieName = m.movieName, language = m.language, status = m.status, screenName = s.screenName, timeslotDisc = t.timeslotDisc }).ToList();

            }
        }

        public List<MovieModel> GetMovieById(string id)
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                int mId = Convert.ToInt32(id);
                return (from m in db.movies
                        join s in db.screens on m.screenID equals s.screenID
                        join t in db.timeslots on m.timeslotID equals t.timeslotID
                        where m.movieID == mId
                        select new MovieModel { movieName = m.movieName, language = m.language, status = m.status, screenName = s.screenName, timeslotDisc = t.timeslotDisc }).ToList();

            }
        }
        public bool PostMovie(movie oMovie)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {

                    movieE.movies.Add(oMovie);
                    movieE.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateMovie(movie oMovie, string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int mId = Convert.ToInt32(id);
                    var movie = movieE.movies.FirstOrDefault(m => m.movieID == mId);
                    if (movie == null)
                    {
                        return false;
                    }
                    else
                    {
                        movie.movieName = oMovie.movieName != null ? oMovie.movieName : movie.movieName;
                        movie.language = oMovie.language != null ? oMovie.language : movie.language;
                        movie.date = oMovie.date != null ? oMovie.date : movie.date;
                        movie.status = oMovie.status != null ? oMovie.status : movie.status;
                        movie.screenID = oMovie.screenID != null ? oMovie.screenID : movie.screenID;
                        movie.timeslotID = oMovie.timeslotID != null ? oMovie.timeslotID : movie.timeslotID;
                        movieE.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteMovieById(string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int mId = Convert.ToInt32(id);
                    movie mO = new movie();
                    var c = (from m in db.movies
                             where m.movieID == mId
                             select m).First();
                    db.movies.Remove(c);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Screen Model
        public List<ScreenModel> GetScreen()
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                return (from scr in db.screens
                        select new ScreenModel { screenID = scr.screenID, screenName = scr.screenName }).ToList();
            }
        }
        public List<ScreenModel> GetScreenByID(string id)
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                int mId = Convert.ToInt32(id);
                return (from scr in db.screens
                        where scr.screenID == mId
                        select new ScreenModel { screenID = scr.screenID, screenName = scr.screenName }).ToList();
            }
        }
        public bool PostScreen(screen oScreen)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    movieE.screens.Add(oScreen);
                    movieE.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateScreen(screen oScreen, string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {

                    int mId = Convert.ToInt32(id);
                    var screen = movieE.screens.FirstOrDefault(m => m.screenID == mId);
                    if (screen == null)
                    {
                        return false;
                    }
                    else
                    {
                        screen.screenName = oScreen.screenName != null ? oScreen.screenName : screen.screenName;
                        movieE.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteScreenById(string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int sId = Convert.ToInt32(id);
                    screen sO = new screen();
                    var c = (from s in db.screens
                             where s.screenID == sId
                             select s).First();
                    db.screens.Remove(c);
                    db.SaveChanges();
                    return true;


                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        //Seat Model
        public List<SeatModel> GetSeat()
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                return (from a in db.seats
                        select new SeatModel { seatID = a.seatID, seatNumber = a.seatNumber, Row = a.Row, status = a.status, price = a.price, screenID = a.screenID }).ToList();

            }
        }

        public List<SeatModel> GetSeatById(string id)
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                int mId = Convert.ToInt32(id);
                return (from a in db.seats
                        where a.seatID == mId
                        select new SeatModel { seatID = a.seatID, seatNumber = a.seatNumber, Row = a.Row, status = a.status, price = a.price, screenID = a.screenID }).ToList();
            }
        }
        public bool PostSeat(seat oSeat)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    movieE.seats.Add(oSeat);
                    movieE.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateSeat(seat oSeat, string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {

                    int mId = Convert.ToInt32(id);
                    var seat = movieE.seats.FirstOrDefault(m => m.seatID == mId);
                    if (seat == null)
                    {
                        return false;
                    }
                    else
                    {
                        seat.seatNumber = oSeat.seatNumber != 0 ? oSeat.seatNumber : seat.seatNumber;
                        seat.Row = oSeat.Row != null ? oSeat.Row : seat.Row;
                        seat.screenID = oSeat.screenID != 0 ? oSeat.screenID : seat.screenID;
                        seat.status = oSeat.status != null ? oSeat.status : seat.status;
                        seat.price = oSeat.price != 0 ? oSeat.price : seat.price;
                        movieE.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteSeatById(string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int sId = Convert.ToInt32(id);
                    seat sO = new seat();
                    var c = (from s in db.seats
                             where s.seatID == sId
                             select s).First();
                    db.seats.Remove(c);
                    db.SaveChanges();
                    return true;


                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Timeslot Model
        public List<TimeslotModel> GetTime()
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                return (from t in db.timeslots
                        select new TimeslotModel { timeslotID = t.timeslotID, timeslotDisc = t.timeslotDisc }).ToList();
            }
        }
        public List<TimeslotModel> GetTimeByID(string id)
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                int mId = Convert.ToInt32(id);
                return (from t in db.timeslots
                        where t.timeslotID == mId
                        select new TimeslotModel { timeslotID = t.timeslotID, timeslotDisc = t.timeslotDisc }).ToList();
            }
        }
        public bool PostTime(timeslot oTime)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    movieE.timeslots.Add(oTime);
                    movieE.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateTime(timeslot oTime, string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {

                    int mId = Convert.ToInt32(id);
                    var time = movieE.timeslots.FirstOrDefault(m => m.timeslotID == mId);
                    if (time == null)
                    {
                        return false;
                    }
                    else
                    {
                        time.timeslotDisc = oTime.timeslotDisc != null ? oTime.timeslotDisc : oTime.timeslotDisc;
                        movieE.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteTimeById(string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int sId = Convert.ToInt32(id);
                    timeslot sO = new timeslot();
                    var c = (from t in db.timeslots
                             where t.timeslotID == sId
                             select t).First();
                    db.timeslots.Remove(c);
                    db.SaveChanges();
                    return true;


                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Booking Model
        public List<BookingModel> GetBooking()
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                return (from m in db.bookings
                        //join s in db.screens on m.screenID equals s.screenID
                        //join t in db.timeslots on m.timeslotID equals t.timeslotID
                        select new BookingModel {bookingID=m.bookingID, bookPersonname = m.bookPersonname, bookingDate = m.bookingDate, seatid = m.seatid, movieid = m.movieid, paymentStatusID = m.paymentStatusID }).ToList();

            }
        }

        public List<BookingModel> GetBookingById(string id)
        {
            using (mtb_dbEntities movieE = new mtb_dbEntities())
            {
                int mId = Convert.ToInt32(id);
                return (from m in db.bookings
                        //join s in db.screens on m.screenID equals s.screenID
                        //join t in db.timeslots on m.timeslotID equals t.timeslotID
                        where m.bookingID == mId
                        select new BookingModel { bookingID = m.bookingID, bookPersonname = m.bookPersonname, bookingDate = m.bookingDate, seatid = m.seatid, movieid = m.movieid, paymentStatusID = m.paymentStatusID }).ToList();

            }
        }
        public bool PostBooking(booking oBooking)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {

                    movieE.bookings.Add(oBooking);
                    movieE.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateBooking(booking oBooking, string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int mId = Convert.ToInt32(id);
                    var booking = movieE.bookings.FirstOrDefault(m => m.bookingID == mId);
                    if (booking == null)
                    {
                        return false;
                    }
                    else
                    {
                        booking.bookingID = oBooking.bookingID != 0 ? oBooking.bookingID : booking.bookingID;
                        booking.bookPersonname = oBooking.bookPersonname != null ? oBooking.bookPersonname : booking.bookPersonname;
                        booking.bookingDate = oBooking.bookingDate != null ? oBooking.bookingDate : booking.bookingDate;
                        booking.seatid = oBooking.seatid != 0 ? oBooking.seatid : booking.seatid;
                        booking.movieid = oBooking.movieid != 0 ? oBooking.movieid : booking.movieid;
                        booking.paymentStatusID = oBooking.paymentStatusID != null ? oBooking.paymentStatusID : booking.paymentStatusID;                        
                        movieE.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteBookingById(string id)
        {
            try
            {
                using (mtb_dbEntities movieE = new mtb_dbEntities())
                {
                    int mId = Convert.ToInt32(id);
                    booking bO = new booking();
                    var c = (from m in db.bookings
                             where m.bookingID == mId
                             select m).First();
                    db.bookings.Remove(c);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TimeslotModel> GetTimeById(string id)
        {
            throw new NotImplementedException();
        }
    }
}