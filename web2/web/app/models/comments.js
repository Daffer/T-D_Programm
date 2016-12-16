var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var CommentSchema = new Schema({
  title: String,
  image: String,
  text: String
});

mongoose.model('Comment', CommentSchema);