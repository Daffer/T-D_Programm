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
  /*var vasya = new Users({
    ID: 1,
    FirstName: 'Vasya',    
    SurName: 'Pupkin',     
    SecondName: 'Georgievich',   
    Sex: 'Male',          
    DateOfBirth: '13/03/2015',    
    Login: '1.1@.com',        
    Password: '1',     
    Discount: '50',     
    Role: 'Admin'          
  });

  vasya.save(function (err, data) {
    if (err) console.log(err);
    else console.log('Saved : ', data );
  });

  var kolya = new Users({
    ID: 1,
    FirstName: 'Kolya',    
    SurName: 'Pupkin',     
    SecondName: 'Georgievich',   
    Sex: 'Male',          
    DateOfBirth: '13/03/1915',    
    Login: '2.2@.com',        
    Password: '2',     
    Discount: '50',     
    Role: 'User'          
  });

  kolya.save(function (err, data) {
    if (err) console.log(err);
    else console.log('Saved : ', data );
  });*/
  Cars.find(function (err, cars) {
    if (err) 
      return next(err);
    res.render('index', {
      title: 'Generator-Express MVC 2',
      articles: cars
    });
  });
});
