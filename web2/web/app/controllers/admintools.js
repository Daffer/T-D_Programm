var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Admin = mongoose.model('Admin');
var Users = mongoose.model('User');

module.exports = function (app) 
{
  app.use('/', router);
};

/*module.exports = function (app)
{
  app.use('/admintools', router);
};*/

/*router.get('/', function (req, res, next) {
  Admin.find(function (err, cars) {
    if (err) 
      return next(err);
    res.render('index', {
      title: 'Generator-Express M',
      articles: cars
    });
  });
});
*/

/*router.get('/admintools', function (req, res, next) {
    res.render('admintools', {
      title: 'Admin page',
      log: cookies["login"],
      pwd: cookies["password"]
    });
    Users.find({login: log, password:pwd}, result);
});*/
router.get('/admintools', function (req, res, next) {
  Users.find(function (err, usrs){
    res.render('admintools', {
      title: 'Has users',
      users: usrs
    });
    for (i = 0; i < usrs.length; i++)
      console.log(usrs[i]);
  });
  /*Admin.find(function (err, cars) {
    if (err) 
      return next(err);
    res.render('admintools', {
      title: 'Generator-Express MVC',
      articles: cars
    });
  });*/
});