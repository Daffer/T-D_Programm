var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Admin = mongoose.model('Admin');

module.exports = function (app) 
{
  app.use('/', router);
};

module.exports = function (app)
{
  app.use('/Admin', router);
};

router.get('/', function (req, res, next) {
  Admin.find(function (err, cars) {
    if (err) 
      return next(err);
    res.render('index', {
      title: 'Generator-Express MVC 2',
      articles: cars
    });
  });
});