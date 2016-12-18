var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Users = mongoose.model('User');
var Cars = mongoose.model('Car');
var CarManager = require('../models/car');

module.exports = function (app) 
{
  app.use('/buycar', router);
};

router.get('/', function (req, res, next) {
 
  Cars.find(function (err, findcars) 
  {
    if (err) 
      return next(err);
    count = findcars.length;
    res.render('buycar', {
      title: 'Buy car page',
      car: findcars[0],
      countcars: count
    });
  });
});

router.get('/cars/json',function (req, res, next)
{
  console.log("get cars");
  Cars.find(function (err, findcars)
  {
      res.status(200).send(200,{cars:findcars});
  });
});

router.get('/setcar',function(req, res, next)
{
    /*var car = new Cars({
                    Name: 'Nissan Maxima',
                    Producer: 'Japan',
                    CreationYear: 2015,
                    Price: 1000,
                    Image: 'img/car-image1.jpg'
                });
    car.save(function(err)
        {
            if (err)
                console.log("Error to save new car");
            else
                console.log("Car :" + car.Name + "was saved");
        });*/
  Cars.find(function(err, car)
  {
    console.log(car);
  });
  res.redirect("/buycar");
});

// nissan maxima lada 2106 mercedes amg gt