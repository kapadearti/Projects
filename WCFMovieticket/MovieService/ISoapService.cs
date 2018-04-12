using MovieDataLayer;
using MovieService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MovieService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISoapService
    {
        //Movie Model
        [OperationContract]
        List<MovieModel> GetMovieS();
        [OperationContract]
        List<MovieModel> GetMovieByIdS(string id);
        [OperationContract]
        string PostMovieS(movie oMovie);
        [OperationContract]
        bool UpdateMovieS(movie oMovie, string id);
        [OperationContract]
        bool DeleteMovieByIdS(string id);

        //Screen Model
        [OperationContract]
        List<ScreenModel> GetScreenS();
        [OperationContract]
        List<ScreenModel> GetScreenByIDS(string id);
        [OperationContract]
        bool PostScreenS(screen oScreen);
        [OperationContract]
        bool UpdateScreenS(screen oScreen, string id);
        [OperationContract]
        bool DeleteScreenByIdS(string id);

        //Seats
        [OperationContract]
        List<SeatModel> GetSeatS();
        [OperationContract]
        List<SeatModel> GetSeatByIdS(string id);
        [OperationContract]
        bool PostSeatS(seat oSeat);
        [OperationContract]
        bool UpdateSeatS(seat oSeat, string id);
        [OperationContract]
        bool DeleteSeatByIdS(string id);

        //Timeslots
        [OperationContract]
        List<TimeslotModel> GetTimeS();
        [OperationContract]
        List<TimeslotModel> GetTimeByIDS(string id);
        [OperationContract]
        bool PostTimeS(timeslot oTime);
        [OperationContract]
        bool UpdateTimeS(timeslot oTime, string id);
        [OperationContract]
        bool DeleteTimeByIdS(string id);

        //Booking

    }

}
