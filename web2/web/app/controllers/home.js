var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Cars = mongoose.model('Car');
var Users = mongoose.model('User');

module.exports = function (app) 
{
  app.use('/', router);
};

router.get('/', function (req, res, next) {
  Cars.find(function (err, cars) {
    if (err) 
      return next(err);
    res.render('index', {
      title: 'Generator-Express MVC 2',
      articles: cars
    });
  });
});
