'use strict';


/*var mongoose = require('mongoose'),
  Task = mongoose.model('Tasks');

exports.list_all_tasks = function(req, res) {
  Task.find({}, function(err, task) {
    if (err)
      res.send(err);
    res.json(task);
  });
};*/

var mongoose = require('mongoose'),
  Movie = mongoose.model('Movies');

exports.list_all_tasks = function(req, res) {
  Movie.find({}, function(err, movie) {
    if (err)
      res.send(err);
    res.json(movie);
  });
};




/*exports.create_a_task = function(req, res) {
  var new_task = new Task(req.body);
  new_task.save(function(err, task) {
    if (err)
      res.send(err);
    res.json(task);
  });
};*/

exports.create_a_task = function(req, res) {
  var new_task = new Movie(req.body);
  new_task.save(function(err, movie) {
    if (err)
      res.send(err);
    res.json(movie);
  });
};


/*exports.read_a_task = function(req, res) {
  Task.findById(req.params.taskId, function(err, task) {
    if (err)
      res.send(err);
    res.json(task);
  });
};*/

exports.read_a_task = function(req, res) {
  Movie.findById(req.params.movieId, function(err, movie) {
    if (err)
      res.send(err);
    res.json(movie);
  });
};


/*exports.update_a_task = function(req, res) {
  Task.findOneAndUpdate({_id: req.params.taskId}, req.body, {new: true}, function(err, task) {
    if (err)
      res.send(err);
    res.json(task);
  });
};*/

exports.update_a_task = function(req, res) {
  Movie.findOneAndUpdate({_id: req.params.movieId}, req.body, {new: true}, function(err, movie) {
    if (err)
      res.send(err);
    res.json(movie);
  });
};



/*exports.delete_a_task = function(req, res) {
  Task.remove({
    _id: req.params.taskId
  }, function(err, task) {
    if (err)
      res.send(err);
    res.json({ message: 'Task successfully deleted' });
  });
};*/

exports.delete_a_task = function(req, res) {
  Movie.remove({
    _id: req.params.movieId
  }, function(err, movie) {
    if (err)
      res.send(err);
    res.json({ message: 'Movie successfully deleted' });
  });
};

