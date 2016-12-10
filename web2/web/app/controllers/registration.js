var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Users = mongoose.model('User');

var logined = false;
module.exports = function (app) 
{
  app.use('/', router);
};

var currentstatename = true;
var currentstatesurname = true;
var currentstatesex = true;
var currentstatepwd = 0;
var currentstatelogin = 0;

var clear = new function()
{
    currentstatepwd = 0;
    currentstatelogin = 0;
    currentstatesex = true;
    currentstatesurname = true;
    currentstatename = true;
}

router.get('/reg', function (req, res, next) {
    res.render('register', {
      title: 'registration',
      correctname: currentstatename,
      correctsurname: currentstatesurname,
      correctsex: currentstatesex,
      correctpwd: currentstatepwd,
      correctlog: currentstatelogin
    });
});

router.post('/reg',function(req,res,next)
{
    Users.findOne({login: 'log'}, function(err, user)
    {
        console.log("get post registration");
        clear();
        var name = req.body.name;
        if (typeof(name) == undefined)
        {
            correctname = false;
            console.log("incorrectname");
        }
        var surname = req.body.surname;
        if (typeof(name) == undefined)
        {
            correctsurname = false;
            console.log("incorrectsurname");
        }
        var secondname = req.body.secondname;
        var log = req.body.login;
        if (typeof(log) == undefined)
        {
            correctlog = 1;
            console.log("login is empty");
        }
        Users.findOne({'Login':log}, function(err, user){
            if (log == user.Login)
                currentstatelogin = 2;
        });
        var pwd1 = req.body.mainpassword;
        var pwd2 = req.body.verpassword;
        if (typeof(pwd1) == undefined)
        {
            currentstatepwd = 1;
        }
        else if (pwd1 == pwd2)
        {
            
        }


    });
    
    // Users.find({login: log, password:pwd}, result);
    // if (result == undefined)
    // {
    //     console.log(result);
    //     res.redirect('/login');
    // }
    res.redirect('/');
});
