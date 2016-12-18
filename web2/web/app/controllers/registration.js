var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Users = mongoose.model('User');
var UserManager = require('../models/userstools');

module.exports = function (app) 
{
  app.use('/', router);
};

var currentstatename = true;
var currentstatesurname = true;
var currentstatesex = true;
var currentstatepwd = 0;
var currentstatelogin = 0;

var clear = function()
{
    currentstatepwd = 0;
    currentstatelogin = 0;
    currentstatesex = true;
    currentstatesurname = true;
    currentstatename = true;
}

router.get('/reg', function (req, res, next) {
    if (req.session.IsAuthorized == true)
        res.redirect("/");
    res.render('register', {
      title: 'registration',
      correctname: currentstatename,
      correctsurname: currentstatesurname,
      correctsex: currentstatesex,
      correctpwd: currentstatepwd,
      correctlog: currentstatelogin,
      logined: false,
      role: "ghost",
      name: "error"
    });
});

router.post('/reg',function(req,res,next)
{
        console.log("get post registration");
        clear();
        var name = req.body.FirstName;
        console.log(name);
        if (typeof(name) == undefined || typeof(name) == String && name.length == 0)
        {
            currentstatename = false;
            console.log("incorrectname");
        }
        var surname = req.body.SurName;
        console.log(surname);
        if (typeof(surname) == undefined || typeof(surname) == String && surname.length == 0)
        {
            currentstatesurname = false;
            console.log("incorrectsurname");
        }
        var secondname = req.body.SecondName;
        var sex = req.body.Sex;
        if (typeof(sex) == undefined || typeof(sex) == String && sex.length == 0)
        {
            currentstatesex = false;
            console.log("incorrectsex");
        }
        var log = req.body.Login;
        if (typeof(log) == undefined || typeof(log) == String && name.length == 0)
        {
            currentstatelogin = 1;
            console.log("login is empty");
        }
        Users.findOne({'Login':log}, function(err, user){
            if (user == null)
            {
                console.log("users not found");
                currentstatelogin = 0;
            }
            else
            {
                console.log("exists user");
                currentstatelogin = 2;
            }
            console.log(currentstatelogin);
            var pwd1 = req.body.mainpassword;
            var pwd2 = req.body.verpassword;
            console.log(pwd1 + " "+pwd2);
            if (typeof(pwd1) == undefined || typeof(pwd2) == String && name.length == 0)
            {
                currentstatepwd = 1;
            }
            else if (pwd1 != pwd2)
            {
                currentstatepwd = 2;
            }
            var date = req.body.date;
            if ((currentstatepwd == 0) && (currentstatesex == true) &&
                (currentstatesurname == true) && (currentstatelogin == 0) && (currentstatename == true))
            {
                 user = new Users({
                    FirstName: name,
                    SurName: surname,
                    SecondName: secondname,
                    Sex: sex,
                    DateOfBirth: date,
                    Login: log,
                    Password: pwd1,
                    Discount: 0,
                    Role: "User"
                });
                req.session.UserName = name;
                req.session.IsAuthorized = true;
                req.session.UserRole = "User";
                console.log("save");
                UserManager.AddUser(user);
                console.log("cookie");
                res.cookie("login",log);
                res.cookie("password",pwd1);
                console.log("redirect");
                res.redirect('/buycar');
            }
            else
                res.redirect("/reg");
        });
});
