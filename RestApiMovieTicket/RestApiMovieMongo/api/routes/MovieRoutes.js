'use strict';
module.exports = function(app) {
  var Movie = require('../controllers/MovieController');

  // Movie Routes
  app.route('/movie')
    .get(Movie.list_all_tasks)
    .post(Movie.create_a_task);

  app.route('/movie/:Theatre_list')
    .get(Movie.list_all_tasks)
    .put(Movie.update_a_task);


  app.route('/movie/:movieId')
    .get(Movie.read_a_task)
    .put(Movie.update_a_task)
    .delete(Movie.delete_a_task);

  app.route('/movie/:Seats_available')
    .get(Movie.read_a_task)
    .put(Movie.update_a_task)
    
};