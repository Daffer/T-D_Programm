var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Users = mongoose.model('User');

var logined = false;
module.exports = function (app) 
{
  app.use('/', router);
};

router.get('/login', function (req, res, next) {
    res.render('login', {
      title: 'logined',
      logined: logined,
      log: req.cookies["login"],
      pwd: req.cookies["password"]
    });
});

router.post('/login',function(req,res,next)
{
    console.log("get post");
    var log = req.body.login;
    var pwd = req.body.password;
    var result = undefined;
    Users.find({login: log, password:pwd}, result);
    result = {
        FirstName: 'Vasya',
        LastName: 'Pupkin',
        Role: 'Admin'
    }
    console.log(log + pwd + result);
    switch (result.Role) {
        case ('User'):
            res.redirect('/');
            break;
        case ('Admin'):
            res.redirect('/admintools');
            break;
        case (undefined):
            console.log('undefined error');
            break;
        default:
            console.log('exception');
            break;
    }
    /*if (result == undefined)
    {
        console.log(result);
        res.redirect('/login');
    }*/
    res.redirect('/');
});
