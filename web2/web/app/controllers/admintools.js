var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Users = mongoose.model('User');

module.exports = function (app) 
{
  app.use('/', router);
};

router.get('/admintools', function (req, res, next) {
  console.log("get");
  var username = req.session.UserName;
  var userrole = req.session.UserRole;
  if (req.session.IsAuthorized == undefined || req.session.IsAuthorized == false)
  {
      res.redirect("/");
  }
  if (userrole == undefined || userrole != "Admin")
  {
      res.redirect("/");
  }
  Users.find(function (err, usrs){
    res.render('admintools', {
      title: 'Has users',
      users: usrs,
      logined: true,
      name: username,
      role: userrole
    });
    for (i = 0; i < usrs.length; i++)
      console.log(usrs[i]);
  });
});