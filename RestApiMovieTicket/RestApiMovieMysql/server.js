var express  = require('express'),
    path     = require('path'),
    bodyParser = require('body-parser'),
    app = express(),
    expressValidator = require('express-validator');

    var http = require('http');
    var connect = require('connect');
    
  //  var app = connect();
/*Set EJS template Engine*/
app.set('views','./views');
app.set('view engine','ejs');

app.use(express.static(path.join(__dirname, 'public')));
app.use(bodyParser.urlencoded({ extended: true })); //support x-www-form-urlencoded
app.use(bodyParser.json());
app.use(expressValidator());

/*MySql connection*/
var connection  = require('express-myconnection'),
    mysql = require('mysql');

app.use(

    connection(mysql,{
        host     : 'localhost',
        user     : 'root',
        password : 'pwd2017*',
        database : 'mtb_db',
        debug    : false //set true if you wanna see debug logger
    },'request')

);

//movie 
//GET call for movie
app.get('/',function(req,res){
    res.send('Welcome');
});

app.get('/movie',function(req,res,next){


    req.getConnection(function(err,conn){
        
        if (err) return next("Cannot Connect");

        var query = conn.query('SELECT * FROM movie m left join screen s on  m.screenID =s.screenID left join timeslot t on m.timeslotID = t.timeslotID',function(err,rows){

            if(err){
                console.log(err);
                return next("Mysql error, check your query");
            }

            res.render('Movie',{title:"RESTful Crud Example",data:rows});

         });

    });

});

app.get('/movie/:id',function(req,res,next){

    req.getConnection(function(err,conn){
        var movieID = req.params.id;
        if (err) return next("Cannot Connect");

        var query = conn.query('SELECT * FROM movie m left join screen s on  m.screenID =s.screenID left join timeslot t on m.timeslotID = t.timeslotID where movieid=' + movieID ,function(err,rows){

            if(err){
                console.log(err);
                return next("Mysql error, check your query");
            }

            res.render('movieEdit',{title:"RESTful Crud Example",data:rows});

         });

    });

});
//POST call for movie
app.post('/movie',function(req,res,next){

    //get data
    var data = {
        movieName:req.body.movieName,
        language:req.body.language,
        status:req.body.status,
        date:req.body.date,
        screenID:req.body.screenID,
        timeslotID:req.body.timeslotID
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");
    
        var query = conn.query("INSERT INTO movie ( movieName, language, status, date, screenID, timeslotID) values ('"+ data.movieName +"','"+ data.language +"','"+ data.status +"','"+ data.date +"','"+ data.screenID +"','"+ data.timeslotID +"')", function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query" + err);
           }

          res.sendStatus(200);

        });

     });

});

//PUT call for movie
//update data
app.put('/movie',function(req,res,next){
   
    //get data
    var data = {
        movieName:req.body.movieName,
        language:req.body.language,
        status:req.body.status,
        date:req.body.date,
        screenID:req.body.screenID,
        timeslotID:req.body.timeslotID
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");

        var query = conn.query("UPDATE movie WHERE movieID = 2 ",[data,user_id], function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query");
           }

          res.sendStatus(200);

        });

     });

});

//DELETE call for movie
//delete data
app.delete('/movie',function(req,res,next){

    var user_id = req.params.user_id;

     req.getConnection(function (err, conn) {

        if (err) return next("Cannot Connect");

        var query = conn.query("DELETE FROM movie  WHERE movieID = 1 ",[user_id], function(err, rows){

             if(err){
                console.log(err);
                return next("Mysql error, check your query");
             }

             res.sendStatus(200);

        });
        //console.log(query.sql);

     });
});

//booking
// GET call for booking
app.get('/booking',function(req,res,next){

    req.getConnection(function(err,conn){
        
        if (err) return next("Cannot Connect");

        var query = conn.query('SELECT * FROM booking',function(err,rows){

            if(err){
                console.log(err);
                return next("Mysql error, check your query");
            }

            res.render('user',{title:"RESTful Crud Example",data:rows});

         });
    });
});

// POST call for booking
app.post('/booking',function(req,res,next){

    //get data
    var data = {
        bookingID:req.body.bookingID,
        bookPersonname:req.body.bookPersonname,
        bookingDate:req.body.bookingDate,
        seatid:req.body.seatid,
        movieid:req.body.movieid,
        paymentStatusID:req.body.paymentStatusID
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");

        var query = conn.query("INSERT INTO booking ( bookingID, bookPersonname, bookingDate, seatid, movieid, paymentStatusID) values ('"+ data.bookingID +"','"+ data.bookPersonname +"','"+ data.bookingDate +"','"+ data.seatid +"','"+ data.movieid +"','"+ data.paymentStatusID +"')",data, function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query" + err);
           }

          res.sendStatus(200);

        });

     });

});

//PUT call for booking
//update data
app.put('/booking',function(req,res,next){
   
    //get data
    var data = {
        bookingID:req.body.bookingID,
        bookPersonname:req.body.bookPersonname,
        bookingDate:req.body.bookingDate,
        seatid:req.body.seatid,
        movieid:req.body.movieid,
        paymentStatusID:req.body.paymentStatusID
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");

        var query = conn.query("UPDATE booking WHERE movieID = 2 ",[data,user_id], function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query");
           }

          res.sendStatus(200);

        });

     });

});

//DELETE call for booking
//delete data
app.delete('/booking',function(req,res,next){

    var user_id = req.params.user_id;

     req.getConnection(function (err, conn) {

        if (err) return next("Cannot Connect");

        var query = conn.query("DELETE FROM booking  WHERE movieID = 1 ",[user_id], function(err, rows){

             if(err){
                console.log(err);
                return next("Mysql error, check your query");
             }

             res.sendStatus(200);

        });
        //console.log(query.sql);

     });
});

//seats
// GET call for seats
app.get('/seats',function(req,res,next){

    req.getConnection(function(err,conn){
        
        if (err) return next("Cannot Connect");

        var query = conn.query('SELECT * FROM seats',function(err,rows){

            if(err){
                console.log(err);
                return next("Mysql error, check your query");
            }

            res.render('user',{title:"RESTful Crud Example",data:rows});

         });
    });
});

// POST call for seats
app.post('/seats',function(req,res,next){

    //get data
    var data = {
        seatID:req.body.seatID,
        seatNumber:req.body.seatNumber,
        Row:req.body.Row,
        screenID:req.body.screenID,
        status:req.body.status,
        price:req.body.price
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");

        var query = conn.query("INSERT INTO seats ( seatID, seatNumber, Row, screenID, status, price) values ('"+ data.seatID +"','"+ data.seatNumber +"','"+ data.Row +"','"+ data.screenID +"','"+ data.status +"','"+ data.price +"')",data, function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query" + err);
           }

          res.sendStatus(200);

        });

     });

});

//PUT call for seats
//update data
app.put('/seats',function(req,res,next){
   
    //get data
    var data = {
        seatID:req.body.seatID,
        seatNumber:req.body.seatNumber,
        Row:req.body.Row,
        screenID:req.body.screenID,
        status:req.body.status,
        price:req.body.price
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");

        var query = conn.query("UPDATE seats WHERE movieID = 2 ",[data,user_id], function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query");
           }

          res.sendStatus(200);

        });

     });

});

//DELETE call for seats
//delete data
app.delete('/seats',function(req,res,next){

    var user_id = req.params.user_id;

     req.getConnection(function (err, conn) {

        if (err) return next("Cannot Connect");

        var query = conn.query("DELETE FROM seats  WHERE movieID = 1 ",[user_id], function(err, rows){

             if(err){
                console.log(err);
                return next("Mysql error, check your query");
             }

             res.sendStatus(200);

        });
        //console.log(query.sql);

     });
});

//screen
// GET call for screen
app.get('/screen',function(req,res,next){

    req.getConnection(function(err,conn){
        
        if (err) return next("Cannot Connect");

        var query = conn.query('SELECT * FROM screen',function(err,rows){

            if(err){
                console.log(err);
                return next("Mysql error, check your query");
            }

            res.render('screen',{title:"RESTful Crud Example",data:rows});

         });
    });
});

// POST call for screen
app.post('/screen',function(req,res,next){

    //get data
    var data = {
        screenID:req.body.screenID,
        screenName:req.body.screenName
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");

        var query = conn.query("INSERT INTO screen ( screenID, screenName) values ('"+ data.screenID +"','"+ data.screenName +"')",data, function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query" + err);
           }

          res.sendStatus(200);

        });

     });

});

//PUT call for screen
//update data
app.put('/screen',function(req,res,next){
   
    //get data
    var data = {
        screenID:req.body.screenID,
        screenName:req.body.screenName
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");

        var query = conn.query("UPDATE screen WHERE movieID = 2 ",[data,user_id], function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query");
           }

          res.sendStatus(200);

        });

     });

});

//DELETE call for screen
//delete data
app.delete('/screen',function(req,res,next){

    var user_id = req.params.user_id;

     req.getConnection(function (err, conn) {

        if (err) return next("Cannot Connect");

        var query = conn.query("DELETE FROM screen  WHERE movieID = 1 ",[user_id], function(err, rows){

             if(err){
                console.log(err);
                return next("Mysql error, check your query");
             }

             res.sendStatus(200);

        });
        //console.log(query.sql);

     });
});

//timeslot
// GET call for timeslot
app.get('/timeslot',function(req,res,next){

    req.getConnection(function(err,conn){
        
        if (err) return next("Cannot Connect");

        var query = conn.query('SELECT * FROM timeslot',function(err,rows){

            if(err){
                console.log(err);
                return next("Mysql error, check your query");
            }

            res.render('user',{title:"RESTful Crud Example",data:rows});

         });
    });
});

// POST call for timeslot
app.post('/timeslot',function(req,res,next){

    //get data
    var data = {
        timeslotID:req.body.timeslotID,
        timeslotDisc:req.body.timeslotDisc
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");

        var query = conn.query("INSERT INTO timeslot ( timeslotID, timeslotDisc) values ('"+ data.timeslotID +"','"+ data.timeslotDisc +"')",data, function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query" + err);
           }

          res.sendStatus(200);

        });

     });

});




//RESTful route
var router = express.Router();


/*------------------------------------------------------
*  This is router middleware,invoked everytime
*  we hit url /api and anything after /api
*  like /api/user , /api/user/7
*  we can use this for doing validation,authetication
*  for every route started with /api
--------------------------------------------------------*/
router.use(function(req, res, next) {
    console.log(req.method, req.url);
    next();
});

//var app = router.route('/movie');


//now we need to apply our router here
app.use('/api', router);

//start Server
var server = app.listen(3000,function(){

   console.log("Listening to port %s",server.address().port);

});


//PUT call for timeslot
//update data
app.put('/timeslot',function(req,res,next){
   
    //get data
    var data = {
        timeslotID:req.body.timeslotID,
        timeslotDisc:req.body.timeslotDisc
     };

    //inserting into mysql
    req.getConnection(function (err, conn){

        if (err) return next("Cannot Connect");

        var query = conn.query("UPDATE timeslot WHERE movieID = 2 ",[data,user_id], function(err, rows){

           if(err){
                console.log(err);
                return next("Mysql error, check your query");
           }

          res.sendStatus(200);

        });

     });

});

//DELETE call for timeslot
//delete data
app.delete('/timeslot',function(req,res,next){

    var user_id = req.params.user_id;

     req.getConnection(function (err, conn) {

        if (err) return next("Cannot Connect");

        var query = conn.query("DELETE FROM timeslot  WHERE movieID = 1 ",[user_id], function(err, rows){

             if(err){
                console.log(err);
                return next("Mysql error, check your query");
             }

             res.sendStatus(200);

        });
        //console.log(query.sql);

     });
});

