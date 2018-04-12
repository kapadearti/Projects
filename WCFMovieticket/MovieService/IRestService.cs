using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieDataLayer;
using MovieService.Model;

namespace MovieService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract(Namespace = "MovieService")]
    public interface IRestService
    {
        //Movie
        [OperationContract]
        [WebGet(UriTemplate = "/Movie", RequestFormat = WebMessageFormat.Json,
                                                      ResponseFormat = WebMessageFormat.Json
                                                      )]
        List<MovieModel> GetMovie();

        [OperationContract]
        [WebGet(UriTemplate = "/Movie/{id}", RequestFormat = WebMessageFormat.Json,
                                                    ResponseFormat = WebMessageFormat.Json
                                                    )]
        List<MovieModel> GetMovieById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Movie", RequestFormat = WebMessageFormat.Json,
                                                      ResponseFormat = WebMessageFormat.Json
                                                   )]
        bool PostMovie(movie oMovie);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Movie/{id}", RequestFormat = WebMessageFormat.Json,
                                                    ResponseFormat = WebMessageFormat.Json
                                                 )]
        bool DeleteMovieById(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Movie/{id}", RequestFormat = WebMessageFormat.Json,
                                                     ResponseFormat = WebMessageFormat.Json
                                                  )]
        bool UpdateMovie(movie oMovie,string id);


        // Screen

        [OperationContract]
        [WebGet(UriTemplate = "/Screen", RequestFormat = WebMessageFormat.Json,
                                                    ResponseFormat = WebMessageFormat.Json
                                                    )]
        List<ScreenModel> GetScreen();

        [OperationContract]
        [WebGet(UriTemplate = "/Screen/{id}", RequestFormat = WebMessageFormat.Json,
                                                    ResponseFormat = WebMessageFormat.Json
                                                    )]
        List<ScreenModel> GetScreenByID(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Screen", RequestFormat = WebMessageFormat.Json,
                                                      ResponseFormat = WebMessageFormat.Json
                                                   )]
        bool PostScreen(screen oScreen);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Screen/{id}", RequestFormat = WebMessageFormat.Json,
                                                     ResponseFormat = WebMessageFormat.Json
                                                  )]
        bool UpdateScreen(screen oScreen, string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Screen/{id}", RequestFormat = WebMessageFormat.Json,
                                                    ResponseFormat = WebMessageFormat.Json
                                                 )]
        bool DeleteScreenById(string id);


        //Seat

        [OperationContract]
        [WebGet(UriTemplate = "/Seat", RequestFormat = WebMessageFormat.Json,
                                                      ResponseFormat = WebMessageFormat.Json
                                                      )]
        List<SeatModel> GetSeat();

        [OperationContract]
        [WebGet(UriTemplate = "/Seat/{id}", RequestFormat = WebMessageFormat.Json,
                                                    ResponseFormat = WebMessageFormat.Json
                                                    )]
        List<SeatModel> GetSeatById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Seat", RequestFormat = WebMessageFormat.Json,
                                                      ResponseFormat = WebMessageFormat.Json
                                                   )]
        bool PostSeat(seat oSeat);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Seat/{id}", RequestFormat = WebMessageFormat.Json,
                                                     ResponseFormat = WebMessageFormat.Json
                                                  )]
        bool UpdateSeat(seat oSeat, string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Seat/{id}", RequestFormat = WebMessageFormat.Json,
                                                   ResponseFormat = WebMessageFormat.Json
                                                )]
        bool DeleteSeatById(string id);

        //Timeslot Model
        [OperationContract]
        [WebGet(UriTemplate = "/Time", RequestFormat = WebMessageFormat.Json,
                                                   ResponseFormat = WebMessageFormat.Json
                                                   )]
        List<TimeslotModel> GetTime();

        [OperationContract]
        [WebGet(UriTemplate = "/Time/{id}", RequestFormat = WebMessageFormat.Json,
                                                    ResponseFormat = WebMessageFormat.Json
                                                    )]
        List<TimeslotModel> GetTimeById(string id);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Time", RequestFormat = WebMessageFormat.Json,
                                                      ResponseFormat = WebMessageFormat.Json
                                                   )]
        bool PostTime(timeslot oTime);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Time/{id}", RequestFormat = WebMessageFormat.Json,
                                                     ResponseFormat = WebMessageFormat.Json
                                                  )]
        bool UpdateTime(timeslot oTime, string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Time/{id}", RequestFormat = WebMessageFormat.Json,
                                                   ResponseFormat = WebMessageFormat.Json
                                                )]
        bool DeleteTimeById(string id);

        //Booking Model
        [OperationContract]
        [WebGet(UriTemplate = "/Booking", RequestFormat = WebMessageFormat.Json,
                                                   ResponseFormat = WebMessageFormat.Json
                                                   )]
        List<BookingModel> GetBooking();

        [OperationContract]
        [WebGet(UriTemplate = "/Booking/{id}", RequestFormat = WebMessageFormat.Json,
                                                    ResponseFormat = WebMessageFormat.Json
                                                    )]
        List<BookingModel> GetBookingById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Booking", RequestFormat = WebMessageFormat.Json,
                                                      ResponseFormat = WebMessageFormat.Json
                                                   )]
        bool PostBooking(booking oBooking);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Booking/{id}", RequestFormat = WebMessageFormat.Json,
                                                     ResponseFormat = WebMessageFormat.Json
                                                  )]
        bool UpdateBooking(booking oBooking, string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Booking/{id}", RequestFormat = WebMessageFormat.Json,
                                                   ResponseFormat = WebMessageFormat.Json
                                                )]
        bool DeleteBookingById(string id);
    }
}
