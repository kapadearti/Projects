'use strict';
var mongoose = require('mongoose');
var Schema = mongoose.Schema;


var MovieSchema = new Schema({
  name: {
    type: String,
    required: 'Kindly enter the name of the Movie'
  },
  Language:{
    type: [{
    type: String,
    enum: ['English', 'Deutsch', 'French']
  }],
  default: ['Deutsch']
},
  MovieAdd_date: {
    type: Date,
    default: Date.now
  },
  MovieRelease_date: {
    type: Date,
    default: Date.now
  },
  status: {
      type: String,
      enum: ['Now Showing', 'Coming Soon', 'Exclusive'],
      required: 'Kindly enter the status for this Movie as |Now Showing|Coming Soon|Exclusive'
    },
 Seats_available: {
      type: Number,
      default: Number.now 
  },
  Theatre_list: {
    type: [{
    type: String,
    enum: ['PVR', 'Inox', 'Cinepolis'],
    required: 'Enter the name of the theatre you wish to watch in'
    }]
}
  
});

module.exports = mongoose.model('Movies', MovieSchema);

