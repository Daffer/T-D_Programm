var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Users = mongoose.model('User');

module.exports = function (app) 
{
  app.use('/', router);
};

router.get('/admintools', function (req, res, next) {
  
  Users.find(function (err, usrs){
    res.render('admintools', {
      title: 'Has users',
      users: usrs
    });
    for (i = 0; i < usrs.length; i++)
      console.log(usrs[i]);
  });
});